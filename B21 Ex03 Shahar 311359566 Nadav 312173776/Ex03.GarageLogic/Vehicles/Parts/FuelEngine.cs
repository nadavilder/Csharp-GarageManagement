using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelEngine : Engine
    {
        private eFuelTypes m_FuelType;
    
        public FuelEngine(eFuelTypes i_FuelType, float i_CurrentEnergyAmount, float i_MaxEnergyAmount) : base(i_CurrentEnergyAmount, i_MaxEnergyAmount)
        {
            m_FuelType = i_FuelType;
        }

        public static eFuelTypes ParseFuelTypes(string i_FuelType)
        {
            eFuelTypes type;
            switch (i_FuelType)
            {
                case "Soler":
                    type = eFuelTypes.Soler;
                    break;
                case "Octan95":
                    type = eFuelTypes.Octan95;
                    break;
                case "Octan96":
                    type = eFuelTypes.Octan96;
                    break;
                case "Octan98":
                    type = eFuelTypes.Octan98;
                    break;
                default:
                    throw new FormatException($"{i_FuelType} is not a valid fuel type");
            }

            return type;
        }

        public override string ToString()
        {
            return $"The amount of fuel remaining is {CurrentEnergyAmount} Liters out of {MaxEnergyAmount} Liters , Fuel Type: { m_FuelType}";
        }

        public eFuelTypes FuelType
        {
            get { return m_FuelType; }
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