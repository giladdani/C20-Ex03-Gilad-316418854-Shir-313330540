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
        public List<VehicleDataRequest> GetEngineDataRequests()
        {
            List<VehicleDataRequest> requests = new List<VehicleDataRequest>();
            string currentEnergyMessage = string.Format("Enter current engine energy (from 0 to {0}): ", m_MaxEnergyAmount);
            requests.Add(new VehicleDataRequest(currentEnergyMessage, VehicleDataRequest.eRequestType.NumericRange, 0, m_MaxEnergyAmount));

            return requests;
        }

        public override string ToString()
        {
            return string.Format("Current energy: {0}, Maximum energy: {1}", m_CurrentEnergyAmount, m_MaxEnergyAmount);
        }

        // Properties
        public float CurrentEnergyAmount
        {
            get
            {
                return m_CurrentEnergyAmount;
            }

            set
            {
                if(value <= m_MaxEnergyAmount)
                {
                    m_CurrentEnergyAmount = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(0, m_MaxEnergyAmount, value);
                }

            }
        }

        public float MaxEnergyAmount
        {
            get
            {
                return m_MaxEnergyAmount;
            }

            set
            {
                m_MaxEnergyAmount = value;       // @ validations and exception?
            }
        }
    }
}