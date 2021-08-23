using System.Collections.Generic;
using TrainGraphModel.Comom;

namespace TrainGraphModel.Line
{
    /// <summary>
    /// 停车区域管理器
    /// </summary>
    public class StopAreaManager:ReadOnlyDicManager<StopArea>
    {
        public SubwayLine SubwayLine { get; set; }

        public StopAreaManager(IEnumerable<StopArea> stopAreas):base(stopAreas)
        {

        }

    }

}
