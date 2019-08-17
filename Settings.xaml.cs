using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using Client;


namespace ElectMediaCenter_Project
{
    /// <summary>
    /// Settings.xaml 的交互逻辑
    /// </summary>
    public partial class Settings : Window
    {
        //初始化设置窗口
        public Settings()
        {
            InitializeComponent();
            ConfigRead();
        }

        private void SelfRunningCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            //Common.WindowsBoot WB = new Common.WindowsBoot();
            //WB.SetSelfStarting(true, "ElectMediaCenter");
            //Storage.CommonSettingStorage.IsSelfRunning = true;
        }

        private void SelfRunningCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            //Common.WindowsBoot WB = new Common.WindowsBoot();
            //WB.SetSelfStarting(false, "ElectMediaCenter");
            //Storage.CommonSettingStorage.IsSelfRunning = false;
        }

        private void Visit_ProjectWeb(object sender, RoutedEventArgs e)
        {
            //调用系统默认的浏览器 
            System.Diagnostics.Process.Start("https://github.com/Heartfirey/ElectMediaCenter.git");
         }

        private void MathChooseFiles(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog openFileDialog = new System.Windows.Forms.FolderBrowserDialog();  //选择文件夹

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)//此处应当手动引入System.Window.Forms空间，否则使用默认的DialogResult会发现没有OK属性！
            {
                MathBox.Text = openFileDialog.SelectedPath;
            }
        }

        private void ChineseChooseFiles(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog openFileDialog = new System.Windows.Forms.FolderBrowserDialog();  //选择文件夹

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)//此处应当手动引入System.Window.Forms空间，否则使用默认的DialogResult会发现没有OK属性！
            {
                ChineseBox.Text = openFileDialog.SelectedPath;
            }
        }

        private void EnglishChooseFiles(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog openFileDialog = new System.Windows.Forms.FolderBrowserDialog();  

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                EnglishBox.Text = openFileDialog.SelectedPath;
            }
        }

        private void PhysicalChooseFiles(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog openFileDialog = new System.Windows.Forms.FolderBrowserDialog();  

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                PhysicalBox.Text = openFileDialog.SelectedPath;
            }
        }

        private void ChemisryChooseFiles(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog openFileDialog = new System.Windows.Forms.FolderBrowserDialog();  

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ChemistryBox.Text = openFileDialog.SelectedPath;
            }
        }

        private void BiologyChooseFiles(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog openFileDialog = new System.Windows.Forms.FolderBrowserDialog();  

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                BiologyBox.Text = openFileDialog.SelectedPath;
            }
        }

        private void ScanAppChooseFiles(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog openFileDialog = new System.Windows.Forms.FolderBrowserDialog();

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ScanAppBox.Text = openFileDialog.SelectedPath;
            }

            Storage.CommonSettingStorage.ScanAppFileLoc = ScanAppBox.Text;
            IniFiles ini = new IniFiles(Directory.GetCurrentDirectory() + "\\Settings.ini");
            ini.IniWriteValue("CommonSettings", "ScanAppFileLoc", Storage.CommonSettingStorage.ScanAppFileLoc);
        }

        private void ConfigSave(object sender, RoutedEventArgs e)
        {

            Storage.FileLocationStorage.MathFileLoc = MathBox.Text;
            Storage.FileLocationStorage.ChineseFileLoc = ChineseBox.Text;
            Storage.FileLocationStorage.EnglishFileLoc = EnglishBox.Text;
            Storage.FileLocationStorage.PhysicalFileLoc = PhysicalBox.Text;
            Storage.FileLocationStorage.ChemistryFileLoc = ChemistryBox.Text;
            Storage.FileLocationStorage.BiologyFileLoc = BiologyBox.Text;

            IniFiles ini = new IniFiles(Directory.GetCurrentDirectory() + "\\Settings.ini");
            ini.IniWriteValue("SettingList", "MathFileLoc", Storage.FileLocationStorage.MathFileLoc);
            ini.IniWriteValue("SettingList", "ChineseFileLoc", Storage.FileLocationStorage.ChineseFileLoc);
            ini.IniWriteValue("SettingList", "EnglishFileLoc", Storage.FileLocationStorage.EnglishFileLoc);
            ini.IniWriteValue("SettingList", "PhysicalFileLoc", Storage.FileLocationStorage.PhysicalFileLoc);
            ini.IniWriteValue("SettingList", "ChemistryFileloc", Storage.FileLocationStorage.ChemistryFileLoc);
            ini.IniWriteValue("SettingList", "BiologyFileLoc", Storage.FileLocationStorage.BiologyFileLoc);
        }

        private void ConfigRead()
        {
            MathBox.Text = Storage.FileLocationStorage.MathFileLoc;
            ChineseBox.Text = Storage.FileLocationStorage.ChineseFileLoc;
            EnglishBox.Text = Storage.FileLocationStorage.EnglishFileLoc;
            PhysicalBox.Text = Storage.FileLocationStorage.PhysicalFileLoc;
            ChemistryBox.Text = Storage.FileLocationStorage.ChemistryFileLoc;
            BiologyBox.Text = Storage.FileLocationStorage.BiologyFileLoc;

            IniFiles ini = new IniFiles(Directory.GetCurrentDirectory() + "\\Settings.ini");
            if (ini.IniReadValue("CommonSettings", "Severload") == "1") SLNC.Content = "Command：Endup Local Network Communicate Client Test Sever with safety model";
            else SLNC.Content = "Command：Startup Local Network Communicate Client Test Sever with safety model";

            if(Storage.CommonSettingStorage.IsSelfRunning == true) SelfRunningCheckBox.IsChecked = true;
            else SelfRunningCheckBox.IsChecked = false;

        }



        private void ClientReg(object sender, RoutedEventArgs e)
        {
            IniFiles ini = new IniFiles(Directory.GetCurrentDirectory() + "\\Settings.ini");
            if (ini.IniReadValue("CommonSettings", "Severload") == "1")
            {
                ini.IniWriteValue("CommonSettings", "Severload", "0");
                SLNC.Content = "Command：Startup Local Network Communicate Client Test Sever with safety model";
            }
            else
            {
                Client.MyClient mc = new Client.MyClient();
                mc.StarUp();
            }
        }

        private void SendMessage(object sender, RoutedEventArgs e)
        {
            Client.MyClient mc = new Client.MyClient();

            string message = MessageIputBox.Text;
            mc.StarUp();
            mc.Send(message);
        }


    }
}

    
