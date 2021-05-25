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

        public void FillEngine(float i_FillAmount)
        {

            try
            {
                if (m_CurrentEnergyAmount + i_FillAmount <= m_MaxEnergyAmount)
                {
                    m_CurrentEnergyAmount += i_FillAmount;
                }
                else throw new ArgumentOutOfRangeException("The current + the value is more then Maximum tank amount");
            }
            catch
            {
                throw new ArgumentException("illegal value");
            }
        }

        public override string ToString()
        {
            return ($"Current Energy Amount: {m_CurrentEnergyAmount} Max Energy Amount: {m_MaxEnergyAmount}");
        }

        public enum eEngineType
        {
            Electric,
            Fuel
        }
    }
}
