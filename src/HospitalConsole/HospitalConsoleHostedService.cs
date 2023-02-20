using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Hospital.EntityFrameworkcore;
using Microsoft.Extensions.Hosting;
using Volo.Abp;

namespace HospitalConsole;

public class HospitalConsoleHostedService : IHostedService
{
    private readonly IAbpApplicationWithExternalServiceProvider _abpApplication;
    private readonly HelloWorldService _helloWorldService;

    public HospitalConsoleHostedService(HelloWorldService helloWorldService, IAbpApplicationWithExternalServiceProvider abpApplication)
    {
        _helloWorldService = helloWorldService;
        _abpApplication = abpApplication;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        HospitalDbContext dbobj = new HospitalDbContext();
        await _helloWorldService.SayHelloAsync();
        await _helloWorldService.InsertPatientData();
        if(dbobj.Appusertable.Count() == 0)
        {
        await _helloWorldService.InsertAdminData();
        }
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await _abpApplication.ShutdownAsync();
    }
}
