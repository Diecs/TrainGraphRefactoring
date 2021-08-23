using System;

namespace TrainGraphModel.Comom
{
    public static class EnumConveter
    {

        public static StationType ConvertToStationType(string str)
        {
            var type = Convert.ToUInt16(str, 16);
            StationType etypeRet = StationType.NormalStation;

            // 车站类型0x55AA-无岔非集中站，0x55FF-有岔非集中站，0x5555-集中站,0xaa55-车辆段，0xaaaa-停车场
            switch (type)
            {
                case 0xaa55:
                    etypeRet = StationType.CarDepot;
                    break;
                case 0xaaaa:
                    etypeRet = StationType.CarDepot;
                    break;
            }

            return etypeRet;
        }

        public static TrainDirection ConvertToTrainDirection(string str)
        {
            foreach(TrainDirection value in Enum.GetValues(typeof(TrainDirection)))
            {
                if(value.ToString() == str)
                {
                    return value;
                }
            }
            throw new Exception();
        }

    }
}
