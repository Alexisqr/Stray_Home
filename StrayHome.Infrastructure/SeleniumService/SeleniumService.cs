using Microsoft.AspNetCore.Http;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using StrayHome.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StrayHome.Domain.DTO;
using StrayHome.Domain.Entities;
using System.Drawing;

namespace StrayHome.Infrastructure.SeleniumService
{
    public class SeleniumService : ISeleniumService
    {
        public async Task<List<MissingAnimalSeleniumDto>> DataSearch()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120);
            driver.Navigate().GoToUrl("https://happypaw.ua/ua/found?field_animal_type_target_id=All&field_locality_osm_localities%" +
                "5Btarget_id%5D=&field_locality_osm_localities%5Btarget_type%5D=osm_region&field_breed_target_id=All&field_gender_value=All&field_size_target_id=All&field_age_value=Al" +
                "l&field_found_date_value=&field_animal_id_value=&field_old_id_value=&animal_state=found&items_per_page=10");

            List<MissingAnimalSeleniumDto> advertisements = new List<MissingAnimalSeleniumDto>();
            IWebElement nextPage = null;
            IWebElement counter = driver.FindElement(By.CssSelector(".counter"));
            int value;
            int.TryParse(string.Join("", counter.Text.Where(c => char.IsDigit(c))), out value);
            int brush = 1;
            do
            {
                IReadOnlyList<IWebElement> Elements = driver.FindElements(By.ClassName("list-item"));
                foreach (IWebElement link in Elements)
                {
                    string cardUrl = link.GetAttribute("href");

                    driver.Navigate().GoToUrl(cardUrl);

                    string name = driver.FindElement(By.TagName("h1")).Text;
                    IWebElement image = driver.FindElement(By.CssSelector("img.img-fluid"));
                    string imageLink = image.GetAttribute("src");
                    var locationElements = driver.FindElements(By.CssSelector("p.osm-localities-field"));
                    string? location = locationElements.Count > 0 ? locationElements[0].Text : null;
                    IWebElement toggleElement = driver.FindElement(By.CssSelector(".animal-history-title.toggle"));
                    ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", toggleElement);
                    IWebElement divElement = driver.FindElement(By.CssSelector(".animal-history-text"));
                    string description = divElement.Text;
                    advertisements.Add(new MissingAnimalSeleniumDto { Link = cardUrl, Name = name, ImageLink = imageLink, Location = location, Description = description });
                    Console.WriteLine("Navigated to: " + driver.Url);
                    driver.Navigate().Back();
                }
                
               
                if (brush< Math.Ceiling(value / 10.0))
                {
                    nextPage = driver.FindElement(By.CssSelector("li.page-item.pager__item.pager__item--next > a.page-link"));
                    Thread.Sleep(1000);
                    string nextPageLink = nextPage.GetAttribute("href");
                    driver.Navigate().GoToUrl(nextPageLink);
                }
                
                brush++;
            } while (brush <= Math.Ceiling(value / 10.0));
            driver.Quit();
            return advertisements;
        }
    }
}
