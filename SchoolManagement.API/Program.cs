using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.Interfaces;
using SchoolManagement.Application.Interfaces.Auth;
using SchoolManagement.Application.Services;
using SchoolManagement.Application.Services.Auth;
using SchoolManagement.Domain.Interfaces;
using SchoolManagement.Infrastructure.Data;
using SchoolManagement.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);


// Adiciona política de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:3001")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


// Configuração do EF Core com SQL Server

// Add DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.MigrationsAssembly("SchoolManagement.Infrastructure")
    ));



// Injeção de dependência: Repositórios
builder.Services.AddScoped<IEscolaRepository, EscolaRepository>();
builder.Services.AddScoped<IMensalidadeRepository, MensalidadeRepository>();
builder.Services.AddScoped<IParcelaRepository, ParcelaRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

// Injeção de dependência: Serviços
builder.Services.AddScoped<IEscolaService, EscolaService>();
builder.Services.AddScoped<IMensalidadeService, MensalidadeService>();
builder.Services.AddScoped<IParcelaService, ParcelaService>();
builder.Services.AddScoped<IAuthService, AuthService>();

// Controllers e Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Aplica a política de CORS
app.UseCors("PermitirFrontend");

// Seed de dados
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    SeedData.Inicializar(context);
    SeedUsuarios.Inicializar(context);

    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await db.Database.MigrateAsync();
}

// Middleware de tratamento de erros
app.UseMiddleware<ExceptionHandlingMiddleware>();

// Swagger e HTTPS
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapGet("/", context =>
{
    context.Response.Redirect("/swagger/index.html");
    return Task.CompletedTask;
});
await app.RunAsync();