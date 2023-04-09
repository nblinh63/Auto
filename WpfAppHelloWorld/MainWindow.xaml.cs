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
using System.Net.Http;
using OtpNet;
using System.Runtime.CompilerServices;

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
           // ADBHelper.SetADBFolderPath("\\Debug\\net6.0-windows");

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
            string[] ports = tbProxy.Text.Split(new char[] { '\n', });
            if (devices != null && devices.Count > 0 && devices.Count <= ports.Length)
            {
                for (int i = 0; i < devices.Count; i++)
                {
                    ADBHelper.ExecuteCMD("adb -s " + devices[i] + " shell settings put global http_proxy " + ports[i]);
                }
            }
        }

        private void removeProxy()
        {
            devices?.ForEach(device =>
            {
                ADBHelper.ExecuteCMD("adb -s " + device + " shell settings put global http_proxy :0");
            });

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
                        ADBHelper.InputText(devices[i], content[i].Trim());
                    }
                });




            }
        }

        private void generateToken()
        {
            string[] content = tb2FA.Text.Split(new char[] { '\n', });
            string generateString = "";

            for (int i = 0; i < content.Length; i++)
            {
                generateString += getGenerateToken(content[i].Trim()) + "\n";
            }
            tb2FAConverted.Text = generateString;
        }


        private string getGenerateToken(string secret)
        {
            var secretKey = Base32Encoding.ToBytes(secret.Replace("\r", ""));
            var totp = new Totp(secretKey);
            var otp = totp.ComputeTotp();
            return otp.ToString();
        }

        private void copyToken()
        {
            string[] content = tb2FAConverted.Text.Split(new char[] { '\n', });
            if (devices != null && devices.Count > 0 && devices.Count <= content.Length)
            {
                Task.Run(() =>
                {
                    for (int i = 0; i < devices.Count; i++)
                    {
                        ADBHelper.TapByPercent(devices[i], 15.9, 17.6);
                    }

                    for (int i = 0; i < devices.Count; i++)
                    {
                        ADBHelper.TapByPercent(devices[i], 23.5, 8.3);
                    }

                    Task.Delay(1000);


                    for (int i = 0; i < devices.Count; i++)
                    {
                        ADBHelper.InputText(devices[i], content[i].Trim());
                    }
                });

            }
        }

        private void copyClipboard()
        {

        }
        private void clearClipboard()
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            applyProxy();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            removeProxy();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            generateToken();

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            copyToken();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            copyClipboard();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            clearClipboard();
        }



        /*    <TextBox.Resources>
                           <Style TargetType = "{x:Type Paragraph}" >
                               < Setter Property="Margin" Value="0" />
                           </Style>
                       </TextBox.Resources>*/

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
