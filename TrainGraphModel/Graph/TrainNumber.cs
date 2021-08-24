using TrainGraphModel.Comom;

namespace TrainGraphModel.Graph
{
    /// <summary>
    /// 车次号
    /// </summary>
    public class TrainNumber:ObservableParentBase<TrainNode>,ISon
    {
        public object Parent { get; set; }

    }





}
