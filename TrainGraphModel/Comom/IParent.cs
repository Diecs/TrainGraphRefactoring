using System;
using System.Collections.Generic;

namespace TrainGraphModel.Comom
{

    /// <summary>
    /// 父亲类接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IParent<T>:IEnumerable<T>
        where T:ISon
    {
        IReadOnlyList<T> Sons { get; }
    }

    public interface ISon
    {
        Object Parent { get; set; }
    }

}
