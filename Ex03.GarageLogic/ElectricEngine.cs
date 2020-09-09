using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        // Constructors
        public ElectricEngine(float i_MaxEnergyAmount) : base(i_MaxEnergyAmount)
        {
        }

        // Public Methods
        public void ChargeBattery(float i_HoursToCharge)
        {
            m_CurrentEnergyAmount += i_HoursToCharge;
        }
    }
}
