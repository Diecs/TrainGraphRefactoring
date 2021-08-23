using System;
using System.Collections;
using System.Collections.Generic;
using TrainGraphModel.Comom;
using System.Linq;

namespace TrainGraphModel.Line
{
    /// <summary>
    /// 地铁线路信息
    /// </summary>
    public class SubwayLine :IStaff<uint>
    {

        #region 成员变量
        public uint Key => id;

        public object Manager { get ; set ; }
        /// <summary>
        /// 线路ID
        /// </summary>
        uint id;
        public uint ID => id;
        string name;
        public string Name => name;
        string dataVersion;
        public string DataVersion => dataVersion;
        StationManager stationManager;
        public StationManager StationManager => stationManager;
        StopAreaManager stopAreaManager;
        /// <summary>
        /// 停车区域管理器
        /// </summary>
        public StopAreaManager StopAreaManager => stopAreaManager;
        ReadOnlyDicManager<PathUnit> pathUnitManager;
        public ReadOnlyDicManager<PathUnit> PathUnitManager => pathUnitManager;
     
        RoutingManager routingManager;
        /// <summary>
        /// 列车交路列表
        /// </summary>
        public RoutingManager RoutingManager => routingManager;
        
        RuleManager<Rule<RunTimeRuleItem>> runRuleManager;
        /// <summary>
        /// 运行等级管理器
        /// </summary>
        public RuleManager<Rule<RunTimeRuleItem>> RunRuleManager => runRuleManager;

        RuleManager<Rule<StopTimeRuleItem>> stopRuleManager;
        /// <summary>
        /// 停车等级管理器
        /// </summary>
        public RuleManager<Rule<StopTimeRuleItem>> StopRuleManager => stopRuleManager;
        RuleManager<Rule<ReturnTimeRuleItem>> returnRuleManager;
        /// <summary>
        /// 折返等级管理器
        /// </summary>
        public RuleManager<Rule<ReturnTimeRuleItem>> ReturnRuleManager => returnRuleManager;

        #endregion

        public SubwayLine(
            UInt32 idPara,
            string namePara,
            string dataVersion,
            StationManager stationManager,
            StopAreaManager stopAreaManager,
            ReadOnlyDicManager<PathUnit> pathUnitManager,
            RoutingManager trainRoutingManager,
            RuleManager<Rule<RunTimeRuleItem>> runRuleManager,
            RuleManager<Rule<StopTimeRuleItem>> stopTimeRuleManager,
            RuleManager<Rule<ReturnTimeRuleItem>> returnTimeRuleManager
            )
        {
            id = idPara;
            name = namePara;
            this.dataVersion = dataVersion;
            this.stationManager = stationManager;
            this.stationManager.SubwayLine = this;
            this.stopAreaManager = stopAreaManager;
            this.stopAreaManager.SubwayLine = this;
            this.pathUnitManager = pathUnitManager;
            this.routingManager = trainRoutingManager;
            this.routingManager.SubwayLine = this;
            this.runRuleManager = runRuleManager;
            this.runRuleManager.SubwayLine = this;
            this.stopRuleManager = stopTimeRuleManager;
            this.stopRuleManager.SubwayLine = this;
            this.returnRuleManager = returnTimeRuleManager;
            this.returnRuleManager.SubwayLine = this;

            SortStation();
        }


