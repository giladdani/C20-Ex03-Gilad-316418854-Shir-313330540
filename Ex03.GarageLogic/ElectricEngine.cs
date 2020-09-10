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
            try
            {
                CurrentEnergyAmount += i_HoursToCharge;
            }
            catch (ValueOutOfRangeException exception)
            {
                float maxPossibleAddition = exception.MaxValue - CurrentEnergyAmount;
                string batteryOverflowMessage = string.Format(
                    "Cannot fill over {0}, maximum addition is {1}.",
                    exception.MaxValue,
                    maxPossibleAddition);
                throw new Exception(batteryOverflowMessage);
            }
        }

        public override string ToString()
        {
            return string.Format("Battery hours left: {0}, Maximum battery hours: {1}", m_CurrentEnergyAmount, m_MaxEnergyAmount);
        }
    }
}
