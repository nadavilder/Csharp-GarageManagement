using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Client
    {
        private Vehicle m_Vehicle;
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private GarageLogic.eVehicleState m_VehicleState;

        public Client(Vehicle i_Vehicle, string i_clientData)
        {
            m_Vehicle = i_Vehicle;
            ParseClientData(i_clientData);
        }

        private void ParseClientData(string i_clientData)
        {
            //TODO: parse inside

            throw new NotImplementedException();
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
    }
}
