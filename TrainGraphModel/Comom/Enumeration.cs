using System;
using System.Collections.Generic;
using System.Text;

namespace TrainGraphModel.Comom
{

    /// <summary>
    /// 车站类型
    /// </summary>
    public enum StationType 
    {
        /// <summary>
        /// 正常车站
        /// </summary>
        NormalStation,
        /// <summary>
        /// 停车场
        /// </summary>
        ParkingLot,
        /// <summary>
        /// 车辆段
        /// </summary>
        CarDepot
    }

    /// <summary>
    /// 列车运行方向（上行、下行）
    /// </summary>
    public enum TrainDirection
    {
        /// <summary>
        /// 上行
        /// </summary>
        Up,
        /// <summary>
        /// 下行
        /// </summary>
        Down
    }
}
