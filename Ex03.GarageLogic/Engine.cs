using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        // Private Members
        protected float m_CurrentEnergyAmount;
        protected float m_MaxEnergyAmount;

        // Constructors
        public Engine(float i_MaxEnergyAmount)
        {
            m_MaxEnergyAmount = i_MaxEnergyAmount;
        }
    }
}
