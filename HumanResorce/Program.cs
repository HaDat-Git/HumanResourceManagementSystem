using System;
using System.Windows.Forms;
using System.Threading;

namespace HumanResorce
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            // Hiển thị SplashForm
            SplashForm splash = new SplashForm();
            splash.Show();
            Application.DoEvents(); // Cho phép UI vẽ xong

            // Chờ vài giây
            Thread.Sleep(3000);

            splash.Close(); // Đóng splash
            Application.Run(new MainForm());
        }
    }
}
