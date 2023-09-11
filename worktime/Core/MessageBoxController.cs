using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Worktime.Core
{
    static class MessageBoxController
    {
        public static void ShowSuccess(string msg, string caption = "Siker")
        {
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Information;

            MessageBox.Show(msg, caption, button, icon, MessageBoxResult.OK);
        }

        public static void ShowFail(string msg, string caption = "Hiba")
        {
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Error;

            MessageBox.Show(msg, caption, button, icon, MessageBoxResult.OK);
        }
    }
}
