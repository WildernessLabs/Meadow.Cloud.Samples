﻿using Meadow.Devices;
using Meadow.Peripherals.Displays;
using Meadow.Peripherals.Leds;

namespace Meadow.Cloud_OTA.Hardware
{
    internal class MeadowCloudOtaHardware : IMeadowCloudOtaHardware
    {
        protected ProjectLabHardwareBase ProjectLab { get; private set; }

        public IPixelDisplay Display { get; set; }

        public IRgbPwmLed RgbPwmLed { get; set; }

        public void Initialize()
        {
            ProjectLab = Devices.ProjectLab.Create() as ProjectLabHardwareBase;

            Display = ProjectLab.Display;

            RgbPwmLed = ProjectLab.RgbLed;
        }
    }
}