using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        // Private Members
        private string m_Manufacturer;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;

        // Constructor
        public Wheel(string i_Manufacturer, float i_MaxAirPressure)
        {
            m_Manufacturer = i_Manufacturer;
            m_MaxAirPressure = i_MaxAirPressure;
        }

        // Public Methods
        public void AddAir(float i_AirToAdd)
        {
            if(i_AirToAdd < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(i_AirToAdd));      // @ exception like this?
            }

            else if(m_CurrentAirPressure + i_AirToAdd <= m_MaxAirPressure)
            {
                m_CurrentAirPressure += i_AirToAdd;
            }
        }
    }
}
