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
using Alura.ByteBank.WebApp.Testes.Utilities;
using Alura.ByteBank.WebApp.Testes.PageObjects;

namespace Alura.ByteBank.WebApp.Testes
{
    public class AposRealizarLogin : IClassFixture<Manager>
    {
        private IWebDriver driver;
        public ITestOutputHelper SaidaConsoleTeste;

        public AposRealizarLogin(Manager _manager,ITestOutputHelper _saidaConsoleTeste)
        {
            // Arrange
            driver = _manager.Driver;
            SaidaConsoleTeste = _saidaConsoleTeste;
        }

        [Fact]
        public void TentaAcessarPaginaDeContaCorrenteSemEstarLogado()
        {
            // Arrange
            var loginPO = new LoginPO(driver);

            // Act        
            loginPO.Navegar("https://localhost:44309/ContaCorrente/Index");

            // Assert
            Assert.Contains("https://localhost:44309/ContaCorrente/Index", driver.Url);
            Assert.Contains("401", driver.PageSource);
            
        }

        [Fact]
        public void TentaAcessarPaginaDeAgenciaSemEstarLogado()
        {
            // Arrange
            var loginPO = new LoginPO(driver);

            // Act
            loginPO.Navegar("https://localhost:44309/Agencia/Index");

            // Assert
            Assert.Contains("https://localhost:44309/Agencia/Index", driver.Url);
            Assert.Contains("401", driver.PageSource);
            
        }

        [Fact]
        public void TentaAcessarPaginaDeClienteSemEstarLogado()
        {
            // Arrange
            var loginPO = new LoginPO(driver);

            // Act
            loginPO.Navegar("https://localhost:44309/Clientes/Index");

            // Assert
            Assert.Contains("https://localhost:44309/Clientes/Index", driver.Url);
            Assert.Contains("401", driver.PageSource);
            
        }

        [Fact]
        public void TesteValidaPaginaDeContaCorrente()
        {
            //Arrange

            var loginPO = new LoginPO(driver);
            loginPO.Navegar("https://localhost:44309/UsuarioApps/Login");
            loginPO.PreencherCampos("andre@email.com", "senha01");
            loginPO.Logar();

            //Act
            loginPO.Navegar("https://localhost:44309/ContaCorrentes/Index");

            //Assert
            Assert.Contains("https://localhost:44309/ContaCorrentes/Index", driver.Url);
            Assert.Contains("Contas Correntes", driver.Title);
            Assert.Contains("Editar", driver.PageSource);
            Assert.Contains("Detalhes", driver.PageSource);
            Assert.Contains("Excluir", driver.PageSource);

        }

        [Fact]
        public void TesteValidaPaginaDeCliente()
        {
            //Arrange

            var loginPO = new LoginPO(driver);
            loginPO.Navegar("https://localhost:44309/UsuarioApps/Login");
            loginPO.PreencherCampos("andre@email.com", "senha01");
            loginPO.Logar();

            //Act
            loginPO.Navegar("https://localhost:44309/Clientes/Index");

            //Assert
            Assert.Contains("https://localhost:44309/Clientes/Index", driver.Url);

        }

        [Fact]
        public void TesteValidaPaginaDeAgencia()
        {
            //Arrange

            var loginPO = new LoginPO(driver);
            loginPO.Navegar("https://localhost:44309/UsuarioApps/Login");
            loginPO.PreencherCampos("andre@email.com", "senha01");
            loginPO.Logar();

            //Act
            loginPO.Navegar("https://localhost:44309/Agencia/Index");

            //Assert
            Assert.Contains("https://localhost:44309/Agencia/Index", driver.Url);

        }

        [Fact]
        public void TesteRealizaLoginAcessaListagemDeContas()
        {
            // Arrange
            var loginPO = new LoginPO(driver);
            loginPO.Navegar("https://localhost:44309/UsuarioApps/Login");
            loginPO.PreencherCampos("andre@email.com", "senha01");
            loginPO.Logar();

            var homePO = new HomePO(driver);
            homePO.LinkContaCorrenteClick();

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


        }

    }
}
