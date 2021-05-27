using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;
namespace B21_Ex03_Shahar_311359566_Nadav_312173776
{
    class UI
    {
        public static void PreformUserAction()
        {
            //Parse user action and call relevant methods
            Console.WriteLine();
            Console.WriteLine("Hi! What Can I Do For You?\n");
            Console.WriteLine("Please Choose: \n1. Admit Vehicle  \n2. Show Current Vehicles   \n3. Change Vehicle Status" +
                "\n4. Fill Air  \n5. Fill Fuel \n6. Charge Vehicle  \n7. Show Vehicle Details  \n8. Exit");

            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    AdmitNewVehicle();
                    break;
                case "2":
                    ShowCurrentVehicles();
                    break;
                case "3":
                    ChangeVehicleStatus();
                    break;
                case "4":
                    FillAir();
                    break;
                case "5":
                    FillFuelVehicle();
                    break;
                case "6":
                    ChargeElectricVehicle();
                    break;
                case "7":
                    ShowVehicleDetails();
                    break;
                case "8":
                    Program.active = false;
                    break;

            }
        }
            //1
        
        private static void AdmitNewVehicle()
        {
            Console.WriteLine("Please Enter License Plate Number");
            string liecensePlate = Console.ReadLine();
            bool exists = GarageLogic.m_Clients.ContainsKey(liecensePlate);
            if (exists)
            {
                GarageLogic.ChangeVehicleStatus(liecensePlate, GarageLogic.eVehicleState.In_Repair);
                Console.WriteLine("Your Vehicle is already in the garage and is in Repair");
            }
            if (!exists)
            {
                Vehicle newVehicle = null;
                while(newVehicle == null)
                {
                    Console.WriteLine("Please Choose Vehicle Type from the following:");
                    foreach (string type in Enum.GetNames(typeof(Factory.eVehicleType)))
                    {
                        Console.WriteLine(type.Replace('_', ' '));
                    }
                    string vehicleType = Console.ReadLine();
                    try
                    {
                        newVehicle = Factory.CreateVehicleFromData(vehicleType, liecensePlate);
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                Dictionary<string, string> questions = newVehicle.GetParams();
                List<string> questionsStrings = new List<string>(questions.Keys);
                int i = 0;
                while (i < questions.Count)
                {
                    try
                    {
                        string question = questionsStrings[i];
                        Console.WriteLine($"Please Enter {question}{questions[question]}");
                        string answer = Console.ReadLine();
                        newVehicle.SetParam(question, answer);
                        i++;
                    }
                    catch(FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch(ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                Console.WriteLine("Please Enter Your Owner Name");
                string ownerName = Console.ReadLine();
                Console.WriteLine("Please Enter Phone Number");
                string phoneNum = Console.ReadLine();
                GarageLogic.AdmitNewVehicle(ownerName, phoneNum, newVehicle);
            }
        }
        
        /*private static void AdmitNewVehicle()
        {
            //Parse vehicle details and send to factory
            Console.WriteLine("Please Choose Vehicle Type:\n");
            //TODO: Loop over vehicle types enum to print types
            Console.WriteLine("1.Fuel Motorcycle \n2.Electric Motorcycle \n3.Fuel Car \n4.Electric Car \n5.Truck:\n");
            string vehicleTypeChoise = Console.ReadLine();
            Factory.eVehicleType vehicleType=Factory.eVehicleType.Fuel_Car;
            switch (vehicleTypeChoise)
            {
                case "1":
                    vehicleType=Factory.eVehicleType.Fuel_Motorcycle;
                    break;
                case "2":
                    vehicleType = Factory.eVehicleType.Electric_Motorcycle; 
                    break;
                case "3":
                    vehicleType = Factory.eVehicleType.Fuel_Car;
                    break;
                case "4":
                    vehicleType = Factory.eVehicleType.Electric_Car;
                    break;
                case "5":
                    vehicleType = Factory.eVehicleType.Truck;
                    break;
            }
            Console.WriteLine("Please Enter License Plate Number");
            string liecensePlate = Console.ReadLine();
            if (GarageLogic.m_Clients.ContainsKey(liecensePlate))
            {
                GarageLogic.ChangeVehicleStatus(liecensePlate, GarageLogic.eVehicleState.In_Repair);
                Console.WriteLine("Your Vehicle is in Repair");
            }
            Vehicle newVehicle = Factory.CreateVehicleFromData(vehicleType);
            newVehicle.LicensePlate = liecensePlate;
            Dictionary<string, string> questions = newVehicle.GetParams();
            List<string> questionsStrings = new List<string>(questions.Keys);

            foreach (string question in questionsStrings)
            {
                Console.WriteLine($"Please Enter {question}");
                string answer = Console.ReadLine();
                questions[question] = answer;
            }

            
            newVehicle.SetParams(questions);
            Console.WriteLine("Please Enter Your Owner Name");
            string ownerName = Console.ReadLine(); 
            Console.WriteLine("Please Enter Phone Number");
            string phoneNum = Console.ReadLine();
            GarageLogic.AdmitNewVehicle(ownerName, phoneNum, newVehicle);
          
       
        }*/

        //2
        private static void ShowCurrentVehicles()
        {
            try
            {
                //TODO add available statuses
                Console.WriteLine($"If you like to Filter by Vehicle State from the following statuses..., Enter State, else Press Enter ");
                foreach (string type in Enum.GetNames(typeof(GarageLogic.eVehicleState)))
                {
                    Console.WriteLine(type);
                }
                Console.WriteLine();
                string filterState = Console.ReadLine();
                List<string> vehicles = GarageLogic.ShowCurrentVehicles(filterState);
                foreach(string liecensePlate in vehicles)
                {
                   Console.WriteLine(liecensePlate);
                }
            }
            catch(FormatException ex)
            {
                Console.WriteLine($"{ex.Message} is an invalid argument For the filter");
                ShowCurrentVehicles();
            }
        }

        //3
        private static void ChangeVehicleStatus()
        {
            try
            {
                Console.WriteLine("Please Enter License Plate Number");
                string licensePlate = Console.ReadLine();
                Console.WriteLine("Please Choose new Vehicle State (Enter number 1-3)");
                Console.WriteLine("1.In Repair \n2.Repaired \n3.Paid For");
                string state = Console.ReadLine();
                GarageLogic.eVehicleState vehicleState = GarageLogic.eVehicleState.In_Repair;
                switch (state)
                {
                    case "1":
                        vehicleState = GarageLogic.eVehicleState.In_Repair;
                        break;
                    case "2":
                        vehicleState = GarageLogic.eVehicleState.Repaired;
                        break;
                    case "3":
                        vehicleState = GarageLogic.eVehicleState.Paid_For;
                        break;
                }
                GarageLogic.ChangeVehicleStatus(licensePlate, vehicleState);
                Console.WriteLine($"The Vehicle's state has been Uptated to {vehicleState}");
            }catch (KeyNotFoundException ex)
            {
                Console.WriteLine($"The Vehicle {ex.Message} Does not Exist");
            }
        }

        //4
        private static void FillAir()
        {
            try
            {
                //Get license plate number and fill amount and send to logic
                Console.WriteLine("Please Enter License Plate Number");
                string licensePlate = Console.ReadLine();
                bool fillSuccess=GarageLogic.FillAir(licensePlate);
                if (fillSuccess)
                {
                    Console.WriteLine("The wheels of the Vehicle were inflated");
                }
                else
                {
                    Console.WriteLine("The wheels of the Vehicle were already full");

                }
            }
            catch (ValueOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine($"The Vehicle {ex.Message} Don't Exsist");
            }
        }

        //5
        private static void FillFuelVehicle()
        {
            // Get license plate number, fuel type and amount and send to logic

            Console.WriteLine("Please Enter License Plate Number");
            string licensePlate = Console.ReadLine();
            Console.WriteLine("Please Enter fuel type");
            string fuelType = Console.ReadLine();
            Console.WriteLine("Please Enter amout to fill");
            string fuelAmount = Console.ReadLine();
            try
            {
                if(GarageLogic.FillFuelVehicle(licensePlate,FuelEngine.ParseFuelTypes(fuelType),float.Parse(fuelAmount)))
                {
                    Console.WriteLine($"The Vehicle was fueled with {fuelAmount} liters");
                }
                else
                {
                    Console.WriteLine("Vehicle's fuel tank was already full");
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine($"The Vehicle {ex.Message} Don't Exsist");
            }
            catch (ValueOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //6
        private static void ChargeElectricVehicle()
        {

            Console.WriteLine("Please Enter License Plate Number");
            string licensePlate = Console.ReadLine();
            Console.WriteLine("Please Enter Minutes to Charge");
            string minutes = Console.ReadLine();
            try
            {
                if (GarageLogic.ChargeElectricVehicle(licensePlate, float.Parse(minutes)))
                {
                    Console.WriteLine($"The Vehicle was Charged with {minutes} minutes of battery charge");
                }
                else
                {
                    Console.WriteLine("Vehicle's battey was already full");
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine($"The Vehicle {ex.Message} Don't Exsist");
            }
            catch (ValueOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        //7
        private static void ShowVehicleDetails()
        {
            try
            {
                Console.WriteLine("Please Enter License Plate Number");
                string lisencePlate = Console.ReadLine();
                Console.WriteLine();
                string details = GarageLogic.ShowVehicleDetails(lisencePlate);

                Console.WriteLine(details);
            }
            catch(KeyNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


    }
 }
