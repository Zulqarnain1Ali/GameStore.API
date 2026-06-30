using GameStore.Endpoints;
using GameStore.DTOs;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using GameStore.Data;
using GameStore.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();

var app = builder.Build();

app.MapGamesEndpoints();

app.MigrateDb();

app.Run();