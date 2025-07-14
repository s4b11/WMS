using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NLog;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Text;
using WMS.Api.Validation;
using WMS.Contracts;
using WMS.Contracts.ILog;
using WMS.DataLayer;
using WMS.Dtos;
using WMS.LoggerService;
using WMS.Models;
using WMS.Repositories;
using WMS.Repositories.Log;
using WMS.Services;
using WMS.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwtSettings["SecretKey"];
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
    };
});

var connectionString = configuration["ConnectionStrings:DefaultConnection"];
builder.Services.AddDbContext<WMSContext>(
    options => options.UseNpgsql(connectionString, b => b.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)),
    ServiceLifetime.Transient
);

builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddMvc(opt =>
{
    opt.Filters.Add(typeof(ValidatorActionFilter));
}).AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<Program>());


// Country
builder.Services.AddTransient<IValidator<CountryEditDto>, CountryEditDtoValidator>();
builder.Services.AddTransient<IValidator<CountryCreateDto>, CountryCreateDtoValidator>();
//builder.Services.AddScoped<IRepositoryBase<Country>, CountryRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<ICountryService, CountryService>();

// Company
builder.Services.AddTransient<IValidator<CompanyEditDto>, CompanyEditDtoValidator>();
builder.Services.AddTransient<IValidator<CompanyCreateDto>, CompanyCreateDtoValidator>();
//builder.Services.AddScoped<IRepositoryBase<Company>, CompanyRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ICompanyService, CompanyService>();

// Vendor
builder.Services.AddTransient<IValidator<VendorEditDto>, VendorEditDtoValidator>();
builder.Services.AddTransient<IValidator<VendorCreateDto>, VendorCreateDtoValidator>();
//builder.Services.AddScoped<IRepositoryBase<Vendor>, VendorRepository>();
builder.Services.AddScoped<IVendorRepository, VendorRepository>();
builder.Services.AddScoped<IVendorService, VendorService>();

// Customer
builder.Services.AddTransient<IValidator<CustomerEditDto>, CustomerEditDtoValidator>();
builder.Services.AddTransient<IValidator<CustomerCreateDto>, CustomerCreateDtoValidator>();
//builder.Services.AddScoped<IRepositoryBase<Customer>, CustomerRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

// Carrier
builder.Services.AddTransient<IValidator<CarrierEditDto>, CarrierEditDtoValidator>();
builder.Services.AddTransient<IValidator<CarrierCreateDto>, CarrierCreateDtoValidator>();
//builder.Services.AddScoped<IRepositoryBase<Carrier>, CarrierRepository>();
builder.Services.AddScoped<ICarrierRepository, CarrierRepository>();
builder.Services.AddScoped<ICarrierService, CarrierService>();

// Currency
builder.Services.AddTransient<IValidator<CurrencyEditDto>, CurrencyEditDtoValidator>();
builder.Services.AddTransient<IValidator<CurrencyCreateDto>, CurrencyCreateDtoValidator>();
//builder.Services.AddScoped<IRepositoryBase<Currency>, CurrencyRepository>();
builder.Services.AddScoped<ICurrencyRepository, CurrencyRepository>();
builder.Services.AddScoped<ICurrencyService, CurrencyService>();

// Uom
builder.Services.AddTransient<IValidator<UomEditDto>, UomEditDtoValidator>();
builder.Services.AddTransient<IValidator<UomCreateDto>, UomCreateDtoValidator>();
//builder.Services.AddScoped<IRepositoryBase<Uom>, UomRepository>();
builder.Services.AddScoped<IUomRepository, UomRepository>();
builder.Services.AddScoped<IUomService, UomService>();

// Zone
builder.Services.AddTransient<IValidator<ZoneEditDto>, ZoneEditDtoValidator>();
builder.Services.AddTransient<IValidator<ZoneCreateDto>, ZoneCreateDtoValidator>();
//builder.Services.AddScoped<IRepositoryBase<Zone>, ZoneRepository>();
builder.Services.AddScoped<IZoneRepository, ZoneRepository>();
builder.Services.AddScoped<IZoneService, ZoneService>();


builder.Services.AddScoped<ILoggerManager, LoggerManager>();
builder.Services.AddScoped<ILogRepository, LogRepository>();


var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddHttpContextAccessor();

var allowedOrigins = builder.Configuration.GetSection("CORS:AllowedOrigins").Get<string[]>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.WithOrigins(allowedOrigins)
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials();
    });
});

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "WMS API",
        Version = "v1",
        Description = "Warehouse Management System API"
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});

var app = builder.Build();

await EnsureDbAsync(app.Services);

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
    c.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "WMS API");
    c.DocExpansion(DocExpansion.None);
    c.ConfigObject.AdditionalItems["syntaxHighlight"] = new Dictionary<string, object>
    {
        ["activated"] = false
    };
});

app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<CustomExceptionMiddleware>();
app.MapControllers();
app.UseHttpsRedirection();
app.UseMiddleware<CorsMiddleware>();

static async Task EnsureDbAsync(IServiceProvider services)
{
    using var db = services.CreateScope().ServiceProvider.GetRequiredService<WMSContext>();
    await db.Database.MigrateAsync();
}

builder.WebHost.UseUrls("http://0.0.0.0:5000");
app.Run();