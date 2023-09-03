using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MAM.Users;
using MAM.Infrastructure;
using MAM.Allergens.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterDependencyInjections();

builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddAuthorizationBuilder();

builder.Services.AddDbContext<AuthenticatedUserDbContext>(x => x.UseSqlite("DataSource=app.db"));

builder.Services.AddIdentityCore<AuthenticatedUser>()
    .AddEntityFrameworkStores<AuthenticatedUserDbContext>()
    .AddApiEndpoints();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.MapIdentityApi<AuthenticatedUser>();

using (var scope = app.Services.CreateScope())
{
    var authenticationDbContext = scope.ServiceProvider.GetRequiredService<AuthenticatedUserDbContext>();
    var allergensDbContext = scope.ServiceProvider.GetRequiredService<AllergensDbContext>();

    authenticationDbContext.Database.Migrate();
    allergensDbContext.Database.Migrate();
}

app.Run();