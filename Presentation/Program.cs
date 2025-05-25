using Microsoft.EntityFrameworkCore;
using Presentation.Data.Context;
using Presentation.Data.Repositories;
using Presentation.Services;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
});

builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(x =>
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));


builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IGuestAdressRepository, GuestAdressRepository>();
builder.Services.AddScoped<IBookingGuestRepository, BookingGuestRepository>();
builder.Services.AddScoped<IBookingService, BookingService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Event API V1");
    c.RoutePrefix = string.Empty;
});


app.MapOpenApi();
app.UseHttpsRedirection();
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();