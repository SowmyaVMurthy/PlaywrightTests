using Microsoft.Playwright;

namespace PlaywrightTests.Pages
{
    public class Navigation
    {
        public readonly IPage _page;
    
        public Navigation(IPage page)
        {
            _page = page;
        }

        private ILocator NavigationSetup => _page.GetByRole(AriaRole.Link, new() { Name = "Setup" });
        private ILocator ManageTeamMember => _page.GetByRole(AriaRole.Link, new() { Name = "Manage Team Members" });

        public async Task SetupNavigation()
        {
            await NavigationSetup.ClickAsync();
            await ManageTeamMember.ClickAsync();
        }
    
    }

}
