using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TrainGraphModel.Comom;

namespace TrainGraphModel.Graph
{
    /// <summary>
    /// 表号/服务号
    /// </summary>
    public class ServerNumber: ObservableParentBase<TrainNumber>,ISon
    {
        public object Parent { get; set; }

    }


}
