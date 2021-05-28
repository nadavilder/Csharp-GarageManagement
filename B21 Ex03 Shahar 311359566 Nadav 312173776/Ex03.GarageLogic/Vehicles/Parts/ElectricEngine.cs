using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class ElectricEngine : Engine
    {
        public ElectricEngine(float i_CurrentEnergyAmount, float i_MaxEnergyAmount) : base(i_CurrentEnergyAmount, i_MaxEnergyAmount)
        {

        }

        public override string ToString()
        {
            return $"The time left for driving is {CurrentEnergyAmount} hours out of {MaxEnergyAmount} hours";
        }
    }
}

