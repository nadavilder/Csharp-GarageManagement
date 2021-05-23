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
            Console.WriteLine("choose");
            string option = Console.ReadLine();
            switch (option){
                case "1":
                    AdmitNewVehicle();
                    break;
                case "2":
                    ShowCurrentVehicles();
                    break;
            }
        }

        //1
        private static void AdmitNewVehicle()
        {
            //Parse vehicle details and send to factory
            Console.WriteLine("Please enter basic vehicle Type");
            string vehicleTypeString = Console.ReadLine();

            //Check if license plate exists
            //if not create new vehicle
            Vehicle newVehicle = Factory.CreateVehicleFromData(vehicleTypeString);
            Dictionary<string, string> questions = newVehicle.GetParams();
            List<string> questionsStrings = new List<string>( questions.Keys);
            foreach(string question in questionsStrings)
            {
                Console.WriteLine($"Please Enter {question}");
                string answer = Console.ReadLine();
                questions[question] = answer;
            }

            newVehicle.SetParams(questions);
            //Ask qeustions based on the vehicle


            
            //GarageLogic.AdmitNewVehicle(vehicleTypeString, basicVehicleDetailsString, wheelDetailsString, engineDetailsString, additionalDetailsString);

        }

        //2
        private static void ShowCurrentVehicles()
        {
            //print from list of all vehicles
        }

        //3
        private static void ChangeVehicleStatus()
        {
            //Get license plate number and new status and change it
        }

        //4
        private static void FillAir()
        {
            //Get license plate number and fill amount and send to logic
        }

        //5
        private static void FillFuelVehicle()
        {
            // Get license plate number, fuel type and amount and send to logic
        }

        //6
        private static void ChargeElectricVehicle()
        {
            // Get license plate number, fuel type and amount and send to logic
        }

        //7
        private static void ShowVehicleDetails()
        {
            //Get license plate and print all details
        }

        //TODO: FILL
        private enum eUserAction
        {

        }
    }
}
