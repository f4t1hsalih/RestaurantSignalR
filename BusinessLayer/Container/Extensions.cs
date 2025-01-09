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
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer.Container
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddDbContext<Context>();

            services.AddScoped<IAboutService, AboutManager>();
            services.AddScoped<IAboutDal, EfAboutDal>();

            services.AddScoped<IBookingService, BookingManager>();
            services.AddScoped<IBookingDal, EfBookingDal>();

            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();

            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IContactDal, EfContactDal>();

            services.AddScoped<IDiscountService, DiscountManager>();
            services.AddScoped<IDiscountDal, EfDiscountDal>();

            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IProductDal, EfProductDal>();

            services.AddScoped<ISocialMediaService, SocialMediaManager>();
            services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();

            services.AddScoped<ITestimonialService, TestimonialManager>();
            services.AddScoped<ITestimonialDal, EfTestimonialDal>();

            services.AddScoped<IOrderService, OrderManager>();
            services.AddScoped<IOrderDal, EfOrderDal>();

            services.AddScoped<IMoneyCaseService, MoneyCaseManager>();
            services.AddScoped<IMoneyCaseDal, EfMoneyCaseDal>();

            services.AddScoped<ITableService, TableManager>();
            services.AddScoped<ITableDal, EfTableDal>();

            services.AddScoped<ISliderService, SliderManager>();
            services.AddScoped<ISliderDal, EfSliderDal>();

            services.AddScoped<IBasketService, BasketManager>();
            services.AddScoped<IBasketDal, EfBasketDal>();

            services.AddScoped<INotificationService, NotificationManager>();
            services.AddScoped<INotificationDal, EfNotificationDal>();

            services.AddValidatorsFromAssemblyContaining<AboutUpdateValidation>();
            services.AddValidatorsFromAssemblyContaining<BookingAddValidation>();
            services.AddValidatorsFromAssemblyContaining<BookingUpdateValidation>();
            services.AddValidatorsFromAssemblyContaining<CategoryAddValidation>();
            services.AddValidatorsFromAssemblyContaining<CategoryUpdateValidation>();
            services.AddValidatorsFromAssemblyContaining<ContactUpdateValidation>();
            services.AddValidatorsFromAssemblyContaining<DiscountAddValidation>();
            services.AddValidatorsFromAssemblyContaining<DiscountUpdateValidation>();
            services.AddValidatorsFromAssemblyContaining<RegisterValidation>();
            services.AddValidatorsFromAssemblyContaining<NotificationAddValidation>();
            services.AddValidatorsFromAssemblyContaining<NotificationUpdateValidation>();
            services.AddValidatorsFromAssemblyContaining<ProductAddValidation>();
            services.AddValidatorsFromAssemblyContaining<ProductUpdateValidation>();
            services.AddValidatorsFromAssemblyContaining<SliderUpdateValidation>();
            services.AddValidatorsFromAssemblyContaining<SocialMediaAddValidation>();
            services.AddValidatorsFromAssemblyContaining<SocialMediaUpdateValidation>();
            services.AddValidatorsFromAssemblyContaining<TableAddValidation>();
            services.AddValidatorsFromAssemblyContaining<TableUpdateValidation>();
            services.AddValidatorsFromAssemblyContaining<TestimonialAddValidation>();
            services.AddValidatorsFromAssemblyContaining<TestimonialUpdateValidation>();
        }
    }
}
