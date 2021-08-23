namespace TrainGraphModel.Comom
{
    /// <summary>
    /// 有唯一编号的成员
    /// </summary>
    /// <typeparam name="key"></typeparam>
    public interface IStaff<key>
    {
        key Key { get; }
        object Manager { get; set; }
    }


}
