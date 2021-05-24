﻿using System;
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
        private static List<string> ShowCurrentVehicles(string i_VehicleState)
        {
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
        private static bool ChangeVehicleStatus(string i_LicensePlate, string i_VehicleState)
        {
            eVehicleState VehicleState = ParseVehicleState(i_VehicleState);
            bool updateSuccesful = false;
            if (m_Clients.ContainsKey(i_LicensePlate))
            {
                m_Clients[i_LicensePlate].VehicleState = VehicleState;
                updateSuccesful = true;
            }

            return updateSuccesful;
        }

        //4
        private static bool FillAir(string i_LicensePlate)
        {
            bool filled = false;
            try
            {
                m_Clients[i_LicensePlate].Vehicle.FillAir();
            }
            catch (KeyNotFoundException ex)
            {
                throw (new ArgumentException(i_LicensePlate));
            }

            return filled;
        }

        //5
        private static bool FillFuelVehicle(string i_LicensePlate, FuelEngine.eFuelTypes i_FuelType, float i_FillAmount)
        {
            bool filled = false;
            try
            {
                m_Clients[i_LicensePlate].Vehicle.Engine.FillEngine(i_FuelType, i_FillAmount);
            }
            catch (KeyNotFoundException ex)
            {
                throw (new ArgumentException(i_LicensePlate));
            }

            return filled;
        }

        //6
        private static bool ChargeElectricVehicle(string i_LicensePlate, float i_FillAmount)
        {
            bool filled = false;
            try
            {
                m_Clients[i_LicensePlate].Vehicle.Engine.FillEngine(i_FillAmount);
            }
            catch (KeyNotFoundException ex)
            {
                throw (new ArgumentException(i_LicensePlate));
            }

            return filled;
        }

        //7
        private static string ShowVehicleDetails(string i_LicensePlate)
        {
            try
            {
                return m_Clients[i_LicensePlate].ToString();
            }
            catch (KeyNotFoundException ex)
            {
                throw (new ArgumentException(i_LicensePlate));
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
                    throw new ArgumentException(i_VehicleState);
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
