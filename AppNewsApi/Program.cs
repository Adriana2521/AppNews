using AppNewsApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var conexion = builder.Configuration.GetConnectionString("ApiStringConnection");
builder.Services.AddDbContext<Sistem21NoticiasdbContext>(x => x.UseMySql(conexion, ServerVersion.AutoDetect(conexion)));
builder.Services.AddControllers();
string Issuer = "docentes.itesrc.net";
string Audiance = "mauidocentes";
var Secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("NoticiasKeyMoviles83G"));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer
(
    jwt =>
    {
        jwt.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidIssuer = Issuer,
            ValidAudience = Audiance,
            IssuerSigningKey = Secret,
            ValidateAudience = true,
            ValidateIssuer= true
        };
    }
);

builder.Services.AddCors();

var app = builder.Build();

app.UseCors();
app.UseAuthorization();
app.MapControllers();

app.Run();