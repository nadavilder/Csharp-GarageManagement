using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Truck: Vehicle
      
    {
        private bool m_HazardsMat;
        private float m_MaxWeight;
        private Wheel[] m_Wheels = new Wheel[16];
        public Truck()
        {

        }

        public override Dictionary<string, string> GetParams()
        {
            Dictionary<string, string> questions = base.GetParams();
            questions.Add("Engine Type", "");
            questions.Add("Hazardous Materials", "");
            questions.Add("Max Weight", "");
            questions.Add("Current Fuel Liters", "");
           
            return questions;
        }

        public override void SetParams(Dictionary<string, string> i_Answers)
        {
            base.SetParams(i_Answers);
            m_HazardsMat = bool.Parse(i_Answers["Hazardous Materials"]);
            m_MaxWeight = float.Parse(i_Answers["Max Weight"]);
            m_Wheels = new Wheel[16];
            for (int i = 0; i < m_Wheels.Length; i++)
            {
                m_Wheels[i] = new Wheel(i_Answers["Wheel Manufacturer"], float.Parse(i_Answers["Wheel's Current Air Pressure"]), 26f);
            }
            Engine newEngine = new FuelEngine(FuelEngine.eFuelTypes.Soler, float.Parse(i_Answers["Current Fuel Liters"]), 120f);
        }
    }


    }

