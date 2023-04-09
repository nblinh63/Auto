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
using System.Collections;
using System.Threading;

namespace WpfAppHelloWorld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private List<string>? devices = null;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void showAllDevices()
        {
            ADBHelper.SetADBFolderPath("C:\\Users\\nguye\\source\\repos\\WpfAppHelloWorld\\WpfAppHelloWorld\\bin\\Debug\\net6.0-windows");

            devices = ADBHelper.GetDevices();
            string devicesName = "";
            devices?.ForEach(device =>
            {
                devicesName += device + "\r";
            });
            txtblDevicesName.Text = devicesName;
        }

        private void applyProxy()
        {

        }

        private void inputText()
        {
            string[] content = tbContent.Text.Split(new char[] { '\n', });
            if (devices != null && devices.Count > 0 && devices.Count <= content.Length)
            {
                Task.Run(() =>
                {
                    for (int i = 0; i < devices.Count; i++)
                    {
                        ADBHelper.TapByPercent(devices[i], 15.9, 17.6);
                    }

                    Task.Delay(3000);

                    for (int i = 0; i < devices.Count; i++)
                    {
                        ADBHelper.TapByPercent(devices[i], 23.5, 8.3);
                    }

                    Task.Delay(1000);


                    for (int i = 0; i < devices.Count; i++)
                    {
                        ADBHelper.InputText(devices[i], content[i]);
                    }
                });
              
                   

               
            }
        }

        private void generateToken()
        {

        }

        private void copyToken()
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            showAllDevices();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            inputText();
        }



        /*     public void OpenFileDialogForm()
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
                    *//* ADBHelper.SetADBFolderPath("C:\\Users\\nguye\\source\\repos\\WpfAppHelloWorld\\WpfAppHelloWorld\\bin\\Debug\\net6.0-windows");
                      var listDevice = ADBHelper.GetDevices();
                     if (listDevice != null && listDevice.Count > 0)
                     {
                         deviceID = listDevice.First();
                         ADBHelper.TapByPercent(deviceID, 22.5, 41.7);
                     }*//*

                 }
             }*/

    }
}
