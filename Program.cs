using ListaDePaises.API.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//CORS
builder.Services.AddCors(options => {
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        }
      );
});

// Usando Banco em Memoria 
builder.Services.AddDbContext<PaisesDbContext>(
    o => o.UseInMemoryDatabase("PaisesDb")
    );

//// Usando SQL SERVER 
//var stringConexao = builder.Configuration.GetConnectionString("ListaPaises");

//builder.Services.AddDbContext<PaisesDbContext>(
//    o => o.UseSqlServer(stringConexao)
//);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Inserir para documentar o Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "ListaPaises.API",
        Version = "v1",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Diego Cruz",
            Email = "diego.cruz.developer@gmail.com",
            Url = new Uri("https://diegoandradepoa.github.io/")
        }
    });
});




var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

// Configure the HTTP request pipeline. EM PRODUCAO USAR ESSE
if (true)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
