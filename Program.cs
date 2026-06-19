using GameStore.DTOs;

const string GetGameEndpointName = "GetGame";


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<GameDto> games = [
    new GameDto(1, "Game 1", "Action", 59.99m, new DateOnly(2022, 01, 01)),
    new GameDto(2, "Game 2", "Adventure", 49.99m, DateOnly.FromDateTime(DateTime.Now)),
    new GameDto(3, "Game 3", "RPG", 79.99m, DateOnly.FromDateTime(DateTime.Now))
];

//get /games
app.MapGet("/games", () => games);


//get /games/1
app.MapGet("/games/{id}", (int id) => games.Find(game => game.Id == id))
   .WithName(GetGameEndpointName);


//post /games
app.MapPost("/games", (CreateGameDtos newGame) =>
{
    GameDto game = new(
        games.Count + 1,
        newGame.Name,
        newGame.Genre,
        newGame.Price,
        newGame.ReleaseDate
    );
    games.Add(game);

    return Results.CreatedAtRoute(GetGameEndpointName, new {id = game.Id}, game);
});


// PUT /games/1
 app.MapPut("/game/{id}", (int id, UpdateGameDto updatedGame) =>
 {
     var index = games.FindIndex(game => game.Id == id);
     games[index] = new GameDto(

     );
 });



app.Run();