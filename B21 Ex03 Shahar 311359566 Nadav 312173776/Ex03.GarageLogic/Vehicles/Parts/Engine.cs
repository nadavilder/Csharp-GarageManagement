using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Engine
    {
        private float m_CurrentEnergyAmount;
        private float m_MaxEnergyAmount;
        private const int k_MinFuel = 0;

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
                if (i_FillAmount > k_MinFuel)
                {
                    filled = true;
                }
            }
            else throw new ValueOutOfRangeException(k_MinFuel,m_MaxEnergyAmount-m_CurrentEnergyAmount);
            return filled;
        }


        public float CurrentEnergyAmount
        {
            get { return m_CurrentEnergyAmount; }
        }
        public float MaxEnergyAmount
        {
            get { return m_MaxEnergyAmount; }
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
