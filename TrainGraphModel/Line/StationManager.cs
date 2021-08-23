using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrainGraphModel.Comom;

namespace TrainGraphModel.Line
{
    public class StationManager:ReadOnlyDicManager<Station>,IEnumerable<Station>
    {
        public SubwayLine SubwayLine { get; set; }
        List<Station> sortedStations;
        /// <summary>
        /// 按下行方向排序好的车站列表
        /// </summary>
        public IReadOnlyList<Station> SortedStations => sortedStations;
        /// <summary>
        /// 随着公里标增大是下行方向
        /// </summary>
        public bool IsDownByKiloAdding { get; private set; }

        public StationManager(IEnumerable<Station> stations):base(stations)
        {

        }
        /// <summary>
        /// 按下行方向排序车站，排序后的列表放入sortedStations
        /// </summary>
        internal void Sort(StopArea preArea,StopArea nextArea,TrainDirection trainDirection)
        {
            sortedStations = this.KeyValuePairs.Values.ToList();
            if(preArea.Kilometer < nextArea.Kilometer && trainDirection == TrainDirection.Down)
            {
                IsDownByKiloAdding = true;
                sortedStations.Sort(Station.SortByKiloAsc);
            }
            else
            {
                IsDownByKiloAdding = false;
                sortedStations.Sort(Station.SortByKiloDesc);

            }
        }
    

    }
}
