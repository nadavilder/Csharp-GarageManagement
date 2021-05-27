using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Engine
    {
        private float m_CurrentEnergyAmount;
        private float m_MaxEnergyAmount;


        public Engine(float i_CurrentEnergyAmount, float i_MaxEnergyAmount)
        {
            m_CurrentEnergyAmount = i_CurrentEnergyAmount;
            m_MaxEnergyAmount = i_MaxEnergyAmount;
        }

        public bool FillEngine(float i_FillAmount)
        {
            bool filled = false;
            if (m_CurrentEnergyAmount + i_FillAmount <= m_MaxEnergyAmount)
            {
                m_CurrentEnergyAmount += i_FillAmount;
                if (i_FillAmount > 0)
                {
                    filled = true;
                }
            }
            else throw new ValueOutOfRangeException("The current + the value is more then Maximum tank amount");
            return filled;
        }


        public override string ToString()
        {
            return ($"Current Energy Amount: {m_CurrentEnergyAmount} , Max Energy Amount: {m_MaxEnergyAmount}");
        }


        public float AmountOfEnergyLeft
        {
            get { return (m_CurrentEnergyAmount / m_MaxEnergyAmount) * 100; }
        }


        public enum eEngineType
        {
            Electric,
            Fuel
        }
    }
}
