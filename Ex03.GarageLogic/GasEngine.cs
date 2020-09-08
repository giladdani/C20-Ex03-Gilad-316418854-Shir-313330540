using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class GasEngine : Engine
    {
        // Private Members
        private eFuelType m_FuelType;
        private const int k_MinMenuOptionValue = 1; // @ use ValueOutOfRangeException?
        private const int k_MaxMenuOptionValue = 8;
        // Constructors
        public GasEngine(eFuelType i_FuelType, float i_MaxEnergyAmount) : base(i_MaxEnergyAmount)
        {
            m_FuelType = i_FuelType;
        }

        // Enums
        public enum eFuelType
        {
            Octan95 = 1,
            Octan96 = 2,
            Octan98 = 3,
            Soler = 4
        }

        // Public Methods
        public void AddFuel(float i_FuelAmountToAdd, eFuelType i_FuelType)
        {
            if(m_FuelType == i_FuelType)
            {
                if(m_CurrentEnergyAmount + i_FuelAmountToAdd <= m_MaxEnergyAmount)
                {
                    m_CurrentEnergyAmount += i_FuelAmountToAdd;
                }
                else
                {
                    // @ Throw exception
                }
            }
            else
            {
                // @ Throw exception
            }
        }

        public override string ToString()
        {
            return string.Format("{0}, Fuel Type: {1}", base.ToString(), FuelType);
        }

        // Properties
        public eFuelType FuelType
        {
            get => m_FuelType;
            set => m_FuelType = value;  // @ Add validations and exceptions
        }

        public static bool IsFuelTypeInRange(int fuelType)
        {
            bool isTypeInRange;
            if (fuelType >= m_FuelType. || typeAsNumber < k_MinVehicleTypeValue)
            {
                isTypeInRange = false;
            }
            else
            {
                isTypeInRange = true;
            }
            return isTypeInRange;

        }
       
    }
}
