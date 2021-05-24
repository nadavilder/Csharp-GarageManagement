using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
   public class Client
    {
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private GarageLogic.eVehicleState m_VehicleState;
        private Vehicle m_Vehicle;

        public Client(string i_OwnerName, string i_OwnerPhoneNumber, Vehicle i_Vehicle)
        {
            m_OwnerName = i_OwnerName;
            m_OwnerPhoneNumber = i_OwnerPhoneNumber;
            m_VehicleState = GarageLogic.eVehicleState.In_Repair;
            m_Vehicle = i_Vehicle;
            
        }

        public Vehicle Vehicle
        {
            get { return m_Vehicle; }
        }

        public string OwnerName
        {
            get { return m_OwnerName; }
        }

        public string OwnerPhoneNumber
        {
            get { return m_OwnerPhoneNumber; }
        }

        public GarageLogic.eVehicleState VehicleState
        {
            get { return m_VehicleState; }
            set { m_VehicleState = value; }
        }

        public override string ToString()
        {
            return ($"Owner Name: {m_OwnerName} Phone Number: {m_OwnerPhoneNumber} Vehicle State: {m_VehicleState} " + m_Vehicle.ToString());
        }
    }
}
