using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public static class VehicleGenerator
    {
        // Private Members
        private const int k_MinVehicleTypeValue = 1;
        private const int k_MaxVehicleTypeValue = 5;

        // Enums
        public enum eVehicleType
        {
            GasMotorBike = 1,
            ElectricMotorBike = 2,
            ElectricCar = 3,
            GasCar = 4,
            Truck = 5
        }

        // Public Methods
        public static bool IsVehicleTypeInRange(string i_NumberInRange)
        {
            bool isTypeInRange;
            int typeAsNumber = int.Parse(i_NumberInRange);

            if (typeAsNumber > k_MaxVehicleTypeValue || typeAsNumber < k_MinVehicleTypeValue)
            {
                isTypeInRange = false;
            }
            else
            {
                isTypeInRange = true;
            }

            return isTypeInRange;
        }

        public static Vehicle CreateVehicle(string i_LicenseNumber, string i_VehicleType)
        {
            Vehicle createdVehicle;
            int converterVehicleType = int.Parse(i_VehicleType);
            eVehicleType vehicleType = (eVehicleType)converterVehicleType;

            switch (vehicleType)
            {
                case eVehicleType.ElectricMotorBike:
                    {
                        createdVehicle = createElectricMotorBike(i_LicenseNumber);
                        break;
                    }

                case eVehicleType.GasMotorBike:
                    {
                        createdVehicle = createGasMotorBike(i_LicenseNumber);
                        break;
                    }

                case eVehicleType.ElectricCar:
                    {
                        createdVehicle = createElectricCar(i_LicenseNumber);
                        break;
                    }

                case eVehicleType.GasCar:
                    {
                        createdVehicle = createGasCar(i_LicenseNumber);
                        break;
                    }

                case eVehicleType.Truck:
                    {
                        createdVehicle = createTruck(i_LicenseNumber);
                        break;
                    }

                default:
                    {
                        throw new ArgumentException();
                    }
            }

            return createdVehicle;
        }

        // Private Methods
        private static Car createGasCar(string i_LicenseNumber)
        {
            return new Car(i_LicenseNumber, new GasEngine(GasEngine.eFuelType.Octan96, 50));
        }

        private static Car createElectricCar(string i_LicenseNumber)
        {
            return new Car(i_LicenseNumber, new ElectricEngine(4.8f));
        }

        private static MotorBike createGasMotorBike(string i_LicenseNumber)
        {
            return new MotorBike(i_LicenseNumber, new GasEngine(GasEngine.eFuelType.Octan95, 5.5f));
        }

        private static MotorBike createElectricMotorBike(string i_LicenseNumber)
        {
            return new MotorBike(i_LicenseNumber, new ElectricEngine(1.6f));
        }

        private static Truck createTruck(string i_LicenseNumber)
        {
            return new Truck(i_LicenseNumber, new GasEngine(GasEngine.eFuelType.Soler, 105));
        }
    }
}