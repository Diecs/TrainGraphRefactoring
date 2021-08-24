using System;
using System.Collections.Generic;
using TrainGraphModel.Comom;
using TrainGraphModel.IO.Xml;

namespace TrainGraphModel.Line
{
    /// <summary>
    /// 读取xml时line类型转换
    /// </summary>
    public class LineConverter
    {
        LineXmlDto lineXmlDto;
        RulesXmlDto rulesXmlDto;

        StopAreaManager stopAreaManager;
        StationManager stationManager;
        ReadOnlyDicManager<PathUnit> pathUnitManager;
        RoutingManager trainRoutingManager;

        RuleManager<Rule<RunTimeRuleItem>> runRuleManager;
        RuleManager<Rule<StopTimeRuleItem>> stopTimeRuleManager;
        RuleManager<Rule<ReturnTimeRuleItem>> returnTimeRuleManager;

        public LineConverter(LineXmlDto lineXmlDto,RulesXmlDto rulesXmlDto)
        {
            this.lineXmlDto = lineXmlDto;
            this.rulesXmlDto = rulesXmlDto;
        }

        /// <summary>
        /// xml线路类转换为基础线路类
        /// </summary>
        /// <param name="lineXmlDto"></param>
        /// <returns></returns>
        public SubwayLine Convert()
        {
            //转换lineInfo.xml内的数据
            SetStopAreaManager();
            SetStationManager();
            SetRoutingMnanager();
            SetPathUnitManager();

            //转换标线数据
            SetRunTimeRuleManager();
            SetStopTimeRuleManager();
            SetReturnTimeRuleManager();


            return new SubwayLine(lineXmlDto.id,lineXmlDto.Name,lineXmlDto.FsVersion,stationManager,stopAreaManager,
                pathUnitManager,trainRoutingManager,runRuleManager,stopTimeRuleManager,returnTimeRuleManager);
        }

        private void SetStopAreaManager()
        {
            List<StopArea> stopAreas = new List<StopArea>();
            foreach(var xmlStation in lineXmlDto.Stations)
            {
                foreach(var xmlStopArea in xmlStation.StopAreas)
                {
                    bool isRe = System.Convert.ToBoolean(xmlStopArea.IsReversalTrack);
                    bool isTr = System.Convert.ToBoolean(xmlStopArea.IsTransferTrack);
                    bool isPl = System.Convert.ToBoolean(xmlStopArea.IsPlatTrack);
                    var stopArea = new StopArea(xmlStopArea.ID, xmlStopArea.Name, xmlStopArea.Kilo, xmlStopArea.VirtualKilo,
                        isRe, isTr, isPl);
                    stopAreas.Add(stopArea);
                }
            }
            stopAreaManager = new StopAreaManager(stopAreas);
        }

        private void SetStationManager()
        {
            List<Station> stations = new List<Station>();
            foreach (var xmlStation in lineXmlDto.Stations)
            {
                StationType stationType = EnumConveter.ConvertToStationType(xmlStation.Type);
                List<StopArea> stopAreas = new List<StopArea>();
                foreach(var xmlStopArea in xmlStation.StopAreas)
                {
                    var stopArea = stopAreaManager.Get(xmlStopArea.ID);
                    stopAreas.Add(stopArea);
                }
                List<StopArea> transferTrackStopAreas = new List<StopArea>();
                if (xmlStation.TrackStopAreas != null && xmlStation.TrackStopAreas.Length != 0)
                {
                    foreach (var xmlStopArea in xmlStation.TrackStopAreas)
                    {
                        var stopArea = stopAreaManager.Get(xmlStopArea.ID);
                        transferTrackStopAreas.Add(stopArea);
                    }
                }
                Station station = new Station(xmlStation.ID, xmlStation.Name, stationType,transferTrackStopAreas,stopAreas);
                stations.Add(station);
            }
            stationManager = new StationManager(stations);
        }

