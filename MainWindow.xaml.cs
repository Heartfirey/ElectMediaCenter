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


namespace ElectMediaCenter_Project
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class FileLocation : Window
    {
        public string temp_Mathloc;
        public string temp_Chineseloc;
        public string temp_Englishloc;
        public string temp_Physicloc;
        public string temp_Chemistryloc;
        public string temp_Biologyloc;

        IniFiles ini = new IniFiles(Process.GetCurrentProcess().MainModule.FileName + "Settings.ini");
        public void read()
        {
            if (ini.ExistINIFile())
            {
                temp_Mathloc = ini.IniReadValue("SettingList", "数学");
                temp_Mathloc = ini.IniReadValue("SettingList", "语文");
                temp_Mathloc = ini.IniReadValue("SettingList", "英语");
                temp_Mathloc = ini.IniReadValue("SettingList", "物理");
                temp_Mathloc = ini.IniReadValue("SettingList", "化学");
                temp_Mathloc = ini.IniReadValue("SettingList", "生物");
            }
            else
            {
                MessageBox.Show("配置错误", "未检索到配置文件", MessageBoxButton.OK);
            }
        }
    }
    public partial class MainWindow : Window
    {
        //主窗口声明
        public MainWindow()
        {
            InitializeComponent();
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
            catch(Exception ex)
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
            SettingWindows f2 = new SettingWindows();
            f2.Show();
        }

        

        //索引函数
        //函数用法 System.Diagnostics.Process.Start(路径);
        FileLocation temp_Mathloc = new FileLocation();
        FileLocation temp_Chineseloc = new FileLocation();
        FileLocation temp_Englishloc = new FileLocation();
        FileLocation temp_Physicloc = new FileLocation();
        FileLocation temp_Chemistryloc = new FileLocation();
        FileLocation temp_Biologyloc = new FileLocation();



        private void StartMath(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:/");
        }
    }

   
}

