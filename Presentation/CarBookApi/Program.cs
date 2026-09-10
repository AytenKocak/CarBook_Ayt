using CarBook.Application.Features.CQRS.Handlers.AboutHandlers;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using CarBook.Application.Features.CQRS.Handlers.BrandHandlers;
using CarBook.Application.Features.CQRS.Handlers.CarHandlers;
using CarBook.Application.Features.CQRS.Handlers.CategoryHandler;
using CarBook.Application.Features.CQRS.Handlers.ContactHandlers;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Application.Interfaces.CarDescriptionInterfaces;
using CarBook.Application.Interfaces.CarFeatureInterfaces;
using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Application.Interfaces.ReviewRepository;
using CarBook.Application.Interfaces.StatisticsInterfaces;
using CarBook.Application.Interfaces.TagCloudInterfaces;
using CarBook.Application.RepositoryPattern;
using CarBook.Application.Services;
using CarBook.Domain.Entities;
using CarBook_Ayt_Persistance;
using CarBook_Ayt_Persistance.Repositories;
using CarBook_Ayt_Persistance.Repositories.BlogRepositories;
using CarBook_Ayt_Persistance.Repositories.CarDescriptionRepositories;
using CarBook_Ayt_Persistance.Repositories.CarFeatureRepositories;
using CarBook_Ayt_Persistance.Repositories.CarPricingRepositories;
using CarBook_Ayt_Persistance.Repositories.CommentRepositories;
using CarBook_Ayt_Persistance.Repositories.RentACarInterfaces;
using CarBook_Ayt_Persistance.Repositories.RentACarRepositories;
using CarBook_Ayt_Persistance.Repositories.ReviewRepository;
using CarBook_Ayt_Persistance.Repositories.StatisticsRepositories;
using CarBook_Ayt_Persistance.Repositories.TagCloudepositories;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<CarBookContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICarRepository, CarBook_Ayt_Persistance.Repositories.CarRepositories.CarRepository>();
builder.Services.AddScoped<IBlogRepository, BlogRepository>();
builder.Services.AddScoped<ICarPricingRepository, CarPricingRepository>();
builder.Services.AddScoped<ITagCloudRepository, TagCloudRepository>();
builder.Services.AddScoped<IRentACarRepository, RentACarRepositories>();
builder.Services.AddScoped<IStatisticsRepository, StatisticsRepository>();
builder.Services.AddScoped<IGenericRepository<Comment>, CommentRepository>();
builder.Services.AddScoped<ICarFeatureRepository, CarFeatureRepository>();
builder.Services.AddScoped<ICarDescriptionRepository, CarDescriptionRepository>(); 
builder.Services.AddScoped<IReviewRepository, ReviewRepository>(); 


builder.Services.AddScoped<CreateAboutCommandHandler>();
builder.Services.AddScoped<GetAboutByIdQueryHandler>();
builder.Services.AddScoped<GetAboutQueryHandler>();
builder.Services.AddScoped<RemoveAboutCommandHandler>();
builder.Services.AddScoped<UpdateAboutCommandHandle>();

builder.Services.AddScoped<CreateBannerCommandHandler>();
builder.Services.AddScoped<GetBannerByIdQueryHandler>();
builder.Services.AddScoped<GetBannerQueryHandler>();
builder.Services.AddScoped<RemoveBannerCommnadHandler>();
builder.Services.AddScoped<UpdateBannerCommandHandler>();

builder.Services.AddScoped<CreateBrandCommandHandler>();
builder.Services.AddScoped<GetBrandByIdQueryHandler>();
builder.Services.AddScoped<GetBrandQueryHandler>();
builder.Services.AddScoped<RemoveBrandCommandHandler>();
builder.Services.AddScoped<UpdateBrandCommandHandler>();

builder.Services.AddScoped<CreateCarCommandHandler>();
builder.Services.AddScoped<GetCarByIdQueryHandler>();
builder.Services.AddScoped<GetCarQueryHandler>();
builder.Services.AddScoped<RemoveCarCommandHandler>();
builder.Services.AddScoped<UpdateCarCommandHandler>();
builder.Services.AddScoped<GetCarWithBrandQueryHandler>();
builder.Services.AddScoped<GetLast5CarWithBrandQueryHandler>();


builder.Services.AddScoped<CreateCategoryCommandHandler>();
builder.Services.AddScoped<GetCategoryByIdCommandHandler>();
builder.Services.AddScoped<GetCategoryQueryHandler>();
builder.Services.AddScoped<RemoveCategoryCommandHandler>();
builder.Services.AddScoped<UpdateCategoryCommandHandler>();

builder.Services.AddScoped<CreateContactCommandHandler>();
builder.Services.AddScoped<GetContactByIdQueryHandler>();
builder.Services.AddScoped<GetContactQueryHandler>();
builder.Services.AddScoped<RemoveContactCommandHandler>();
builder.Services.AddScoped<UpdateContactCommandHandler>();

builder.Services.SaveApplicationServices();
builder.Services.AddControllers();
builder.Services.AddControllers();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();




// CORS Configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.WithOrigins(
                "https://localhost:7270", // UI projesi
                "http://localhost:7270"   // HTTP alternatifi
            )
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
});

// Swagger Configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "CarBook API",
        Version = "v1"
    });
});

var app = builder.Build();



// Middleware Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        // Swagger JSON dosyasýnýn yolunu belirtir
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CarBook API V1");

        // EÐER Swagger'ýn direkt localhost:5013/ adresinde açýlmasýný istiyorsan 
        // aþaðýdaki satýrý aktif býrak. 
        // EÐER localhost:5013/swagger adresinde açýlmasýný istiyorsan 
        // aþaðýdaki satýrý yorum satýrý yap (baþýna // koy).

        // c.RoutePrefix = string.Empty; 
    });
}

//app.UseHttpsRedirection(); // Eðer port hatasý alýyorsan bunu eklemek güvenli olur

app.UseCors("AllowAll");

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();