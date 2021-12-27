using BDDSpecFlowSample.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;

namespace BDDSpecFlowSample.Pages
{
    public class UserDetailsPage
    {
        private ChromeDriver _chromeDriver;

        public UserDetailsPage(ChromeDriver chromeDriver) => _chromeDriver = chromeDriver;
        public IWebElement userDetailsContainer => _chromeDriver.FindElement(By.XPath("//div[contains(@class, 'user-details-container')]"));
        public IWebElement backBtn => _chromeDriver.FindElement(By.XPath("//button[contains(@class, 'back-btn')]"));
        public IWebElement userCard => _chromeDriver.FindElement(By.XPath("//div[contains(@class, 'user-details')]/app-user-card"));
        public ReadOnlyCollection<IWebElement> repositoryCards => _chromeDriver.FindElements(By.XPath("//div[contains(@class, 'user-details')]/div[contains(@class, 'repo-wrapper')]"));


        public bool UsersDetailsContainerExists => SeleniumUtils.ElementExists(userDetailsContainer);
        public bool RepositoryCardsExist => SeleniumUtils.ElementListExists(repositoryCards);
        public bool BackButtonExists => SeleniumUtils.ElementExists(backBtn);
        public bool UserCardExists => SeleniumUtils.ElementExists(userCard);

    }
}
