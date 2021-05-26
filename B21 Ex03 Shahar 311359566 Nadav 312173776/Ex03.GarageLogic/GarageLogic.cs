using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class GarageLogic
    {
        public static readonly Dictionary<string, Client> m_Clients = new Dictionary<string, Client>();




        //1
        public static void AdmitNewVehicle(string i_OwnerName, string i_OwnerPhoneNumber, Vehicle i_Vehicle)
        {
            Client newClient = new Client(i_OwnerName, i_OwnerPhoneNumber, i_Vehicle);
            m_Clients.Add(i_Vehicle.LicensePlate, newClient);
        }


        //2
        public static List<string> ShowCurrentVehicles(string i_VehicleState)
        {
            //Logic for no filter
            eVehicleState VehicleState = ParseVehicleState(i_VehicleState);
            List<string> vehicles = new List<string>();
            foreach(string client in m_Clients.Keys)
            {
                if (m_Clients[client].VehicleState == VehicleState)
                {
                    vehicles.Add(client);
                }
            }
            return vehicles;
        }

        //3
        public static void ChangeVehicleStatus(string i_LicensePlate, eVehicleState i_VehicleState)
        {
          //  eVehicleState VehicleState = ParseVehicleState(i_VehicleState);
            try
            {
                m_Clients[i_LicensePlate].VehicleState = i_VehicleState;
            }
            catch (KeyNotFoundException ex)
            {
                throw (new KeyNotFoundException(i_LicensePlate));
            }
        }

        //4
        public static bool FillAir(string i_LicensePlate)
        {
            bool filled = false;
            try
            {
                filled = m_Clients[i_LicensePlate].Vehicle.FillAir();
            }
            catch (KeyNotFoundException ex)
            {
                throw (new KeyNotFoundException(i_LicensePlate));
            }

            return filled;
        }

        //5
        public static bool FillFuelVehicle(string i_LicensePlate, FuelEngine.eFuelTypes i_FuelType, float i_FillAmount)
        {
            bool filled = false;
            try
            {
               /* if (!Check Fuel Type and throw argument exception if not valid)
                {
                    throw new ArgumentException(i_FuelType.ToString());
                }*/
                m_Clients[i_LicensePlate].Vehicle.Engine.FillEngine(i_FillAmount);
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException(i_LicensePlate);
            }
            return filled;
        }

        //6
        public static bool ChargeElectricVehicle(string i_LicensePlate, float i_FillAmount)
        {
            bool filled = false;
            try
            {
                m_Clients[i_LicensePlate].Vehicle.Engine.FillEngine(i_FillAmount);
            }
            catch (KeyNotFoundException ex)
            {
                throw (new KeyNotFoundException(i_LicensePlate));
            }

            return filled;
        }

        //7
        public static string ShowVehicleDetails(string i_LicensePlate)
        {
            try
            {
                return m_Clients[i_LicensePlate].ToString();
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException($"The vehicle {i_LicensePlate} does not exists");
            }
        }

        private static eVehicleState ParseVehicleState(string i_VehicleState)
        {
            eVehicleState state;
            switch (i_VehicleState)
            {
                case "In Repair":
                    state = eVehicleState.In_Repair;
                    break;
                case "Repaired":
                    state = eVehicleState.Repaired;
                    break;
                case "Paid For":
                    state = eVehicleState.Paid_For;
                    break;
                default:
                    throw new FormatException(i_VehicleState);
            }
            return state;
        }

        public enum eVehicleState
        {
            In_Repair,
            Repaired,
            Paid_For
        }
    }
}
