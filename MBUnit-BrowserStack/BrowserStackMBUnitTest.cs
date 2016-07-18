using Gallio.Framework;
using MbUnit.Framework;
using MbUnit.Framework.ContractVerifiers;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Text;
using BrowserStack;

namespace BrowserStack
{
  [TestFixture]
  public class BrowserStackMBUnitTest
  {
    protected IWebDriver driver;
    protected string profile;
    protected string environment;
    private Local browserStackLocal;

    public BrowserStackMBUnitTest(string profile, string environment = "chrome")
    {
      this.profile = profile;
      this.environment = environment;
    }

    [FixtureSetUp]
    public void Init()
    {
      NameValueCollection caps = ConfigurationManager.GetSection("capabilities/" + profile) as NameValueCollection;
      NameValueCollection settings = ConfigurationManager.GetSection("environments/" + environment) as NameValueCollection;

      DesiredCapabilities capability = new DesiredCapabilities();

      foreach (string key in caps.AllKeys)
      {
        capability.SetCapability(key, caps[key]);
      }

      foreach (string key in settings.AllKeys)
      {
        capability.SetCapability(key, settings[key]);
      }

      String username = Environment.GetEnvironmentVariable("BROWSERSTACK_USERNAME");
      if(username == null)
      {
        username = ConfigurationManager.AppSettings.Get("user");
      }

      String accesskey = Environment.GetEnvironmentVariable("BROWSERSTACK_ACCESS_KEY");
      if (accesskey == null)
      {
        accesskey = ConfigurationManager.AppSettings.Get("key");
      }

      capability.SetCapability("browserstack.user", username);
      capability.SetCapability("browserstack.key", accesskey);

      if (capability.GetCapability("browserstack.local") != null && capability.GetCapability("browserstack.local").ToString() == "true")
      {
        browserStackLocal = new Local();
        List<KeyValuePair<string, string>> bsLocalArgs = new List<KeyValuePair<string, string>>() {
          new KeyValuePair<string, string>("key", accesskey)
        };
        browserStackLocal.start(bsLocalArgs);
      }

      driver = new RemoteWebDriver(new Uri("http://"+ ConfigurationManager.AppSettings.Get("server") +"/wd/hub/"), capability);
    }

    [FixtureTearDown]
    public void Cleanup()
    {
      driver.Quit();
      if (browserStackLocal != null)
      {
        browserStackLocal.stop();
      }
    }
  }
}
