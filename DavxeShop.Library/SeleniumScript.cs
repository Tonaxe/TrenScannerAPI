using DavxeShop.Models;
using System.Text;

namespace DavxeShop.Library
{
    public class SeleniumScript
    {
        private string GenerateSeleniumScript(FlightData flightData)
        {
            var scriptBuilder = new StringBuilder();

            scriptBuilder.AppendLine("from selenium import webdriver");
            scriptBuilder.AppendLine("from selenium.webdriver.common.by import By");
            scriptBuilder.AppendLine("from selenium.webdriver.common.keys import Keys");
            scriptBuilder.AppendLine("import time");

            scriptBuilder.AppendLine("driver = webdriver.Chrome()");
            scriptBuilder.AppendLine("driver.get('https://www.renfe.com/es')");

            scriptBuilder.AppendLine($"origin_input = driver.find_element(By.ID, 'origin')");
            scriptBuilder.AppendLine($"origin_input.send_keys('{flightData.Origin}')");
            scriptBuilder.AppendLine("time.sleep(2)");
            scriptBuilder.AppendLine("origin_input.send_keys(Keys.RETURN)");

            scriptBuilder.AppendLine($"destination_input = driver.find_element(By.ID, 'destination')");
            scriptBuilder.AppendLine($"destination_input.send_keys('{flightData.Destination}')");
            scriptBuilder.AppendLine("time.sleep(2)");
            scriptBuilder.AppendLine("destination_input.send_keys(Keys.RETURN)");

            scriptBuilder.AppendLine($"departure_date_input = driver.find_element(By.ID, 'first-input')");
            scriptBuilder.AppendLine($"departure_date_input.clear()");
            scriptBuilder.AppendLine($"departure_date_input.send_keys('{flightData.DepartureDate}')");

            scriptBuilder.AppendLine($"return_date_input = driver.find_element(By.ID, 'second-input')");
            scriptBuilder.AppendLine($"return_date_input.clear()");
            scriptBuilder.AppendLine($"return_date_input.send_keys('{flightData.ReturnDate}')");

            scriptBuilder.AppendLine($"passengers_input = driver.find_element(By.ID, 'passengersSelection')");
            scriptBuilder.AppendLine($"passengers_input.click()");
            scriptBuilder.AppendLine("time.sleep(1)");

            scriptBuilder.AppendLine($"adult_button = driver.find_element(By.XPATH, \"//button[contains(@aria-label, 'añadir pasajero adulto')]\"))");
            for (int i = 0; i < flightData.Adults - 1; i++)
            {
                scriptBuilder.AppendLine("adult_button.click()");
                scriptBuilder.AppendLine("time.sleep(1)");
            }

            if (flightData.Children > 0)
            {
                scriptBuilder.AppendLine($"children_button = driver.find_element(By.XPATH, \"//button[contains(@aria-label, 'añadir pasajero niño')]\"))");
                for (int i = 0; i < flightData.Children; i++)
                {
                    scriptBuilder.AppendLine("children_button.click()");
                    scriptBuilder.AppendLine("time.sleep(1)");
                }
            }

            if (flightData.Infants > 0)
            {
                scriptBuilder.AppendLine($"infants_button = driver.find_element(By.XPATH, \"//button[contains(@aria-label, 'añadir pasajero niño menor de 4 años')]\"))");
                for (int i = 0; i < flightData.Infants; i++)
                {
                    scriptBuilder.AppendLine("infants_button.click()");
                    scriptBuilder.AppendLine("time.sleep(1)");
                }
            }

            scriptBuilder.AppendLine("search_button = driver.find_element(By.ID, 'ticketSearchBt')");
            scriptBuilder.AppendLine("search_button.click()");

            scriptBuilder.AppendLine("time.sleep(5)");

            scriptBuilder.AppendLine("driver.quit()");

            return scriptBuilder.ToString();
        }
    }
}
