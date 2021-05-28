using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;
namespace B21_Ex03_Shahar_311359566_Nadav_312173776
{
    class UI
    {
        public static bool PreformUserAction()
        {
            Console.WriteLine();
            Console.WriteLine("Hi! What Can I Do For You?\n");
            Console.WriteLine("Please Choose: \n1. Admit Vehicle  \n2. Show Current Vehicles   \n3. Change Vehicle Status" +
                "\n4. Fill Air  \n5. Fill Fuel \n6. Charge Vehicle  \n7. Show Vehicle Details  \n8. Exit");
            bool continueProgram = true;
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    admitNewVehicle();
                    break;
                case "2":
                    showCurrentVehicles();
                    break;
                case "3":
                    changeVehicleStatus();
                    break;
                case "4":
                    fillAir();
                    break;
                case "5":
                    fillFuelVehicle();
                    break;
                case "6":
                    chargeElectricVehicle();
                    break;
                case "7":
                    showVehicleDetails();
                    break;
                case "8":
                    continueProgram = false;
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
            return continueProgram;
        }
        
        
        //1
        private static void admitNewVehicle()
        {
            string liecensePlate = null;
            bool validLicensePlate = false;
            while (!validLicensePlate)
            {
                Console.WriteLine("Please Enter License Plate Number of length 8");
                liecensePlate = Console.ReadLine();
                if (validateNumber(liecensePlate, 8))
                {
                    validLicensePlate = true;
                }
                else
                {
                    Console.WriteLine("Invalid license plate number");
                }
            }
            bool exists = GarageLogic.CheckVehicleExists(liecensePlate);
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
                string phoneNum = null;
                bool validPhone = false;
                while (!validPhone)
                {
                    Console.WriteLine("Please Enter Phone Number of length 10");
                    phoneNum = Console.ReadLine();
                    if (validateNumber(phoneNum, 10))
                    {
                        validPhone = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid phone number");
                    }
                }
                GarageLogic.AdmitNewVehicle(ownerName, phoneNum, newVehicle);
            }
        }
        


        //2
        private static void showCurrentVehicles()
        {
            try
            {
                Console.WriteLine($"If you like to Filter by Vehicle State from the following statuses..., Enter State, else Press Enter ");
                foreach (string type in Enum.GetNames(typeof(GarageLogic.eVehicleState)))
                {
                    Console.WriteLine(type.Replace('_', ' '));
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
                showCurrentVehicles();
            }
        }

        //3
        private static void changeVehicleStatus()
        {
            try
            {
                Console.WriteLine("Please Enter License Plate Number");
                string licensePlate = Console.ReadLine();
                bool valid = false;
                GarageLogic.eVehicleState vehicleState= GarageLogic.eVehicleState.In_Repair;

                while (!valid)
                {
                    Console.WriteLine("Please Choose new Vehicle State (Enter number 1-3)");
                    Console.WriteLine("1.In Repair \n2.Repaired \n3.Paid For");
                    string state = Console.ReadLine();
                    switch (state)
                    {
                        case "1":
                            vehicleState = GarageLogic.eVehicleState.In_Repair;
                            valid = true;
                            break;
                        case "2":
                            vehicleState = GarageLogic.eVehicleState.Repaired;
                            valid = true;
                            break;
                        case "3":
                            vehicleState = GarageLogic.eVehicleState.Paid_For;
                            valid = true;
                            break;
                        default:
                            Console.WriteLine("invalid input");
                            break;
                    }
                }
                GarageLogic.ChangeVehicleStatus(licensePlate, vehicleState);
                Console.WriteLine($"The Vehicle's state has been Uptated to {vehicleState}");
            }catch (KeyNotFoundException ex)
            {
                Console.WriteLine($"The Vehicle {ex.Message} Does not Exist");
            }
        }

        //4
        private static void fillAir()
        {
            try
            {
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
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //5
        private static void fillFuelVehicle()
        {

            Console.WriteLine("Please Enter License Plate Number");
            string licensePlate = Console.ReadLine();
            Console.WriteLine("Please Enter fuel type from the following:");
            foreach (string type in Enum.GetNames(typeof(FuelEngine.eFuelTypes)))
            {
                Console.WriteLine(type);
            }
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
        private static void chargeElectricVehicle()
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
        private static void showVehicleDetails()
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

        private static bool validateNumber(string i_Number, int i_RequiredLength)
        {
            bool validNumber = true;
            if(i_Number.Length != i_RequiredLength)
            {
                validNumber = false;
            }
            foreach(char digit in i_Number)
            {
                if (!char.IsDigit(digit))
                {
                    validNumber = false;
                }
            }
            return validNumber;
        }


    }
 }
