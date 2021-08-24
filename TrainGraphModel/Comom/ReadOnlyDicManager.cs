using System.Collections.Generic;

namespace TrainGraphModel.Comom
{
    /// <summary>
    /// key是int的管理类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ReadOnlyDicManager<T>:ReadOnlyDicManagerBase<ushort, T>
        where T:IStaff<ushort>
    {
        public ReadOnlyDicManager(IEnumerable<T> list):base(list)
        {

        }


    }


}
