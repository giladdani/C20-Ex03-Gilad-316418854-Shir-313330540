using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        // Private Members
        private float m_MaxValue;
        private float m_MinValue;

        // Properties
        public float MaxValue
        {
            get => m_MaxValue;
            set => m_MaxValue = value;
        }

        public float MinValue
        {
            get => m_MinValue;
            set => m_MinValue = value;
        }
    }
}
