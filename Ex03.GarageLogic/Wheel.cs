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
            if(m_CurrentAirPressure + i_AirToAdd <= m_MaxAirPressure)
            {
                m_CurrentAirPressure += i_AirToAdd;
            }
            else 
            {
                throw new ArgumentOutOfRangeException(nameof(i_AirToAdd));      // @ exception like this?
            }
        }

        public override string ToString()
        {
            return string.Format(
                "Wheels: Manufacturer: {0}, Current air pressure: {1}, Maximum air pressure: {2}",
                m_Manufacturer,
                m_CurrentAirPressure,
                m_MaxAirPressure);
        }

        public void FillToMaxAir()
        {
            if (m_CurrentAirPressure < m_MaxAirPressure)
            {
                AddAir(m_MaxAirPressure - m_CurrentAirPressure);
            }
        }
    }
}
