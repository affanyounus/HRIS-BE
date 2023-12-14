global using HRIS.Basic.Models;
global using Microsoft.EntityFrameworkCore;
global using HRIS.Basic.Data;
global using System.ComponentModel.DataAnnotations;
using System.Text;
using HRIS.Basic.Authorization.Permission;
using HRIS.Basic.Mappings;
using HRIS.Basic.Models.Domain.Auth;
using HRIS.Basic.Repositories;
using HRIS.Basic.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<HrisDbRevContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("HrisDataConnectionString")
        );
});

builder.Services.AddDbContext<HrisDbAuthContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("HrisAuthConnectionString")
        );
});

//builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITokenRepository, TokenRepository>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));


builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>("HRIS")
    .AddEntityFrameworkStores<HrisDbAuthContext>()
    .AddDefaultTokenProviders();
    


builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
    options.SignIn.RequireConfirmedAccount = true;
});

builder.Services.AddAuthentication(options => {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });



builder.Services.AddAuthorization(options =>
{
    //options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Administrator"));
    options.AddPolicy("AdminPermissions", policy=>
    {
        policy.Requirements.Add(new PermissionRequirement("CreateEmployee"));
        policy.Requirements.Add(new PermissionRequirement("ReadEmployee"));
        policy.Requirements.Add(new PermissionRequirement("EditEmployee"));
        policy.Requirements.Add(new PermissionRequirement("DeleteEmployee"));
        //policy.Requirements.Add(new PermissionRequirement("CHKPRM1"));
    });
});
builder.Services.AddTransient<IAuthorizationHandler, PermissionHandler>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
