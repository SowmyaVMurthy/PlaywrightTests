using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using NUnit.Framework;
using PlaywrightTests.Pages;

namespace PlaywrightTests.Tests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class EditUser : PageTest
{
    private LoginPage _loginPage;
    private Navigation _navigation;
    private UserSetup _userSetup;

    [SetUp]
    public void SetUp()
    {
        _loginPage = new LoginPage(Page);
        _navigation = new Navigation(Page);
        _userSetup = new UserSetup(Page);
    }

    [Test]
    public async Task EditCreatedUser()
    {
        await _loginPage.GoToURL();
        await _loginPage.Login("testautomation", "Welcome123");
        await _navigation.SetupNavigation();
        await _userSetup.EditExistingUser("PlaywrightAssignedFN-1");

        // Verify newly created record is edited successfully and the role is changed to provided value
        await _userSetup.SearchTextInSearchBar("PlaywrightAssignedFN-1");
        await Expect(_userSetup.TableGridRole).ToContainTextAsync("Supervisor");
    }

}