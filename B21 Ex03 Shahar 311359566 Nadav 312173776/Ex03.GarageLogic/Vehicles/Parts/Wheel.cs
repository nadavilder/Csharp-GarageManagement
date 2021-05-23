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

        private void FillAir(float i_AirToFill)
        {
            try
            {
                if (m_CurrentPressure + i_AirToFill <= m_MaxPressure)
                {
                    m_CurrentPressure += i_AirToFill;
                }
                else throw new ArgumentOutOfRangeException("The current + the value is more then Maximum pressure");
            }
            catch
            {
                throw new ArgumentException("illegal value");
            }
                
            
        }



    }


}
