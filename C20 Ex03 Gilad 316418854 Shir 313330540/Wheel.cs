using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace C20_Ex03_Gilad_316418854_Shir_313330540
{
    public class Wheel      // TODO should be struct?
    {
        // Private Members
        private string m_Manufacturer;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;

        // Public Methods
        public void AddAir(float i_AirAmount)
        {
            if(m_CurrentAirPressure + i_AirAmount <= m_MaxAirPressure)
            {
                m_CurrentAirPressure += i_AirAmount;
            }
            // TODO else- what to do? return false?
        }

        // Properties
        public string Manufacturer
        {
            get => m_Manufacturer;
            set => m_Manufacturer = value;
        }

        public float MaxAirPressure
        {
            get => m_MaxAirPressure;
            set => m_MaxAirPressure = value;
        }

        public float CurrentAirPressure
        {
            get => m_CurrentAirPressure;
            set => m_CurrentAirPressure = value;
        }
    }
}
