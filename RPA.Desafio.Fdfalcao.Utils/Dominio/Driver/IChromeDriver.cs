using OpenQA.Selenium;

namespace RPA.Desafio.Fdfalcao.Utils.Dominio.Driver
{
    public interface IChromeDriver
    {
        public IWebDriver IniciarChromeDriver();
        public void FinalizarChromeDriver();
    }
}