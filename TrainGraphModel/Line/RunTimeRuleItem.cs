using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrainGraphModel.Comom;

namespace TrainGraphModel.Line
{
    /// <summary>
    /// 运行等级标尺项
    /// </summary>
   public class RunTimeRuleItem:ISon
    {
        public StopArea StartArea { get; }
        public StopArea EndArea { get; }
        /// <summary>
        /// 运行时间（s）
        /// </summary>
        public ushort Time { get; }
        /// <summary>
        /// 默认运行时间（s）
        /// </summary>
        public ushort DefaultTime { get; }

        public object Parent { get; set; }

        public RunTimeRuleItem(StopArea startStationPara, StopArea endStationPara, ushort time, ushort defaultTime)
        {
            StartArea = startStationPara;
            EndArea = endStationPara;
            this.Time = time;
            this.DefaultTime = defaultTime;
        }
    }
}
