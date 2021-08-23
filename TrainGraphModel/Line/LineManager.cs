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
    /// ��·����
    /// </summary>
    public class LineManager:DicManagerBase<uint,SubwayLine>
    {
        public static LineManager Instance => SingletonProvider.Instance.Get<LineManager>();

        private LineManager()
        {
            Init();
        }

        /// <summary>
        /// ��ȡ��·�ļ�,��ʼ����·������
        /// </summary>
        private void Init()
        {
            var lines = LineReader.ReadLinesInfoFromXml();
            this.AddRange(lines);
        }


    }

}
