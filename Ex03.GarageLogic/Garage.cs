using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        // Private Members
        private Dictionary<string, GarageVehicle> m_GarageVehicles;
        private int m_MinVehicleStatusValue;
        private int m_MaxVehicleStatusValue;

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
@"Owner name: {0}, Phone Number: {1}, Vehicle status: {2}.
Vehicle information: {3}{4}",
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
            m_GarageVehicles[i_LicenseNumber].Status = i_NewStatus;
        }

        public List<string> GetLicenseNumberListByStatus(int i_StatusFilter)
        {
            List<string> licenseList = new List<string>();
            if(i_StatusFilter == 0)
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
                    if(garageVehicle.Status == (eVehicleStatus)i_StatusFilter)
                    {
                        licenseList.Add(garageVehicle.OwnerVehicle.LicenseNumber);
                    }
                }
            }

            return licenseList;
        }

        // Properties
        public Dictionary<string, GarageVehicle> GarageVehicles
        {
            get => m_GarageVehicles;
            set => m_GarageVehicles = value;
        }

        public int MinVehicleStatusValue
        {
            get => m_MinVehicleStatusValue;
            set => m_MinVehicleStatusValue = value;
        }

        public int MaxVehicleStatusValue
        {
            get => m_MaxVehicleStatusValue;
            set => m_MaxVehicleStatusValue = value;
        }
    }
}
