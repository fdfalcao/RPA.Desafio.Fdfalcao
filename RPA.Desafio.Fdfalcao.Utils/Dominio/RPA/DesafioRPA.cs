using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using RPA.Desafio.Fdfalcao.Utils.Dominio.Entidade;
using System.Reflection;

namespace RPA.Desafio.Fdfalcao.Utils.Dominio.RPA
{
    public class DesafioRPA : IDesafioRPA
    {
        private ILogger<DesafioRPA> _logger;

        public DesafioRPA(ILogger<DesafioRPA> logger, IConfiguration configuration)
        {
            _logger = logger;
        }

        public ResultadoEntidade DigitarPalavras(IWebDriver driver)
        {
            try
            {
                driver.Navigate().GoToUrl($"https://10fastfingers.com/typing-test/portuguese");

                string tempo = ObterElemento(driver, By.Id("timer"));
                while (tempo != "0:00")
                {
                    try
                    {
                        var palavraSelecionada = ObterElemento(driver, By.ClassName("highlight"));
                        if (palavraSelecionada != null && palavraSelecionada != "")
                            driver.FindElement(By.Id("inputfield")).SendKeys(palavraSelecionada + " ");

                        tempo = ObterElemento(driver, By.Id("timer"));

                        // Nos testes do desenvolvimento foi observado que, por ser muito rápido,
                        // chegava uma hora que o programa apresentava erro pois não tínhamos mais
                        // palavras com "highlight". Foi checado a propriedade "::after" porém, sem 
                        // sucesso (mesmo em testes manuais no site). Sendo assim, para não corrermos
                        // o risco de chegar no máximo de palavras (aproximadamente 400 palavras) foi
                        // inserido o sleep abaixo.
                        Thread.Sleep(60);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, $"ERRO: {ex.Message}");
                    }
                }

                ResultadoEntidade resultado = ResultadoConsulta(driver);
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception($"{MethodBase.GetCurrentMethod()?.Name} -> {ex.Message}");
            }
        }

        public string ObterElemento(IWebDriver driver, By selector)
        {
            try
            {
                IWebElement element = driver.FindElement(selector);
                return element.Text ?? "";
            }
            catch (NoSuchElementException)
            {
                return "";
            }
        }

        private ResultadoEntidade ResultadoConsulta(IWebDriver driver)
        {
            try
            {
                string wpm = driver.FindElement(By.Id("wpm")).FindElement(By.TagName("strong")).Text;
                int qtdePalavras = int.Parse(driver.FindElement(By.Id("keystrokes")).FindElement(By.ClassName("correct")).Text);
                string precisao = driver.FindElement(By.Id("accuracy")).FindElement(By.TagName("strong")).Text;
                int qtdePalavrasCorretas = int.Parse(driver.FindElement(By.Id("correct")).FindElement(By.TagName("strong")).Text);
                int qtdePalavrasIncorretas = int.Parse(driver.FindElement(By.Id("wrong")).FindElement(By.TagName("strong")).Text);

                ResultadoEntidade resultado = new ResultadoEntidade(wpm, qtdePalavras, precisao, qtdePalavrasCorretas, qtdePalavrasIncorretas);

                return resultado;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"{ex.Message}");
                return null;
            }
        }
    }
}
