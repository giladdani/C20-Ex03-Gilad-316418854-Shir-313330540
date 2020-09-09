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
        public static List<VehicleDataRequest> GetWheelDataRequests()
        {
            List<VehicleDataRequest> requests = new List<VehicleDataRequest>();
            string manufacturerMessage = string.Format("enter wheel manufacturer: ");
            string maxAirPressureMessage = string.Format("enter current air pressure (from 0 to {0}): ", 3); // @find solution for this
            requests.Add(new VehicleDataRequest(manufacturerMessage, VehicleDataRequest.eRequestType.String));
            requests.Add(new VehicleDataRequest(maxAirPressureMessage, VehicleDataRequest.eRequestType.NumericRange));

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
                "Wheels: Manufacturer: {0}, Current air pressure: {1}, Maximum air pressure: {2}",
                m_Manufacturer,
                m_CurrentAirPressure,
                m_MaxAirPressure);
        }

        // Properties
        public string Manufacturer
        {
            get => m_Manufacturer;
            set => m_Manufacturer = value;
        }

        public float CurrentAirPressure
        {
            get => m_CurrentAirPressure;
            set
            {
                if(m_CurrentAirPressure + value > m_MaxAirPressure)
                {
                    throw new ValueOutOfRangeException(0, m_MaxAirPressure - m_CurrentAirPressure, value);
                }
            }
        }

        public float MaxAirPressure
        {
            get => m_MaxAirPressure;
        }
    }
}
