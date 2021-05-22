using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class GarageLogic
    {
        //Dictionary of Vehicles ?based on electric and fuel?
        private static Dictionary<string, Client> m_Clients;




        //1
        public static bool AdmitNewVehicle(string i_VehicleType, string i_BasicVehicleData, string i_WheelData, string i_EngineData, string i_AdditionalData, string i_ClientData)

        {
            //Client newClient = new Client(newVehicle, i_ClientData);
            //m_Clients.Add(newClient.Vehicle.LicensePlate, newClient);
            return false;
        }


        //2
        private static string[] ShowCurrentVehicles()
        {
            return null;
        }

        //3
        private static void ChangeVehicleStatus(string i_LicensePlate, eVehicleState i_VehicleState)
        {
            m_Clients[i_LicensePlate].VehicleState = i_VehicleState;
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

        }
    }
}
