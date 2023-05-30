using Microsoft.AspNetCore.Mvc.Razor;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.ByteBank.WebApp.Testes.Utilities
{
    public class Manager : IDisposable
    {
        public IWebDriver Driver { get; private set; }

        public Manager()
        {
            Driver = new ChromeDriver(Useful.CaminhoDriverNavegador());
        }

        public void Dispose()
        {
            Driver.Quit();
        }
    }
}
