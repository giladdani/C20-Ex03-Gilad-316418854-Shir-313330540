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
        protected Vehicle(string i_LicenseNumber, eWheelsAmount i_NumberOfWheels, float i_WheelMaxAirPressure, Engine i_Engine)
        {
            r_LicenseNumber = i_LicenseNumber;
            m_Engine = i_Engine;
            m_Wheels = new List<Wheel>((int)i_NumberOfWheels);
            for (int i = 0; i < (int)i_NumberOfWheels; i++)
            {
                m_Wheels.Add(new Wheel(i_WheelMaxAirPressure));
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
            string modelNameMessage = string.Format("enter vehicle model: ");
            requests.Add(new VehicleDataRequest(modelNameMessage, VehicleDataRequest.eRequestType.String));
            requests.AddRange(m_Engine.GetEngineDataRequests());
            requests.AddRange(Wheel.GetWheelDataRequests());

            return requests;
        }

        public virtual void UpdateVehicleData(List<string> i_DataList)
        {
            float currentEnergyAmount, currentAirPressure;
            m_ModelName = i_DataList[0];
            if(!float.TryParse(i_DataList[1], out currentEnergyAmount))
            {
                currentEnergyAmount = (float)int.Parse(i_DataList[1]);
            }

            m_Engine.CurrentEnergyAmount = currentEnergyAmount;

            foreach (Wheel wheel in m_Wheels)
            {
                wheel.Manufacturer = i_DataList[2];
                if (!float.TryParse(i_DataList[3], out currentAirPressure))
                {
                    currentAirPressure = (float)int.Parse(i_DataList[3]);
                }

                wheel.CurrentAirPressure = currentAirPressure;
            }
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
