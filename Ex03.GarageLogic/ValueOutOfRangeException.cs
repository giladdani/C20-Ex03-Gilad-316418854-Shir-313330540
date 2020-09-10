using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        // Private Members
        private const string k_Message = "{0} was invalid. Values allowed are in the range {1} - {2}";
        private float m_MinValue;
        private float m_MaxValue;
        
        // Constructors
        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue, float i_InvalidValue) 
            : base(string.Format(k_Message, i_InvalidValue, i_MinValue, i_MaxValue))
        {
            m_MinValue = i_MinValue;
            m_MaxValue = i_MaxValue;
        }

        // Properties
        public float MinValue
        {
            get
            {
                return m_MinValue;
            }

            set
            {
                m_MinValue = value;
            }
        }

        public float MaxValue
        {
            get
            {
                return m_MaxValue;
            }

            set
            {
                m_MaxValue = value;
            }
        }
    }
}
