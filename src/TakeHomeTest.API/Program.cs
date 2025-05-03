using TakeHomeTest.API.Repositories;
using TakeHomeTest.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<BillService, BillService>();
builder.Services.AddSingleton<LegislatorService, LegislatorService>();
builder.Services.AddSingleton<BillRepository, BillRepository>();
builder.Services.AddSingleton<LegislatorRepository, LegislatorRepository>();
builder.Services.AddSingleton<VoteRepository, VoteRepository>();
builder.Services.AddSingleton<VoteResultRepository, VoteResultRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(options => options.WithOrigins("*").AllowAnyMethod());

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
