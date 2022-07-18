using Microsoft.EntityFrameworkCore;
using WebAppiWorldCup2022.Data;
using WebAppiWorldCup2022.Services;
using WebAppiWorldCup2022.Services.GroupService;
using WebAppiWorldCup2022.Services.InstanceService;
using WebAppiWorldCup2022.Services.MathcServices;
using WebAppiWorldCup2022.Services.PeopleServices;
using WebAppiWorldCup2022.Services.PlayerServices;
using WebAppiWorldCup2022.Services.RoundOf16Services;
using WebAppiWorldCup2022.Services.RoundOfSixteenServices;
using WebAppiWorldCup2022.Services.SoccerteamService;
using WebAppiWorldCup2022.Services.StadiumService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Fixture_WorldCupContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("ConnectionDB")));

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddTransient<ImatchService, MatchService>();
builder.Services.AddTransient<IRoundOfSixteen, RoundOfSixteen>();
builder.Services.AddTransient<ISoccerTeamService, SoccerTeamService>();
builder.Services.AddTransient<IStadiumService, StadiumService>();
builder.Services.AddTransient<IInstansService, InstansService>();
builder.Services.AddTransient<IGroupService, GroupService>();
builder.Services.AddTransient<IPLayerService, PlayerService>();
builder.Services.AddTransient<IPeopleService, PeopleService>();

builder.Services.AddControllers();
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

app.UseCors(x => x.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
