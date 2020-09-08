using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        // Private Members
        Dictionary<string, GarageVehicle> m_GarageVehicles;

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
                get => OwnerPhoneNumber;
                set => OwnerPhoneNumber = value;
            }

            public eVehicleStatus Status
            {
                get => Status;
                set => Status = value;
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

        // Properties
        public Dictionary<string, GarageVehicle> GarageVehicles
        {
            get => m_GarageVehicles;
            set => m_GarageVehicles = value;
        }
    }
}
