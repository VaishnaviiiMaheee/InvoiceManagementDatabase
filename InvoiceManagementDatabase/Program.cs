using InvoiceManagementDatabase.Models;
using InvoiceManagementDatabase.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.Configure<UserStoreDatabaseSettings>(builder.Configuration.GetSection(nameof(UserStoreDatabaseSettings)));
builder.Services.AddSingleton<IUserStoreDatabaseSettings>(sp=>sp.GetRequiredService<IOptions<UserStoreDatabaseSettings>>().Value);
builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("UserStoreDatabaseSettings:ConnectionString")));
builder.Services.AddScoped<IUserService,UserService>();

builder.Services.Configure<ProductStoreDatabaseSettings>(builder.Configuration.GetSection(nameof(ProductStoreDatabaseSettings)));
builder.Services.AddSingleton<IProductStoreDatabaseSettings>(sp => sp.GetRequiredService<IOptions<ProductStoreDatabaseSettings>>().Value);
builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("ProductStoreDatabaseSettings:ConnectionString")));
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.Configure<InvoiceStoreDatabaseSettings>(builder.Configuration.GetSection(nameof(InvoiceStoreDatabaseSettings)));
builder.Services.AddSingleton<IInvoiceStoreDatabaseSettings>(sp => sp.GetRequiredService<IOptions<InvoiceStoreDatabaseSettings>>().Value);
builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("InvoiceStoreDatabaseSettings:ConnectionString")));
builder.Services.AddScoped<IInvoiceService, InvoiceService>();

builder.Services.Configure<InvoiceProductStoreDatabaseSettings>(builder.Configuration.GetSection(nameof(InvoiceProductStoreDatabaseSettings)));
builder.Services.AddSingleton<IInvoiceProductStoreDatabaseSettings>(sp => sp.GetRequiredService<IOptions<InvoiceProductStoreDatabaseSettings>>().Value);
builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("InvoiceProductStoreDatabaseSettings:ConnectionString")));
builder.Services.AddScoped<IInvoiceProductService, InvoiceProductService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
        builder =>
        {
            builder.WithOrigins("http://localhost:4200", "http://www.contoso.com")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});
var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);
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
