using Meadow.Devices;
using Meadow.Foundation.Graphics;
using Meadow.Foundation.Sensors.Atmospheric;
using Meadow.Peripherals.Leds;

namespace Meadow.Cloud_Logging.Hardware
{
    internal class MeadowCloudLoggingHardware : IMeadowCloudLoggingHardware
    {
        protected IProjectLabHardware ProjLab { get; private set; }

        public IGraphicsDisplay Display { get; set; }

        public Bme68x EnvironmentalSensor { get; set; }

        public IRgbPwmLed RgbPwmLed { get; set; }

        public void Initialize()
        {
            ProjLab = ProjectLab.Create();

            Display = ProjLab.Display;

            RgbPwmLed = ProjLab.RgbLed;

            EnvironmentalSensor = ProjLab.EnvironmentalSensor;
        }
    }
}