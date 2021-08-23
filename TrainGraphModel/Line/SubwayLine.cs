using System;
using System.Collections;
using System.Collections.Generic;
using TrainGraphModel.Comom;
using System.Linq;

namespace TrainGraphModel.Line
{
    /// <summary>
    /// ������·��Ϣ
    /// </summary>
    public class SubwayLine :IStaff<uint>
    {

        #region ��Ա����
        public uint Key => id;

        public object Manager { get ; set ; }
        /// <summary>
        /// ��·ID
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
        /// ͣ�����������
        /// </summary>
        public StopAreaManager StopAreaManager => stopAreaManager;
        ReadOnlyDicManager<PathUnit> pathUnitManager;
        public ReadOnlyDicManager<PathUnit> PathUnitManager => pathUnitManager;
     
        RoutingManager routingManager;
        /// <summary>
        /// �г���·�б�
        /// </summary>
        public RoutingManager RoutingManager => routingManager;
        
        RuleManager<Rule<RunTimeRuleItem>> runRuleManager;
        /// <summary>
        /// ���еȼ�������
        /// </summary>
        public RuleManager<Rule<RunTimeRuleItem>> RunRuleManager => runRuleManager;

        RuleManager<Rule<StopTimeRuleItem>> stopRuleManager;
        /// <summary>
        /// ͣ���ȼ�������
        /// </summary>
        public RuleManager<Rule<StopTimeRuleItem>> StopRuleManager => stopRuleManager;
        RuleManager<Rule<ReturnTimeRuleItem>> returnRuleManager;
        /// <summary>
        /// �۷��ȼ�������
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
        /// ȡ�õ�����·�ܳ���
        /// </summary>
        public double GetLineTotalLength()
        {
            return stationManager.IsDownByKiloAdding ? stationManager.SortedStations.Last().MaxVirtualKilometer 
                : stationManager.SortedStations.First().MaxVirtualKilometer;
        }

        
        ///// <summary>
        ///// ��ȡ���⽻·
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
        ///// ��ȡ��⽻·
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
        ///// ��ȡ��·
        ///// </summary>
        ///// <param name="name">��·����</param>
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
        /////peng.tian 2019/9/19 ��ȡ���ý�·
        ///// <summary>
        ///// ��ȡ���ý�·
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
        ///// ��ȡ���г��⽻·
        ///// </summary>
        ///// <param name="depotStopAreaList">ת����</param>
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
        //        {//���У���ʼ��վΪ���г��γ�վ�����յ�վΪ�û�ѡ�е���ʼ/��ֹ��վ�������յ�վΪ���⳵վ
        //            retVal.Add(route);
        //        }
        //    }
        //    return retVal;
        //}
        ///// <summary>
        ///// ��ȡ���г��⽻·
        ///// </summary>
        ///// <param name="depotStopAreaList">ת����</param>
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
        //        { //���У���ʼ��վΪ���г��γ�վ�����յ�վΪ�û�ѡ�е���ʼ/��ֹ��վ
        //            retVal.Add(route);
        //        }
        //    }
        //    return retVal;
        //}
        ///// <summary>
        ///// ��ȡ������⽻·
        ///// </summary>
        ///// <param name="depotStopAreaList">ת����</param>
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
        //        {//���У��յ㳵վΪ������γ�վ������ʼվΪ�û�ѡ�е���ʼ/��ֹ��վ
        //            retVal.Add(route);
        //        }
        //    }
        //    return retVal;
        //}
        ///// <summary>
        ///// ��ȡ������⽻·
        ///// </summary>
        ///// <param name="depotStopAreaList">ת����</param>
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
        //        { //���У��յ㳵վΪ������γ�վ������ʼվΪ�û�ѡ�е���ʼ/��ֹ��վ
        //            retVal.Add(route);
        //        }
        //    }
        //    return retVal;
        //}
        ///// <summary>
        ///// ��ȡָ����վ������н�·
        ///// </summary>
        ///// <param name="startStation">������վ</param>
        ///// <param name="endStation">�յ���վ</param>
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
        //        {//���߽�·
        //            retVal.Add(route);
        //        }
        //    }
        //    return retVal;
        //}
        ///// <summary>
        ///// ͨ��ID��ȡ��վ
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
        ///// ͨ��ID��ȡͣ������
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
        ///// ��ȡ����վ������
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
        ///// ��ȡ����ͣ����������еȼ��������ؿ�ֵ��
        ///// </summary>
        //public PRunLevel GetAreaRunLevel(StopArea startStopArea, StopArea endStopArea)
        //{
        //    PRunLevel retVal = null;

        //    //�����ݣ���ʱ�������ɵĵ�������
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
        //            TransLanguage.TransLanguage.instance().TransLanguageString("ͣ������{0}��{1}֮������еȼ���Ϣȱʧ"),
        //            startStopArea.Name,
        //            endStopArea.Name);
        //        throw new Exception(strMessage);
        //    }

        //    return retVal;
        //}

        ///// <summary>
        ///// ��ȡ������������ʱ��
        ///// </summary>
        //public UInt16 GetRunTime(StopArea startStopArea, StopArea endStopArea, byte level)
        //{
        //    PRunLevel runLevel = GetAreaRunLevel(startStopArea, endStopArea);
        //    return runLevel.GetRunTime(level);
        //}
        ///// <summary>
        ///// ��ȡ������������ʱ��
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
