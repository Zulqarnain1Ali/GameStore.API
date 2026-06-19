namespace GameStore.DTOs;

public record CreateGameDtos(
    string Name,
    string Genre,
    decimal Price,
    DateOnly ReleaseDate
);