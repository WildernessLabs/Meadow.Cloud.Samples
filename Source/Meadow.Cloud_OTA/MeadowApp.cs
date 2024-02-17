using Meadow.Cloud_OTA.Hardware;
using Meadow.Devices;
using Meadow.Hardware;
using System.Threading.Tasks;

namespace Meadow.Cloud_OTA
{
    public class MeadowApp : App<F7CoreComputeV2>
    {
        /*
        
        OTA instructions:

        1. Bump VERSION value below

        2. In a Terminal (in .csproj folder), type: 

            meadow cloud package create

        3. In a Terminal (in \bin\Release\netstandard2.1\mpak)

            meadow cloud package upload <filename.mpak>

        4. Go to Meadow.Cloud site -> Packages, click Publish on the .mpak uploaded

        */

        public double VERSION { get; set; } = 1.0;

        MainController mainController;

        public override Task Initialize()
        {
            Resolver.Log.Info("Initialize...");

            var hardware = new MeadowCloudOtaHardware();
            var network = Device.NetworkAdapters.Primary<IWiFiNetworkAdapter>();

            mainController = new MainController(hardware, network);
            mainController.Initialize();

            return Task.CompletedTask;
        }

        public override Task Run()
        {
            Resolver.Log.Info("Run...");

            mainController.Run();

            return Task.CompletedTask;
        }
    }
}