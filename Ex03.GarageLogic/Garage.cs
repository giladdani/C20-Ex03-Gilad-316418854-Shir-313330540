using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        // Private Members
        private Dictionary<string, GarageVehicle> m_GarageVehicles;
        private const int k_MinVehicleStatusValue = 1;
        private const int k_MaxVehicleStatusValue = 3;

        // Constructors
        public Garage()
        {
            m_GarageVehicles = new Dictionary<string, GarageVehicle>();
        }

        // Enums
        public enum eVehicleStatus
        {
            InRepair = 1,
            Fixed = 2,
            Paid = 3
        }

        public class GarageVehicle
        {
            private string m_OwnerName;
            private string m_OwnerPhoneNumber;
            private eVehicleStatus m_VehicleStatus;
            private Vehicle m_OwnerVehicle;

            public GarageVehicle(string i_OwnerName, string i_OwnerPhoneNumber, Vehicle i_Vehicle)
            {
                m_OwnerName = i_OwnerName;
                m_OwnerPhoneNumber = i_OwnerPhoneNumber;
                m_VehicleStatus = eVehicleStatus.InRepair;
                m_OwnerVehicle = i_Vehicle;
            }

            public string OwnerName
            {
                get => m_OwnerName;
                set => m_OwnerName = value;
            }

            public string OwnerPhoneNumber
            {
                get => m_OwnerPhoneNumber;
                set => m_OwnerPhoneNumber = value;
            }

            public eVehicleStatus VehicleStatus
            {
                get => m_VehicleStatus;
                set => m_VehicleStatus = value;
            }

            public Vehicle OwnerVehicle
            {
                get => m_OwnerVehicle;
                set => m_OwnerVehicle = value;
            }

            public override string ToString()
            {
                return string.Format(
                "Owner name: {0}, Owner phone number: {1}, Vehicle status: {2}.{3}{4}",
                m_OwnerName,
                m_OwnerPhoneNumber,
                m_VehicleStatus.ToString(),
                Environment.NewLine,
                m_OwnerVehicle.ToString());
            }
        }

        // Public Methods
        public void InsertNewVehicle(string i_OwnerName, string i_OwnerPhoneNumber, Vehicle i_Vehicle)
        {
            GarageVehicle newGarageVehicle = new GarageVehicle(i_OwnerName, i_OwnerPhoneNumber, i_Vehicle);
            m_GarageVehicles.Add(i_Vehicle.LicenseNumber, newGarageVehicle);
        }

        public bool IsVehicleInGarage(string i_LicenseNumber)
        {
            return m_GarageVehicles.ContainsKey(i_LicenseNumber);
        }

        public void UpdateVehicleStatus(string i_LicenseNumber, eVehicleStatus i_NewStatus)
        {
            m_GarageVehicles[i_LicenseNumber].VehicleStatus = i_NewStatus;
        }

        public List<string> GetLicenseNumberListByStatus(int i_StatusFilter)
        {
            List<string> licenseList = new List<string>();
            if(i_StatusFilter == 4)
            {
                foreach (GarageVehicle garageVehicle in m_GarageVehicles.Values)
                {
                    licenseList.Add(garageVehicle.OwnerVehicle.LicenseNumber);
                }
            }
            else
            {
                foreach (GarageVehicle garageVehicle in m_GarageVehicles.Values)
                {
                    if(garageVehicle.VehicleStatus == (eVehicleStatus)i_StatusFilter)
                    {
                        licenseList.Add(garageVehicle.OwnerVehicle.LicenseNumber);
                    }
                }
            }

            return licenseList;
        }

        public void FillMaxAirToVehicleWheels(string i_LicenseNumber)
        {
            m_GarageVehicles[i_LicenseNumber].OwnerVehicle.FillAirInVehicleWheels();
        }

        public void FillGasVehicleFuel(string i_LicenseNumber, int i_FuelType, float i_FuelAmount)
        {
            Vehicle vehicle = m_GarageVehicles[i_LicenseNumber].OwnerVehicle;
            if(vehicle.VehicleEngine is GasEngine engine)
            {
                engine.AddFuel(i_FuelAmount, (GasEngine.eFuelType)i_FuelType);
            }
        }

        public void ChargeElectricVehicleBattery(string i_LicenseNumber, float i_HoursToCharge)
        {
            ElectricEngine engine = m_GarageVehicles[i_LicenseNumber].OwnerVehicle.VehicleEngine as ElectricEngine;
            engine.ChargeBattery(i_HoursToCharge);
        }

        // Properties
        public Dictionary<string, GarageVehicle> GarageVehicles
        {
            get => m_GarageVehicles;
            set => m_GarageVehicles = value;
        }

        public int MinVehicleStatusValue
        {
            get => k_MinVehicleStatusValue;
        }

        public int MaxVehicleStatusValue
        {
            get => k_MaxVehicleStatusValue;
        }
    }
}
