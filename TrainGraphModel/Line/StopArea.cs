using System;
using TrainGraphModel;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TrainGraphModel.Comom;

namespace TrainGraphModel.Line
{
    /// <summary>
    /// ͣ������
    /// </summary>
    public class StopArea :ISon,IStaff<ushort>
    {
        /// <summary>
        /// ͣ����ID
        /// </summary>
        public ushort ID { get; }
        /// <summary>
        /// ͣ��������
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// ʵ�ʹ���꣨��λ���ף�
        /// </summary>
        public double Kilometer { get; }
        /// <summary>
        /// ���⹫��꣨��λ���ף�
        /// </summary>
        public double VirtualKilometer { get; }
        /// <summary>
        /// �Ƿ��۷���
        /// </summary>
        public bool IsReversalTrack { get; }
        /// <summary>
        /// �Ƿ�ת����
        /// </summary>
        public bool IsTransferTrack { get; }
        /// <summary>
        /// �Ƿ�վ̨��
        /// </summary>
        public bool IsPlatformTrack { get; }
        /// <summary>
        /// ���ڵ�����
        /// </summary>
        public Station Station => Parent as Station;
        public object Parent { get; set; }

        public ushort Key => ID;

        public object Manager { get ; set ; }

        public StopArea(ushort iD, string name, double kilometer, double virtualKilometer,
            bool isReversalTrack,bool isTransferTrack,bool isPlatformTrack)
        {
            ID = iD;
            Name = name;
            Kilometer = kilometer;
            VirtualKilometer = virtualKilometer;
            IsReversalTrack = isReversalTrack;
            IsTransferTrack = isTransferTrack;
            IsPlatformTrack = isPlatformTrack;
        }

    }

}
