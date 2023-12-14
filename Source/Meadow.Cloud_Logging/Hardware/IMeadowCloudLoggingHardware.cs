using Meadow.Foundation.Graphics;
using Meadow.Foundation.Sensors.Atmospheric;
using Meadow.Peripherals.Leds;

namespace Meadow.Cloud_Logging.Hardware
{
    internal interface IMeadowCloudLoggingHardware
    {
        public IGraphicsDisplay Display { get; }

        public Bme68x EnvironmentalSensor { get; }

        public IRgbPwmLed RgbPwmLed { get; }

        public void Initialize();
    }
}