from selenium import webdriver
from selenium.webdriver.chrome.service import Service
from selenium.webdriver.common.by import By
from selenium.webdriver.chrome.options import Options
from webdriver_manager.chrome import ChromeDriverManager
import time
import unittest

class Test(unittest.TestCase):
    def setUp(self):
        options = Options()
        options.binary_location = "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe"
        self.driver = webdriver.Chrome(service=Service(ChromeDriverManager().install()), options=options)
        self.driver.implicitly_wait(30)
        self.base_url = "https://megatop.by/catalog/zhenshchiny/galantereya/sumki"
        self.verificationErrors = []
        self.accept_next_alert = True

    def test(self):
        driver = self.driver
        driver.get(self.base_url)
        time.sleep(1)
        element = driver.find_element(By.XPATH, "//*[@id=\"app\"]/div[3]/div/div/div/div/div/div/div[2]/button[1]")
        if element is not None:
            element.click()
        self.assertEqual(driver.title, "Купить сумки женские в Минске, цена")
        driver.find_element(By.CSS_SELECTOR, "button.basket").click()
        self.assertEqual(driver.title, "Купить сумки женские в Минске, цена")
        driver.get("https://megatop.by/cart")
        self.assertEqual(driver.title, "Оформление заказа MEGATOP")
        time.sleep(1)
        self.assertEqual(driver.find_element(By.CSS_SELECTOR, ".mr-3.my-auto").text, "1 шт.")

    def tearDown(self):
        self.driver.quit()
        self.assertEqual([], self.verificationErrors)

if __name__ == "__main__":
    unittest.main()
