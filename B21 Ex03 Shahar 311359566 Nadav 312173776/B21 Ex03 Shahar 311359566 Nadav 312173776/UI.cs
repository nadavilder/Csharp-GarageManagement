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
            Console.WriteLine("Hi! What Can I Do For You?\n");
            Console.WriteLine("Please Choose: \n1. Admit Vehicle  \n2.Show Current Vehicles   \n3. Change Vehicle Status" +
                "\n4.Fill Air  \n5.Fill Fuel \n6.Charge Vehicle  \n7.Show Vehicle Details");

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

            }
        }
            //1
            private static void AdmitNewVehicle()
        {
            //Parse vehicle details and send to factory
            Console.WriteLine("Please Enter Basic Vehicle Type\n");
            string vehicleTypeString = Console.ReadLine();
            Console.WriteLine("Please Enter License Plate Number");
            string liecensePlate = Console.ReadLine();
            if (GarageLogic.m_Clients.ContainsKey(liecensePlate))
            {
                GarageLogic.ChangeVehicleStatus(liecensePlate, "In Repair");
                Console.WriteLine("Your Vehicle is in Repair");
            }
            Vehicle newVehicle = Factory.CreateVehicleFromData(vehicleTypeString);
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
            //While in main?
            PreformUserAction();
        }

        //2
        private static void ShowCurrentVehicles()
        {
            try
            {
                //TODO add available statuses
                Console.WriteLine($"If you like to Filter by Vehicle State from the following statuses..., Enter State, else Press Enter ");
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
                string lisencePlate=Console.ReadLine();
                Console.WriteLine("Please Enter new Vehicle State");
                string state = Console.ReadLine();
                GarageLogic.ChangeVehicleStatus(lisencePlate, state);
                Console.WriteLine($"The Vehicle's state has been Uptated to {state}");
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
                string lisencePlate = Console.ReadLine();
                bool fillSuccess=GarageLogic.FillAir(lisencePlate);
                if (fillSuccess)
                {
                    Console.WriteLine("The wheels of the Vehicle were inflated");
                }
                else
                {
                    Console.WriteLine("The wheels of the Vehicle were already full");

                }
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

            try
            {
                Console.WriteLine("Please Enter License Plate Number");
                string lisencePlate = Console.ReadLine();
                Console.WriteLine("Please Enter fuel type");
                string fuelType = Console.ReadLine();
                Console.WriteLine("Please Enter amout to fill");
                string fuelAmount = Console.ReadLine();
                bool fillSuccess = GarageLogic.FillFuelVehicle(lisencePlate,FuelEngine.ParseFuelTypes(fuelType),float.Parse(fuelAmount));
                if (!fillSuccess)
                {
                    Console.WriteLine("This Vehicle Don't Exsist");
                }
                else
                {
                    Console.WriteLine($"The wheels of the Vehicle were inflated");
                }
            }catch (ArgumentException ex)
            {
                //Print for incorrect Fuel type
            }catch (KeyNotFoundException ex)
            {
                //Print for non existent License plate
            }/*catch (ValueOutOfRangeException ex)
            {
                //Print for too much fuel
            }*/
        }

        //6
        private static void ChargeElectricVehicle()
        {

            Console.WriteLine("Please Enter License Plate Number");
            string lisencePlate = Console.ReadLine();
            Console.WriteLine("Please Enter Minutes to Charge");
            string minutes = Console.ReadLine();
            bool chargeSuccess = GarageLogic.ChargeElectricVehicle(lisencePlate, float.Parse(minutes));
            if (!chargeSuccess)
            {
                Console.WriteLine("This Vehicle Don't Exsist");
            }
            else
            {
                Console.WriteLine($"The wheels of the Vehicle were inflated");
            }
        }

        //7
        private static void ShowVehicleDetails()
        {
            Console.WriteLine("Please Enter License Plate Number");
            string lisencePlate = Console.ReadLine();
            string details = GarageLogic.ShowVehicleDetails(lisencePlate);
            if (details!= null)
            {
                Console.WriteLine(details);
            }
            else
            {
                Console.WriteLine("This Vehicle Don't Exsist");
            }
        }

        //TODO: FILL
        private enum eUserAction
        {

        }
     }
 }
