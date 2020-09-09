using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class MotorBike : Vehicle
    {
        // Private Members
        private eLicenseType m_LicenseType;
        private int m_EngineCapacity;

        // Enums
        public enum eLicenseType
        {
            A = 1,
            A1 = 2,
            B1 = 3,
            B2 = 4
        }

        // Constructors
        public MotorBike(string i_LicenseNumber, Engine i_Engine) 
            : base(i_LicenseNumber, eWheelsAmount.Two, 28, i_Engine)
        {
        }

        // Public Methods
        public override List<VehicleDataRequest> GetVehicleDataRequests()
        {
            List<VehicleDataRequest> requests = new List<VehicleDataRequest>();
            requests.AddRange(base.GetVehicleDataRequests());
            string[] licenseNames = Enum.GetNames(typeof(eLicenseType));
            string licenseTypeMessage = string.Format("Choose license type:{0}1.{1}{0}2.{2}{0}3.{3}{0}4.{4}{0}", Environment.NewLine, licenseNames[0], licenseNames[1], licenseNames[2], licenseNames[3]);
            string engineCapacityMessage = string.Format("Enter engine capacity: ");
            requests.Add(new VehicleDataRequest(licenseTypeMessage, VehicleDataRequest.eRequestType.Number));
            requests.Add(new VehicleDataRequest(engineCapacityMessage, VehicleDataRequest.eRequestType.Number));

            return requests;
        }

        public override string ToString()
        {
            return string.Format("{0}License Type: {1}, Engine Capacity: {2}{3}",
                base.ToString(), m_LicenseType, m_EngineCapacity, Environment.NewLine);
        }

        // Properties
        public eLicenseType LicenseType
        {
            get => m_LicenseType;
            set => m_LicenseType = value;       // @ Add validations and exceptions
        }

        public int EngineCapacity
        {
            get => m_EngineCapacity;
            set => m_EngineCapacity = value;        // @ Add validations and exceptions
        }


    }
}
