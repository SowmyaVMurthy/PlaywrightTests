using Microsoft.Playwright;

namespace PlaywrightTests.Pages
{
    public class UserSetup
    {
        public readonly IPage _page;
    
        public UserSetup(IPage page)
        {
            _page = page;
        }

        private ILocator AddTeamMember => _page.GetByTitle("Add Team Member");
        private ILocator FirstName => _page.GetByRole(AriaRole.Textbox, new() { Name = "First Name Required" });
        private ILocator LastName => _page.GetByRole(AriaRole.Textbox, new() { Name = "Last Name Required" });
        private ILocator EmailId => _page.GetByRole(AriaRole.Textbox, new() { Name = "Email Required" });
        private ILocator UserNameNewUser => _page.GetByRole(AriaRole.Textbox, new() { Name = "Username Required" });
        private ILocator PasswordNewUser => _page.GetByRole(AriaRole.Textbox, new() { Name = "Password Required",Exact=true });
        private ILocator ConfirmPasswordNewUser => _page.GetByRole(AriaRole.Textbox, new() { Name = "Confirm Password Required" });
        private ILocator SaveAndCloseButton => _page.GetByText(" Save and Close ");
        private ILocator SearchText => _page.GetByRole(AriaRole.Textbox, new() { Name = "Search team members"});
        private ILocator EditRecord => _page.GetByText("Edit");
        private ILocator AssignRoleDropdown => _page.Locator("//select[@id='memberRoleSelection']");
        private ILocator ConfirmChangesButton => _page.GetByRole(AriaRole.Button, new() { Name = "Confirm" });
        private ILocator DeleteButton => _page.GetByRole(AriaRole.Button, new() { Name = "Delete" });
        private ILocator ConfirmDeleteButton => _page.GetByRole(AriaRole.Button, new() { Name = "Delete" });
        private ILocator CloseButton => _page.GetByText(" Close ");
        public ILocator TableGridName => _page.Locator("//table/tbody/tr/td[1]");
        public ILocator TableGridRole => _page.Locator("//table/tbody/tr/td[2]");

        public async Task SearchTextInSearchBar(string searchText)
        {
            await SearchText.FillAsync(searchText);
            await _page.WaitForTimeoutAsync(3000);
        }

        public async Task AddNewUser(string firstname, string lastname, string emailid, string newusername, string newpassword, string confirmnewpassword)
        {
            await AddTeamMember.ClickAsync();
            await FirstName.FillAsync(firstname);
            await LastName.FillAsync(lastname);
            await EmailId.FillAsync(emailid);
            await UserNameNewUser.FillAsync(newusername);
            await PasswordNewUser.FillAsync(newpassword);
            await ConfirmPasswordNewUser.FillAsync(confirmnewpassword);
            await SaveAndCloseButton.ClickAsync();
        }
        public async Task EditExistingUser(string searchtext)
        {
            await SearchTextInSearchBar(searchtext);
            await EditRecord.ClickAsync();
            await AssignRoleDropdown.SelectOptionAsync("Administrator");
            await SaveAndCloseButton.ClickAsync();
            await ConfirmChangesButton.ClickAsync();
        }
        public async Task DeleteExistingUser(string searchtext)
        {
            await SearchTextInSearchBar(searchtext);
            await EditRecord.ClickAsync();
            await DeleteButton.ClickAsync();
            await ConfirmDeleteButton.ClickAsync();
            await CloseButton.ClickAsync();
        }

    }

}
