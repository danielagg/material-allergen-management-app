using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MAM.Infrastructure;

class AuthenticatedUserDbContext : IdentityDbContext<AuthenticatedUser>
{
    public AuthenticatedUserDbContext(DbContextOptions<AuthenticatedUserDbContext> options) : base(options)
    {

    }
}