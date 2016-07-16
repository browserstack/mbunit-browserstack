using Gallio.Framework;
using MbUnit.Framework;
using MbUnit.Framework.ContractVerifiers;
using OpenQA.Selenium;
using System.Text.RegularExpressions;

namespace BrowserStack
{
  [TestFixture]
  public class LocalTest : BrowserStackMBUnitTest
  {
    public LocalTest() : base("chrome", true) { }

    [Test]
    public void HealthCheck()
    {
      driver.Navigate().GoToUrl("http://bs-local.com:45691/check");
      Assert.IsTrue(Regex.IsMatch(driver.PageSource, "Up and running", RegexOptions.IgnoreCase));
    }
  }
}
