using OpenQA.Selenium;
using SeleniumCore;

namespace Core.Utils
{
    public class Screenshot
    {
        /// <summary>
        /// Takes screenshot and save it as jpeg file
        /// </summary>
        /// <param name="filepath"></param>
        public static void TakeScreenshot(string filepath)
        {
            var screenshot = ((ITakesScreenshot)Base.Instance).GetScreenshot();
            screenshot.SaveAsFile(filepath, ScreenshotImageFormat.Jpeg);
        }
    }
}
