using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class FuelEngine: Engine
    {
        private eFuelTypes m_FuelType;
    

        public FuelEngine(eFuelTypes i_FuelType, float i_CurrentEnergyAmount, float i_MaxEnergyAmount) : base(i_CurrentEnergyAmount, i_MaxEnergyAmount)
        {
            m_FuelType = i_FuelType;
        }

        public enum eFuelTypes
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }


    }
}
