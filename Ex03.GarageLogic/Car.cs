using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        // Private Members
        private eColor m_Color;
        private eDoorsAmount m_DoorsAmount;

        // Constructors
        public Car(string i_ModelName, string i_LicenseNumber, string i_WheelsManufacturer, Engine i_Engine)
            : base(i_ModelName, i_LicenseNumber, eWheelsAmount.Four, i_WheelsManufacturer, 32, i_Engine)
        {
        }

        // Enums
        public enum eColor
        {
            Gray = 1,
            White = 2,
            Green = 3,
            Red = 4
        }

        public enum eDoorsAmount
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5
        }

        // Public Methods
        public override List<VehicleDataRequest> GetVehicleDataRequests()
        {

        }

        public override string ToString()
        {
            return string.Format("{0}Color: {1}, Number of doors: {2}{3}", 
                base.ToString(), m_Color, m_DoorsAmount,  Environment.NewLine);
        }

        // Properties
        public eColor Color
        {
            get => m_Color;
            set => m_Color = value;     // @ Add validations and exceptions
        }

        public eDoorsAmount DoorsAmount
        {
            get => m_DoorsAmount;
            set => m_DoorsAmount = value;       // @ Add validations and exceptions
        }
    }
}
