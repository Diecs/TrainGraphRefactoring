using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrainGraphModel.Comom;

namespace TrainGraphModel.Line
{
    /// <summary>
    /// 停站标尺项
    /// </summary>
    public class StopTimeRuleItem:ISon
    {
        #region  变量
        public StopArea StopArea { get; }
        /// <summary>
        /// 停站时间
        /// </summary>
        public ushort Time { get; }
        /// <summary>
        /// 默认停站时间
        /// </summary>
        public ushort DefaultTime { get; }
        /// <summary>
        /// 最小停站时间
        /// </summary>
        public ushort MinTime { get; }
        public object Parent { get; set; }
        #endregion
       
        #region 构造函数
        public StopTimeRuleItem(StopArea stopAreaPara, ushort time,ushort minTime, ushort defaultTime)
        {
            StopArea = stopAreaPara;
            Time = time;
            DefaultTime = defaultTime;
            MinTime = minTime;
        }
        #endregion
    }
}
