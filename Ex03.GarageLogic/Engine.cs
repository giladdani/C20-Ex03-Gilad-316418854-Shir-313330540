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

        // Public Methods
        public override string ToString()
        {
            return string.Format("Engine: Current energy: {0}, Maximum energy: {1}", m_CurrentEnergyAmount, m_MaxEnergyAmount);
        }

        // Properties
        public float CurrentEnergyAmount
        {
            get => m_CurrentEnergyAmount;
            set => m_CurrentEnergyAmount = value;   // @ add validations and exceptions
        }

        public float MaxEnergyAmount
        {
            get => m_MaxEnergyAmount;
            set => m_MaxEnergyAmount = value;   // @ add validations and exceptions
        }
    }
}