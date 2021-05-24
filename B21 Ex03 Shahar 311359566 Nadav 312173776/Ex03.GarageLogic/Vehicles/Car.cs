using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Car:Vehicle
    {
        private string m_Color;
        private int m_Doors;
        private Engine.eEngineType m_EngineType;
      
        public Car(Engine.eEngineType i_EngineType)
        {
            m_EngineType = i_EngineType;
        }

        public override Dictionary<string, string> GetParams()
        {
            Dictionary<string, string> questions = base.GetParams();
            questions.Add("Engine Type", "");
            questions.Add("Car Color", "");
            questions.Add("Number Of Doors", "");
            switch (m_EngineType)
            {
                case Engine.eEngineType.Electric:
                    questions.Add("Current Battery Charge", "");
                    break;
                case Engine.eEngineType.Fuel:
                    questions.Add("Current Fuel Liters", "");
                    break;
            }
            return questions;


        }

        public override void SetParams(Dictionary<string, string> i_Answers)
        {
            base.SetParams(i_Answers);
            m_Color = i_Answers["Car Color"];
            m_Doors = Int32.Parse(i_Answers["Number Of Doors"]);
            m_Wheels = new Wheel[4];
            for (int i = 0; i < m_Wheels.Length; i++)
            {
                m_Wheels[i] = new Wheel(i_Answers["Wheel Manufacturer"], float.Parse(i_Answers["Wheel's Current Air Pressure"]), 32f);
            }
            Engine newEngine = null;
            switch (m_EngineType)
            {
                case Engine.eEngineType.Electric:
                    newEngine = new ElectricEngine(float.Parse(i_Answers["Current Battery Charge"]), 3.2f);
                    break;
                case Engine.eEngineType.Fuel:
                    newEngine = new FuelEngine(FuelEngine.eFuelTypes.Octan95, float.Parse(i_Answers["Current Fuel Liters"]), 45f);
                    break;
            }

        }


    }
}
