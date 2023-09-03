using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using TocoToco.BL.Services.CategoryService;
using TocoToco.BL.Services.IceService;
using TocoToco.BL.Services.OrderDetailService;
using TocoToco.BL.Services.OrderService;
using TocoToco.BL.Services.PaymentService.MoMo;
using TocoToco.BL.Services.ProductService;
using TocoToco.BL.Services.RoleService;
using TocoToco.BL.Services.SizeOrderService;
using TocoToco.BL.Services.SugarService;
using TocoToco.BL.Services.ToppingOrderService;
using TocoToco.BL.Services.ToppingService;
using TocoToco.BL.Services.TypeOrderService;
using TocoToco.BL.Services.UserService;
using TocoToco.DL.Constracts;
using TocoToco.DL.Context;
using TocoToco.DL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateAudience = false,
        ValidateIssuer = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                builder.Configuration.GetSection("AppSettings:Token").Value!))
    };
});


// add db context
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Connection"));
});

// auto mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// add service
// role
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();

// user
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// category
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

// product
builder.Services.AddScoped<IProductService , ProductService>();
builder.Services.AddScoped<IProductRepository , ProductRepository>();

// order
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

// type order
builder.Services.AddScoped<ITypeOrderService, TypeOrderService>();
builder.Services.AddScoped<ITypeOrderRepository, TypeOrderRepository>();

// size order
builder.Services.AddScoped<ISizeOrderService, SizeOrderService>();
builder.Services.AddScoped<ISizeOrderRepository, SizeOrderRepository>();

// sugar
builder.Services.AddScoped<ISugarService, SugarService>();
builder.Services.AddScoped<ISugarRepository, SugarRepository>();

// ice
builder.Services.AddScoped<IIceService, IceService>();
builder.Services.AddScoped<IIceRepository, IceRepository>();

// topping
builder.Services.AddScoped<IToppingService, ToppingService>();
builder.Services.AddScoped<IToppingRepository, ToppingRepository>();

// order detail
builder.Services.AddScoped<IOrderDetailService, OrderDetailService>();
builder.Services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();

// topping order
builder.Services.AddScoped<IToppingOrderService, ToppingOrderService>();
builder.Services.AddScoped<IToppingOrderRepository, ToppingOrderRepository>();

// momo payment
builder.Services.AddScoped<IMoMoPaymentService, MoMoPaymentService>();

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
