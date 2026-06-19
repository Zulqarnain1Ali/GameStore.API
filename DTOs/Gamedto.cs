namespace GameStore.DTOs;
 
//  A dto is a a contract between the client and server, since it 
//  represents the a shared agreement about how data will be send and recieved.

public record GameDto(
    int Id,
    string Name,
    string Genre,
    decimal Price,
    DateOnly ReleaseDate
);
