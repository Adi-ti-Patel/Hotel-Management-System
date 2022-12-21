using Hotel.Bussiness.Interface;
using Hotel.Bussiness.Model;
using Hotel.Data.DBContext;
using Hotel.Data.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<HotelDbContext>(option => 
    option.UseSqlServer(builder.Configuration.GetConnectionString("hotel"))
);

builder.Services.AddTransient<HotelDbContext, HotelDbContext>();
builder.Services.AddTransient<IBookingRepository, BookingRepository>();
builder.Services.AddTransient<ICityRepository, CityRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IRoomBookedRepository, RoomBookedRepository>();
builder.Services.AddTransient<IRoomRepository, RoomRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//Booking
app.MapGet("/booking", (IBookingRepository repo) => {
    return Results.Ok(repo.GetAllItems());
}).WithTags("Booking");

app.MapGet("/booking/{id}", (IBookingRepository repo, int id) => {
    return Results.Ok(repo.GetItemById(id));
}).WithTags("Booking");

app.MapPut("/booking", (IBookingRepository repo, Booking item) => {
    return Results.Ok(repo.UpdateItem(item));
}).WithTags("Booking");

app.MapPost("/booking", (IBookingRepository repo, Booking item) =>
{
    return Results.Ok(repo.CreateItem(item));
}).WithTags("Booking");

app.MapDelete("/booking/{id}", (IBookingRepository repo, int id) =>
{
    return Results.Ok(repo.DeleteItem(id));
}).WithTags("Booking");

//City
app.MapGet("/city", (ICityRepository repo) => {
    return Results.Ok(repo.GetAllItems());
}).WithTags("City");

app.MapGet("/city/{id}", (ICityRepository repo, int id) => {
    return Results.Ok(repo.GetItemById(id));
}).WithTags("City");

app.MapPut("/city", (ICityRepository repo, City item) => {
    return Results.Ok(repo.UpdateItem(item));
}).WithTags("City");

app.MapPost("/city", (ICityRepository repo, City item) =>
{
    return Results.Ok(repo.CreateItem(item));
}).WithTags("City");

app.MapDelete("/city/{id}", (ICityRepository repo, int id) =>
{
    return Results.Ok(repo.DeleteItem(id));
}).WithTags("City");

//Order
app.MapGet("/order", (IOrderRepository repo) => {
    return Results.Ok(repo.GetAllItems());
}).WithTags("Order");

app.MapGet("/order/{id}", (IOrderRepository repo, int id) => {
    return Results.Ok(repo.GetItemById(id));
}).WithTags("Order");

app.MapPut("/order", (IOrderRepository repo, Order item) => {
    return Results.Ok(repo.UpdateItem(item));
}).WithTags("Order");

app.MapPost("/order", (IOrderRepository repo, Order item) =>
{
    return Results.Ok(repo.CreateItem(item));
}).WithTags("Order");

app.MapDelete("/order/{id}", (IOrderRepository repo, int id) =>
{
    return Results.Ok(repo.DeleteItem(id));
}).WithTags("Order");

//RoomBooked
app.MapGet("/roomBooked", (IRoomBookedRepository repo) => {
    return Results.Ok(repo.GetAllItems());
}).WithTags("RoomBooked");

app.MapGet("/roomBooked/{id}", (IRoomBookedRepository repo, int id) => {
    return Results.Ok(repo.GetItemById(id));
}).WithTags("RoomBooked");

app.MapPut("/roomBooked", (IRoomBookedRepository repo, RoomBooked item) => {
    return Results.Ok(repo.UpdateItem(item));
}).WithTags("RoomBooked");

app.MapPost("/roomBooked", (IRoomBookedRepository repo, RoomBooked item) =>
{
    return Results.Ok(repo.CreateItem(item));
}).WithTags("RoomBooked");

app.MapDelete("/roomBooked/{id}", (IRoomBookedRepository repo, int id) =>
{
    return Results.Ok(repo.DeleteItem(id));
}).WithTags("RoomBooked");

//Room
app.MapGet("/room", (IRoomRepository repo) => {
    return Results.Ok(repo.GetAllItems());
}).WithTags("Room");

app.MapGet("/room/{id}", (IRoomRepository repo, int id) => {
    return Results.Ok(repo.GetItemById(id));
}).WithTags("Room");

app.MapPut("/room", (IRoomRepository repo, Room item) => {
    return Results.Ok(repo.UpdateItem(item));
}).WithTags("Room");

app.MapPost("/room", (IRoomRepository repo, Room item) =>
{
    return Results.Ok(repo.CreateItem(item));
}).WithTags("Room");

app.MapDelete("/room/{id}", (IRoomRepository repo, int id) =>
{
    return Results.Ok(repo.DeleteItem(id));
}).WithTags("Room");

app.Run();