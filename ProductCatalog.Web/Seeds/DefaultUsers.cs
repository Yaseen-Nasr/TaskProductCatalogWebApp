
namespace ProductCatalog.Web.Seeds
{
    public static class DefaultUsers
    {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager)
        {
            var admin = new ApplicationUser
            {
                UserName = "admin", 
                Email = "admin@default.com",
                EmailConfirmed = true

            };
            var user = await userManager.FindByEmailAsync(admin.Email);
            if (user is null)
            {
                await userManager.CreateAsync(admin, "Def@ult123");
                await userManager.AddToRoleAsync(admin, AppRoles.Admin);
            };

        }
    }
}
