using System;
using System.Collections.Generic;
using System.Reflection;

namespace TrainGraphModel.Comom
{
    /// <summary>
    /// 单例提供商，所有单例都通过该类访问
    /// </summary>
    public class SingletonProvider
    {
        static object locker = new object();
        public static SingletonProvider Instance { get; } = new SingletonProvider();

        Dictionary<Type, object> singletonDic;

        private SingletonProvider()
        {
            singletonDic = new Dictionary<Type, object>();
            singletonDic.Add(typeof(SingletonProvider), this);
        }

        public T Get<T>()
        {
            lock (locker)
            {
                if (!singletonDic.ContainsKey(typeof(T)))
                {
                    singletonDic[typeof(T)] = CreateInstance<T>();
                }
            }
            return (T)singletonDic[typeof(T)];
        }

        private static T CreateInstance<T>()
        {
            var type = typeof(T);
            try
            {
                return (T)type.Assembly.CreateInstance(type.FullName, true, BindingFlags.NonPublic | BindingFlags.Instance, null, null, null, null);
            }
            catch (MissingMethodException ex)
            {
                throw new System.Exception(string.Format("{0}(单例模式下，构造函数必须为private)", ex.Message));
            }
        }

    }


}
