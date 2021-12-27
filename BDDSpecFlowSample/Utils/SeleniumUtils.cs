using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace BDDSpecFlowSample.Utils
{
    public static class SeleniumUtils
    {
        /// <summary>
        /// Determines the existance of a single IWebElement in the DOM
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool ElementExists(IWebElement element)
            => element.Displayed;

        /// <summary>
        /// Determines the existance of a IWebElement list in the DOM by evaluating the list length
        /// </summary>
        /// <param name="elementList"></param>
        /// <returns></returns>
        public static bool ElementListExists(ReadOnlyCollection<IWebElement> elementList)
            => elementList.Count > 0;
    }
}
