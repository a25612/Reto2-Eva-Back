using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Models;
using Repositories;
using Repository;
using Service;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Obtener la cadena de conexión
var connectionString = builder.Configuration.GetConnectionString("servicios_atemtia");

// Configurar opciones de JSON en los controladores
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
});

// Registrar el DbContext
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 29))));

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173", "https://localhost:7163", "http://servicios-atemtia.retocsv.es/")
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials();
    });
});

// Registrar los repositorios
builder.Services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();
builder.Services.AddScoped<IUsuariosRepository, UsuariosRepository>();
builder.Services.AddScoped<IServiciosRepository, ServiciosRepository>();
builder.Services.AddScoped<ITutorRepository, TutorRepository>();
builder.Services.AddScoped<ISesionRepository, SesionRepository>();
builder.Services.AddScoped<ICentroRepository, CentroRepository>();
builder.Services.AddScoped<IAnuncioRepository, AnuncioRepository>();
builder.Services.AddScoped<IUsuarioTutorRepository, UsuarioTutorRepository>();

// Registrar los servicios
builder.Services.AddScoped<IUsuariosService, UsuariosService>();
builder.Services.AddScoped<IServiciosService, ServiciosService>();
builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();
builder.Services.AddScoped<ITutorService, TutorService>();
builder.Services.AddScoped<ISesionService, SesionService>();
builder.Services.AddScoped<ICentroService, CentroService>();
builder.Services.AddScoped<IAnuncioService, AnuncioService>();
builder.Services.AddScoped<IUsuarioTutorService, UsuarioTutorService>();

// Registrar AutoMapper y el perfil de mapeo
builder.Services.AddAutoMapper(typeof(MappingProfile));

// ====== CONFIGURACIÓN JWT ======
// Obtener la clave secreta desde appsettings.json
var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddAuthorization();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowFrontend");
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
