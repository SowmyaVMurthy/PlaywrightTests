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
public class UserCreation : PageTest
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
    public async Task CreatedNewUserIsVisible()
    {
        await _loginPage.GoToURL();
        await _loginPage.Login("testautomation", "Welcome123");
        await _navigation.SetupNavigation();
        await _userSetup.AddNewUser("PlaywrightAssignedFN-1", "PlaywrightAssignedLN-1", "pa_1@email.com", "playwrightuser_1", "Testpassword1", "Testpassword1");

        // Verify newly created record is visible and present with the same names provided while creation
        await _userSetup.SearchTextInSearchBar("PlaywrightAssignedFN-1");
        await Expect(_userSetup.TableGridName).ToBeVisibleAsync();
        await Expect(_userSetup.TableGridName).ToContainTextAsync("PlaywrightAssignedLN, PlaywrightAssignedFN-1");
    }

}