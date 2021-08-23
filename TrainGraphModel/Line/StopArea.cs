using System;
using TrainGraphModel;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TrainGraphModel.Comom;

namespace TrainGraphModel.Line
{
    /// <summary>
    /// 停车区域
    /// </summary>
    public class StopArea :ISon,IStaff<ushort>
    {
        /// <summary>
        /// 停车点ID
        /// </summary>
        public ushort ID { get; }
        /// <summary>
        /// 停车点名称
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// 实际公里标（单位：米）
        /// </summary>
        public double Kilometer { get; }
        /// <summary>
        /// 虚拟公里标（单位：米）
        /// </summary>
        public double VirtualKilometer { get; }
        /// <summary>
        /// 是否折返轨
        /// </summary>
        public bool IsReversalTrack { get; }
        /// <summary>
        /// 是否转换轨
        /// </summary>
        public bool IsTransferTrack { get; }
        /// <summary>
        /// 是否站台轨
        /// </summary>
        public bool IsPlatformTrack { get; }
        /// <summary>
        /// 父节点属性
        /// </summary>
        public Station Station => Parent as Station;
        public object Parent { get; set; }

        public ushort Key => ID;

        public object Manager { get ; set ; }

        public StopArea(ushort iD, string name, double kilometer, double virtualKilometer,
            bool isReversalTrack,bool isTransferTrack,bool isPlatformTrack)
        {
            ID = iD;
            Name = name;
            Kilometer = kilometer;
            VirtualKilometer = virtualKilometer;
            IsReversalTrack = isReversalTrack;
            IsTransferTrack = isTransferTrack;
            IsPlatformTrack = isPlatformTrack;
        }

    }

}
