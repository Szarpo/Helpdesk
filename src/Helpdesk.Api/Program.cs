using Helpdesk.Application;
using Helpdesk.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();

builder.Services
    .AddInfrastructure(builder.Configuration)
    .AddApplication();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c=> c.EnableAnnotations()
    );


var app = builder.Build();

app.UseInfrastructure();

if (app.Environment.IsDevelopment() || app.Environment.EnvironmentName == "Local")
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
