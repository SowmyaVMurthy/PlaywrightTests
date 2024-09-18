using Microsoft.Playwright;

namespace PlaywrightTests.Pages
{
    public class LoginPage
    {
        public readonly IPage _page;

        public LoginPage(IPage page)
        {
            _page = page;
        }

        private ILocator Username => _page.GetByPlaceholder("User Name");
        private ILocator Password => _page.GetByRole(AriaRole.Textbox, new() { Name = "password-input"});
        private ILocator LoginButton => _page.GetByRole(AriaRole.Button, new() { Name = "Sign in" });

        public async Task GoToURL()
        {
            await _page.GotoAsync("https://rta-edu-dev-web.azurewebsites.net/login/");
        }

        public async Task Login(string username, string password)
        {
            await Username.FillAsync(username);
            await Password.FillAsync(password);
            await LoginButton.ClickAsync();
        }

    }

}
