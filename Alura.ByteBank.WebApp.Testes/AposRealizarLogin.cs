using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using System.Reflection.Metadata;

namespace Alura.ByteBank.WebApp.Testes
{
    public class AposRealizarLogin
    {
        private IWebDriver driver;
        public ITestOutputHelper SaidaConsoleTeste;

        public AposRealizarLogin(ITestOutputHelper _saidaConsoleTeste)
        {
            // Arrange
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            SaidaConsoleTeste = _saidaConsoleTeste;
        }

        [Fact]
        public void TentaAcessarPaginaDeContaCorrenteSemEstarLogado()
        {
            // Act
            driver.Navigate().GoToUrl("https://localhost:44309/ContaCorrente/Index");

            // Assert
            Assert.Contains("https://localhost:44309/ContaCorrente/Index", driver.Url);
            Assert.Contains("401", driver.PageSource);
            driver.Close();
        }

        [Fact]
        public void TentaAcessarPaginaDeAgenciaSemEstarLogado()
        {
            // Act
            driver.Navigate().GoToUrl("https://localhost:44309/Agencia/Index");

            // Assert
            Assert.Contains("https://localhost:44309/Agencia/Index", driver.Url);
            Assert.Contains("401", driver.PageSource);
            driver.Close();
        }

        [Fact]
        public void TentaAcessarPaginaDeClienteSemEstarLogado()
        {
            // Act
            driver.Navigate().GoToUrl("https://localhost:44309/Clientes/Index");

            // Assert
            Assert.Contains("https://localhost:44309/Clientes/Index", driver.Url);
            Assert.Contains("401", driver.PageSource);
            driver.Close();
        }

        [Fact]
        public void TesteValidaPaginaDeContaCorrente()
        {
            //Arrange
            
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

        [Fact]
        public void TesteRealizaLoginAcessaListagemDeContas()
        {
            // Arrange
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

            driver.FindElement(By.Id("contacorrente")).Click();

            IReadOnlyCollection<IWebElement> elements = driver.FindElements(By.TagName("a"));

            // Other ways to find an element
            // IReadOnlyCollection<IWebElement> divs = driver.FindElements(By.TagName("div"));
            // IReadOnlyCollection<IWebElement> inputs = driver.FindElements(By.TagName("input"));
            // IReadOnlyCollection<IWebElement> labels = driver.FindElements(By.TagName("label"));

            var elemento = (from webElement in elements
                            where webElement.Text.Contains("Detalhes")
                            select webElement).First();

            // Act
            elemento.Click();

            // Assert
            Assert.Contains("Voltar", driver.PageSource);

            driver.FindElement(By.CssSelector(".btn-secondary")).Click();
            Assert.Contains("https://localhost:44309/ContaCorrentes/Index", driver.Url);
            driver.Close();

        }

    }
}
