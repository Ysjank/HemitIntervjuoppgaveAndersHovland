using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace HemitIntervjuoppgaveAndersHovland.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>());

            if (context == null || context.Patients == null)
            {
                throw new NullReferenceException(
                    "Null ApplicationDbContext or Patients DbSet");
            }

            if (context.Patients.Any())
            {
                return;
            }

            var conditions = new List<string>() {
                "Diabetes type 1",
                "Diabetes type 2",
                "Hypertensjon",
                "Hypokondri",
                "Lungekreft",
                "Strupekreft",
                "Testikkelkreft",
                "Livmorhalskreft",
                "Brystkreft",
                "Peanøttallergi",
                "Glutenallergi",
                "Bjørkepollenallergi",
                "Burotpollenallergi",
                "Støvallergi",
                "Hundeallergi",
                "Katteallergi",
                "Hesteallergi",
                "Skalldyrallergi",
            };

            var rand = new Random();
            for (var i = 0; i < 20; i++)
            {
                var patientConditions = new List<string>();
                for (var j = 1; j < rand.Next(2, 4); j++)
                {
                    var condition = "";
                    do {
                        condition = conditions[rand.Next(0, conditions.Count)];
                    } while (patientConditions.Contains(condition));

                    patientConditions.Add(condition);
                }

                context.Patients.Add(
                    new Patient
                    {
                        Name = $"Test Pasient",
                        DateOfBirth = DateTime.Today.AddDays(-rand.Next((int)Math.Floor(12 * 365.25), (int)Math.Floor(90 * 365.25))),
                        Conditions = patientConditions.Aggregate((a, b) => $"{a}, {b}")
                    }
                );
            }

            context.SaveChanges();
        }
    }
}