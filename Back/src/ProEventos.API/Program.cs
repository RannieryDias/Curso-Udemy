using Microsoft.EntityFrameworkCore;
using ProEventos.Application;
using ProEventos.Application.Contracts;
using ProEventos.Persistence.Context;
using ProEventos.Persistence.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProEventosContext>(options => 
                options.UseSqlite(builder.Configuration.
                GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

builder.Services.AddControllers()
                .AddNewtonsoftJson(
                 x => x.SerializerSettings.ReferenceLoopHandling =
                                Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IGeneralPersistence, GeneralPersistence>();
builder.Services.AddScoped<IEventPersistence, EventPersistence>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(x => x.AllowAnyHeader().
                    AllowAnyMethod().
                    AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
