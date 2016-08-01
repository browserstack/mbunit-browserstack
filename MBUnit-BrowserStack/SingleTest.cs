using Gallio.Framework;
using MbUnit.Framework;
using MbUnit.Framework.ContractVerifiers;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace BrowserStack
{
  [TestFixture]
  public class SingleTest : BrowserStackMBUnitTest
  {
    public SingleTest() : base("single", "chrome") { }

    [Test]
    public void SearchGoogle()
    {
      driver.Navigate().GoToUrl("https://www.google.com/ncr");
      IWebElement query = driver.FindElement(By.Name("q"));
      query.SendKeys("BrowserStack");
      query.Submit();
      System.Threading.Thread.Sleep(5000);
      Assert.AreEqual("BrowserStack - Google Search", driver.Title);
    }
  }
}
