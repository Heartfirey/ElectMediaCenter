using System.Windows;
using System.Windows.Forms;

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
        }
    }

    public partial class Settings : Window
    {
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
    }
}

    
