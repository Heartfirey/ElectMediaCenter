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
        
    }

    /// <summary>
    /// 位于Window命名空间，用于储存目录地址
    /// </summary>
    
}

namespace Storage
{
    public partial class FileLocationStorage
    {
        public static string MathFileLoc;
        public static string ChineseFileLoc;
        public static string EnglishFileLoc;
        public static string PhysicalFileLoc;
        public static string ChemistryFileLoc;
        public static string BiologyFileLoc;
        public static string IP_dress;
    }

    public partial class CommonSettingStorage
    {
        public static string ScanAppFileLoc;
    }
}