using System;
using System.Collections.Generic;
using System.Linq;
using TrainGraphModel.Comom;
using TrainGraphModel.Line;

namespace TrainGraphModel
{
    /// <summary>
    /// �г���·
    /// </summary>
    public class Routing :IStaff<ushort>
    {
        /// <summary>
        /// ��·���
        /// </summary>
        public ushort Id { get; }
        /// <summary>
        /// ��·����
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// ��·�ضα�־
        /// </summary>
        public string ShowMarkContent { get; }
        /// <summary>
        /// ��·����
        /// </summary>
        public TrainDirection Direction { get; }
        /// <summary>
        /// ��·����
        /// </summary>
        public string Discription { get; }

        List<StopArea> stopAreas;
        /// <summary>
        /// ��·�б�
        /// </summary>
        public IReadOnlyList<StopArea> StopAreas => stopAreas;

        public ushort Key => Id;

        public object Manager { get; set; }

        public StopArea StartStopArea => stopAreas.First();
        public StopArea EndStopArea => stopAreas.Last();


        public Routing( ushort id, string name, string showMarkContent, TrainDirection direction, string discription, List<StopArea> stopAreas)
        {
            Name = name;
            Id = id;
            ShowMarkContent = showMarkContent;
            Direction = direction;
            Discription = discription;
            this.stopAreas = stopAreas;
        }
    }

}
