using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Test1
{
    public enum TypeOfMessage
    {
        Success,
        Warning,
        Error,
    }
    class LoadingScreen
    {
        static LoadingWindowForm sf = null;
        public static void ShowSplashScreen()
        {
            if (sf == null)
            {
                sf = new LoadingWindowForm();
                sf.StartPosition = FormStartPosition.CenterScreen;
                sf.ShowSplashScreen();
            }
        }
        public static void CloseSplashScreen()
        {
            if (sf != null)
            {
                sf.CloseSplashScreen();
                sf = null;
            }
        }

        public static void UpdateStatusText(string Text,TypeOfMessage tom)
        {
            if (sf != null)
                sf.UpdateStatusTextWithStatus(Text, tom);
        }


    }
}
