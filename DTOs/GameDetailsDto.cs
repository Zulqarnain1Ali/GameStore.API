namespace GameStore.DTOs;
 
//  A dto is a a contract between the client and server, since it 
//  represents the a shared agreement about how data will be send and recieved.

public record GameDetailsDto(
    int Id,
    string Name,
    int GenreId,
    decimal Price,
    DateOnly ReleaseDate
);
