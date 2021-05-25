using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Motorcycle : Vehicle
    {
        private string m_LicenseType;
        private int m_EngineVolume;
        private Engine.eEngineType m_EngineType;

        public Motorcycle(Engine.eEngineType i_EngineType,Factory.eVehicleType i_VehicleType)
        {
            m_VehicleType = i_VehicleType;
            m_EngineType = i_EngineType;
        }
        

        public override Dictionary<string, string> GetParams()
        {
            Dictionary<string, string> questions = base.GetParams();
            questions.Add("Engine Type", "");
            questions.Add("License Type", "");
            questions.Add("Motor Volume in cc", "");
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
            m_LicenseType= i_Answers["License Type"];
            m_EngineVolume = Int32.Parse(i_Answers["Motor Volume in cc"]);
            m_Wheels = new Wheel[2];
            for (int i = 0; i < m_Wheels.Length; i++)
            {
                m_Wheels[i]=new Wheel(i_Answers["Wheel Manufacturer"], float.Parse(i_Answers["Wheel's Current Air Pressure"]), 30f);
            }
           
            switch (m_EngineType)
            {
                case Engine.eEngineType.Electric:
                    m_Engine = new ElectricEngine(float.Parse(i_Answers["Current Battery Charge"]), 1.8f);
                    break;
                case Engine.eEngineType.Fuel:
                    m_Engine = new FuelEngine(FuelEngine.eFuelTypes.Octan98, float.Parse(i_Answers["Current Fuel Liters"]), 6f);
                    break;
            }

        }


        public override string ToString()
        {

            return $"{base.ToString()} License Type: {m_LicenseType}, Engine Volume: {m_EngineVolume}";
        }
    }
}
