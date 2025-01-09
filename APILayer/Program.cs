using APILayer.Hubs;
using BusinessLayer.Container;
using FluentValidation;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowed((host) => true)
        .AllowCredentials();
    });
});
builder.Services.AddSignalR();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

//Ba��ml�l�klar Container Klas�r�nden �a�r�ld�
builder.Services.ContainerDependencies();

// json taraf�nda i� i�e yap� hatas�n� engeller
builder.Services.AddControllersWithViews().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Burada FluentValidation k�t�phanesini kullanarak model validasyonlar�n� yapabilmek i�in gerekli ayarlamalar� yap�yoruz.
ValidatorOptions.Global.LanguageManager.Culture = new System.Globalization.CultureInfo("tr");

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

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHub<SignalRHub>("/signalrhub");

app.Run();
