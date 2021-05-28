using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Factory
    {
        
        public static Vehicle CreateVehicleFromData(string i_VehicleType, string i_LicensePlate)
        {
            eVehicleType vehicleType = ParseVehicleType(i_VehicleType);

            Vehicle newVehicle = null;

            switch (vehicleType)
            {
                case eVehicleType.Electric_Motorcycle:
                    newVehicle = new Motorcycle(vehicleType, Engine.eEngineType.Electric, i_LicensePlate);
                    break;
                case eVehicleType.Fuel_Motorcycle:
                    newVehicle = new Motorcycle(vehicleType, Engine.eEngineType.Fuel, i_LicensePlate);
                    break;
                case eVehicleType.Electric_Car:
                    newVehicle = new Car(vehicleType, Engine.eEngineType.Electric, i_LicensePlate);
                    break;
                case eVehicleType.Fuel_Car:
                    newVehicle = new Car(vehicleType, Engine.eEngineType.Fuel, i_LicensePlate);
                    break;
                case eVehicleType.Truck:
                    newVehicle = new Truck(vehicleType, Engine.eEngineType.Fuel, i_LicensePlate);
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
                    throw new FormatException("Invalid Vehicle Type");
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
