using TrainCode.Persistence;
using TrainCode.Persistence.Repositories;

using TrainCode.App.Repositories;

using TrainCode.App.Client;
using TrainCode.App.Exercise;
using TrainCode.App;

var builder = WebApplication.CreateBuilder(args);

var dbConnectionString = builder.Configuration.GetConnectionString("Database");
builder.Services.InjectTrainCodeDbContext(dbConnectionString);

builder.Services.AddScoped<ICoachRepository, CoachRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();

builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<ICoachService, CoachService>();
builder.Services.AddScoped<IExerciseService, ExerciseService>();

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

app.UseCors(opt => {
    opt.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:5173");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
