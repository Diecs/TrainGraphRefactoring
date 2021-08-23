using System;
using System.Collections.Generic;
using System.Linq;
using TrainGraphModel.Comom;
using TrainGraphModel.Line;

namespace TrainGraphModel
{
    /// <summary>
    /// 列车交路
    /// </summary>
    public class Routing :IStaff<ushort>
    {
        /// <summary>
        /// 交路编号
        /// </summary>
        public ushort Id { get; }
        /// <summary>
        /// 交路名称
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// 交路回段标志
        /// </summary>
        public string ShowMarkContent { get; }
        /// <summary>
        /// 交路方向
        /// </summary>
        public TrainDirection Direction { get; }
        /// <summary>
        /// 交路描述
        /// </summary>
        public string Discription { get; }

        List<StopArea> stopAreas;
        /// <summary>
        /// 交路列表
        /// </summary>
        public IReadOnlyList<StopArea> StopAreas => stopAreas;

        public ushort Key => Id;

        public object Manager { get; set; }

        public StopArea StartStopArea => stopAreas.First();
        public StopArea EndStopArea => stopAreas.Last();


        public Routing( ushort id, string name, string showMarkContent, TrainDirection direction, string discription, List<StopArea> stopAreas)
        {
            Name = name;
            Id = id;
            ShowMarkContent = showMarkContent;
            Direction = direction;
            Discription = discription;
            this.stopAreas = stopAreas;
        }
    }

}
