using Test1.Services;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = "Host=localhost;Port=5432;Database=DEMO;Username=postgres;Password=nikitos";

IServiceCollection allServices = builder.Services; // коллекция сервисов
allServices.AddTransient<IProductService>(provider => new ProductService(connectionString));
allServices.AddTransient<IProviderSevice>(provider => new ProviderService(connectionString));
builder.Services.AddControllers();

builder.Services.AddCors(options =>
options.AddDefaultPolicy(
policy =>
policy.AllowAnyHeader()
.AllowAnyMethod()
.AllowAnyOrigin()
)
);

var app = builder.Build();


app.UseCors();


app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.Run();
