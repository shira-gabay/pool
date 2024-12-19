using Pool;
using Pool.Core.Repositories;
using Pool.Data.Repositories;
using Pool.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<ActivitiesService>();
builder.Services.AddScoped<SwimmersService>();
builder.Services.AddScoped<InstructorsService>();
builder.Services.AddScoped<IActivitiesRepository, ActivitiesRepository>();
builder.Services.AddScoped<IInstructorsRepository, InstructorsRepository>();
builder.Services.AddScoped<ISwimmersRepository, SwimmersRepository>();
builder.Services.AddDbContext<DataContext>();
var app = builder.Build();

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
