using APILayer.Hubs;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.AboutValidations;
using BusinessLayer.ValidationRules.BookingValidations;
using BusinessLayer.ValidationRules.CategoryValidations;
using BusinessLayer.ValidationRules.ContactValidations;
using BusinessLayer.ValidationRules.DiscountValidations;
using BusinessLayer.ValidationRules.IdentityValidations;
using BusinessLayer.ValidationRules.NotificationValidations;
using BusinessLayer.ValidationRules.ProductValidations;
using BusinessLayer.ValidationRules.SliderValidations;
using BusinessLayer.ValidationRules.SocialMediaValidations;
using BusinessLayer.ValidationRules.TableValidations;
using BusinessLayer.ValidationRules.TestimonialValidations;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
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

builder.Services.AddDbContext<Context>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddScoped<IAboutService, AboutManager>();
builder.Services.AddScoped<IAboutDal, EfAboutDal>();

builder.Services.AddScoped<IBookingService, BookingManager>();
builder.Services.AddScoped<IBookingDal, EfBookingDal>();

builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();

builder.Services.AddScoped<IContactService, ContactManager>();
builder.Services.AddScoped<IContactDal, EfContactDal>();

builder.Services.AddScoped<IDiscountService, DiscountManager>();
builder.Services.AddScoped<IDiscountDal, EfDiscountDal>();

builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<IProductDal, EfProductDal>();

builder.Services.AddScoped<ISocialMediaService, SocialMediaManager>();
builder.Services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();

builder.Services.AddScoped<ITestimonialService, TestimonialManager>();
builder.Services.AddScoped<ITestimonialDal, EfTestimonialDal>();

builder.Services.AddScoped<IOrderService, OrderManager>();
builder.Services.AddScoped<IOrderDal, EfOrderDal>();

builder.Services.AddScoped<IMoneyCaseService, MoneyCaseManager>();
builder.Services.AddScoped<IMoneyCaseDal, EfMoneyCaseDal>();

builder.Services.AddScoped<ITableService, TableManager>();
builder.Services.AddScoped<ITableDal, EfTableDal>();

builder.Services.AddScoped<ISliderService, SliderManager>();
builder.Services.AddScoped<ISliderDal, EfSliderDal>();

builder.Services.AddScoped<IBasketService, BasketManager>();
builder.Services.AddScoped<IBasketDal, EfBasketDal>();

builder.Services.AddScoped<INotificationService, NotificationManager>();
builder.Services.AddScoped<INotificationDal, EfNotificationDal>();

builder.Services.AddValidatorsFromAssemblyContaining<AboutUpdateValidation>();
builder.Services.AddValidatorsFromAssemblyContaining<BookingAddValidation>();
builder.Services.AddValidatorsFromAssemblyContaining<BookingUpdateValidation>();
builder.Services.AddValidatorsFromAssemblyContaining<CategoryAddValidation>();
builder.Services.AddValidatorsFromAssemblyContaining<CategoryUpdateValidation>();
builder.Services.AddValidatorsFromAssemblyContaining<ContactUpdateValidation>();
builder.Services.AddValidatorsFromAssemblyContaining<DiscountAddValidation>();
builder.Services.AddValidatorsFromAssemblyContaining<DiscountUpdateValidation>();
builder.Services.AddValidatorsFromAssemblyContaining<RegisterValidation>();
builder.Services.AddValidatorsFromAssemblyContaining<NotificationAddValidation>();
builder.Services.AddValidatorsFromAssemblyContaining<NotificationUpdateValidation>();
builder.Services.AddValidatorsFromAssemblyContaining<ProductAddValidation>();
builder.Services.AddValidatorsFromAssemblyContaining<ProductUpdateValidation>();
builder.Services.AddValidatorsFromAssemblyContaining<SliderUpdateValidation>();
builder.Services.AddValidatorsFromAssemblyContaining<SocialMediaAddValidation>();
builder.Services.AddValidatorsFromAssemblyContaining<SocialMediaUpdateValidation>();
builder.Services.AddValidatorsFromAssemblyContaining<TableAddValidation>();
builder.Services.AddValidatorsFromAssemblyContaining<TableUpdateValidation>();
builder.Services.AddValidatorsFromAssemblyContaining<TestimonialAddValidation>();
builder.Services.AddValidatorsFromAssemblyContaining<TestimonialUpdateValidation>();

// json tarafýnda iç içe yapý hatasýný engeller
builder.Services.AddControllersWithViews().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Add services to the container.

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
