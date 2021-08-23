using System.Collections.Generic;
using TrainGraphModel.Comom;
using TrainGraphModel.Line;

namespace TrainGraphModel
{
    public class RuleManager<T> :ReadOnlyDicManagerBase<string,T>
        where T:IStaff<string>
    {
        public SubwayLine SubwayLine { get; set; }

        public RuleManager(IEnumerable<T> list):base(list)
        {

        }

    }


}