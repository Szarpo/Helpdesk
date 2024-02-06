using Helpdesk.Application;
using Helpdesk.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

builder.Configuration.AddJsonFile("appsettings.Local.json", optional: true, reloadOnChange: true);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();


var app = builder.Build();

app.UseInfrastructure();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapControllers();
app.UseHttpsRedirection();

app.Run();
