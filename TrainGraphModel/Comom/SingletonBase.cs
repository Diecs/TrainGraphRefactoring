namespace TrainGraphModel.Comom
{
    /// <summary>
    /// 单例基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class SingletonBase<T>
    {
        static T instance;
        protected static object locker = new object();
        public static T Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = SingletonProvider.Instance.Get<T>();
                    }
                }
                return instance;
            }
        }

     

    }


}
