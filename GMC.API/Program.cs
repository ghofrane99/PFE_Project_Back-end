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
builder.Services.AddScoped<IUSRepository, USRepository>();
builder.Services.AddScoped<IUSService, USService>();
builder.Services.AddSingleton<EmailService>();


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
app.UseStaticFiles();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();
var next8AM = DateTime.Now.Date.AddHours(8);
if (DateTime.Now > next8AM)
{
    next8AM = next8AM.AddDays(1);
}

TimeSpan timeUntil8AM = next8AM - DateTime.Now;

Timer timer = new Timer(async _ =>
{
    using (var scope = app.Services.CreateScope())
    {
        var pickListService = scope.ServiceProvider.GetRequiredService<IPickListService>();
        var emailService = scope.ServiceProvider.GetRequiredService<EmailService>();
        var report = await pickListService.GeneratePickListReportAsync();
        emailService.SendEmail("service.sagemcom@gmail.com", "control.sagemcom@gmail.com", "Sujet", "Le mail marche trés bien.", report);
    }
}, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));

/*DateTime now = DateTime.Now;

var emailService = app.Services.GetRequiredService<EmailService>();

Timer timer = new Timer(_ => emailService.SendEmail("service.sagemcom@gmail.com", "control.sagemcom@gmail.com", "Sujet", "Le mail marche trés bien."), null, TimeSpan.Zero, TimeSpan.FromMinutes(1));*/


app.Run();
