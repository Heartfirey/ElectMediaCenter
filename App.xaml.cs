using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ElectMediaCenter_Project
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        class FileLocationStorage //用于全局储存课件的目录
        {
            string MathFileLoc;
            string ChineseFileLoc;
            string EnglishFileLoc;
            string PhysicalFileLoc;
            string ChemistryFileloc;
            string BiologyFileLoc;
        }
    }
}
