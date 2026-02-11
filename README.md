# Demo Web Shop Automation Testing

This project is an automated testing framework for the public demo e-commerce site:  
**http://demowebshop.tricentis.com/**

## What the project does

The framework tests the most common user flows on a typical online store:

- User registration
- Successful & failed login scenarios
- Logout functionality
- Product search
- Adding product to cart
- Removing product from cart

All tests are independent, use explicit waits, and follow Page Object Model (POM) pattern.

## Technologies used

- **Language & Framework**: C# / .NET 10.0
- **Test Runner**: NUnit 4.4.0
- **Browser Automation**: Selenium WebDriver 4.40.0
- **Waits & Helpers**: Selenium.Support 4.40.0
- **IDE**: Visual Studio 2026
- **Browser**: Google Chrome

## Project features

- **Page Object Model** implementation — each page has its own class with locators and actions
- Shared **BaseTest** class that handles:
  - ChromeDriver initialization
  - Navigation to base URL
  - Common 'Wait' property
- All test classes inherit from 'BaseTest' → no code duplication for setup/teardown
- Random email generation in registration → no hard-coded users

## How to run

1. Open solution in Visual Studio 2026
2. Restore NuGet packages
3. Build → Rebuild Solution
4. Open **Test Explorer** (Test → Test Explorer)
5. Run All or select specific tests

Tests require internet connection and installed Chrome browser.

---
Methods and Techniques of Software Testing  