        private void SetRoutingMnanager()
        {
            List<Routing> routings = new List<Routing>();
            foreach(var xmlRouting in lineXmlDto.Routes)
            {
                TrainDirection trainDirection = EnumConveter.ConvertToTrainDirection(xmlRouting.Direction);
                List<StopArea> stopAreas = new List<StopArea>();
                foreach(var stopAreaId in xmlRouting.RoutStopArea)
                {
                    stopAreas.Add( stopAreaManager.Get(stopAreaId));
                }
                Routing routing = new Routing(xmlRouting.ID, xmlRouting.Name, xmlRouting.ShowMarkContent,
                    trainDirection, xmlRouting.Discription, stopAreas);
                routings.Add(routing);
            }
            trainRoutingManager = new RoutingManager(routings);
        }

        private void SetPathUnitManager()
        {
            List<PathUnit> pathUnits = new List<PathUnit>();
            foreach(var xmlPath in lineXmlDto.PathUnits)
            {
                var direction = EnumConveter.ConvertToTrainDirection(xmlPath.RunDirection);
                var startArea = stopAreaManager.Get(xmlPath.StartID);
                var endArea = stopAreaManager.Get(xmlPath.EndID);
                PathUnit pathUnit = new PathUnit(xmlPath.ID,startArea,endArea,direction);
                pathUnits.Add(pathUnit);
            }
            pathUnitManager = new ReadOnlyDicManager<PathUnit>(pathUnits);

        }

        private void SetRunTimeRuleManager()
        {
            List<Rule<RunTimeRuleItem>> rules = new List<Rule<RunTimeRuleItem>>();
            foreach (var xmlRunTimeRules in rulesXmlDto.RunRules)
            {
                List<RunTimeRuleItem> items = new List<RunTimeRuleItem>();
                foreach(var item in xmlRunTimeRules.RunAreaRule)
                {
                    var startArea = stopAreaManager.Get(item.StartID);
                    var endArea = stopAreaManager.Get(item.EndID);
                    RunTimeRuleItem runTimeRuleItem = new RunTimeRuleItem(startArea, endArea, item.Value, item.DefaultRunTime);
                    items.Add(runTimeRuleItem);
                }
                Rule<RunTimeRuleItem> runTimeRuleItems = new Rule<RunTimeRuleItem>(xmlRunTimeRules.Name, xmlRunTimeRules.Description, items);
                rules.Add(runTimeRuleItems);
            }
            runRuleManager = new RuleManager<Rule<RunTimeRuleItem>>(rules);
        }

        private void SetStopTimeRuleManager()
        {
            List<Rule<StopTimeRuleItem>> rules = new List<Rule<StopTimeRuleItem>>();
            foreach (var xmlRules in rulesXmlDto.StopRules)
            {
                List<StopTimeRuleItem> items = new List<StopTimeRuleItem>();
                foreach (var item in xmlRules.StopTimeRule)
                {
                    var stopArea = stopAreaManager.Get(item.StationAreaId);
                    StopTimeRuleItem stopTimeRuleItem = new StopTimeRuleItem(stopArea, item.Value, item.MinStopTime, item.DefaultStopTime);
                    items.Add(stopTimeRuleItem);
                }
                Rule<StopTimeRuleItem> rule = new Rule<StopTimeRuleItem>(xmlRules.Name, xmlRules.Description, items);
                rules.Add(rule);
            }
            stopTimeRuleManager = new RuleManager<Rule<StopTimeRuleItem>>(rules);
        }

        private void SetReturnTimeRuleManager()
        {
            List<Rule<ReturnTimeRuleItem>> rules = new List<Rule<ReturnTimeRuleItem>>();
            foreach (var xmlRules in rulesXmlDto.ReturnRules)
            {
                List<ReturnTimeRuleItem> items = new List<ReturnTimeRuleItem>();
                foreach (var item in xmlRules.ReturnTimeRule)
                {
                    var stopArea = stopAreaManager.Get(item.StationAreaId);
                    ReturnTimeRuleItem ReturnTimeRuleItem = new ReturnTimeRuleItem(stopArea, item.Value, item.MinReturnTime, item.DefaultReturnTime);
                    items.Add(ReturnTimeRuleItem);
                }
                Rule<ReturnTimeRuleItem> rule = new Rule<ReturnTimeRuleItem>(xmlRules.Name, xmlRules.Description, items);
                rules.Add(rule);
            }
            returnTimeRuleManager = new RuleManager<Rule<ReturnTimeRuleItem>>(rules);
        }

    }


}
