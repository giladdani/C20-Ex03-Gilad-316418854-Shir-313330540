using System;
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
            int choosenOption = int.Parse(Console.ReadLine());
            while (choosenOption < k_MinMenuOptionValue || choosenOption > k_MaxMenuOptionValue)
            {
                Console.WriteLine(string.Format("Invalid Choice. Enter a value in range {0} to {1}.", k_MinMenuOptionValue, k_MaxMenuOptionValue));
                choosenOption = int.Parse(Console.ReadLine());
            }

            try
            {
                runGarageFunction((eMenuOptions)choosenOption);
            }
            catch (ValueOutOfRangeException voore)      // @ can we combine all of these by catching father class Exception?
            {
                Console.WriteLine(voore.Message);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
                        insertVehicleToGarage();
                        break;
                    }

                case eMenuOptions.ShowLicenseNumbersByFilter:
                    {
                        showLicenseNumbersByFilter();
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
            string chosenType;
            Console.WriteLine("Choose vehicle type: ");
            StringBuilder stringOfVehicleTypes = new StringBuilder();
            foreach (object vehicleTypeObject in Enum.GetValues(typeof(VehicleGenerator.eVehicleType)))
            {
                stringOfVehicleTypes.Append(
                    string.Format(
                    "{0}. {1}{2}",
                    (int)vehicleTypeObject,
                    vehicleTypeObject,
                    Environment.NewLine));
            }

            Console.WriteLine(stringOfVehicleTypes);
            chosenType = Console.ReadLine();
            while(!VehicleGenerator.IsVehicleTypeInRange(chosenType))
            {
                Console.WriteLine("Invalid choice. Enter a valid number in range");
                chosenType = Console.ReadLine();
            }

            return chosenType;
        }

        private void getOwnerDetailsFromUser(out string io_OwnerNamem, out string io_OwnerPhoneNumber)
        {
            string ownerName, phoneNumber;
            do
            {
                Console.WriteLine("Enter vehicle owner name: ");
                ownerName = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(ownerName));

            Console.WriteLine("Enter owner phone number: ");
            phoneNumber = Console.ReadLine();
            while(string.IsNullOrEmpty(phoneNumber) || !isStringDigitsOnly(phoneNumber))
            {
                Console.WriteLine("Please enter numbers only: ");
            }

            io_OwnerNamem = ownerName;
            io_OwnerPhoneNumber = phoneNumber;
        }

        private bool isStringDigitsOnly(string i_String)
        {
            bool isDigitsOnly = true;
            for (int i = 0; i < i_String.Length; i++)
            {
                if(!char.IsDigit(i_String[i]))
                {
                    isDigitsOnly = false;
                }
            }

            return isDigitsOnly;
        }

        private void showLicenseNumbersByFilter()
        {
            Console.WriteLine(string.Format("Filter by vehicle status:{0}1. In Repair{0}Fixed{0}Paid{0}Show All", Environment.NewLine));
            int filterOption = getVehicleStatusFromUser();
            List<string> filteredLicenseNumberList = getLicenseNumberListByStatus(filterOption);
            printLicenseNumbersList(filteredVehiclesList);
        }
    }
}
