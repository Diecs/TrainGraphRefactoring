using System.Collections.Generic;
using TrainGraphModel.IO.Xml;

namespace TrainGraphModel.Line
{
    /// <summary>
    /// 读取线路信息类
    /// </summary>
    public static class LineReader
    {
        /// <summary>
        /// 从ini/TrainGraph中获取所有的线路信息
        /// </summary>
        /// <returns></returns>
        public static List<SubwayLine> ReadLinesInfoFromXml()
        {
            List<SubwayLine> lines = new List<SubwayLine>();
            var config = TrainGraphConfig.Instance;
            foreach(var dirInfo in config.GetAllLineDirectories())
            {
                var lineInfoFilePath = config.GetLineInfoFilePath(dirInfo);
                var xmlLine = XmlSerializeHelper.DeserializeFromXml<LineXmlDto>(lineInfoFilePath);
                var rulesInfoFilePath = config.GetGraphRulesInfoFilePath(dirInfo);
                var rules = XmlSerializeHelper.DeserializeFromXml<RulesXmlDto>(rulesInfoFilePath);
                LineConverter lineConverter = new LineConverter(xmlLine,rules);
                SubwayLine line = lineConverter.Convert();
                lines.Add(line);
            }

            return lines;
        }
    }


}
