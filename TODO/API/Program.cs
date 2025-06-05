using API.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();

var app = builder.Build();


app.MapGet("/Tarefas", (AppDataContext db) =>
{
    db.Tarefas.ToList();
    return db.Tarefas.ToList();

});

app.MapGet("/Tarefas{id}", (int id, AppDataContext db) =>
{
    db.Tarefas.Find(id);
    return db.Tarefas.Find(id);
});

app.MapPost("/Tarefas", (Tarefa tarefa, AppDataContext db) =>
{
    db.Tarefas.Add(tarefa);
    db.SaveChangesAsync();
});


app.Run();
