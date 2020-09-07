using System;
using System.Collections.Generic;

namespace C20_Ex03_Gilad_316418854_Shir_313330540
{
    public abstract class Vehicle
    {
        // Private Members
        protected string m_BrandName;
        protected string m_SerialNumber;
        protected float m_EnergyLeft;
        protected List<Wheel> m_Wheels;

        // Properties      TODO not in abstract class?
        public string BrandName
        {
            get => m_BrandName;
            set => m_BrandName = value;
        }

        public string SerialNumber
        {
            get => m_SerialNumber;
            set => m_SerialNumber = value;
        }

        public float EnergyLeft
        {
            get => m_EnergyLeft;
            set
            {
                if (value >= 0)
                {
                    m_EnergyLeft = value;
                }
                // TODO else- throw Exception?
            }
        }
    }
}
