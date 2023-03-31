using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TAO.FoodList.Core.Configuration;
using TAO.FoodList.Core.Entities.Auth;
using TAO.FoodList.Core.Repositories;
using TAO.FoodList.Core.Services;
using TAO.FoodList.Core.UnitOfWork;
using TAO.FoodList.Data.DbContexts;
using TAO.FoodList.Data.Repositories;
using TAO.FoodList.Data.UnitOfWorks;
using TAO.FoodList.Service.Services;
using TAO.FoodList.Shared.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region DI Register

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IGenericService<,>), typeof(GenericService<,>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
#endregion


builder.Services.Configure<CustomTokenOption>(builder.Configuration.GetSection("TokenOptions"));

var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<CustomTokenOption>();

builder.Services.Configure<List<Client>>(builder.Configuration.GetSection("Clients"));

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"), sqlOptions =>
     {

         sqlOptions.MigrationsAssembly("TAO.FoodList.Data");

     });

});
builder.Services.AddIdentity<UserApp, IdentityRole>(options=>
{
    options.User.RequireUniqueEmail = true;
    options.Password.RequireNonAlphanumeric = false;

}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme=JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme=JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options=>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters() 
    { 
       ValidIssuer = tokenOptions.Issuer,
       ValidAudience = tokenOptions.Audience[0],
       IssuerSigningKey = SignInService.GetSymmetricSecurityKey(tokenOptions.SecurityKey),
       ValidateIssuerSigningKey = true,
       ValidateAudience = true,
       ValidateIssuer = true,
       ValidateLifetime = true,

       ClockSkew=TimeSpan.Zero

    };
});





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
