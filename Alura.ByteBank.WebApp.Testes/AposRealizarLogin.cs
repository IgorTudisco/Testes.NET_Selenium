using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Alura.ByteBank.WebApp.Testes
{
    public class AposRealizarLogin
    {

        [Fact]
        public void TentaAcessarPaginaDeContaCorrenteSemEstarLogado()
        {
            //Arrange
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            //Act
            driver.Navigate().GoToUrl("https://localhost:44309/ContaCorrente/Index");

            //Assert
            Assert.Contains("https://localhost:44309/ContaCorrente/Index", driver.Url);
            Assert.Contains("401", driver.PageSource);
            driver.Close();
        }

        [Fact]
        public void TentaAcessarPaginaDeAgenciaSemEstarLogado()
        {
            //Arrange
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            //Act
            driver.Navigate().GoToUrl("https://localhost:44309/Agencia/Index");

            //Assert
            Assert.Contains("https://localhost:44309/Agencia/Index", driver.Url);
            Assert.Contains("401", driver.PageSource);
            driver.Close();
        }

        [Fact]
        public void TentaAcessarPaginaDeClienteSemEstarLogado()
        {
            //Arrange
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            //Act
            driver.Navigate().GoToUrl("https://localhost:44309/Clientes/Index");

            //Assert
            Assert.Contains("https://localhost:44309/Clientes/Index", driver.Url);
            Assert.Contains("401", driver.PageSource);
            driver.Close();
        }

        [Fact]
        public void TesteValidaPaginaDeContaCorrente()
        {
            //Arrange
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            var navigate = driver.Navigate();
            navigate.GoToUrl("https://localhost:44309/");

            var login = driver.FindElement(By.LinkText("Login"));
            login.Click();

            var email = driver.FindElement(By.Id("Email"));
            email.Click();

            var sendEmail = driver.FindElement(By.Id("Email"));
            sendEmail.SendKeys("andre@email.com");

            var senha = driver.FindElement(By.Id("Senha"));
            senha.Click();

            var sendSenha = driver.FindElement(By.Id("Senha"));
            sendSenha.SendKeys("senha01");

            var logar = driver.FindElement(By.Id("btn-logar"));
            logar.Click();

            //Act
            navigate.GoToUrl("https://localhost:44309/ContaCorrentes/Index");

            //Assert
            Assert.Contains("https://localhost:44309/ContaCorrentes/Index", driver.Url);
            Assert.Contains("Contas Correntes", driver.Title);
            Assert.Contains("Editar", driver.PageSource);
            Assert.Contains("Detalhes", driver.PageSource);
            Assert.Contains("Excluir", driver.PageSource);
            driver.Close();
        }

        [Fact]
        public void TesteValidaPaginaDeCliente()
        {
            //Arrange
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            var navigate = driver.Navigate();
            navigate.GoToUrl("https://localhost:44309/");

            var login = driver.FindElement(By.LinkText("Login"));
            login.Click();

            var email = driver.FindElement(By.Id("Email"));
            email.Click();

            var sendEmail = driver.FindElement(By.Id("Email"));
            sendEmail.SendKeys("andre@email.com");

            var senha = driver.FindElement(By.Id("Senha"));
            senha.Click();

            var sendSenha = driver.FindElement(By.Id("Senha"));
            sendSenha.SendKeys("senha01");

            var logar = driver.FindElement(By.Id("btn-logar"));
            logar.Click();

            //Act
            navigate.GoToUrl("https://localhost:44309/Clientes/Index");

            //Assert
            Assert.Contains("https://localhost:44309/Clientes/Index", driver.Url);
            driver.Close();
        }

        [Fact]
        public void TesteValidaPaginaDeAgencia()
        {
            //Arrange
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            var navigate = driver.Navigate();
            navigate.GoToUrl("https://localhost:44309/");

            var login = driver.FindElement(By.LinkText("Login"));
            login.Click();

            var email = driver.FindElement(By.Id("Email"));
            email.Click();

            var sendEmail = driver.FindElement(By.Id("Email"));
            sendEmail.SendKeys("andre@email.com");

            var senha = driver.FindElement(By.Id("Senha"));
            senha.Click();

            var sendSenha = driver.FindElement(By.Id("Senha"));
            sendSenha.SendKeys("senha01");

            var logar = driver.FindElement(By.Id("btn-logar"));
            logar.Click();

            //Act
            navigate.GoToUrl("https://localhost:44309/Agencia/Index");

            //Assert
            Assert.Contains("https://localhost:44309/Agencia/Index", driver.Url);
            driver.Close();
        }

    }
}
