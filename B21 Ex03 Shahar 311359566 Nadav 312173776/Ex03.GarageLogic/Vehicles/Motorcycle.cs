using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Motorcycle : Vehicle
    {
        private string m_LicenseType;
        private int m_EngineVolume;
        public Motorcycle(string i_ModelName, string i_LicesnsePlateNum, float i_AmountOfEnergtLeft, Wheel[] i_Wheels,Engine i_Engine, string i_AdditionalData) : base(i_ModelName, i_LicesnsePlateNum, i_AmountOfEnergtLeft, i_Wheels, i_Engine)
        {
            //parse "A, 56"
        }

        public override string ToString()
        {

            string res = base.ToString() + m_LicenseType.ToString() + m_EngineVolume.ToString();
            return res;
        }
    }
}
