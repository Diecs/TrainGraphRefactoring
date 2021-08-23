using System.Collections.Generic;
using System.Linq;
using TrainGraphModel.Comom;
using TrainGraphModel.Line;

namespace TrainGraphModel
{
    /// <summary>
    /// 交路管理器
    /// </summary>
    public class RoutingManager:ReadOnlyDicManager<Routing>
    {
        public SubwayLine SubwayLine { get; set; }

        public RoutingManager(IEnumerable<Routing> list):base(list)
        {

        }

        public Routing Get(StopArea start,StopArea end)
        {
            foreach(var r in this)
            {
                if(r.StartStopArea == start && r.EndStopArea == end)
                {
                    return r;
                }
            }
            throw new System.Exception();
        }


    }

}
