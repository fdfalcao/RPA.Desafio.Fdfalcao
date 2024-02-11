using RPA.Desafio.Fdfalcao.Utils.DBA;
using RPA.Desafio.Fdfalcao.Utils.Dominio.Driver;
using RPA.Desafio.Fdfalcao.Utils.Dominio.RPA;

namespace RPA.Desafio.Fdfalcao.Aplicacao
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private IServiceProvider _serviceProvider;

        public Worker(ILogger<Worker> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    /// <summary>
                    /// Serviço desenvolvido para o Desafio RPA
                    /// 
                    /// Visual Studio com Selenium
                    /// Banco de Dados Postgres
                    /// 
                    /// Ele irá acessar o site 10fastfingers e realizar o teste da digitação das
                    /// palavras por 1 minuto. Após a conclusão, armazenará o resultado em banco.
                    /// 
                    /// Os scripts para criação do Banco de Dados se encontram em Utils/DBA/Scripts
                    /// </summary>
                    ExecutaServico();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"ERRO -> {ex.Message}");
            }

            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await Task.Delay(1000, stoppingToken);
        }

        public async void ExecutaServico()
        {
            using IServiceScope scope = _serviceProvider.CreateScope();

            IChromeDriver _chrome = scope.ServiceProvider.GetRequiredService<IChromeDriver>();
            IDesafioRPA _desafioRPA = scope.ServiceProvider.GetRequiredService<IDesafioRPA>();

            var driver = _chrome.IniciarChromeDriver();
            if (driver == null)
                await Task.Delay(TimeSpan.FromSeconds(30));
            else
            {
                var resultado = _desafioRPA.DigitarPalavras(driver);

                if (resultado != null)
                    ProcessaDadosControll.InsereResultado(resultado);
            }

            _chrome.FinalizarChromeDriver();
        }
    }
}
