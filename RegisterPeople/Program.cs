using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RegisterPeople.Data;
using System.Configuration;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProductDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));



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

void ConfigureServices(IServiceCollection services)
{
    // setting for jwt , taeed hoviat ba Authentication
    var jwtSettings = Configuration.GetSection("JwtSettings");
    var Key = Encoding.ASCII.GetBytes(jwtSettings["Secret"]);

    services.AddAuthentication(X =>
    {
        X.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        X.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(X =>
    {
        X.RequireHttpsMetadata = false;
        X.SaveToken = true;
        X.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Key),
            ValidateIssuer = false,
            ValidateAudience = false,


        };
    });
    services.AddAuthorization(options =>
    {
        options.AddPolicy("AdminOnly", options => options.RequireRole("Admin"));
    });
}
