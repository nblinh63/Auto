using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using KAutoHelper;

namespace WpfAppHelloWorld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           // Process.Start(new ProcessStartInfo { FileName = @"C:\LDPlayer\ldmutiplayer\dnmultiplayerex.exe", UseShellExecute = true });
           OpenFileDialogForm();


        }

        public void OpenFileDialogForm()
        {
            string defaultPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {

                InitialDirectory = @defaultPath,
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "csv",
                Filter = "files (*.csv)|*.csv",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == true)
            {
                string sSelectedPath = openFileDialog1.FileNames.First();
                //txtFileName.Content = sSelectedPath;
                string deviceID = "";
               /* ADBHelper.SetADBFolderPath("C:\\Users\\nguye\\source\\repos\\WpfAppHelloWorld\\WpfAppHelloWorld\\bin\\Debug\\net6.0-windows");
                 var listDevice = ADBHelper.GetDevices();
                if (listDevice != null && listDevice.Count > 0)
                {
                    deviceID = listDevice.First();
                    ADBHelper.TapByPercent(deviceID, 22.5, 41.7);
                }*/

            }
        }
    }
}
