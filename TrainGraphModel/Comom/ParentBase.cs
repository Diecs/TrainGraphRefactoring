using System;
using System.Collections;
using System.Collections.Generic;

namespace TrainGraphModel.Comom
{
    /// <summary>
    /// 只读的父亲类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ReadOnlyParentBase<T> : IEnumerable<T>
        where T:ISon
    {
        List<T> sons = new List<T>();
        public IReadOnlyList<T> Sons => sons;

        protected ReadOnlyParentBase()
        {

        }
        protected ReadOnlyParentBase(IEnumerable<T> items)
        {
            AddRange(items);
        }

        private void AddRange(IEnumerable<T> items)
        {
            sons.AddRange(items);
            foreach (var son in items)
            {
                son.Parent = this;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)sons).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)sons).GetEnumerator();
        }
    }

    public interface ISon
    {
        Object Parent { get; set; }
    }

}
