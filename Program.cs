using GameStore.Endpoints;
using GameStore.DTOs;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGamesEndpoints();

app.Run();