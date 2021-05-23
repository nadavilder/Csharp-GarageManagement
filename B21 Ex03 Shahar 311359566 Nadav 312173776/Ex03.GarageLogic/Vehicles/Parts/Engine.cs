using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Engine
    {
        float m_CurrentEnergyAmount;
        float m_MaxEnergyAmount;


        public Engine(float i_CurrentEnergyAmount, float i_MaxEnergyAmount)
        {
            m_CurrentEnergyAmount = i_CurrentEnergyAmount;
            m_MaxEnergyAmount = i_MaxEnergyAmount;
        }
        public enum eEngineType
        {
            Electric,
            Fuel
        }


        
    }
}
