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



builder.Services.AddControllers();


builder.Services.AddCors(options =>
{
    options.AddPolicy("ITEC-FrontEnd", policy =>
    {
        policy.WithOrigins("https://calm-stone-035810a00.4.azurestaticapps.net") 
              .AllowAnyHeader() 
              .AllowAnyMethod(); 
    });
});






// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("ITEC-FrontEnd");


app.UseAuthorization();

app.MapControllers();

app.Run();
