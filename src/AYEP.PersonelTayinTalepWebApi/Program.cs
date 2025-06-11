using Application.Behaviors;
using Application.Features.AdaletKomisyonlari.Command.Create;
using Application.Features.AdaletKomisyonlari.Mapping;
using Application.Features.AdaletKomisyonlari.Rules;
using Application.Features.Adliyeler.Rules;
using Application.Features.Auth.Rules;
using Application.Features.Birimler.Rules;
using Application.Features.PersonelBirimGorevlendirmeler.Rules;
using Application.Features.Personeller.Rules;
using Application.Features.PersonelTayinTalepleri.Rules;
using Application.Interfaces;
using Domain.Repositories.AdaletKomisyonlari;
using Domain.Repositories.Adliyeler;
using Domain.Repositories.Birimler;
using Domain.Repositories.LogEntrys;
using Domain.Repositories.PersonelGorevlendirmeler;
using Domain.Repositories.Personeller;
using Domain.Repositories.PersonelTayinTalepleri;
using Domain.Repositories.PersonelTayinTalepTercihleri;
using FluentValidation;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repositories.AdaletKomisyonlari;
using Infrastructure.Persistence.Repositories.Adliyeler;
using Infrastructure.Persistence.Repositories.Auth;
using Infrastructure.Persistence.Repositories.Birimler;
using Infrastructure.Persistence.Repositories.LogEntrys;
using Infrastructure.Persistence.Repositories.PersonelBirimGorevlendirmeler;
using Infrastructure.Persistence.Repositories.Personeller;
using Infrastructure.Persistence.Repositories.PersonelTayinTalepleri;
using Infrastructure.Persistence.Repositories.PersonelTayinTalepTercihleri;
using Infrastructure.Persistence.UnitOfWork;
using Infrastructure.Security;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CreateAdaletKomisyonuCommandHandler).Assembly));
builder.Services.AddAutoMapper(typeof(AdaletKomisyonuProfile).Assembly);
builder.Services.AddValidatorsFromAssemblyContaining<CreateAdaletKomisyonuCommandValidator>();
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
// Repositories

builder.Services.AddScoped<IAdaletKomisyonuRepository, AdaletKomisyonuRepository>();
builder.Services.AddScoped<IAdliyeRepository, AdliyeRepository>();
builder.Services.AddScoped<IBirimRepository, BirimRepository>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<ILogEntryRepository, LogEntryRepository>();
builder.Services.AddScoped<IPersonelBirimGorevlendirmeRepository, PersonelBirimGorevlendirmeRepository>();
builder.Services.AddScoped<IPersonelRepository, PersonelRepository>();
builder.Services.AddScoped<IPersonelTayinTalepRepository, PersonelTayinTalepRepository>();
builder.Services.AddScoped<IPersonelTayinTalepTercihRepository, PersonelTayinTalepTercihRepository>();
builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


// BusinessRules
builder.Services.AddScoped<AdaletKomisyonuBusinessRules>();
builder.Services.AddScoped<AdliyeBusinessRules>();
builder.Services.AddScoped<PersonelLoginBusinessRules>();
builder.Services.AddScoped<BirimBusinessRules>();
builder.Services.AddScoped<PersonelBirimGorevlendirmeBusinessRules>();
builder.Services.AddScoped<PersonelBusinessRules>();
builder.Services.AddScoped<PersonelTayinTalepBusinessRules>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var jwtKey = builder.Configuration["Jwt:Key"];
        if (string.IsNullOrEmpty(jwtKey))
        {
            throw new InvalidOperationException("JWT Key is not configured in the application settings.");
        }

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
        };
    });

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AYEP.PersonelTayinTalep API", Version = "v1" });

    // JWT Authentication için:
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGci...\""
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

builder.Services.AddAuthorization();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

var app = builder.Build();

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