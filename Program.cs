using GameStore.Endpoints;
using GameStore.DTOs;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using GameStore.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();

var connString = "Data Source = GameStore.db";
builder.Services.AddSqlite<GameStoreContext>(connString);
var app = builder.Build();

app.MapGamesEndpoints();

app.MigrateDb();

app.Run();