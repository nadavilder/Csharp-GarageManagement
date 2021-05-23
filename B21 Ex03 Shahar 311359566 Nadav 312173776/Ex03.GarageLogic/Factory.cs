﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Factory
    {
        
        public static Vehicle CreateVehicleFromData(string i_Type)
        {
            eVehicleType vehicleType = ParseVehicleType(i_Type);
            Vehicle newVehicle = null;

            switch (vehicleType)
            {
                case eVehicleType.Electric_Motorcycle:
                    newVehicle = new Motorcycle(Engine.eEngineType.Electric);
                    break;
                case eVehicleType.Fuel_Motorcycle:
                    newVehicle = new Motorcycle(Engine.eEngineType.fuel);
                    break;
                case eVehicleType.Electric_Car:
                    newVehicle = new Car(Engine.eEngineType.Electric);
                    break;
                case eVehicleType.Fuel_Car:
                    newVehicle = new Car(Engine.eEngineType.fuel);
                    break;
                case eVehicleType.Truck:
                    newVehicle = new Truck();
                    break;


            }
            return newVehicle;
        }
        
        private static eVehicleType ParseVehicleType(string i_VehicleType)
        {
            eVehicleType type;
            switch (i_VehicleType)
            {
                case "Electric Motorcycle":
                    type = eVehicleType.Electric_Motorcycle;
                    break;
                case "Fuel Motorcycle":
                    type = eVehicleType.Fuel_Motorcycle;
                    break;
                case "Electric Car":
                    type = eVehicleType.Electric_Car;
                    break;
                case "Fuel Car":
                    type = eVehicleType.Fuel_Car;
                    break;
                case "Truck":
                    type = eVehicleType.Truck;
                    break;
                default:
                    throw new ArgumentException(i_VehicleType);
            }
            return type;
        }
        public enum eVehicleType
        {
            Electric_Motorcycle,
            Fuel_Motorcycle,
            Electric_Car,
            Fuel_Car,
            Truck,

        }
    }
}
