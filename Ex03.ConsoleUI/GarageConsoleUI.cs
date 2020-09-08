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
        private const int k_MinMenuOptionValue = 1;
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
      
            while (!int.TryParse(Console.ReadLine(), out choosenOption) && (choosenOption < k_MinMenuOptionValue || choosenOption > k_MaxMenuOptionValue))
            {
                Console.WriteLine(string.Format("Invalid Choice. Enter a value in range {0} to {1}.", k_MinMenuOptionValue, k_MaxMenuOptionValue));
            }
            runGarageFunction((eMenuOptions)choosenOption);

            /*int choosenOption = int.Parse(Console.ReadLine());
            try
            {
                while (choosenOption < k_MinMenuOptionValue || choosenOption > k_MaxMenuOptionValue)
                {
                    Console.WriteLine(string.Format("Invalid Choice. Enter a value in range {0} to {1}.", k_MinMenuOptionValue, k_MaxMenuOptionValue));
                    choosenOption = int.Parse(Console.ReadLine());
                }

                runGarageFunction((eMenuOptions)choosenOption);
            }
            catch (ValueOutOfRangeException voore)      // @TODO can we combine all of these by catching father class Exception?
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
               
            }
             PrintMenu();*/
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

               /* default:
                    {
                        throw new ArgumentException("Invalid option.");
                    }*/
            }
        }

        private void insertVehicleToGarage()
        {
            string licenseNumber = getLicenseNumberFromUser();// @create this method
            bool isVehicleAlreadyInGarage = m_Garage.GarageVehicles.ContainsKey(licenseNumber);
            if(isVehicleAlreadyInGarage)
            {
                Console.WriteLine("The vehicle is already in the garage.");
                m_Garage.UpdateVehicleStatus(licenseNumber, Garage.eVehicleStatus.InRepair);
            }
            else
            {
                createVehicle(licenseNumber);
            }

            PrintMenu();
        }

        private void createVehicle(string i_LicenseNumber)
        {
            string ownerName, ownerPhoneNumber;
            string vehicleType = getVehicleTypeFromUser();
            getOwnerDetailsFromUser(out ownerName, out ownerPhoneNumber);// @create this method


        }

        private string getVehicleTypeFromUser()
        {
            string chosenType;
            Console.WriteLine("Choose vehicle type by number:");
            StringBuilder stringOfVehicleTypes = new StringBuilder();
            foreach (object vehicleTypeObject in Enum.GetValues(typeof(VehicleGenerator.eVehicleType)))
            {
                stringOfVehicleTypes.Append(string.Format(
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

        private void showLicenseNumbersByFilter()
        {
            Console.WriteLine(string.Format("Filter by vehicle status:{0}1. In Repair{0}Fixed{0}Paid{0}Show All", Environment.NewLine));
            int filterOption = getVehicleStatusFromUser();
            List<string> filteredLicenseNumberList = getLicenseNumberListByStatus(filterOption);
            printLicenseNumbersList(filteredVehiclesList);
        }
    }
}
