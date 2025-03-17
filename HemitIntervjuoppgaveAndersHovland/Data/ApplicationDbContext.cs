
using System.Text.Json;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HemitIntervjuoppgaveAndersHovland.Data;

namespace HemitIntervjuoppgaveAndersHovland.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Patient> Patients { get; set; } = default!;
}
