using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MaterialAllergenManagementApp.Users;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();

// todo: move to proper Infra folder
class AuthenticatedUserDbContext : IdentityDbContext<AuthenticatedUser>
{
    public AuthenticatedUserDbContext(DbContextOptions<AuthenticatedUserDbContext> options) : base(options)
    {

    }
}