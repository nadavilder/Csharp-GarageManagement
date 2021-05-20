using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    abstract class Vehicle
    {
        protected string m_ModelName;
        protected readonly string  m_LicesnsePlateNum;
        protected float m_AmountOfEnergtLeft;
        protected Wheel[] m_Wheels;
        protected Engine m_Engine;

        public Vehicle(string i_ModelName, string i_LicesnsePlateNum, float i_AmountOfEnergtLeft, Wheel[] i_Wheels, Engine i_Engine)
        {
            m_ModelName = i_ModelName;
            m_LicesnsePlateNum = i_LicesnsePlateNum;
            m_AmountOfEnergtLeft = i_AmountOfEnergtLeft;
            m_Wheels = i_Wheels;
            //m_Engine = i_Engine;
        }

        public Engine Engine
        {
            get { return m_Engine; }
        }

        public string LicensePlate
        {
            get { return m_LicesnsePlateNum; }
        }
    }
}
