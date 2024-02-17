using Meadow.Foundation.Graphics;
using Meadow.Foundation.Graphics.MicroLayout;
using Meadow.Peripherals.Displays;

namespace Meadow.Cloud_OTA.Controllers
{
    internal class DisplayController
    {
        private Color backgroundColor = Color.FromHex("84705B");

        private Font12x16 font12X16 = new Font12x16();

        Label status;

        public DisplayController(IPixelDisplay display)
        {
            var displayScreen = new DisplayScreen(display, RotationType._270Degrees)
            {
                BackgroundColor = backgroundColor
            };

            var logo = Image.LoadFromResource("Meadow.Cloud_OTA.Resources.img_meadow.bmp");
            displayScreen.Controls.Add(new Picture(95, 33, logo.Width, logo.Height, logo));

            displayScreen.Controls.Add(new Label(0, 127, displayScreen.Width, font12X16.Height * 2)
            {
                Text = "App v1.0",
                TextColor = Color.White,
                Font = font12X16,
                ScaleFactor = ScaleFactor.X2,
                HorizontalAlignment = HorizontalAlignment.Center
            });

            status = new Label(0, 175, displayScreen.Width, font12X16.Height)
            {
                Text = "-",
                TextColor = Color.White,
                Font = font12X16,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            displayScreen.Controls.Add(status);
        }

        public void UpdateStatus(string text)
        {
            status.Text = text;
        }
    }
}
