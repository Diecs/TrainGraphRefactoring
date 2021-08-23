using System.Collections.Generic;
using TrainGraphModel.Comom;

namespace TrainGraphModel
{
    /// <summary>
    /// 标尺类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Rule<T>:ReadOnlyParentBase<T>,IStaff<string>
        where T:ISon
    {
        /// <summary>
        /// 标尺名称
        /// </summary>
        public string Name { get; }
        public string Key => Name;
        public object Manager { get; set; }
        /// <summary>
        /// 标尺描述
        /// </summary>
        public string Description { get; }

        public Rule(string name, string description,List<T> list):
            base(list)
        {
            Name = name;
            Description = description;
        }

    }


}