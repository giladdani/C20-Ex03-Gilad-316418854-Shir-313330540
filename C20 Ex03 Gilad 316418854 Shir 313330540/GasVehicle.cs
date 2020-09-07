using System;
using System.Collections.Generic;

namespace C20_Ex03_Gilad_316418854_Shir_313330540
{
    public abstract class GasVehicle : Vehicle      // TODO should be abstract? i want to implement methods
    {
        // Private Members
        private eFuelType m_FuelType;
        private float m_CurrentFuel;
        private float m_MaxFuel;

        // Public Methods
        public void AddFuel(float i_FuelAmountToAdd, eFuelType i_FuelTypeToAdd)
        {
            if(i_FuelTypeToAdd == m_FuelType)
            {
                if(m_CurrentFuel + i_FuelAmountToAdd <= m_MaxFuel)
                {
                    m_CurrentFuel += i_FuelAmountToAdd;
                }
            }
        }
    }
}
