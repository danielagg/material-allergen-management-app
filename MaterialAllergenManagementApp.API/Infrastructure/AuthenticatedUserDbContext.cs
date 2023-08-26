using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MaterialAllergenManagementApp.Users;
using Microsoft.EntityFrameworkCore;

namespace MaterialAllergenManagementApp.Infrastructure;

class AuthenticatedUserDbContext : IdentityDbContext<AuthenticatedUser>
{
    public AuthenticatedUserDbContext(DbContextOptions<AuthenticatedUserDbContext> options) : base(options)
    {

    }
}