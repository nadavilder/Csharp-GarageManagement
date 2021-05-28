using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class GarageLogic
    {
        private static readonly Dictionary<string, Client> m_Clients = new Dictionary<string, Client>();




        //1
        public static void AdmitNewVehicle(string i_OwnerName, string i_OwnerPhoneNumber, Vehicle i_Vehicle)
        {
            Client newClient = new Client(i_OwnerName, i_OwnerPhoneNumber, i_Vehicle);
            m_Clients.Add(i_Vehicle.LicensePlate, newClient);
        }


        //2
        public static List<string> ShowCurrentVehicles(string i_VehicleState)
        {
           
            List<string> vehicles = new List<string>();
            
            if (i_VehicleState == "")
            {
                foreach (string client in m_Clients.Keys)
                {
                        vehicles.Add(client);
                }

            }
            else
            {
                eVehicleState VehicleState = parseVehicleState(i_VehicleState);
                foreach(string client in m_Clients.Keys)
                {
                    if (m_Clients[client].VehicleState == VehicleState)
                    {
                        vehicles.Add(client);
                    }
                }

            }
            return vehicles;
        }

        //3
        public static void ChangeVehicleStatus(string i_LicensePlate, eVehicleState i_VehicleState)
        {
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

               if(m_Clients[i_LicensePlate].Vehicle.EngineType == Engine.eEngineType.Fuel)
                {
                    FuelEngine engine = m_Clients[i_LicensePlate].Vehicle.Engine as FuelEngine;
                    if(engine.FuelType == i_FuelType)
                    {
                        filled = m_Clients[i_LicensePlate].Vehicle.Engine.FillEngine(i_FillAmount);
                    }
                    else
                    {
                        throw new ArgumentException("Wrong Fuel Type");
                    }
                }
                else
                {
                    throw new ArgumentException("Vehicle is not a fuel based vehicle");
                }
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
                if(m_Clients[i_LicensePlate].Vehicle.EngineType == Engine.eEngineType.Electric)
                {
                    filled = m_Clients[i_LicensePlate].Vehicle.Engine.FillEngine(i_FillAmount);
                }
                else
                {
                    throw new ArgumentException("Vehicle is not an electric vehicle");
                }
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

        public static bool CheckVehicleExists(string i_LicensePlate)
        {
            return m_Clients.ContainsKey(i_LicensePlate);
        }

        private static eVehicleState parseVehicleState(string i_VehicleState)
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
