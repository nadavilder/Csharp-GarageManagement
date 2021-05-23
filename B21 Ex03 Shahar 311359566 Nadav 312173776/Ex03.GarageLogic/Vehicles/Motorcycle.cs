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

        public Motorcycle(Engine.eEngineType i_EngineType)
        {
            m_EngineType = i_EngineType;
        }
        
        public Motorcycle(string i_ModelName, string i_LicesnsePlateNum, float i_AmountOfEnergtLeft, Wheel[] i_Wheels,Engine i_Engine, string i_AdditionalData) : base(i_ModelName, i_LicesnsePlateNum, i_AmountOfEnergtLeft, i_Wheels, i_Engine)
        {
            //parse "A, 56"
        }

        public override Dictionary<string, string> GetParams()
        {
            Dictionary<string, string> questions = base.GetParams();
            questions.Add("License Type", "");
            questions.Add("Motor Volume in cc", "");
            switch (m_EngineType)
            {
                case Engine.eEngineType.Electric:
                    //Add electric qeustions
                    break;
                    
            }
            return questions;

        }

        public override void SetParams(Dictionary<string, string> i_Answers)
        {
            base.SetParams(i_Answers);

            m_LicenseType= i_Answers["License Type"];
            m_EngineVolume = Int32.Parse(i_Answers["Motor Volume in cc"]);

        }


        public override string ToString()
        {

            string res = base.ToString() + m_LicenseType.ToString() + m_EngineVolume.ToString();
            return res;
        }
    }
}
