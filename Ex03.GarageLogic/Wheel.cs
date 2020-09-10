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
        public Wheel(float i_MaxAirPressure)
        {
            m_MaxAirPressure = i_MaxAirPressure;
        }

        // Public Methods
        public List<VehicleDataRequest> GetWheelDataRequests()
        {
            List<VehicleDataRequest> requests = new List<VehicleDataRequest>();
            string manufacturerMessage = string.Format("Enter wheel manufacturer name:");
            string maxAirPressureMessage = string.Format("Enter current air pressure (from 0 to {0}):", m_MaxAirPressure);
            requests.Add(new VehicleDataRequest(manufacturerMessage, VehicleDataRequest.eRequestType.String));
            requests.Add(new VehicleDataRequest(maxAirPressureMessage, VehicleDataRequest.eRequestType.NumericRange, 0, m_MaxAirPressure));

            return requests;
        }

        public bool AddAir(float i_AirToAdd)
        {
            bool isSucceed;
            try
            {
                m_CurrentAirPressure += i_AirToAdd;
                isSucceed = true;
            }
            catch
            {
                isSucceed = false;
            }

            return isSucceed;
        }

        public void FillToMaxAir()
        {
            if (m_CurrentAirPressure < m_MaxAirPressure)
            {
                AddAir(m_MaxAirPressure - m_CurrentAirPressure);
            }
        }

        public override string ToString()
        {
            return string.Format(
                "Manufacturer: {0}, Current air pressure: {1}, Maximum air pressure: {2}",
                m_Manufacturer,
                m_CurrentAirPressure,
                m_MaxAirPressure);
        }

        // Properties
        public string Manufacturer
        {
            get
            {
                return m_Manufacturer;
            }

            set
            {
                m_Manufacturer = value;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }

            set
            {
                if(value <= m_MaxAirPressure)
                {
                    m_CurrentAirPressure = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(0, m_MaxAirPressure - m_CurrentAirPressure, value);
                }
            }
        }

        public float MaxAirPressure
        {
            get
            {
                return m_MaxAirPressure;
            }
        }
    }
}
