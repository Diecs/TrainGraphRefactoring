using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TrainGraphModel;
using TrainGraphModel.Comom;

namespace TrainGraphModel.Line
{
    /// <summary>
    /// ��վ
    /// </summary>
    public class Station:ReadOnlyParentBase<StopArea>, IStaff<ushort>
    {
        #region ����

        /// <summary>
        /// ��վID
        /// </summary>
        public ushort ID { get; }
        public ushort Key => ID;
        public object Manager { get; set; }
        public StationManager StationManager => Manager as StationManager;
        /// <summary>
        /// ��վ����
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// ��վ����
        /// </summary>
        public StationType StationType { get; }

        /// <summary>
        /// ���ͣ�������б�
        /// </summary>
        public IReadOnlyList<StopArea> StopAreas => Sons;

        /// <summary>
        /// ȡ�ñ���վͣ�������������
        /// </summary>
        public double MaxKilometer => StopAreas.Max(s => s.Kilometer);
        /// <summary>
        /// ȡ�ñ���վͣ�������������⹫���
        /// </summary>
        public double MaxVirtualKilometer => StopAreas.Max(s => s.VirtualKilometer);

        #endregion

        public Station(ushort id,string name,StationType stationType,List<StopArea> stopAreas)
            :base(stopAreas)
        {
            ID = id;
            Name = name;
            StationType = stationType;
        }

        public static int SortByKiloAsc(Station objA, Station objB)
        {
            if (objA.MaxKilometer < objB.MaxKilometer)
            {
                return -1;
            }
            else if (objA.MaxKilometer > objB.MaxKilometer)
            {
                return 1;
            }
            else
            {
                return 0;
            }

        }

        public static int SortByKiloDesc(Station objA, Station objB)
        {
            if (objA.MaxKilometer > objB.MaxKilometer)
            {
                return -1;
            }
            else if (objA.MaxKilometer < objB.MaxKilometer)
            {
                return 1;
            }
            else
            {
                return 0;
            }

        }

    }

}