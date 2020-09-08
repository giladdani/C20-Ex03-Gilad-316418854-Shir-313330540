﻿using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageConsoleUI
    {
        // Private Members
        private Garage m_Garage;
        private const int k_MinMenuOptionValue = 1; // @ use ValueOutOfRangeException?
        private const int k_MaxMenuOptionValue = 8;

        // Public Methods
        public void Start()
        {
            m_Garage = new Garage();
            Console.WriteLine("Welcome to Garages R Us!");
            PrintMenu();
        }

        // Enums
        public enum eMenuOptions
        {
            InsertVehicleToGarage = 1,
            ShowLicenseNumbersByFilter = 2,
            ChangeVehicleStatus = 3,
            FillMaxAirToVehicleWheels = 4,
            FillGasVehicleFuel = 5,
            ChargeElectricVehicleBattery = 6,
            ShowAllVehicleDetails = 7,
            ExitProgram = 8
        }

        // Public Methods
        public void PrintMenu()
        {
            Console.WriteLine(string.Format(
@"
1. Insert a new vehicle to the garage 
2. Show all vehicle license numbers
3. Change status of vehicle
4. Fill air pressure of vehicle wheel
5. Fill fuel of gas vehicle
6. Charge battery of electric vehicle
7. Show Full details of a vehicle
8. Exit garage"));

            chooseOptionFromMenu();
        }

        // Private Methods
        private void chooseOptionFromMenu()
        {
            try
            {
                int chosenOption = int.Parse(Console.ReadLine());
                while (chosenOption < k_MinMenuOptionValue || chosenOption > k_MaxMenuOptionValue)
                {
                    Console.WriteLine(string.Format("Invalid Choice. Enter a value in range {0} to {1}.", k_MinMenuOptionValue, k_MaxMenuOptionValue));
                    chosenOption = int.Parse(Console.ReadLine());
                }

                runGarageFunction((eMenuOptions)chosenOption);
            }
            catch (ValueOutOfRangeException valueOutOfRangeException)
            {
                Console.WriteLine(valueOutOfRangeException.Message);
            }
            catch (ArgumentException argumentException)
            {
                Console.WriteLine(argumentException.Message);
            }
            catch (FormatException formatException)
            {
                Console.WriteLine(formatException.Message);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                PrintMenu();
            }
        }

        private void runGarageFunction(eMenuOptions i_ChosenOption)
        {
            switch(i_ChosenOption)
            {
                case eMenuOptions.InsertVehicleToGarage:
                    {
                        insertVehicleToGarage(); // @ need to finish function
                        break;
                    }

                case eMenuOptions.ShowLicenseNumbersByFilter:
                    {
                        showLicenseNumbersByFilter(); // @ need to finish function
                        break;
                    }

                case eMenuOptions.ChangeVehicleStatus:
                    {
                        changeVehicleStatus();
                        break;
                    }

                case eMenuOptions.FillMaxAirToVehicleWheels:
                    {
                        fillMaxAirToVehicleWheels();
                        break;
                    }

                case eMenuOptions.FillGasVehicleFuel:
                    {
                        fillGasVehicleFuel();
                        break;
                    }

                case eMenuOptions.ChargeElectricVehicleBattery:
                    {
                        chargeElectricVehicleBattery();
                        break;
                    }

                case eMenuOptions.ShowAllVehicleDetails:
                    {
                        showAllVehicleDetails();
                        break;
                    }

                case eMenuOptions.ExitProgram:
                    {
                        Console.WriteLine("Goodbye!");
                        Environment.Exit(-1);
                        break;
                    }

                default:
                    {
                        throw new ArgumentException("Invalid option.");
                    }
            }
        }

        private void insertVehicleToGarage()
        {
            string licenseNumber = getLicenseNumberFromUser();
            bool isVehicleAlreadyInGarage = m_Garage.GarageVehicles.ContainsKey(licenseNumber);
            if(isVehicleAlreadyInGarage)
            {
                Console.WriteLine("The vehicle is already in the garage. It's status was changed to 'In Repair'");
                m_Garage.UpdateVehicleStatus(licenseNumber, Garage.eVehicleStatus.InRepair);
            }
            else
            {
                createVehicle(licenseNumber);
            }

            PrintMenu();
        }

        private string getLicenseNumberFromUser()
        {
            Console.WriteLine("Enter License number: ");
            string licenseNumber = Console.ReadLine();
            while(!isStringDigitsOnly(licenseNumber))
            {
                Console.WriteLine("License number must be digits only, enter license number: ");
                licenseNumber = Console.ReadLine();
            }

            return licenseNumber;
        }

        private void createVehicle(string i_LicenseNumber)
        {
            string vehicleType = getVehicleTypeFromUser();
            getOwnerDetailsFromUser(out string ownerName, out string ownerPhoneNumber);
            Vehicle newVehicle = VehicleGenerator.CreateVehicle(i_LicenseNumber, vehicleType);

        }

        private string getVehicleTypeFromUser()
        {
            Console.WriteLine("Choose vehicle type: ");
            StringBuilder vehicleTypesString = new StringBuilder();
            foreach (object vehicleTypeObject in Enum.GetValues(typeof(VehicleGenerator.eVehicleType)))
            {
                vehicleTypesString.Append(
                    string.Format(
                    "{0}. {1}{2}",
                    (int)vehicleTypeObject,
                    vehicleTypeObject,
                    Environment.NewLine));
            }

            Console.WriteLine(vehicleTypesString);
            string chosenType = Console.ReadLine();
            while(!VehicleGenerator.IsVehicleTypeInRange(chosenType))
            {
                Console.WriteLine("Invalid choice. Enter a valid number in range");
                chosenType = Console.ReadLine();
            }

            return chosenType;
        }

        private void getOwnerDetailsFromUser(out string io_OwnerName, out string io_OwnerPhoneNumber)
        {
            string ownerName;
            do
            {
                Console.WriteLine("Enter vehicle owner name: ");
                ownerName = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(ownerName));

            Console.WriteLine("Enter owner phone number: ");
            string phoneNumber = Console.ReadLine();
            while(string.IsNullOrEmpty(phoneNumber) || !isStringDigitsOnly(phoneNumber))
            {
                Console.WriteLine("Please enter numbers only: ");
            }

            io_OwnerName = ownerName;
            io_OwnerPhoneNumber = phoneNumber;
        }

        private bool isStringDigitsOnly(string i_String)
        {
            bool isDigitsOnly = true;
            foreach(char character in i_String)
            {
                if(!char.IsDigit(character))
                {
                    isDigitsOnly = false;
                }
            }

            return isDigitsOnly;
        }

        private void showLicenseNumbersByFilter()
        {
            int chosenFilter;
            Console.WriteLine(string.Format("Filter by vehicle status:{0}1. In Repair{0}2. Fixed{0}3. Paid{0}4. Show All", Environment.NewLine));
            string userInput = Console.ReadLine();
            while (!int.TryParse(userInput, out chosenFilter) && (chosenFilter > m_Garage.MaxVehicleStatusValue + 1 || chosenFilter < m_Garage.MinVehicleStatusValue))
            {
                Console.WriteLine("Invalid choice. Enter a valid number in range {0} to {1}", m_Garage.MinVehicleStatusValue, m_Garage.MaxVehicleStatusValue + 1);
                userInput = Console.ReadLine();
            }

            List<string> filteredLicenseNumberList = m_Garage.GetLicenseNumberListByStatus(chosenFilter);
            if(filteredLicenseNumberList.Count > 0)
            {
                StringBuilder licensesString = new StringBuilder();
                for (int i = 0; i < filteredLicenseNumberList.Count; i++)
                {
                    licensesString.Append(filteredLicenseNumberList[i]);
                    string commaOrDot = i == filteredLicenseNumberList.Count - 1 ? ". " : ", ";
                    licensesString.Append(commaOrDot);
                }
            }
            else
            {
                Console.WriteLine("No licenses were found.");
            }
        }

        private int getVehicleStatusFromUser()
        {
            int chosenStatus;
            Console.WriteLine("Choose vehicle status:");
            StringBuilder vehicleStatusString = new StringBuilder();
            foreach (object vehicleStatusObject in Enum.GetValues(typeof(Garage.eVehicleStatus)))
            {
                vehicleStatusString.Append(
                    string.Format(
                    "{0}. {1}{2}",
                    (int)vehicleStatusObject,
                    vehicleStatusObject,
                    Environment.NewLine));
            }

            Console.WriteLine(vehicleStatusString);
            string userInput = Console.ReadLine();
            while (!int.TryParse(userInput, out chosenStatus) && (chosenStatus > m_Garage.MaxVehicleStatusValue || chosenStatus < m_Garage.MinVehicleStatusValue))
            {
                Console.WriteLine("Invalid choice. Enter a valid number in range");
                userInput = Console.ReadLine();
            }

            return chosenStatus;
        }
    }
}
