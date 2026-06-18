using GameStore.DTOs;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<GameDto> games = [
    new GameDto(1, "Game 1", "Action", 59.99m, DateOnly.FromDateTime(DateTime.Now)),
    new GameDto(2, "Game 2", "Adventure", 49.99m, DateOnly.FromDateTime(DateTime.Now)),
    new GameDto(3, "Game 3", "RPG", 79.99m, DateOnly.FromDateTime(DateTime.Now))
];

app.MapGet("/games", () => games);

app.Run();