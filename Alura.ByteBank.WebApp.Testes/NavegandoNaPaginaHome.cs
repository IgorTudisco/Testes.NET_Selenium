using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Alura.ByteBank.WebApp.Testes
{
    public class NavegandoNaPaginaHome
    {
        private IWebDriver driver;
        public ITestOutputHelper SaidaConsoleTeste;

        public NavegandoNaPaginaHome(ITestOutputHelper _saidaConsoleTeste)
        {
            // Arrange
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            SaidaConsoleTeste = _saidaConsoleTeste;
        }

        [Fact]
        public void CarregarPaginaHomeEVerificarTituloDaPagina()
        {
            // Act
            driver.Navigate().GoToUrl("https://localhost:44309/");
            // Assert
            Assert.Contains("WebApp", driver.Title);
            driver.Close();
        }

        [Fact]
        public void CarregadaPaginaHomeVerificaExistenciaLinkLoginEHome()
        {
            // Act
            driver.Navigate().GoToUrl("https://localhost:44309/");
            // Assert
            Assert.Contains("Login", driver.PageSource);
            Assert.Contains("Home", driver.PageSource);
            driver.Close();
        }

        // Method created by Selenium
        [Fact]
        public void LogandoNoSistema()
        {
            driver.Navigate().GoToUrl("https://localhost:44309/");
            driver.Manage().Window.Size = new System.Drawing.Size(1920, 1040);
            driver.FindElement(By.LinkText("Login")).Click();
            driver.FindElement(By.Id("Email")).Click();
            driver.FindElement(By.Id("Email")).SendKeys("andre@email.com");
            driver.FindElement(By.Id("Senha")).Click();
            driver.FindElement(By.Id("Senha")).SendKeys("senha01");
            driver.FindElement(By.Id("btn-logar")).Click();
            driver.FindElement(By.CssSelector(".btn")).Click();
            driver.Close();
        }

        [Fact]
        public void ValidaLinkDeLoginNaHome()
        {
            driver.Navigate().GoToUrl("https://localhost:44309/");

            // FindElement(By. element type ("the element name") identifies an html element on the page.
            var linkLogin = driver.FindElement(By.LinkText("Login"));

            linkLogin.Click();

            Assert.Contains("img", driver.PageSource);
            driver.Close();
        }

    }
}
