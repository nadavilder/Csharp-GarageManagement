using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private const float k_MaxFuelCapacity = 120F;
        private const float k_MaxWheelAirCapacity = 28F;
        private const int k_NumOfWheels = 16;
        private bool m_HazardsMat;
        private float m_MaxWeight;

        public Truck(Factory.eVehicleType i_VehicleType, Engine.eEngineType i_EngineType, string i_LicensePlate) : base(i_VehicleType, i_EngineType, i_LicensePlate)
        {
        }

        public override Dictionary<string, string> GetParams()
        {
            Dictionary<string, string> questions = base.GetParams();
            questions.Add("Wheel manufacturer and current air pressure", $" up to {k_MaxWheelAirCapacity} seperated by a single space");
            questions.Add("Carring Hazardous Materials?", "Enter true of false");
            questions.Add("Max Weight", string.Empty);
            questions.Add("Current Fuel Liters", $" Up to {k_MaxFuelCapacity} liters");

            return questions;
        }

        public override void SetParam(string i_Question, string i_Answer)
        {
            base.SetParam(i_Question, i_Answer);
            try
            {
                switch (i_Question)
                {
                    case "Carring Hazardous Materials?":
                        m_HazardsMat = bool.Parse(i_Answer);
                        break;
                    case "Max Weight":
                        float maxWeight = float.Parse(i_Answer);
                        if (maxWeight < 0)
                        {
                            throw new ArgumentException("Weight cannot be negative");
                        }

                        m_MaxWeight = maxWeight;
                        break;
                    case "Wheel manufacturer and current air pressure":
                        m_Wheels = ParseWheelData(i_Answer, k_MaxWheelAirCapacity, k_NumOfWheels);
                        break;
                    case "Current Fuel Liters":
                        float currentFuel = float.Parse(i_Answer);
                        if (currentFuel < 0 || currentFuel > k_MaxFuelCapacity)
                        {
                            throw new ArgumentException("Invalid number for fuel ammount");
                        }

                        m_Engine = new FuelEngine(FuelEngine.eFuelTypes.Soler, currentFuel, k_MaxFuelCapacity);
                        break;
                }
            }
            catch (FormatException ex)
            {
                throw new FormatException($"{i_Answer} is not a valid input for {i_Question}");
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}Carring Hazardous Materials: {m_HazardsMat} , Max Weight: {m_MaxWeight.ToString()}";
        }
    }
}