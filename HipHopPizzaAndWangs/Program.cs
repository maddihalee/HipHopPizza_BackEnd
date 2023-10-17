using HipHopPizzaAndWangs.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using HipHopPizzaAndWangs;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

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
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
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
app.MapPost("/register", (HipHopPizzaDbContext db, User user) =>
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
app.MapGet("/products", (HipHopPizzaDbContext db) =>
{
    return db.Products.ToList();
});

// Create a product
app.MapPost("/products", async (HipHopPizzaDbContext db, Product product) =>
{
   db.Products.Add(product);
   await db.SaveChangesAsync();
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
    db.Update(productToUpdate);
    db.SaveChanges();
    return Results.Ok(productToUpdate);
});

// Delete a product
app.MapDelete("/products/{id}", (HipHopPizzaDbContext db, int productId) =>
{
    var productToDelete = db.Products.FirstOrDefault(p => p.Id == productId);
    if (productToDelete == null)
    {
        return Results.NotFound();
    }
    db.Remove(productToDelete);
    db.SaveChanges();
    return Results.NoContent();
});

// Get product by ID
app.MapGet("/products/{id}", (HipHopPizzaDbContext db, int id) =>
{
    var product = db.Products.Find(id);
    if (product == null)
    {
        return Results.NotFound(id);
    }

    return Results.Ok(product);
});

// Get all orders
app.MapGet("/orders", (HipHopPizzaDbContext db) =>
{
    return db.Orders.ToList();
});

// Create an order
app.MapPost("/orders", (HipHopPizzaDbContext db, Order order) =>
{
    db.Orders.Add(order);
    db.SaveChanges();
    return Results.Ok(order);
});

// Update an order
app.MapPut("orders/{id}", (HipHopPizzaDbContext db, int orderId, Order order) =>
{
    Order orderToUpdate = db.Orders.FirstOrDefault(order => order.Id == orderId);
    if (orderToUpdate == null)
    {
        return Results.NotFound();
    }
    orderToUpdate.UserId = order.UserId;
    db.SaveChanges();
    return Results.Ok(orderToUpdate);
});

// Delete an order
app.MapDelete("orders/{id}", (HipHopPizzaDbContext db, int orderId) =>
{
    var orderToDelete = db.Orders.FirstOrDefault(o => o.Id == orderId);
    if (orderToDelete == null)
    {
        return Results.NotFound();
    }
    db.Remove(orderToDelete);
    db.SaveChanges();
    return Results.NoContent();
});

// Get order by ID
app.MapGet("/orders/{id}", (HipHopPizzaDbContext db, int id) =>
{
    var order = db.Orders.Find(id);
    if (order == null)
    {
        return Results.NotFound(id);
    }

    return Results.Ok(order);
});

// Get an order's products
app.MapGet("/ordersProducts/{orderId}", (HipHopPizzaDbContext db, int orderId) =>
{
    var orderProducts = db.Orders.Where(x => x.Id == orderId).Include(x => x.products).FirstOrDefault();
    if (orderProducts != null)
    {
        var items = orderProducts.products.ToList();
        return Results.Ok(items);
    } else
    {
        return Results.NotFound();
    }
});

// Get all payment types
app.MapGet("/paymentTypes", (HipHopPizzaDbContext db) =>
{
    return db.PaymentTypes.ToList();
});

// Create a payment type
app.MapPost("/paymentTypes", (HipHopPizzaDbContext db, PaymentType paymentType) =>
{
    db.PaymentTypes.Add(paymentType);
    db.SaveChanges();
    return Results.Ok(paymentType);
});

// Update payment type
app.MapPut("/paymentTypes/{id}", (HipHopPizzaDbContext db, int typeId, PaymentType paymentType) =>
{
    PaymentType paymentTypeToUpdate = db.PaymentTypes.FirstOrDefault(o => o.Id == typeId);
    if (paymentTypeToUpdate == null)
    {
        return Results.NotFound();
    }
    paymentTypeToUpdate.Type = paymentType.Type;
    db.SaveChanges();
    return Results.Ok(paymentTypeToUpdate);
});

// Delete a payment type
app.MapDelete("/paymentType/{id}", (HipHopPizzaDbContext db, int typeId) =>
{
    var typeToDelete = db.PaymentTypes.FirstOrDefault(t => t.Id == typeId);
    if (typeToDelete == null)
    {
        return Results.NotFound();
    }
    db.PaymentTypes.Remove(typeToDelete);
    db.SaveChanges();
    return Results.NoContent();
});

// Get all order status
app.MapGet("/orderstatus", (HipHopPizzaDbContext db) =>
{
    return db.Statuses.ToList();
});

// Adding an order status
app.MapPost("orderstatus", (HipHopPizzaDbContext db, Status newStatus) =>
{
    db.Statuses.Add(newStatus);
    db.SaveChanges();
    return Results.Created($"/orderstatus/{newStatus.Id}", newStatus);
});

// Delete an order status
app.MapDelete("/orderstatus/{id}", (HipHopPizzaDbContext db, int id) =>
{
    var status = db.Statuses.Find(id);
    if (status == null)
    {
        return Results.NotFound(id);
    }

    db.Statuses.Remove(status);
    db.SaveChanges();

    return Results.NoContent();
});

//Adding Product to an Order
app.MapPost("/productOrders/{OrderId}", ([FromRoute]int OrderId, HipHopPizzaDbContext db, Product product) =>
{
    var orderToAdd = db.Orders.FirstOrDefault(o => o.Id == OrderId);

    if (orderToAdd == null)
    {
        return Results.NotFound();
    }

    if (orderToAdd.products == null)
    {
        orderToAdd.products = new List<Product>();
    }

    orderToAdd.products.Add(product);
    db.SaveChanges();

    return Results.Created($"orders/{orderToAdd.Id}", orderToAdd);
});

// Adding a status to an order
//app.MapPost("/orderStatus", (int OrderId, int OrderStatusId, HipHopPizzaDbContext db) =>
//{
//    var order = db.Orders.Include(o => o.Status).FirstOrDefault(o => o.Id == OrderId);

//    if (order == null)
//    {
//        return Results.NotFound();
//    }

//    var statusToAdd = db.Statuses.FirstOrDefault(s => s.Id == OrderStatusId);

//    if (statusToAdd == null)
//    {
//        return Results.NotFound();
//    }

//    order.StatusId = statusToAdd.Id;

//    db.SaveChanges();

//    return Results.NoContent();
//});


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
