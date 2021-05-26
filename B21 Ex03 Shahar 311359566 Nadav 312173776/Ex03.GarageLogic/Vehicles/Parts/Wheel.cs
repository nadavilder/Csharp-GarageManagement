using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_Manufacturer;
        private float m_CurrentPressure;
        private float m_MaxPressure;

        public Wheel(string i_Manufacturer,float i_CurrentPressure, float i_MaxPressure)
        {
            m_Manufacturer = i_Manufacturer;
            m_CurrentPressure = i_CurrentPressure;
            m_MaxPressure = i_MaxPressure;

        }

/*        public bool FillAir()
        {
            bool filled = false;
            if (m_CurrentPressure < m_MaxPressure)
            {
                m_CurrentPressure = m_MaxPressure;
                filled = true;
            }
            return filled;
        }*/

        public bool FillAir(float i_AirToFill)
        {
            bool filled = false;
            if (m_CurrentPressure + i_AirToFill <= m_MaxPressure)
            {
                m_CurrentPressure += i_AirToFill;
                filled = true;
            }
            else throw new ValueOutOfRangeException("The current + the value is more then Maximum pressure");
            return filled;

        }

        public override string ToString()
        {
            return ($"Manufacturer: {m_Manufacturer} , Current Air Pressure: {m_CurrentPressure} , Max Air Pressure: {m_MaxPressure}");
        }

        public float AirMissing
        {
            get { return m_MaxPressure- m_CurrentPressure; }
        }




    }


}
