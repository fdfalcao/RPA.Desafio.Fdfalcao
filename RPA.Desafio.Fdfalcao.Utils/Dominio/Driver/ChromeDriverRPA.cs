using Microsoft.Extensions.Logging;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Diagnostics;
using System.Reflection;
using RPA.Desafio.Fdfalcao.Utils.Dominio.RPA;

namespace RPA.Desafio.Fdfalcao.Utils.Dominio.Driver
{
    public class ChromeDriverRPA : IChromeDriver
    {
        private IWebDriver _driver;
        private ILogger<DesafioRPA> _logger;
        public ChromeDriverRPA(ILogger<DesafioRPA> logger)
        {
            _logger = logger;
        }
        public IWebDriver IniciarChromeDriver()
        {
            try
            {
                FinalizarPocessoChrome();

                ChromeOptions options = new()
                {
                    PageLoadStrategy = PageLoadStrategy.Normal
                };

                options.AddArgument("no-sandbox");
                options.AddArgument("--profile-directory=Default");
                options.AddArgument("--disable-web-security");
                options.AddArgument("--disable-gpu");
                options.AddArgument("--start-maximized");

                options.AddExcludedArgument("enable-logging");

                options.Proxy = new Proxy { Kind = ProxyKind.System };

                _driver = new OpenQA.Selenium.Chrome.ChromeDriver(options);

                _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(300);

                return _driver;
            }
            catch (Exception ex)
            {
                throw new Exception($"{MethodBase.GetCurrentMethod()?.Name} -> {ex.Message}");
            }
        }
        public void FinalizarChromeDriver()
        {
            try
            {
                _driver?.Dispose();
            }
            catch
            {
            }
        }
        private void FinalizarPocessoChrome()
        {
            try
            {
                var listDrivers = Process.GetProcessesByName("chromedriver");

                foreach (var driver in listDrivers)
                {
                    driver.Kill(true);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ERRO: could not stopted drivers");
            }
        }
    }
}
