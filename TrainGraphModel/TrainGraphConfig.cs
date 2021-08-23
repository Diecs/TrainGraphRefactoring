using System;
using System.IO;
using TrainGraphModel.Comom;

namespace TrainGraphModel
{
    public class TrainGraphConfig:SingletonBase<TrainGraphConfig>
    {
        string directorySeparator = @"\";
        string iniDirectoryName = "ini";
        string trainGraphDirectoryName = "TrainGraph";
        string lineBasciDataDirectoryName = "LineBasicData";
        string graphConfigDirectoryName = "GraphConfig";
        string lineInfoFileName = "LineInfo.xml";
        string graphRulesManageFileName = "GraphRulesManage.xml";

        string iniPath;
        /// <summary>
        /// ini文件夹地址
        /// eg:D:\code\TrainGraphWorkStationForPlan\bin\ini
        /// </summary>
        public string IniPath => iniPath;
        string trainGraphPath;
        /// <summary>
        /// TrainGraph文件夹地址
        /// eg:D:\code\TrainGraphWorkStationForPlan\bin\ini\TrainGraph
        /// </summary>
        public string TrainGraphPath => trainGraphPath;

        private TrainGraphConfig()
        {
            SetPath();
            trainGraphPath = $@"{iniPath}{directorySeparator}{trainGraphDirectoryName}";
        }

        private void SetPath()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(Environment.CurrentDirectory);
            var parentDirectoryInfo = directoryInfo.Parent;
            DirectoryInfo iniDir = null;
            foreach (var info in parentDirectoryInfo.GetDirectories())
            {
                if (info.Name == iniDirectoryName)
                {
                    iniPath = info.FullName;
                    iniDir = info;
                    return;
                }
            }
            if (iniDir == null)
            {
                throw new Exception("没找到ini文件夹");
            }
        }

        /// <summary>
        /// 获取所有的线路信息文件夹
        /// </summary>
        /// <returns></returns>
        public DirectoryInfo[] GetAllLineDirectories()
        {
            DirectoryInfo trainGraphDir = new DirectoryInfo(TrainGraphPath);
            return trainGraphDir.GetDirectories();
        }

        /// <summary>
        /// 获取LineInfo.xml文件地址
        /// </summary>
        /// <returns></returns>
        public string GetLineInfoFilePath(DirectoryInfo trainGraphDirectoryInfo)
        {
            return $@"{trainGraphDirectoryInfo.FullName}{directorySeparator}{lineBasciDataDirectoryName}{directorySeparator}{lineInfoFileName}"; 
        }
        
        /// <summary>
        /// 获取GraphRulesManage.xml文件地址
        /// </summary>
        /// <param name="trainGraphDirectoryInfo"></param>
        /// <returns></returns>
        public string GetGraphRulesInfoFilePath(DirectoryInfo trainGraphDirectoryInfo)
        {
            return $@"{trainGraphDirectoryInfo.FullName}{directorySeparator}{lineBasciDataDirectoryName}{directorySeparator}{graphRulesManageFileName}";
        }

    }

}
