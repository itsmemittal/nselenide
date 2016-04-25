using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nselenide;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ConsoleApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Selenide selenide = new Selenide();
            selenide.Open("http://www.google.com");
            selenide.Element(By.Id("btn")).Click();
            
        }
    }
}