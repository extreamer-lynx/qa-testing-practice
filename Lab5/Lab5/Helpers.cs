using System;
using OpenQA.Selenium;

namespace Lab5
{
	public static class Helpers
	{
		public static void CrearAndType(IWebElement element, string text)
        {
			element.Click();
			element.Clear();
			element.SendKeys(text);
        }
	}
}

