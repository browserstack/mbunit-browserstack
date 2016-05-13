using System;
using BrowserStack;
using System.Collections.Generic;
using System.Text;
using Gallio.Framework;
using MbUnit.Framework;
using MbUnit.Framework.ContractVerifiers;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace MBUnit_BrowserStack_Local
{
  [AssemblyFixture]
  public class LocalSetup
  {
    private Local browserStackLocal;

    [FixtureSetUp]
    public void StartLocal()
    {
      browserStackLocal = new Local();
      List<KeyValuePair<string, string>> bsLocalArgs = new List<KeyValuePair<string, string>>() {
        new KeyValuePair<string, string>("key", BROWSERSTACK_ACCESS_KEY),
        new KeyValuePair<string, string>("forcelocal", "")
      };
      browserStackLocal.start(bsLocalArgs);
    }

    [FixtureTearDown]
    public void StopLocal()
    {
      if(browserStackLocal != null)
      {
        browserStackLocal.stop();
      }
    }
  }

  [TestFixture]
  public class MBUnit_BrowserStack
  {
    private IWebDriver driver;

    [FixtureSetUp]
    public void SetUp()
    {
      string browser = "chrome";
      string version = "50";
      string os = "Windows";
      string os_version = "10";
      DesiredCapabilities capability = new DesiredCapabilities();
      capability.SetCapability("browser", browser);
      capability.SetCapability("browser_version", version); 
      capability.SetCapability("os", os);
      capability.SetCapability("os_version", os_version);

      capability.SetCapability("build", "Sample MBUnit Tests");
      capability.SetCapability("name", "Sample MBUnit Local Test");
      capability.SetCapability("browserstack.user", BROWSERSTACK_USERNAME);
      capability.SetCapability("browserstack.key", BROWSERSTACK_ACCESS_KEY);
      capability.SetCapability("browserstack.local", true);

      Console.WriteLine("Capabilities" + capability.ToString());

      driver = new RemoteWebDriver(new Uri("http://hub.browserstack.com:80/wd/hub/"), capability);
    }

    [Test]
    public void LocalGoogleSearch()
    {
      driver.Navigate().GoToUrl("http://www.google.com");
      Assert.Contains("Google", driver.Title);
      IWebElement query = driver.FindElement(By.Name("q"));
      query.SendKeys("Browserstack");
      query.Submit();
    }

    [FixtureTearDown]
    public void tearDown()
    {
      driver.Quit();
    }
  }
}
