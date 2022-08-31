using Services;

var builder = WebApplication.CreateBuilder (args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ITodoServices, TodoServices>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapGet("/todos" , (ITodoServices TodoServices)=> {
    return TodoServices.GetAll();
});

app.MapPost("/todos", (string title, ITodoServices todoServices) => 
{
    return todoServices.Create(title);
});

app.Run();

