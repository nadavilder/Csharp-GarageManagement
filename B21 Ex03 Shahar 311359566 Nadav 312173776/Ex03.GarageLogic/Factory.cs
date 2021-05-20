using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Factory
    {
        
        public static Vehicle CreateVehicleFromData(string i_Type, string i_BasicVehicleData, string i_WheelData, string i_EngineData, string i_AdditionalData)
        {
            eVehicleType vehicleType = ParseVehicleType(i_Type);
            Vehicle newVehicle = null;
            //Parse everything other than additional
            Wheel[] newWheels = CreateWheelsFromData(i_WheelData);

            switch (i_Type)
            {
                case eVehicleType.Electric_motorcycle:
                    ElectricEngine electricEngine = CreateElectricEngineFromData(i_EngineData);
                    newVehicle = new Motorcycle();
                    break;
                case eVehicleType.Fuel_motorcycle:
                    FuelEngine fuelEngine = CreateFuelEngineFromData(i_EngineData);
                    newVehicle = new Motorcycle();
                    break;
                case eVehicleType.Truck:
                    FuelEngine fuelEngine = CreateFuelEngineFromData(i_EngineData);
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

        "manu 15 32,"
        private static Wheel[] CreateWheelsFromData(string i_WheelData)
        {
            Wheel[] newWheels = new Wheel[i_WheelData.Length];
            return newWheels;
        }

        private static eVehicleType ParseVehicleType(string i_VehicleType)
        {
            throw new NotImplementedException();
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
