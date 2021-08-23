using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TrainGraphModel.Comom
{
    /// <summary>
    /// Dictionary封装的成员不重复只读管理类
    /// </summary>
    /// <typeparam name="key"></typeparam>
    /// <typeparam name="value"></typeparam>
    public abstract class ReadOnlyDicManagerBase<key,value>:IEnumerable<value>
        where value:IStaff<key>
    {
        Dictionary<key, value> dicionary;
        public IReadOnlyDictionary<key, value> KeyValuePairs => dicionary;

        protected ReadOnlyDicManagerBase()
        {
            dicionary = new Dictionary<key, value>();
        }

        protected ReadOnlyDicManagerBase(IEnumerable<value> values):this()
        {
            foreach (var value in values)
            {
                if (dicionary.ContainsKey(value.Key))
                {
                    throw new ArgumentException("已存在相同的键值");
                }
                else
                {
                    dicionary[value.Key] = value;
                    value.Manager = this;
                }
            }
        }

        public virtual value Get(key key)
        {
            return dicionary[key];
        }

        public virtual bool TryGet(key key,out value value)
        {
            return dicionary.TryGetValue(key, out value);
        }

        public IEnumerator<value> GetEnumerator()
        {
            return dicionary.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return dicionary.Values.GetEnumerator();
        }
    }

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
