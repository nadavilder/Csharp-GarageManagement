using System;
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
                case eVehicleType.Electric_motorcycle:
                    newVehicle = new Motorcycle();
                    break;
                case eVehicleType.Fuel_motorcycle:
                    newVehicle = new Motorcycle();
                    break;
                case eVehicleType.Truck:
                    newVehicle = new Truck();
                    break;


            }
            return newVehicle;
        }

        
        private static FuelEngine CreateFuelEngineFromData(object i_EngineData)
        {
            //Parse Fuel Type
            // Parse Engine data
            throw new NotImplementedException();
        }

        private static ElectricEngine CreateElectricEngineFromData(object i_EngineData)
        {
            // Parse Engine data

            throw new NotImplementedException();
        }

        //"manu 15 32,"
        private static Wheel[] CreateWheelsFromData(string i_WheelData)
        {
            Wheel[] newWheels = new Wheel[i_WheelData.Length];
            return newWheels;
        }

        private static eVehicleType ParseVehicleType(string i_VehicleType)
        {
            return eVehicleType.Electric_motorcycle;
        }
        public enum eVehicleType
        {
            Electric_motorcycle,
            Fuel_motorcycle,
            Electric_car,
            Fuel_car,
            Truck,

        }

        
    }
}
