using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        // Private Members
        private readonly string r_LicenseNumber;
        private string m_ModelName;
        private List<Wheel> m_Wheels;
        private Engine m_Engine;

        // Constructors
        protected Vehicle(string i_ModelName, string i_LicenseNumber, eWheelsAmount i_NumberOfWheels, string i_WheelManufacturer, float i_MaxWheelsAirPressure, Engine i_Engine)
        {
            m_ModelName = i_ModelName;
            r_LicenseNumber = i_LicenseNumber;
            m_Engine = i_Engine;
            m_Wheels = new List<Wheel>((int)i_NumberOfWheels);
            for (int i = 0; i < (int)i_NumberOfWheels; i++)
            {
                m_Wheels.Add(new Wheel(i_WheelManufacturer, i_MaxWheelsAirPressure));   // @ really need to supply manufacturer?
            }
        }

        // Enums
        public enum eWheelsAmount
        {
            Two = 2,
            Four = 4,
            Sixteen = 16
        }

        // Public Methods
        public void FillAirInVehicleWheels()
        {
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.FillToMaxAir();
            }
        }

        public virtual List<VehicleDataRequest> GetVehicleDataRequests()
        {
            List<VehicleDataRequest> requests = new List<VehicleDataRequest>();
            requests.AddRange(m_Engine.GetEngineDataRequests());
            return requests;
        }

        public virtual void UpdateVehicleData(List<string> i_DataList)
        {

        }

        public override string ToString()
        {
            return string.Format(
                "License number: {0}, Model: {1}, Energy Percentage: {2}%{3}Wheels: {4}{5}Engine: {6}{7}",
                r_LicenseNumber,
                m_ModelName,
                EnergyPercentageLeft,
                Environment.NewLine,
                m_Wheels[0].ToString(),
                Environment.NewLine,
                m_Engine.ToString(),
                Environment.NewLine);
        }

        // Properties
        public string ModelName
        {
            get => m_ModelName;
            set => m_ModelName = value;
        }

        public string LicenseNumber
        {
            get => r_LicenseNumber;
        }

        public float EnergyPercentageLeft
        {
            get => (m_Engine.MaxEnergyAmount / m_Engine.CurrentEnergyAmount);
        }

        public Engine VehicleEngine
        {
            get => m_Engine;
        }
    }
}
