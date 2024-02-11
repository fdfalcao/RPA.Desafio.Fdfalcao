using OpenQA.Selenium.Chrome;
using RPA.Desafio.Fdfalcao.Aplicacao;
using RPA.Desafio.Fdfalcao.Utils.Dominio.Driver;
using RPA.Desafio.Fdfalcao.Utils.Dominio.RPA;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddScoped<IChromeDriver, ChromeDriverRPA>();
        services.AddScoped<IDesafioRPA, DesafioRPA>();
        services.AddHostedService<Worker>();
    })
    .Build();

host.Run();
