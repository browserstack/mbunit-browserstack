# MBUnit-Browserstack

Execute [MBUnit-V3](https://github.com/Gallio/mbunit-v3) scripts on BrowserStack.

## Usage

### Prerequisites

Visual Studio 2010 SP1

### Clone the repo

`git clone https://github.com/browserstack/mbunit-browserstack.git`

### Install dependencies

Open the appropriate Visual Studio Solution file (.sln) and run `build`.
Visual Studio will automatically download the dependencies

### BrowserStack Authentication

To run the tests, `BROWSERSTACK_USERNAME` and `BROWSERSTACK_ACCESS_KEY` needs to be replaced with BrowserStack authentication.
These can be found on the automate accounts page on [BrowserStack](https://www.browserstack.com/accounts/automate)

These needs to be changed in the following files -

```
MBUnit-BrowserStack/MBUnit_BrowserStack.cs
MBUnit-BrowserStack/MBUnit_BrowserStack_Local.cs
```

### Run the tests

The `MBUnit` dependency provides a way to test from Visual Studio itself.
Just build the solution and, to run the tests -
Go to the `tests` menu -> In the `Run` sub-menu -> Click `All tests`

To run the tests in parallel, you will need to use a runner/VS plugin like [ReSharper](https://www.jetbrains.com/resharper/)

------

#### How to specify the capabilities

The [Code Generator](https://www.browserstack.com/automate/c-sharp#setting-os-and-browser) can come in very handy when specifying the capabilities especially for mobile devices.
