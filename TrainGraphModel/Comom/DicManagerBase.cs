using System;
using System.Collections;
using System.Collections.Generic;

namespace TrainGraphModel.Comom
{
    /// <summary>
    /// Dictionary封装的成员不重复管理类
    /// </summary>
    /// <typeparam name="key"></typeparam>
    /// <typeparam name="value"></typeparam>
    public abstract class DicManagerBase<key, value> : IEnumerable<value>
        where value : IStaff<key>
    {
        Dictionary<key, value> dicionary;

        protected DicManagerBase()
        {
            dicionary = new Dictionary<key, value>();
        }

        protected DicManagerBase(IEnumerable<value> values) : this()
        {
            AddRange(values);
        }

        public void AddRange(IEnumerable<value> values)
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

        public virtual bool TryGet(key key, out value value)
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


}
