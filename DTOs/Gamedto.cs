namespace Gamestore.DTOs;
 
//  A dto is a a contract between the client and server, since it 
//  represents the a shared agreement about how data will be send and recieved.
public record class GameDto(
    int ID,
    string Name, 
    string Genre,
    Decimal Price,
    DateOnly ReleaseDate
);