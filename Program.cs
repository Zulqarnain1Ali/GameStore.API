// var builder = WebApplication.CreateBuilder(args);
// var app = builder.Build();

// app.MapGet("/", () => "Hello World!");

// app.Run();

using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// 1. In-Memory Database (Simulating SQL server for now)
var games = new List<Game>
{
    new Game(1, "Elden Ring", "RPG", 59.99M),
    new Game(2, "Cyberpunk 2077", "Action", 49.99M),
    new Game(3, "FIFA 26", "Sports", 69.99M)
};

// 2. GET: Fetch all games
app.MapGet("/games", () => Results.Ok(games));

