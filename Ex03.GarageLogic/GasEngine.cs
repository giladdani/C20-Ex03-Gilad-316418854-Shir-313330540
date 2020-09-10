using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Ex03.GarageLogic
{
    public class GasEngine : Engine
    {
        // Private Members
        private eFuelType m_FuelType;
        private const int k_MinFuelTypeValue = 1;
        private const int k_MaxFuelTypeValue = 4;

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
               CurrentEnergyAmount += i_FuelAmountToAdd;
            }
            else
            {
                throw new ArgumentException("Cannot fill wrong fuel type");
            }
        }

        public static bool IsFuelTypeInRange(int fuelType)
        {
            bool isTypeInRange;

            if (fuelType > k_MaxFuelTypeValue || fuelType < k_MinFuelTypeValue)
            {
                isTypeInRange = false;
            }
            else
            {
                isTypeInRange = true;
            }

            return isTypeInRange;
        }

        public override string ToString()
        {
            return string.Format("{0}, Fuel Type: {1}", base.ToString(), FuelType);
        }

        // Properties
        public eFuelType FuelType
        {
            get
            {
                return m_FuelType;
            }

            set
            {
                if(IsFuelTypeInRange((int)value))
                {
                    m_FuelType = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(k_MinFuelTypeValue, k_MaxFuelTypeValue, (int)value);
                }
            }
        }
    }
}
