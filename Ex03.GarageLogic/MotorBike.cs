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

        // Constuctors
        public MotorBike(string i_ModelName, string i_LicenseNumber, string i_WheelsManufacturer, Engine i_Engine) 
            : base(i_ModelName, i_LicenseNumber, eWheelsAmount.Two, i_WheelsManufacturer, 28, i_Engine)
        {
        }

        // Public Methods
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
