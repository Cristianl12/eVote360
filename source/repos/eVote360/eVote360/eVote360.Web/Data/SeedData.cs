using Microsoft.AspNetCore.Identity;

namespace eVote360.Web.Data
{
    public static class SeedData
    {
        public static async Task InitializeAsync(RoleManager<IdentityRole> roleManager)
        {
            string[] roles = { "Administrador", "Votante", "Dirigente" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }
}
