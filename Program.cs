using Test1.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = "Host=localhost;Port=5432;Database=DEMO;Username=postgres;Password=nikitos";

IServiceCollection allServices = builder.Services; // коллекция сервисов
allServices.AddTransient<IProductService>(provider => new ProductService(connectionString));
allServices.AddTransient<IProviderSevice>(provider => new ProviderService(connectionString));
builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.Run();
