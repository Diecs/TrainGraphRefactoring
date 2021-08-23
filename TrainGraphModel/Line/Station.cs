using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TrainGraphModel;
using TrainGraphModel.Comom;

namespace TrainGraphModel.Line
{
    /// <summary>
    /// 车站
    /// </summary>
    public class Station:ReadOnlyParentBase<StopArea>, IStaff<ushort>
    {
        #region 属性

        /// <summary>
        /// 车站ID
        /// </summary>
        public ushort ID { get; }
        public ushort Key => ID;
        public object Manager { get; set; }
        public StationManager StationManager => Manager as StationManager;
        /// <summary>
        /// 车站名称
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// 车站类型
        /// </summary>
        public StationType StationType { get; }

        /// <summary>
        /// 获得停车区域列表
        /// </summary>
        public IReadOnlyList<StopArea> StopAreas => Sons;

        /// <summary>
        /// 取得本车站停车区域的最大公里标
        /// </summary>
        public double MaxKilometer => StopAreas.Max(s => s.Kilometer);
        /// <summary>
        /// 取得本车站停车区域的最大虚拟公里标
        /// </summary>
        public double MaxVirtualKilometer => StopAreas.Max(s => s.VirtualKilometer);

        #endregion

        public Station(ushort id,string name,StationType stationType,List<StopArea> stopAreas)
            :base(stopAreas)
        {
            ID = id;
            Name = name;
            StationType = stationType;
        }

        public static int SortByKiloAsc(Station objA, Station objB)
        {
            if (objA.MaxKilometer < objB.MaxKilometer)
            {
                return -1;
            }
            else if (objA.MaxKilometer > objB.MaxKilometer)
            {
                return 1;
            }
            else
            {
                return 0;
            }

        }

        public static int SortByKiloDesc(Station objA, Station objB)
        {
            if (objA.MaxKilometer > objB.MaxKilometer)
            {
                return -1;
            }
            else if (objA.MaxKilometer < objB.MaxKilometer)
            {
                return 1;
            }
            else
            {
                return 0;
            }

        }

    }

}