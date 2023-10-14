using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

const string myAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: myAllowSpecificOrigins,
        policy  =>
        {
            policy.WithOrigins("http://localhost:5173", "http://localhost:5156");
        });
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterAllergenAssemblyDependencyInjections();
builder.Services.RegisterInventoryAssemblyDependencyInjections();

builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddAuthorizationBuilder();

builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(Material).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(Stock).Assembly);
});

builder.Services.AddDbContext<AuthenticatedUserDbContext>(x =>
{
    var connectionString = builder.Environment.IsDevelopment()
        ? "DataSource=app_development.db"
        : "DataSource=app.db";

    x.UseSqlite(connectionString);
});
    
builder.Services.AddIdentityCore<AuthenticatedUser>()
    .AddEntityFrameworkStores<AuthenticatedUserDbContext>()
    .AddApiEndpoints();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(myAllowSpecificOrigins);
}

// app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.MapIdentityApi<AuthenticatedUser>();

// todo: refactor out from here
using (var scope = app.Services.CreateScope())
{
    var authenticationDbContext = scope.ServiceProvider.GetRequiredService<AuthenticatedUserDbContext>();
    var allergensDbContext = scope.ServiceProvider.GetRequiredService<AllergensDbContext>();
    var inventoryDbContext = scope.ServiceProvider.GetRequiredService<InventoryDbContext>();

    authenticationDbContext.Database.Migrate();
    allergensDbContext.Database.Migrate();
    inventoryDbContext.Database.Migrate();
}

app.Run();