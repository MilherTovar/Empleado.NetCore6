using EmpleadoApiRest.Abstractions;
using EmpleadoApiRest.Application;
using EmpleadoApiRest.DataAccess;
using EmpleadoApiRest.Repository;
using EmpleadoApiRest.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Base de datos y autenticación.
builder.Services.AddDbContext<ApiDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaulConnection"), b => b.MigrationsAssembly("EmpleadoApiRest.Webapi")));
builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(jwt =>
    {
        var key = Encoding.ASCII.GetBytes(builder.Configuration["JwtConfig:Secret"]);
        jwt.SaveToken = true;
        jwt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience=false,
            RequireExpirationTime=false,
            ValidateLifetime=true
        };
    });
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApiDbContext>();

//Data
builder.Services.AddScoped(typeof(ICompanyRepository<>), typeof(CompanyRepository<>));
builder.Services.AddScoped(typeof(ICompanyApplication<>), typeof(CompanyApplication<>));
builder.Services.AddScoped(typeof(ICompanyDbContext<>), typeof(CompanyDbContext<>));
builder.Services.AddScoped(typeof(IEmpleadoDbContext<>),typeof(EmpleadoDbContext<>));
builder.Services.AddScoped(typeof(IEmpleadoRepository<>),typeof(EmpleadoRepository<>));
builder.Services.AddScoped(typeof(IEmpleadoApplication<>),typeof(EmpleadoApplication<>));
builder.Services.AddScoped(typeof(ITokenHandlerService), typeof(TokenHandlerService));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
