using BDDSpecFlowSample.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;

namespace BDDSpecFlowSample.Pages
{
    public class UserListPage
    {
        private ChromeDriver _chromeDriver;

        public UserListPage(ChromeDriver chromeDriver) => _chromeDriver = chromeDriver;
        public IWebElement usersContainer => _chromeDriver.FindElement(By.XPath("//div[contains(@class, 'users-container')]"));
        public ReadOnlyCollection<IWebElement> userCards => _chromeDriver.FindElements(By.XPath("//div[contains(@class, 'users-container')]/app-user-card"));
        public IWebElement txtSearchInput => _chromeDriver.FindElement(By.XPath("//input[contains(@class, 'search-input')]"));
        public IWebElement noUsersFoundTxt => _chromeDriver.FindElement(By.XPath("//div[contains(@class, 'no-found-users')]/b"));
        public IWebElement resetListBtn => _chromeDriver.FindElement(By.XPath("//button[contains(@class, 'reset-btn')]"));


        public bool UsersContainerExists => SeleniumUtils.ElementExists(usersContainer);
        public bool UserCardsExist => SeleniumUtils.ElementListExists(userCards);
        public bool ResetListButtonExist => SeleniumUtils.ElementExists(resetListBtn);
        public void TypeSearchInput(string searchTerm)
        {
            txtSearchInput.Click();
            foreach (var character in searchTerm)
            {
                Thread.Sleep(200);
                txtSearchInput.SendKeys(character.ToString());
            }
        }        
        public void ClickOnUserCard(int userCardIndex) => userCards[userCardIndex].Click();
    }
}
