using Models;
using Pisicna_Back.Controllers;
using Pisicna_Back.Repositories;
using Pisicna_Back.Service;

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("servicios_atemita");

// Add repositorys to the container.
builder.Services.AddScoped<IUsuariosRepository, UsuariosRepository>(provider =>
new UsuariosRepository(connectionString));

builder.Services.AddScoped<IServiciosRepository, ServiciosRepository>(provider =>
new ServiciosRepository(connectionString));

builder.Services.AddScoped<IEmpleadoRepository, EmpleadoRepository>(provider =>
new EmpleadoRepository(connectionString));

builder.Services.AddScoped<ITutorRepository, TutorRepository>(provider =>
new TutorRepository(connectionString));


// Add services to the container.
builder.Services.AddScoped<IUsuariosService, UsuariosService>();

builder.Services.AddScoped<IServiciosService, ServiciosService>();

builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();

builder.Services.AddScoped<ITutorService, TutorService>();

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

app.MapControllers();

//PlatoPrincipalController.InicializarDatos();
app.Run();