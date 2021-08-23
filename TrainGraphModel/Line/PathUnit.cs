using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrainGraphModel;
using TrainGraphModel.Comom;

namespace TrainGraphModel.Line
{
    /// <summary>
    /// 路径单元
    /// </summary>
    public class PathUnit:IStaff<ushort>
    {
        /// <summary>
        /// 路径ID
        /// </summary>
        public ushort Id { get; }
        /// <summary>
        /// 起点ID
        /// </summary>
        public StopArea StartStopArea { get; }
        /// <summary>
        /// 终点ID
        /// </summary>
        public StopArea EndStopArea { get; }
        /// <summary>
        /// 运行方向
        /// </summary>
        public TrainDirection Direction { get; }
        public ushort Key => Id;

        public object Manager { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pathId"></param>
        /// <param name="startPointId"></param>
        /// <param name="endPointId"></param>
        /// <param name="runDirection"></param>
        /// <param name="isDefault"></param>
        public PathUnit(UInt16 pathId, StopArea startPoint, StopArea endPoint, TrainDirection runDirection)
        {
            this.Id = pathId;
            StartStopArea = startPoint;
            EndStopArea = endPoint;
            Direction = runDirection;
        }

    }
}
