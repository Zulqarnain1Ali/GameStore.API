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

// 3. GET: Fetch a single game by ID using LINQ
app.MapGet("/games/{id:int}", (int id) =>
{
    var game = games.FirstOrDefault(g => g.Id == id);
    return game is not null ? Results.Ok(game) : Results.NotFound($"Game with ID {id} not found.");
});

// 4. POST: Add a new game
app.MapPost("/games", ([FromBody] Game newGame) =>
{
    if (string.IsNullOrEmpty(newGame.Name)) return Results.BadRequest("Name is required.");
    
    games.Add(newGame);
    return Results.Created($"/games/{newGame.Id}", newGame);
});

// 5. DELETE: Remove a game
app.MapDelete("/games/{id:int}", (int id) =>
{
    var game = games.FirstOrDefault(g => g.Id == id);
    if (game is null) return Results.NotFound();

    games.Remove(game);
    return Results.NoContent();
});

app.Run();

// 6. Data Model / Record Type
public record Game(int Id, string Name, string Genre, decimal Price);