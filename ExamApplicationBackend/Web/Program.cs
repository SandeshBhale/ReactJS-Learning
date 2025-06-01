using Infra;
using Infra.Repo;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddCors(
     p => {
         p.AddDefaultPolicy(
              pol => {      
                  pol.AllowAnyOrigin();
                  pol.AllowAnyMethod();
                  pol.AllowAnyHeader();
              }
             );
     }
    );

var scon = builder.Configuration.GetConnectionString("scon");
builder.Services.AddDbContext<ExamContext>(
    opt => opt.UseSqlServer(scon)
    );

builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IAdminRepo, AdminRepo>();
builder.Services.AddScoped<IQuestionDBRepo, QuestionDBRepo>();
builder.Services.AddScoped<IQuestionRepo, QuestionRepo>();
builder.Services.AddScoped<ISubjectRepo, SubjectRepo>();
builder.Services.AddScoped<ITopicRepo, TopicRepo>();
builder.Services.AddScoped<IQuestionOptionRepo, QuestionOptionRepo>();
builder.Services.AddScoped<IScheduledExamSubjectRepo, ScheduledExamSubjectRepo>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWT:issuer"],
        ValidAudience = builder.Configuration["JWT:audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:key"]))
    };
});

builder.Services.AddSwaggerGen(
     option => {
         option.SwaggerDoc("v1", new OpenApiInfo { Title = "Exam Application API", Version = "v1" });
         option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
         {
             In = ParameterLocation.Header,
             Description = "Please enter a valid token",
             Name = "Authorization",
             Type = SecuritySchemeType.Http,
             BearerFormat = "JWT",
             Scheme = "Bearer"
         });
         option.AddSecurityRequirement(new OpenApiSecurityRequirement
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
     }
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
