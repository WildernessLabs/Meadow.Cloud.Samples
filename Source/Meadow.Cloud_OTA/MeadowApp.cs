using Meadow.Devices;
using Meadow.Update;
using System.Threading.Tasks;

namespace Meadow.Cloud_OTA
{
    public class MeadowApp : App<F7CoreComputeV2>
    {
        IProjectLabHardware projectLab;

        public override Task Initialize()
        {
            Resolver.Log.Info("Initialize...");

            projectLab = ProjectLab.Create();

            projectLab.RgbLed.StartBlink(Color.Green);

            return Task.CompletedTask;
        }

        public override Task Run()
        {
            Resolver.Log.Info("Run...");

            var svc = Resolver.Services.Get<IUpdateService>() as UpdateService;
            svc.ClearUpdates(); // uncomment to clear persisted info

            svc.OnUpdateAvailable += (updateService, info) =>
            {
                projectLab.RgbLed.StartBlink(Color.Orange);
                Resolver.Log.Info("Update available!");

                Task.Run(async () =>
                {
                    await Task.Delay(5000);
                    updateService.RetrieveUpdate(info);
                });
            };

            svc.OnUpdateRetrieved += (updateService, info) =>
            {
                projectLab.RgbLed.StartBlink(Color.Yellow);
                Resolver.Log.Info("Update retrieved!");

                Task.Run(async () =>
                {
                    await Task.Delay(5000);
                    updateService.ApplyUpdate(info);
                });
            };

            return Task.CompletedTask;
        }
    }
}