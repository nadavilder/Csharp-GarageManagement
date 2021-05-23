using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected string m_ModelName;
        protected string  m_LicesnsePlateNum;
        protected float m_AmountOfEnergtLeft;
        protected Engine m_Engine;
        protected Wheel[] m_Wheels;

        
        public Vehicle()
        {

        }
        
        
        public Vehicle(string i_ModelName, string i_LicesnsePlateNum, float i_AmountOfEnergtLeft, Wheel[] i_Wheels, Engine i_Engine)
        {
            m_ModelName = i_ModelName;
            m_LicesnsePlateNum = i_LicesnsePlateNum;
            m_AmountOfEnergtLeft = i_AmountOfEnergtLeft;
           // m_Wheels = i_Wheels;
            //m_Engine = i_Engine;
        }

         public virtual Dictionary<string,string> GetParams()
        {
            Dictionary<string, string> questions =  new Dictionary<string, string>();
            questions.Add("License Plate Number", "");
            questions.Add("Model Name", "");
            questions.Add("Amount of Energy Left", "");
            questions.Add("Wheel Manufacturer", "");
            questions.Add("Wheel's Current Air Pressure", "");
            


            return questions;
        }


        public virtual void SetParams(Dictionary<string, string> i_Answers)
        {
            
            m_ModelName = i_Answers["Model Name"];
            m_LicesnsePlateNum = i_Answers["License Plate Number"];
            m_AmountOfEnergtLeft = float.Parse(i_Answers["Amount of Energy Left"]);
         
        }


        public Engine Engine
        {
            get { return m_Engine; }
        }

        public string LicensePlate
        {
            get { return m_LicesnsePlateNum; }
        }
    }
}