        private void SortStation()
        {
            foreach(var routing in routingManager)
            {
                for (int i = 0; i < routing.StopAreas.Count -1; i++)
                {
                    var preStopArea = routing.StopAreas[i];
                    var nextStopArea = routing.StopAreas[i + 1];
                    if(preStopArea.IsPlatformTrack && nextStopArea.IsPlatformTrack && preStopArea.Parent != nextStopArea.Parent)
                    {
                        stationManager.Sort(preStopArea, nextStopArea, routing.Direction);
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// 取得地铁线路总长度
        /// </summary>
        public double GetLineTotalLength()
        {
            return stationManager.IsDownByKiloAdding ? stationManager.SortedStations.Last().MaxVirtualKilometer 
                : stationManager.SortedStations.First().MaxVirtualKilometer;
        }

        
        ///// <summary>
        ///// 获取出库交路
        ///// </summary>
        //public List<TrainRouting> GetDepartTrainRouting()
        //{
        //    List<TrainRouting> retVal = new List<TrainRouting>();
        //    foreach (TrainRouting route in trainRoutings)
        //    {
        //        if (route.startStopArea.TrackAttribute.IsTransferTrack)
        //        {
        //            retVal.Add(route);
        //        }
        //    }
        //    return retVal;
        //}
        ///// <summary>
        ///// 获取入库交路
        ///// </summary>
        //public List<TrainRouting> GetArriveTrainRouting()
        //{
        //    List<TrainRouting> retVal = new List<TrainRouting>();
        //    foreach (TrainRouting route in trainRoutings)
        //    {
        //        if (route.endStopArea.TrackAttribute.IsTransferTrack)
        //        {
        //            retVal.Add(route);
        //        }
        //    }
        //    return retVal;
        //}
        ///// <summary>
        ///// 获取交路
        ///// </summary>
        ///// <param name="name">交路名字</param>
        //public List<TrainRouting> GetTrainRoutings(Station startStation, Station endStation)
        //{
        //    List<TrainRouting> retVal = new List<TrainRouting>();
        //    foreach (TrainRouting route in trainRoutings)
        //    {
        //        if (startStation != null && endStation != null)
        //        {
        //            if (route.startStopArea.parent == startStation
        //                && route.endStopArea.parent == endStation)
        //            {
        //                retVal.Add(route);
        //            }
        //        }
        //        else if (startStation == null && endStation != null)
        //        {
        //            if (route.endStopArea.parent == endStation)
        //            {
        //                retVal.Add(route);
        //            }
        //        }
        //        else if (startStation != null && endStation == null)
        //        {
        //            if (route.startStopArea.parent == startStation)
        //            {
        //                retVal.Add(route);
        //            }
        //        }
        //    }
        //    return retVal;
        //}
        /////peng.tian 2019/9/19 获取常用交路
        ///// <summary>
        ///// 获取常用交路
        ///// </summary>
        //public List<TrainRouting> GetCommonTrainRoutings()
        //{
        //    List<TrainRouting> retVal = new List<TrainRouting>();
        //    foreach (TrainRouting route in trainRoutings)
        //    {
        //        if (route.CommonRoute)
        //        {
        //            retVal.Add(route);
        //        }
        //    }
        //    return retVal;
        //}
        ///// <summary>
        ///// 获取上行出库交路
        ///// </summary>
        ///// <param name="depotStopAreaList">转换轨</param>
        ///// <returns></returns>
        //public List<TrainRouting> GetUpdepartRoute(List<StopArea> depotStopAreaList, bool CommonRoute)
        //{
        //    List<TrainRouting> retVal = new List<TrainRouting>();
        //    List<TrainRouting> routings = new List<TrainRouting>();
        //    if (CommonRoute)
        //    {
        //        routings = GetCommonTrainRoutings();
        //    }
        //    else
        //    {
        //        foreach (var route in trainRoutings)
        //        {
        //            routings.Add(route);
        //        }
        //    }
        //    foreach (TrainRouting route in routings)
        //    {
        //        if (route.direction == EDirection.Up
        //            && depotStopAreaList.Contains(route.startStopArea)
        //            && route.startStopArea.TrackAttribute.IsTransferTrack)
        //        {//上行，起始车站为上行出段车站，且终点站为用户选中的起始/终止车站，或者终点站为出库车站
        //            retVal.Add(route);
        //        }
        //    }
        //    return retVal;
        //}
        ///// <summary>
        ///// 获取下行出库交路
        ///// </summary>
        ///// <param name="depotStopAreaList">转换轨</param>
        ///// <returns></returns>
        //public List<TrainRouting> GetDowndepartRoute(List<StopArea> depotStopAreaList, bool CommonRoute)
        //{
        //    List<TrainRouting> retVal = new List<TrainRouting>();
        //    List<TrainRouting> routings = new List<TrainRouting>();
        //    if (CommonRoute)
        //    {
        //        routings = GetCommonTrainRoutings();
        //    }
        //    else
        //    {
        //        foreach (var route in trainRoutings)
        //        {
        //            routings.Add(route);
        //        }
        //    }
        //    foreach (TrainRouting route in routings)
        //    {
        //        if (route.direction == EDirection.Down
        //              && depotStopAreaList.Contains(route.startStopArea)
        //              && route.startStopArea.TrackAttribute.IsTransferTrack)
        //        { //下行，起始车站为下行出段车站，且终点站为用户选中的起始/终止车站
        //            retVal.Add(route);
        //        }
        //    }
        //    return retVal;
        //}
        ///// <summary>
        ///// 获取上行入库交路
        ///// </summary>
        ///// <param name="depotStopAreaList">转换轨</param>
        ///// <returns></returns>
        //public List<TrainRouting> GetUpArriveRoute(List<StopArea> depotStopAreaList, bool CommonRoute)
        //{
        //    List<TrainRouting> retVal = new List<TrainRouting>();
        //    List<TrainRouting> routings = new List<TrainRouting>();
        //    if (CommonRoute)
        //    {
        //        routings = GetCommonTrainRoutings();
        //    }
        //    else
        //    {
        //        foreach (var route in trainRoutings)
        //        {
        //            routings.Add(route);
        //        }
        //    }
        //    foreach (TrainRouting route in routings)
        //    {
        //        if (route.direction == EDirection.Up
        //              && depotStopAreaList.Contains(route.endStopArea)
        //              && route.endStopArea.TrackAttribute.IsTransferTrack)
        //        {//上行，终点车站为上行入段车站，且起始站为用户选中的起始/终止车站
        //            retVal.Add(route);
        //        }
        //    }
        //    return retVal;
        //}
        ///// <summary>
        ///// 获取下行入库交路
        ///// </summary>
        ///// <param name="depotStopAreaList">转换轨</param>
        ///// <returns></returns>
        //public List<TrainRouting> GetDownArriveRoute(List<StopArea> depotStopAreaList, bool CommonRoute)
        //{
        //    List<TrainRouting> retVal = new List<TrainRouting>();
        //    List<TrainRouting> routings = new List<TrainRouting>();
        //    if (CommonRoute)
        //    {
        //        routings = GetCommonTrainRoutings();
        //    }
        //    else
        //    {
        //        foreach (var route in trainRoutings)
        //        {
        //            routings.Add(route);
        //        }
        //    }
        //    foreach (TrainRouting route in routings)
        //    {
        //        if (route.direction == EDirection.Down
        //                           && depotStopAreaList.Contains(route.endStopArea)
        //                           && route.endStopArea.TrackAttribute.IsTransferTrack)
        //        { //下行，终点车站为下行入段车站，且起始站为用户选中的起始/终止车站
        //            retVal.Add(route);
        //        }
        //    }
        //    return retVal;
        //}
        ///// <summary>
        ///// 获取指定车站间的运行交路
        ///// </summary>
        ///// <param name="startStation">发车车站</param>
        ///// <param name="endStation">终到车站</param>
        ///// <returns></returns>
        //public List<TrainRouting> GetRoute(Station startStation, Station endStation, bool CommonRoute)
        //{
        //    List<TrainRouting> retVal = new List<TrainRouting>();
        //    List<TrainRouting> routings = new List<TrainRouting>();
        //    if (CommonRoute)
        //    {
        //        routings = GetCommonTrainRoutings();
        //    }
        //    else
        //    {
        //        foreach (var route in trainRoutings)
        //        {
        //            routings.Add(route);
        //        }
        //    }
        //    foreach (TrainRouting route in routings)
        //    {
        //        if ((!route.startStopArea.TrackAttribute.IsTransferTrack && !route.endStopArea.TrackAttribute.IsTransferTrack)
        //              && ((route.endStopArea.parent == endStation && route.startStopArea.parent == startStation)
        //              || (route.endStopArea.parent == startStation && route.startStopArea.parent == endStation)))
        //        {//正线交路
        //            retVal.Add(route);
        //        }
        //    }
        //    return retVal;
        //}
        ///// <summary>
        ///// 通过ID获取车站
        ///// </summary>
        //public Station GetStationByID(UInt16 stationID)
        //{
        //    Station retVal = null;
        //    foreach (Station station in Stations)
        //    {
        //        if (station.ID == stationID)
        //            retVal = station;
        //    }
        //    return retVal;
        //}

        ///// <summary>
        ///// 通过ID获取停车区域
        ///// </summary>
        //public StopArea GetStopAreaByID(UInt16 stopAreaID)
        //{
        //    StopArea retVal = null;
        //    foreach (Station station in Stations)
        //    {
        //        retVal = station.GetStopAreaByID(stopAreaID);
        //        if (null != retVal)
        //            break;
        //    }
        //    return retVal;
        //}

        ///// <summary>
        ///// 获取出入站车辆段
        ///// </summary>
        //public Station GetDepotStation(bool isDepart, EDirection direction)
        //{
        //    Station retVal = null;
        //    foreach (TrainRouting route in trainRoutings)
        //    {
        //        if (isDepart)
        //        {
        //            if ((StationType.CarDepot == route.startStopArea.parent.Type) && (route.direction == direction))
        //            {
        //                retVal = route.startStopArea.parent;
        //                break;
        //            }
        //        }
        //        else
        //        {
        //            if ((StationType.CarDepot == route.endStopArea.parent.Type) && (route.direction == direction))
        //            {
        //                retVal = route.endStopArea.parent;
        //                break;
        //            }
        //        }
        //    }
        //    return retVal;
        //}

        ///// <summary>
        ///// 获取相邻停车区域的运行等级（不返回空值）
        ///// </summary>
        //public PRunLevel GetAreaRunLevel(StopArea startStopArea, StopArea endStopArea)
        //{
        //    PRunLevel retVal = null;

        //    //无数据，暂时用自生成的调试数据
        //    foreach (PRunLevel runLevel in runLevels)
        //    {
        //        if ((startStopArea == runLevel.startStation)
        //            && (endStopArea == runLevel.endStation))
        //        {
        //            retVal = runLevel;
        //            break;
        //        }
        //    }

        //    if (null == retVal)
        //    {
        //        string strMessage = string.Format(
        //            TransLanguage.TransLanguage.instance().TransLanguageString("停车区域{0}与{1}之间的运行等级信息缺失"),
        //            startStopArea.Name,
        //            endStopArea.Name);
        //        throw new Exception(strMessage);
        //    }

        //    return retVal;
        //}

        ///// <summary>
        ///// 获取相邻区间运行时间
        ///// </summary>
        //public UInt16 GetRunTime(StopArea startStopArea, StopArea endStopArea, byte level)
        //{
        //    PRunLevel runLevel = GetAreaRunLevel(startStopArea, endStopArea);
        //    return runLevel.GetRunTime(level);
        //}
        ///// <summary>
        ///// 获取相邻区间运行时间
        ///// </summary>
        //public UInt16 GetMinRunTime(StopArea startStopArea, StopArea endStopArea)
        //{
        //    PRunLevel runLevel = GetAreaRunLevel(startStopArea, endStopArea);
        //    return runLevel.GetminRunTime();
        //}
        //public TrainRouting FindMatchRouting(TrainRouting routing)
        //{
        //    TrainRouting retVal = null;

        //    foreach (TrainRouting node in trainRoutings)
        //    {
        //        if (node.isMatch(routing))
        //        {
        //            retVal = node;
        //            break;
        //        }
        //    }

        //    return retVal;
        //}


        //public TrainRouting FindMatchRouting(List<StopArea> listStopArea)
        //{
        //    if (null == listStopArea || listStopArea.Count <= 0)
        //        return null;

        //    TrainRouting retVal = null;

        //    foreach (TrainRouting node in trainRoutings)
        //    {
        //        if (node.trainRoutings[0] == listStopArea[0]
        //            && node.trainRoutings[node.trainRoutings.Count - 1] == listStopArea[listStopArea.Count - 1]
        //            && node.trainRoutings.Count == listStopArea.Count)
        //        {
        //            bool bMatchFlag = true;
        //            for (Int32 i = 0; i < listStopArea.Count; i++)
        //            {
        //                if (listStopArea[i] != node.trainRoutings[i])
        //                {
        //                    bMatchFlag = false;
        //                    break;
        //                }
        //            }
        //            if (bMatchFlag)
        //            {
        //                retVal = node;
        //                break;
        //            }
        //        }
        //    }

        //    return retVal;
        //}
        ///// <summary>
        ///// Obtain PathUnit By startPointId and endPointId
        ///// </summary>
        ///// <param name="startPointId">StartId of PathUnit</param>
        ///// <param name="endPointId">EndId of PathUnit</param>
        ///// <returns>PPathUnit</returns>
        //public PathUnit GetPathUnit(UInt16 startPointId, UInt16 endPointId)//add by zhixiang.yuan
        //{
        //    foreach (PathUnit pathunit in pathUnits)
        //    {
        //        if (pathunit.StartStopArea.ID == startPointId && pathunit.EndStopArea.ID == endPointId)
        //            return pathunit;
        //    }
        //    return null;
        //}
        ///// <summary>
        ///// Obtain PathUnit By startPointId,endPointId and direction
        ///// </summary>
        ///// <param name="startPointId">StartId of PathUnit</param>
        ///// <param name="endPointId">EndId of PathUnit</param>
        ///// <returns>PPathUnit</returns>
        //public PathUnit GetPathUnit(UInt16 startPointId, UInt16 endPointId, EDirection direction)//add by zhixiang.yuan
        //{
        //    foreach (PathUnit pathunit in pathUnits)
        //    {
        //        if (pathunit.StartStopArea.ID == startPointId && pathunit.EndStopArea.ID == endPointId && pathunit.RunDirection == direction)
        //            return pathunit;
        //    }
        //    return null;
        //}
        ///// <summary>
        ///// Obtain List Of PathUnit By startPointId
        ///// </summary>
        ///// <param name="startPointId">StartId of PathUnit</param>
        ///// <returns>List Of PathUnit</returns>
        //public List<PathUnit> GetPathUnitByStartId(UInt16 startPointId)//add by zhixiang.yuan
        //{
        //    List<PathUnit> pathUnitList = new List<PathUnit>();
        //    foreach (PathUnit pathunit in pathUnits)
        //    {
        //        if (pathunit.StartStopArea != null && pathunit.StartStopArea.ID == startPointId)
        //            pathUnitList.Add(pathunit);
        //    }
        //    return pathUnitList;
        //}
        ///// <summary>
        ///// Obtain List Of PathUnit By endPointId
        ///// </summary>
        ///// <param name="endPointId">endPointId of PathUnit</param>
        ///// <returns>List Of PathUnit</returns>
        //public List<PathUnit> GetPathUnitByEndId(UInt16 endPointId)//add by zhixiang.yuan
        //{
        //    List<PathUnit> pathUnitList = new List<PathUnit>();
        //    foreach (PathUnit pathunit in pathUnits)
        //    {
        //        if (pathunit.EndStopArea.ID == endPointId)
        //            pathUnitList.Add(pathunit);
        //    }
        //    return pathUnitList;
        //}
    }

}
