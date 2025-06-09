using ITEC_API.Database;
using ITEC_API.IRepositories;
using ITEC_API.IServices;
using ITEC_API.Repositories;
using ITEC_API.Services;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("https://black-smoke-0328c1a00.6.azurestaticapps.net")
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

builder.Services.AddControllers();





builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ITECDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ITECConnection")));

builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<ICourseRepo, CourseRepo>();

builder.Services.AddScoped<IIMService, IMService>();
builder.Services.AddScoped<IIMRepo, IMRepo>();

builder.Services.AddScoped<ISMService, SMService>();
builder.Services.AddScoped<ISMRepo, SMRepo>();

builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IStudentRepo, StudentRepo>();

builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IPaymentRepo, PaymentRepo>();

builder.Services.AddScoped<IAdminAuthService, AdminAuthService>();
builder.Services.AddScoped<IAdminAuthRepo, AdminAuthRepo>();

var jwtSettings = builder.Configuration.GetSection("Jwt");
var key = Encoding.ASCII.GetBytes(jwtSettings["key"]);

builder.Services.AddAuthentication().AddJwtBearer(options => {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });

builder.Services.AddAuthorization();





var app = builder.Build();

app.UseStaticFiles();

app.MapFallbackToFile("index.html");


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowFrontend");


app.UseAuthorization();

app.MapControllers();

app.Run();
