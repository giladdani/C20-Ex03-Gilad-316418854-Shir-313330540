using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        // Private Members
        private bool m_IsHazardous;
        private float m_CargoSize;

        // Constructors
        public Truck(string i_ModelName, string i_LicenseNumber, string i_WheelsManufacturer, Engine i_Engine)
            : base(i_ModelName, i_LicenseNumber, eWheelsAmount.Sixteen, i_WheelsManufacturer, 30, i_Engine)
        {
        }

        // Properties
        public bool IsHazardous
        {
            get => m_IsHazardous;
            set => m_IsHazardous = value;   // @ Add validations and exceptions
        }

        public float CargoSize
        {
            get => m_CargoSize;
            set => m_CargoSize = value;     // @ Add validations and exceptions
        }
    }
}
