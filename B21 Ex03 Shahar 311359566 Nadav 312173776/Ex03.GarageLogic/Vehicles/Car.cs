using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Car:Vehicle
    {
        private eCarColor m_Color;
        private int m_NumOfDoors;
        private const float k_MaxBatteryCharge = 3.2F;
        private const float k_MaxFuelCapacity = 45F;
        private const float k_MaxWheelAirCapacity = 32F;
        private const int k_NumOfWheels = 4;


        public Car(Factory.eVehicleType i_VehicleType, Engine.eEngineType i_EngineType, string i_LicensePlate) : base(i_VehicleType, i_EngineType, i_LicensePlate)
        {
        }

        public override Dictionary<string, string> GetParams()
        {
            Dictionary<string, string> questions = base.GetParams();
            questions.Add("Wheel manufacturer and current air pressure", $" up to {k_MaxWheelAirCapacity} seperated by a single space");
            questions.Add("Car Color", " From the following options: Red, Silver, White, Black");
            questions.Add("Number Of Doors", " from 2 up to 5");
            switch (m_EngineType)
            {
                case Engine.eEngineType.Electric:
                    questions.Add("Current Battery Charge", $" up to {k_MaxBatteryCharge} hours");
                    break;
                case Engine.eEngineType.Fuel:
                    questions.Add("Current Fuel Liters", $" up to {k_MaxFuelCapacity} liters");
                    break;
            }
            return questions;


        }



        public override void SetParam(string i_Question, string i_Answer)
        {
            base.SetParam(i_Question, i_Answer);
            try
            {
                switch (i_Question)
                {
                    case "Car Color":
                        m_Color = parseCarColor(i_Answer);
                        break;
                    case "Number Of Doors":
                        int numOfDoors = Int32.Parse(i_Answer);
                        if(numOfDoors<2 || numOfDoors > 5)
                        {
                            throw new ArgumentException("Ivalid amount of doors for this car");
                        }
                        m_NumOfDoors = numOfDoors;
                        break;
                    case "Wheel manufacturer and current air pressure":
                        m_Wheels = ParseWheelData(i_Answer, k_MaxWheelAirCapacity, k_NumOfWheels);
                        break;
                    case "Current Battery Charge":
                        float currentBatteryCahrge = float.Parse(i_Answer);
                        if (currentBatteryCahrge < 0 || currentBatteryCahrge > k_MaxBatteryCharge)
                        {
                            throw new ArgumentException("Invalid number for battery charge");
                        }
                        m_Engine = new ElectricEngine(currentBatteryCahrge, k_MaxBatteryCharge);
                        break;
                    case "Current Fuel Liters":
                        float currentFuel = float.Parse(i_Answer);
                        if (currentFuel < 0 || currentFuel > k_MaxFuelCapacity)
                        {
                            throw new ArgumentException("Invalid number for fuel ammount");
                        }
                        m_Engine = new FuelEngine(FuelEngine.eFuelTypes.Octan95, currentFuel, k_MaxFuelCapacity);
                        break;
                }
            }
            catch (FormatException ex)
            {
                throw new FormatException($"{i_Answer} is not a valid input for {i_Question}");
            }
        }

        private eCarColor parseCarColor(string i_CarColor)
        {
            eCarColor color;
            switch (i_CarColor)
            {
                case "Red":
                    color = eCarColor.Red;
                    break;
                case "Silver":
                    color = eCarColor.Silver;
                    break;
                case "White":
                    color = eCarColor.White;
                    break;
                case "Black":
                    color = eCarColor.Black;
                    break;
                default:
                    throw new FormatException();
            }
            return color;
        }
        
        public override string ToString()
        {
            return $"{base.ToString()}Car Color: {m_Color} , Door Number: {m_NumOfDoors}";
        }

        private enum eCarColor
        {
            Red,
            Silver,
            White,
            Black
        }
    }
}
