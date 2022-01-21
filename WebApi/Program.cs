using StoreDL;
using StoreBL;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Registering our dep here for dependency injection
//Different ways to add dependency
//Scoped, Sigleton, Transient
builder.Services.AddScoped<IRepo>(ctx => new DBRepo(builder.Configuration.GetConnectionString("SFDB")));
builder.Services.AddScoped<IBL, SFBL>();

var app = builder.Build();

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
