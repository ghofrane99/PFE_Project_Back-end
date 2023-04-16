using GMC.Data;
using GMC.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddCors((corsoptions) =>
{
    corsoptions.AddPolicy("Mypolicy", (policyoptions) =>
    {
        policyoptions.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
    });
});
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("veryverysecret..........")),
        ValidateAudience = false ,
        ValidateIssuer = false 
    };
});


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Mypolicy");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
