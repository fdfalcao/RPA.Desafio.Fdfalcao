using OpenQA.Selenium;
using RPA.Desafio.Fdfalcao.Utils.Dominio.Entidade;

namespace RPA.Desafio.Fdfalcao.Utils.Dominio.RPA
{
    public interface IDesafioRPA
    {
        public ResultadoEntidade DigitarPalavras(IWebDriver driver);
    }
}
