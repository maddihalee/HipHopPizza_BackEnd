using HipHopPizzaAndWangs.Models;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using HipHopPizzaAndWangs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<HipHopPizzaDbContext>(builder.Configuration["HipHopPizzaAndWangsDbConnectionString"]);


// Set the JSON serializer options
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:3000",
                                "http://localhost:7009")
                                .AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowAnyOrigin();
        });
});

var app = builder.Build();

app.UseCors();

// Create user 
app.MapPost("/users", (HipHopPizzaDbContext db, User user) =>
{
    db.Users.Add(user);
    db.SaveChanges();
    return Results.Created($"/user/{user.Id}", user);
});

// Get all users
app.MapGet("users", (HipHopPizzaDbContext db) =>
{
    return db.Users.ToList();
});

// Check if user is in database
app.MapGet("checkuser/{uid}", (HipHopPizzaDbContext db, string uid) =>
{
    var userExist = db.Users.Where(x => x.Uid == uid).ToList();
    if (userExist == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(userExist);
});

// Get all products
app.MapGet("products", (HipHopPizzaDbContext db) =>
{
    return db.Products.ToList();
});

// Create a product
app.MapPost("products", (HipHopPizzaDbContext db, Product product) =>
{
   db.Products.Add(product);
   db.SaveChanges();
   return Results.Created($"/products/{product.Id}", product);
});

// Update a product
app.MapPut("/products/{id}", (HipHopPizzaDbContext db, int productId, Product product) =>
{
    Product productToUpdate = db.Products.FirstOrDefault(p => p.Id == productId);
    if (productToUpdate == null)
    {
        return Results.NotFound("This product was not found");
    }
    productToUpdate.Name = product.Name;
    productToUpdate.Price = product.Price;
    productToUpdate.ImgUrl = product.ImgUrl;
    db.Update(productToUpdate);
    db.SaveChanges();
    return Results.Ok(productToUpdate);
});

// Delete a product
app.MapDelete("products/{id}", (HipHopPizzaDbContext db, int productId) =>
{
    var productToDelete = db.Products.FirstOrDefault(p => p.Id == productId);
    if (productToDelete == null)
    {
        return Results.NotFound();
    }
    db.Remove(productToDelete);
    db.SaveChanges();
    return Results.Ok(productToDelete);
});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
