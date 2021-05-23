using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class GarageLogic
    {
        //Dictionary of Vehicles ?based on electric and fuel?
        private static readonly Dictionary<string, Client> m_Clients = new Dictionary<string, Client>();




        //1
        public static void AdmitNewVehicle(string i_OwnerName, string i_OwnerPhoneNumber, eVehicleState i_VehicleState, Vehicle i_Vehicle)

        {
            Client newClient = new Client(i_OwnerName, i_OwnerPhoneNumber, i_VehicleState, i_Vehicle);
            m_Clients.Add(i_Vehicle.LicensePlate, newClient);
        }


        //2
        private static string[] ShowCurrentVehicles()
        {
            return null;
        }

        //3
        private static bool ChangeVehicleStatus(string i_LicensePlate, eVehicleState i_VehicleState)
        {
            bool updateSuccesful = false;
            if (m_Clients.ContainsKey(i_LicensePlate))
            {
                m_Clients[i_LicensePlate].VehicleState = i_VehicleState;
                updateSuccesful = true;
            }

            return updateSuccesful;
        }

        //4
        private static void FillAir(string i_LicensePlate)
        {
        }

        //5
        private static void FillFuelVehicle(string i_LicensePlate, FuelEngine.eFuelTypes i_FuelType, float i_FillAmount)
        {
        }

        //6
        private static void ChargeElectricVehicle(string i_LicensePlate, float i_FillAmount)
        {
        }

        //7
        private static void ShowVehicleDetails()
        {
        }

        

        public enum eVehicleState
        {
            In_Repair,
            Repaired,
            Paid_For
        }
    }
}
