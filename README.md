# mbunit-browserstack
[MBUnit](https://github.com/Gallio/mbunit-v3) Integration with BrowserStack.

![BrowserStack Logo](https://d98b8t1nnulk5.cloudfront.net/production/images/layout/logo-header.png?1469004780)

## Setup
* Clone the repo
* Open the solution `MBUnit-BrowserStack.sln` in Visual Studio 2010 SP1
* Build the solution
* Update `App.config` file with your BrowserStack Username and Access Key(https://www.browserstack.com/accounts/settings)

## Running your tests from Test Explorer via NUnit Test Adapter
- To run parallel tests, run tests with fixture `parallel`
- To run local tests, run test with fixture `local`

 Understand how many parallel sessions you need by using our [Parallel Test Calculator](https://www.browserstack.com/automate/parallel-calculator?ref=github)

## Notes
* You can view your test results on the [BrowserStack automate dashboard](https://www.browserstack.com/automate)
* To test on a different set of browsers, check out our [platform configurator](https://www.browserstack.com/automate/c-sharp#setting-os-and-browser)
* You can export the environment variables for the Username and Access Key of your BrowserStack account

  ```
  export BROWSERSTACK_USERNAME=<browserstack-username> &&
  export BROWSERSTACK_ACCESS_KEY=<browserstack-access-key>
  ```
* To run more tests in parallel, you will need to use a runner/VS plugin like [ReSharper](https://www.jetbrains.com/resharper/)

## Additional Resources
* [Documentation for writing automate test scripts in C#](https://www.browserstack.com/automate/c-sharp)
* [Customizing your tests on BrowserStack](https://www.browserstack.com/automate/capabilities)
* [Browsers & mobile devices for selenium testing on BrowserStack](https://www.browserstack.com/list-of-browsers-and-platforms?product=automate)
* [Using REST API to access information about your tests via the command-line interface](https://www.browserstack.com/automate/rest-api)
