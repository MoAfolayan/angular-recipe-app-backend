using Recipe.Services;
using Recipe.Data.Repositories;
using Recipe.Data.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: MyAllowSpecificOrigins,
        policy =>
        {
            policy
                .WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
        }
    );
});

builder.Services.AddSwaggerService();
builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("create:users", policy => policy.RequireClaim("permissions", "create:users"));
    options.AddPolicy("read:users", policy => policy.RequireClaim("permissions", "read:users"));
    options.AddPolicy("update:users", policy => policy.RequireClaim("permissions", "update:users"));
    options.AddPolicy("delete:users", policy => policy.RequireClaim("permissions", "delete:users"));
    options.AddPolicy(
        "create:non-user-entities",
        policy => policy.RequireClaim("permissions", "create:non-user-entities")
    );
    options.AddPolicy(
        "read:non-user-entities",
        policy => policy.RequireClaim("permissions", "read:non-user-entities")
    );
    options.AddPolicy(
        "update:non-user-entities",
        policy => policy.RequireClaim("permissions", "update:non-user-entities")
    );
    options.AddPolicy(
        "delete:non-user-entities",
        policy => policy.RequireClaim("permissions", "delete:non-user-entities")
    );
});

// Services
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IRecipeService, RecipeService>();
builder.Services.AddTransient<IIngredientService, IngredientService>();

// Repositories
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IRecipeRepository, RecipeRepository>();
builder.Services.AddTransient<IIngredientRepository, IngredientRepository>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
