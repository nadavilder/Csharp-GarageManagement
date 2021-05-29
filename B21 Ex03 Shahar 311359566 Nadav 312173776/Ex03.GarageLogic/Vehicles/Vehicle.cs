using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected readonly string r_LicesnsePlateNum;
        protected Factory.eVehicleType m_VehicleType;
        protected string m_ModelName;
        protected Engine m_Engine;
        protected Wheel[] m_Wheels;
        protected Engine.eEngineType m_EngineType;

        public Vehicle(Factory.eVehicleType i_VehicleType, Engine.eEngineType i_EngineType, string i_LicensePlate)
        {
            m_VehicleType = i_VehicleType;
            m_EngineType = i_EngineType;
            r_LicesnsePlateNum = i_LicensePlate;
        }
        
         public virtual Dictionary<string, string> GetParams()
        {
            Dictionary<string, string> questions = new Dictionary<string, string>();
            questions.Add("Model Name", string.Empty);
            
            return questions;
        }
        
        public virtual void SetParam(string i_Question, string i_Answer)
        {
            try
            {
                switch (i_Question)
                {
                    case "Model Name":
                        m_ModelName = i_Answer;
                        break;
                }
            }
            catch(FormatException)
            {
                throw new FormatException($"{i_Answer} is not a valid input for {i_Question}");
            }
        }

        protected Wheel[] ParseWheelData(string i_WheelData, float i_MaxAirPressue, int i_NumOfWheels)
        {
            Wheel[] wheels = new Wheel[i_NumOfWheels];
            string[] splitData = i_WheelData.Split(" ");
            if(splitData.Length != 2)
            {
                throw new FormatException("invalid wheel data");
            }

            float currentAirPressue = float.Parse(splitData[1]);
            if(currentAirPressue > i_MaxAirPressue)
            {
                throw new ArgumentException("Too much air for wheels");
            }

            for (int i = 0; i < i_NumOfWheels; i++)
            {
                wheels[i] = new Wheel(splitData[0], currentAirPressue, i_MaxAirPressue);
            }

            return wheels;
        }

        public bool FillAir()
        {
            bool filled = false;
            foreach(Wheel wheel in m_Wheels)
            {
                if (wheel.FillAir(wheel.AirMissing))
                {
                    filled = true;
                }
            }

            return filled;
        }

        public override string ToString()
        {
            return $"\nVehicle: {m_VehicleType} , Model: {m_ModelName} , Liecense Plate: {r_LicesnsePlateNum} , Energy: {AmountOfEnergyLeft}\nEngine: {m_Engine} , \nWheels Details: Number of Wheels: {m_Wheels.Length} , {m_Wheels[0]}\n";
        }

        public Engine Engine
        {
            get { return m_Engine; }
        }

        public float AmountOfEnergyLeft
        {
            get { return m_Engine.AmountOfEnergyLeft; }
        }

        public string LicensePlate
        {
            get { return r_LicesnsePlateNum; }
        }

        public Engine.eEngineType EngineType
        {
            get { return m_EngineType; }
        }
    }
}
