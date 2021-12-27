using BDDSpecFlowSample.Pages;
using OpenQA.Selenium.Chrome;

namespace BDDSpecFlowSample.StepDefinitions
{
    [Binding]
    public class GithubUsersStepDefinitions
    {
        private ChromeDriver _chromeDriver;
        private UserListPage _userListPage;
        private UserDetailsPage _userDetailsPage;

        public GithubUsersStepDefinitions()
        {
            _chromeDriver = new ChromeDriver();
            _userListPage = new UserListPage(_chromeDriver);
            _userDetailsPage = new UserDetailsPage(_chromeDriver);
        }            

        const string APPLICATION_BASE_URL = "http://angularsamplegithubproject.s3-website-us-east-1.amazonaws.com/";

        [Given(@"I navigate to the GithubUsers app")]
        public void GivenINavigateToTheGithubUsersApp()
        {
            _chromeDriver.Navigate().GoToUrl(APPLICATION_BASE_URL);
            Assert.Equal("githubusers", _chromeDriver.Title.ToLower());
            Assert.True(_userListPage.UsersContainerExists);
        }

        [Then(@"I verify a list of Users is displayed")]
        public void ThenIVerifyAListOfUsersIsDisplayed()
        {
            _chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            Assert.True(_userListPage.UserCardsExist);
        }

        [When(@"I type (.*) as a searchTerm")]
        public void WhenITypeRolandAsASearchTerm(string searchTerm)
        => _userListPage.TypeSearchInput(searchTerm);

        [Then(@"search results for the given searchTerm should appear")]
        public void ThenSearchResultsForGivenSearchTermShouldAppear()
        {
            _chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            Assert.True(_userListPage.userCards.Count == 1);
        }

        [Then(@"no results message is displayed")]
        public void ThenNoResultsMessageIsDisplayed()
        {
            Assert.Equal("no users found", _userListPage.noUsersFoundTxt.Text.ToLower());
            Assert.True(_userListPage.ResetListButtonExist);
        }

        [When(@"I click on the user card")]
        public void WhenIClickOnTheUserCard()
        => _userListPage.ClickOnUserCard(0);

        [Then(@"the User details page is displayed")]
        public void ThenTheUserDetailsPageIsDisplayed()
        {
            _chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            Assert.True(_userDetailsPage.UsersDetailsContainerExists);
            Assert.True(_userDetailsPage.RepositoryCardsExist);
            Assert.True(_userDetailsPage.BackButtonExists);
            Assert.True(_userDetailsPage.UserCardExists);
        }

        [AfterScenario]
        public void Dispose()
        {
            if (_chromeDriver != null)
                _chromeDriver.Dispose();       
        }
    }
}
