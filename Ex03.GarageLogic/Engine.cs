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
        protected Engine(float i_MaxEnergyAmount)
        {
            m_MaxEnergyAmount = i_MaxEnergyAmount;
        }

        // Public Methods
        public override string ToString()
        {
            return string.Format("Engine: Current energy: {0}, Maximum energy: {1}", m_CurrentEnergyAmount, m_MaxEnergyAmount);
        }

        // Properties
        public float CurrentEnergyAmount
        {
            get => m_CurrentEnergyAmount;
            set
            {
                if(m_CurrentEnergyAmount + value > m_MaxEnergyAmount)
                {
                    throw new ValueOutOfRangeException(0, m_MaxEnergyAmount - m_CurrentEnergyAmount, value);
                }
            }
        }

        public float MaxEnergyAmount
        {
            get => m_MaxEnergyAmount;
            set => m_MaxEnergyAmount = value;
        }
    }
}