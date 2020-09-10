using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Ex03.GarageLogic
{
    public class GasEngine : Engine
    {
        // Private Members
        private const int k_MinFuelTypeValue = 1;
        private const int k_MaxFuelTypeValue = 4;
        private eFuelType m_FuelType;

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
        public static bool IsFuelTypeInRange(int i_FuelType)
        {
            bool isTypeInRange;

            if (i_FuelType > k_MaxFuelTypeValue || i_FuelType < k_MinFuelTypeValue)
            {
                isTypeInRange = false;
            }
            else
            {
                isTypeInRange = true;
            }

            return isTypeInRange;
        }

        public void AddFuel(float i_FuelAmountToAdd, eFuelType i_FuelType)
        {
            if(m_FuelType == i_FuelType)
            {
                try
                {
                    CurrentEnergyAmount += i_FuelAmountToAdd;
                }
                catch(ValueOutOfRangeException exception)
                {
                    float maxPossibleAddition = exception.MaxValue - CurrentEnergyAmount;
                    string fuelOverflowMessage = string.Format(
                        "Cannot fill over {0}, maximum addition is {1}.",
                        exception.MaxValue,
                        maxPossibleAddition);
                    throw new Exception(fuelOverflowMessage);
                }
            }
            else
            {
                throw new ArgumentException("Cannot fill wrong fuel type");
            }
        }

        public override string ToString()
        {
            return string.Format("Current fuel amount: {0} liters, Maximum fuel amount: {1} liters, Fuel type: {2}", m_CurrentEnergyAmount, m_MaxEnergyAmount, m_FuelType);
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
