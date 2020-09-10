using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        // Private Members
        private bool m_IsHazardous;
        private float m_CargoSize;

        // Constructors
        public Truck(string i_LicenseNumber, Engine i_Engine)
            : base(i_LicenseNumber, eWheelsAmount.Sixteen, 30, i_Engine)
        {
        }

        // Public Methods
        public override List<VehicleDataRequest> GetVehicleDataRequests()
        {
            List<VehicleDataRequest> requests = new List<VehicleDataRequest>();
            requests.AddRange(base.GetVehicleDataRequests());
            string hazardousMessage = string.Format("Is carrying hazardous equipment? (enter yes/no):");
            string cargoSizeMessage = string.Format("Enter cargo size:");
            requests.Add(new VehicleDataRequest(hazardousMessage, VehicleDataRequest.eRequestType.YesOrNo));
            requests.Add(new VehicleDataRequest(cargoSizeMessage, VehicleDataRequest.eRequestType.Number));

            return requests;
        }

        public override void UpdateVehicleData(List<string> i_DataList)
        {
            base.UpdateVehicleData(i_DataList);
            m_IsHazardous = i_DataList[4] == "yes" ? true : false;
            m_CargoSize = float.Parse(i_DataList[5]);
        }

        public override string ToString()
        {
            string hazardousYesOrNo = m_IsHazardous == true ? "Yes" : "No";
            return string.Format(
                "{0}Is truck containing hazardous substances: {1}, Cargo size: {2}{3}",
                base.ToString(),
                hazardousYesOrNo,
                m_CargoSize,
                Environment.NewLine);
        }

        // Properties
        public bool IsHazardous
        {
            get
            {
                return m_IsHazardous;
            }

            set
            {
                m_IsHazardous = value;            // @ Add validations and exceptions
            }
        }

        public float CargoSize
        {
            get
            {
                return m_CargoSize;
            }

            set
            {
                m_CargoSize = value;    // @ Add validations and exceptions
            }
        }
    }
}
