using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TrainGraphModel.Comom
{
    /// <summary>
    /// 提供通知的父亲类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ObservableParentBase<T> : ObservableCollection<T>, IParent<T>
        where T:ISon
    {
        public IReadOnlyList<T> Sons => this;

        protected override void InsertItem(int index, T item)
        {
            item.Parent = this;
            base.InsertItem(index, item);
        }

        protected override void SetItem(int index, T item)
        {
            this[index].Parent = null;
            item.Parent = this;
            base.SetItem(index, item);
        }

        protected override void RemoveItem(int index)
        {
            this[index].Parent = null;
            base.RemoveItem(index);
        }

        protected override void ClearItems()
        {
            foreach(var item in this)
            {
                item.Parent = null;
            }
            base.ClearItems();
        }

    }

}
