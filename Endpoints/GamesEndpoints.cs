namespace GameStore.Endpoints;

using GameStore.DTOs;

public static class GamesEndpoints
{
    const string GetGameEndpointName = "GetGame";

    private static readonly List<GameDto> games = [
    new GameDto(1, "Game 1", "Action", 59.99m, new DateOnly(2022, 01, 01)),
    new GameDto(2, "Game 2", "Adventure", 49.99m, DateOnly.FromDateTime(DateTime.Now)),
    new GameDto(3, "Game 3", "RPG", 79.99m, DateOnly.FromDateTime(DateTime.Now))
];

    public static void MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/games"); 

        //get /games
        group.MapGet("/", () => games);



        //get /games/1
        group.MapGet("/{id}", (int id) =>
        {
            var game = games.Find(game => game.Id == id);

            return game is null ? Results.NotFound() : Results.Ok(game);
        })
           .WithName(GetGameEndpointName);



        //post /games
        group.MapPost("/", (CreateGameDtos newGame) =>
        {
            GameDto game = new(
                games.Count + 1,
                newGame.Name,
                newGame.Genre,
                newGame.Price,
                newGame.ReleaseDate
            );
            games.Add(game);

            return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
        });


        // PUT /games/1
        group.MapPut("/{id}", (int id, UpdateGameDto updatedGame) =>
         {
             var index = games.FindIndex(game => game.Id == id);

             if (index == -1)
             {
                 return Results.NotFound();
             }

             games[index] = new GameDto(
                id,
                updatedGame.Name,
                updatedGame.Genre,
                updatedGame.Price,
                updatedGame.ReleaseDate
             );

             return Results.NoContent();
         });


        // DELETE /games/1
        group.MapDelete("/{id}", (int id) =>
        {
            games.RemoveAll(game => game.Id == id);

            return Results.NoContent();
        });

    }
}
