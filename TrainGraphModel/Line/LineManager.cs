using System;
using System.IO;
using System.Reflection;
using System.Data;
using System.Linq;
using System.Xml;
using TrainGraphModel.Comom;

namespace TrainGraphModel.Line
{
    /// <summary>
    /// 线路管理
    /// </summary>
    public class LineManager:DicManagerBase<uint,SubwayLine>
    {
        public static LineManager Instance => SingletonProvider.Instance.Get<LineManager>();

        private LineManager()
        {
            Init();
        }

        /// <summary>
        /// 读取线路文件,初始化线路管理器
        /// </summary>
        private void Init()
        {
            var lines = LineReader.ReadLinesInfoFromXml();
            this.AddRange(lines);
        }


    }

}
