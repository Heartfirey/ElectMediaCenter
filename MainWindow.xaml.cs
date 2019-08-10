using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.IO;

namespace ElectMediaCenter_Project
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class FileLocation : Window
    {


        public void read()
        {
            IniFiles ini = new IniFiles(Directory.GetCurrentDirectory() + "\\Settings.ini");

            if (ini.ExistINIFile())
            {
                Storage.FileLocationStorage.MathFileLoc = ini.IniReadValue("SettingList", "MathFileLoc");
                Storage.FileLocationStorage.ChineseFileLoc = ini.IniReadValue("SettingList", "ChineseFileLoc");
                Storage.FileLocationStorage.EnglishFileLoc = ini.IniReadValue("SettingList", "EnglishFileLoc");
                Storage.FileLocationStorage.PhysicalFileLoc = ini.IniReadValue("SettingList", "PhysicalFileLoc");
                Storage.FileLocationStorage.ChemistryFileLoc = ini.IniReadValue("SettingList", "ChemistryFileloc");
                Storage.FileLocationStorage.BiologyFileLoc = ini.IniReadValue("SettingList", "BiologyFileLoc");
               
            }
            else
            {
                MessageBox.Show("配置错误", "未检索到配置文件,请联系管理员申请配置", MessageBoxButton.OK);
            }
        }
    }

    public partial class MainWindow : Window
    {


        //主窗口声明
        public MainWindow()
        {
            InitializeComponent();
            FileLocation FileLoc = new FileLocation();
            FileLoc.read();
            Check();
        }

        //功能封装函数_关机指令
        private void shutdown(object sender, RoutedEventArgs e)
        {
            try
            {
                //创建一个进程
                Process p = new Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.UseShellExecute = false;//是否使用操作系统shell启动
                p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
                p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
                p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
                p.StartInfo.CreateNoWindow = true;//不显示程序窗口
                p.Start();//启动程序
                //定义命令：shutdown -s -t 关机
                string strCMD = "shutdown -s -t 120";
                //向进程中的cmd发送命令
                p.StandardInput.WriteLine(strCMD + "&exit");
                p.StandardInput.AutoFlush = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "120s shutdown_test already！");
            }
        }

        //功能封装函数_关闭窗口
        private void W_Close(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        //功能封装函数_引导设置窗口
        private void Boot_SettingWindows(object sender, RoutedEventArgs e)
        {
            Settings f2 = new Settings();
            f2.Show();
        }

        //配置文件检索
        private void Check()
        {
            IniFiles ini = new IniFiles(Directory.GetCurrentDirectory() + "\\Settings.ini");
            if (ini.ExistINIFile())
            {
                CheckMode.Content = "AppConfig Working Normally！" + ini.IniReadValue("ConfigInformation", "Version");
                BitmapImage imagetemp = new BitmapImage(new Uri("pack://application:,,,/Image/checkcircle.png", UriKind.Absolute)); 
                CheckImage.Source = imagetemp;
            }
            else
            {
                CheckMode.Content = "Error：配置文件不存在或读取异常，尝试联系管理员安装配置文件";
                BitmapImage imagetemp = new BitmapImage(new Uri("pack://application:,,,/Image/frown.png", UriKind.Absolute));
                CheckImage.Source = imagetemp;
            }
        }

        //索引函数
        //函数用法 System.Diagnostics.Process.Start(路径);


        private void StartMath(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(Storage.FileLocationStorage.MathFileLoc);
        }

        private void StartChinese(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(Storage.FileLocationStorage.ChineseFileLoc);
        }

        private void StartEnglish(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(Storage.FileLocationStorage.EnglishFileLoc);
        }

        private void StartPhysical(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(Storage.FileLocationStorage.PhysicalFileLoc);
        }

        private void StartChemistry(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(Storage.FileLocationStorage.ChemistryFileLoc);
        }

        private void StartBiology(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(Storage.FileLocationStorage.BiologyFileLoc);
        }

        //使窗口可自由拖拽
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.DragMove();
            }
            catch { }
        }

        
    }
}

