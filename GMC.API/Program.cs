using GMC.Data;
using GMC.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContextPool<DataContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("sqlconnectionstring")));
builder.Services.AddScoped<IPickListRepository, PickListRepository>();
builder.Services.AddScoped<IPickListService, PickListService>();
builder.Services.AddScoped<ILigneProductionRepository, LigneProductionRepository>();
builder.Services.AddScoped<ILigneProductionService, LigneProductionService>();
builder.Services.AddScoped<IStatusRepository, StatusRepository>();
builder.Services.AddScoped<IStatusService, StatusService>();
builder.Services.AddScoped<IDetailPickListRepository, DetailPickListRepository>();
builder.Services.AddScoped<IDetailPickListService, DetailPickListService>();
builder.Services.AddScoped<IProduitRepository, ProduitRepository>();
builder.Services.AddScoped<IProduitService, ProduitService>();
builder.Services.AddScoped<IUSPickListRepository, USPickListRepository>();
builder.Services.AddScoped<IUSPickListService, USPickListService>();
builder.Services.AddScoped<IInformationUSRepository, InformationUSRepository>();
builder.Services.AddScoped<IInformationUSService, InformationUSService>();
builder.Services.AddScoped<IRemoteUSRepository, RemoteUSRepository>();
builder.Services.AddScoped<IRemoteUSService, RemoteUSService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
