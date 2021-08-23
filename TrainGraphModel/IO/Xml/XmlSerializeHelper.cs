using System;

namespace TrainGraphModel.IO.Xml
{
    /// <summary>
    /// xml阅读器
    /// </summary>
    public class XmlSerializeHelper
    {
        /// <summary>
        /// 把指定地址的文件序列化为对应对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static T DeserializeFromXml<T>(string filePath)
        {
            if (!System.IO.File.Exists(filePath))
                throw new ArgumentNullException(filePath + "不存在");

            using (System.IO.StreamReader reader = new System.IO.StreamReader(filePath))
            {
                System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(T));
                T ret = (T)xs.Deserialize(reader);
                return ret;
            }

        }
    }

}
