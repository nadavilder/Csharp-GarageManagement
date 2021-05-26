using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Truck : Vehicle

    {
        private bool m_HazardsMat;
        private float m_MaxWeight;
        private const float MAXFUELCAPACITY = 120F;
        private const float MAXWHEELAIRCAPACITY = 28F;
        private const int NUMOFWHEELS = 16;
        public Truck(Factory.eVehicleType i_VehicleType)
        {
            m_VehicleType = i_VehicleType;
        }

        public override Dictionary<string, string> GetParams()
        {
            Dictionary<string, string> questions = base.GetParams();
            //questions.Add("Engine Type", "");
            questions.Add("Wheel manufacturer and current air pressure", $" up to {MAXWHEELAIRCAPACITY} seperated by a single space");
            questions.Add("Carring Hazardous Materials?", "Enter true of false");
            questions.Add("Max Weight", "");
            questions.Add("Current Fuel Liters", $"Up to {MAXFUELCAPACITY}");

            return questions;
        }

        public override void SetParams(Dictionary<string, string> i_Answers)
        {
            base.SetParams(i_Answers);
            m_HazardsMat = bool.Parse(i_Answers["Carring Hazardous Materials? Enter true of false"]);
            m_MaxWeight = float.Parse(i_Answers["Max Weight"]);
            m_Wheels = new Wheel[16];
            for (int i = 0; i < m_Wheels.Length; i++)
            {
                m_Wheels[i] = new Wheel(i_Answers["Wheel Manufacturer"], float.Parse(i_Answers["Wheel's Current Air Pressure"]), 26f);
            }
            m_Engine = new FuelEngine(FuelEngine.eFuelTypes.Soler, float.Parse(i_Answers["Current Fuel Liters"]), 120f);
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
                        m_MaxWeight = float.Parse(i_Answer);
                        break;
                    case "Wheel manufacturer and current air pressure":
                        m_Wheels = ParseWheelData(i_Answer, MAXWHEELAIRCAPACITY, NUMOFWHEELS);
                        break;
                    case "Current Fuel Liters":
                        float currentFuel = float.Parse(i_Answer);
                        if (currentFuel < 0 || currentFuel > MAXFUELCAPACITY)
                        {
                            throw new ArgumentException("Invalid number for fuel ammount");
                        }
                        m_Engine = new FuelEngine(FuelEngine.eFuelTypes.Soler, currentFuel, MAXFUELCAPACITY);
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
            return $"{base.ToString()} Carring Hazardous Materials: {m_HazardsMat}, Max Weight: {m_MaxWeight.ToString()}";
        }
    }
}

