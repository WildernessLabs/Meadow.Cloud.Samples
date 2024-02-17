using Meadow.Cloud_OTA.Controllers;
using Meadow.Cloud_OTA.Hardware;
using Meadow.Hardware;
using Meadow.Update;
using System.Threading.Tasks;

namespace Meadow.Cloud_OTA
{
    internal class MainController
    {
        IMeadowCloudOtaHardware hardware;
        IWiFiNetworkAdapter network;
        DisplayController displayController;

        public MainController(IMeadowCloudOtaHardware hardware, IWiFiNetworkAdapter network)
        {
            this.hardware = hardware;
            this.network = network;
        }

        public void Initialize()
        {
            hardware.Initialize();

            displayController = new DisplayController(hardware.Display);
        }

        public Task Run()
        {
            var svc = Resolver.Services.Get<IUpdateService>() as UpdateService;
            svc.ClearUpdates(); // uncomment to clear persisted info

            svc.OnStateChanged += Svc_OnStateChanged;

            svc.OnUpdateAvailable += SvcOnUpdateAvailable;

            svc.OnUpdateRetrieved += Svc_OnUpdateRetrieved;

            return Task.CompletedTask;
        }

        private void Svc_OnStateChanged(object sender, UpdateState e)
        {
            displayController.UpdateStatus($"{e}");
        }

        private async void SvcOnUpdateAvailable(IUpdateService updateService, UpdateInfo info)
        {
            _ = hardware.RgbPwmLed.StartBlink(Color.Orange);
            displayController.UpdateStatus("Update available!");

            await Task.Delay(5000);
            updateService.RetrieveUpdate(info);
        }

        private async void Svc_OnUpdateRetrieved(IUpdateService updateService, UpdateInfo info)
        {
            _ = hardware.RgbPwmLed.StartBlink(Color.Yellow);
            displayController.UpdateStatus("Update retrieved!");

            await Task.Delay(5000);
            updateService.ApplyUpdate(info);
        }
    }
}