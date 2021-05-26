using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Motorcycle : Vehicle
    {
        private eLicenseType m_LicenseType;
        private int m_EngineVolume;
        private Engine.eEngineType m_EngineType;
        private const float MAXBATTERYCHARGE = 1.8F;
        private const float MAXFUELCAPACITY = 6F;
        private const float MAXWHEELAIRCAPACITY = 30F;
        private const int NUMOFWHEELS = 2;


        public Motorcycle(Engine.eEngineType i_EngineType,Factory.eVehicleType i_VehicleType)
        {
            m_VehicleType = i_VehicleType;
            m_EngineType = i_EngineType;
        }
        

        public override Dictionary<string, string> GetParams()
        {
            //Key for questions and value for possible values if there are any
            Dictionary<string, string> questions = base.GetParams();
            //questions.Add("Engine Type", "");
            questions.Add("Wheel manufacturer and current air pressure", $" up to {MAXWHEELAIRCAPACITY} seperated by a single space");
            questions.Add("License Type", " From the following options: A, AA, B1, BB");
            questions.Add("Motor Volume in cc", "");
            switch (m_EngineType)
            {
                case Engine.eEngineType.Electric:
                    questions.Add("Current Battery Charge", $" up to {MAXBATTERYCHARGE}");
                    break;
                case Engine.eEngineType.Fuel:
                    questions.Add("Current Fuel Liters", $" up to {MAXFUELCAPACITY}");
                    break;      
            }
            return questions;

        }

        public override void SetParams(Dictionary<string, string> i_Answers)
        {
            base.SetParams(i_Answers);
            //m_LicenseType= i_Answers["License Type"];
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

        public override void SetParam(string i_Question, string i_Answer)
        {
            base.SetParam(i_Question, i_Answer);
            try
            {
                switch (i_Question)
                {
                    case "License Type":
                        //m_LicenseType = ParseLicenseType(i_Answer);
                        if(!Enum.TryParse(i_Answer, out m_LicenseType))
                        {
                            throw new ArgumentException("Invalid License type");
                        }
                        break;
                    case "Motor Volume in cc":
                        m_EngineVolume = Int32.Parse(i_Answer);
                        break;
                    case "Amount of Energy Left":
                        m_AmountOfEnergyLeft = float.Parse(i_Answer);
                        break;
                    case "Wheel manufacturer and current air pressure":
                        m_Wheels = ParseWheelData(i_Answer, MAXWHEELAIRCAPACITY, NUMOFWHEELS);
                        break;
                    case "Current Battery Charge":
                        float currentBatteryCahrge = float.Parse(i_Answer);
                        if (currentBatteryCahrge < 0 || currentBatteryCahrge > MAXBATTERYCHARGE)
                        {
                            throw new ArgumentException("Invalid number for battery charge");
                        }
                        m_Engine = new ElectricEngine(currentBatteryCahrge, MAXBATTERYCHARGE);
                        break;
                    case "Current Fuel Liters":
                        float currentFuel = float.Parse(i_Answer);
                        if (currentFuel < 0 || currentFuel > MAXFUELCAPACITY)
                        {
                            throw new ArgumentException("Invalid number for fuel ammount");
                        }
                        m_Engine = new FuelEngine(FuelEngine.eFuelTypes.Octan98, currentFuel, MAXFUELCAPACITY);
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
            return $"{base.ToString()}License Type: {m_LicenseType} , Engine Volume: {m_EngineVolume}";
        }

        private eLicenseType ParseLicenseType(string i_LicenseType)
        {
            eLicenseType type;
            switch (i_LicenseType)
            {
                case "A":
                    type = eLicenseType.A;
                    break;
                case "AA":
                    type = eLicenseType.AA;
                    break;
                case "B1":
                    type = eLicenseType.B1;
                    break;
                case "BB":
                    type = eLicenseType.BB;
                    break;
                default:
                    throw new FormatException();
            }
            return type;
        }
        private enum eLicenseType
        {
            A,
            AA,
            B1,
            BB
        }
    }
}
