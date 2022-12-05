using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;

namespace Assignment2
{
    class Program
    {
        static IWebDriver driver = new ChromeDriver();
        static IWebElement radioEle;
        static IWebElement suggestionsEle;
        private static ReadOnlyCollection<IWebElement> suggclass;

        public static object ObjectRepository { get; private set; }

        static void Main(string[] args)
        {
            String Url = "http://www.qaclickacademy.com/practice.php ";
            driver.Navigate().GoToUrl(Url);
            radioEle = driver.FindElement(By.ClassName("radioButton"));
            suggestionsEle = driver.FindElement(By.Id("autocomplete"));



            //function call
            //Exercise1();
            Exercise2();
            // Exercise3();
            //Exercise41();
            //Exercise4();
            //Exercise42();
            //Exercise5();
            //Exercise6();
            // Exercise7();
            // Exercise8();
            //Exercise9();

        }

        //Radio button

        public static void Exercise1()
        {
            IWebElement radio1 = driver.FindElement(By.ClassName("radioButton"));
            radio1.Click();
            Thread.Sleep(1000);
            System.Console.WriteLine("click on radio button");

            IWebElement radio2 = driver.FindElement(By.ClassName("radioButton"));
            radio1.Click();
            Thread.Sleep(1000);
            System.Console.WriteLine("click on radio button");

            IWebElement radio3 = driver.FindElement(By.ClassName("radioButton"));
            radio1.Click();
            Thread.Sleep(1000);
            System.Console.WriteLine("click on radio button");


            string[] options = { "1", "2", "3" };
            for(int i=0; i < options.Length; i++)
            {
                radioEle = driver.FindElement(By.XPath("//input[@value='radio" + options[i] + "']"));
                radioEle.Click();
                if(radioEle.GetAttribute("checked") == "true")
                {
                    Console.WriteLine("the" + (i + 1) + "radio buttons are checked");

                }
                else
                {
                    Console.WriteLine("radio buttons are not checked");
                }
                
            }
            Thread.Sleep(1000);


        
        }
        public static void Exercise2()
        {
            IWebElement suggclass = driver.FindElement(By.Id("autocomplete"));
            suggclass.Click();
            suggclass.SendKeys("United");
            IList<IWebElement> selectionbox = driver.FindElements(By.XPath("//div[@class='ui-menu-item-wrapper']"));
            foreach (var selement in selectionbox)
            {
                if (selement.Text.Contains("United States (USA)")) ;
                {
                    selement.Click();
                }
            }

 
        }
        public static void Exercise3()
        {
            IWebElement dropdown= driver.FindElement(By.Id("dropdown-class-example"));
            SelectElement down = new SelectElement(dropdown);
            dropdown.Click();
               for (int i = 1; i < 4; i++)

               {
                down.SelectByText("Option" + i + "");
                Thread.Sleep(1000);
               }
        }

        public static void Exercise41()
        {
            for (int i = 1; i <= 3; i++)
            {
                IWebElement deselect = driver.FindElement(By.XPath("//*[@id=\"checkBoxOption" + i + "\"]"));
                deselect.Click();
            }
            Thread.Sleep(2000);
            driver.Quit();
        }

        public static void Exercise4()
        {
            //string options = "1";

            IWebElement option1 = driver.FindElement(By.XPath("//*[@id=\"checkBoxOption1\"]"));
            option1.Click();
            Thread.Sleep(2000);
            option1.Click();
            IWebElement option2 = driver.FindElement(By.XPath("//*[@id=\"checkBoxOption2\"]"));
            option2.Click();
            Thread.Sleep(2000);
            option2.Click();
            IWebElement option3 = driver.FindElement(By.XPath("//*[@id=\"checkBoxOption3\"]"));
            option3.Click();
            Thread.Sleep(2000);
            option3.Click();



        }
        //check box2

        public static void Exercise42()
        {
            for (int i = 1; i <= 3; i++)
            {
                IWebElement deselect = driver.FindElement(By.XPath("//*[@id=\"checkBoxOption" + i + "\"]"));
                deselect.Click();
            }
            Thread.Sleep(3000);
            Console.WriteLine("All checkboxes are deslected");
            driver.Quit();

        }
        //switch window

        public static void Exercise5()
        {
            IWebElement switchin = driver.FindElement(By.Id("openwindow"));
            switchin.Click();
            Thread.Sleep(3000);
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles[0]);

        }
        //switch tab
        public static void Exercise6()
        {
            IWebElement switchtab = driver.FindElement(By.Id("opentab"));
            switchtab.Click();
            Thread.Sleep(3000);
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles[0]);
        }

        //switch alter
        public static void Exercise7()
        {
            IWebElement alter = driver.FindElement(By.Id("name"));
            alter.Click();
            alter.SendKeys("Prajna");
            Thread.Sleep(1000);
            IWebElement button = driver.FindElement(By.Id("alertbtn"));
            button.Click();
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(1000);


        }
        //table

        public static void Exercise8()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript(System.String.Format("window.scrollTo({0},{1})", 400, 627));
            Thread.Sleep(1000);
        }

        //mouse hover
        public static void Exercise9()
        {
            var element = driver.FindElement(By.Id("mousehover"));
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
            Thread.Sleep(2000);
            IWebElement up = driver.FindElement(By.XPath("//a[@href='#top']"));
            action.MoveToElement(element).Perform();
            up.Click();
            Thread.Sleep(2000);
        }
    }
}
