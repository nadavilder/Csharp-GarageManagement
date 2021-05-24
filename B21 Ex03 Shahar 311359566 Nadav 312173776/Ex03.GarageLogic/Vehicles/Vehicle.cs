using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected Factory.eVehicleType m_VehicleType;
        protected string m_ModelName;
        protected string  m_LicesnsePlateNum;
        protected float m_AmountOfEnergyLeft;
        protected Engine m_Engine;
        protected Wheel[] m_Wheels;
        
        public Vehicle()
        {
        }
        
        
        public Vehicle(string i_ModelName, string i_LicesnsePlateNum, float i_AmountOfEnergtLeft, Wheel[] i_Wheels, Engine i_Engine)
        {
            m_ModelName = i_ModelName;
            m_LicesnsePlateNum = i_LicesnsePlateNum;
            m_AmountOfEnergyLeft = i_AmountOfEnergtLeft;
           // m_Wheels = i_Wheels;
            //m_Engine = i_Engine;
        }

         public virtual Dictionary<string,string> GetParams()
        {
            Dictionary<string, string> questions =  new Dictionary<string, string>();
           // questions.Add("License Plate Number", "");
            questions.Add("Model Name", "");
            questions.Add("Amount of Energy Left", "");
            questions.Add("Wheel Manufacturer", "");
            questions.Add("Wheel's Current Air Pressure", "");
            


            return questions;
        }


        
        public virtual void SetParams(Dictionary<string, string> i_Answers)
        {
            //m_LicesnsePlateNum = i_licensePlate;
            m_ModelName = i_Answers["Model Name"];
            m_AmountOfEnergyLeft = float.Parse(i_Answers["Amount of Energy Left"]);
        }


        public bool FillAir()
        {
            bool filled = false;
            foreach(Wheel wheel in m_Wheels)
            {
                //Calculate fill amount
                if (wheel.FillAir(wheel.AirMissing))
                {
                    filled = true;
                }
            }
            return filled;
        }

        public override string ToString()
        {
            return ($"Vehicle: {m_VehicleType} Model: {m_ModelName} Liecense Plate: {m_LicesnsePlateNum}  Energy: {m_AmountOfEnergyLeft} Engine: {m_Engine.ToString()}\n Wheels: {m_Wheels.ToString()}\n");
        }

        public Engine Engine
        {
            get { return m_Engine; }
        }

        public string LicensePlate
        {
            get { return m_LicesnsePlateNum; }
            set { m_LicesnsePlateNum = value; }
        }

        public Factory.eVehicleType VehicleType
        {
            get { return m_VehicleType; }
        }
    }
}
