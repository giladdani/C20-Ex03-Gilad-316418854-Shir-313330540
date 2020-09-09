﻿using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        // Private Members
        private eColor m_Color;
        private eDoorsAmount m_DoorsAmount;

        // Constructors
        public Car( string i_LicenseNumber, Engine i_Engine)
            : base(i_LicenseNumber, eWheelsAmount.Four, 32, i_Engine)
        {
        }

        // Enums
        public enum eColor
        {
            Gray = 1,
            White = 2,
            Green = 3,
            Red = 4
        }

        public enum eDoorsAmount
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5
        }

        // Public Methods
        public override List<VehicleDataRequest> GetVehicleDataRequests()
        {
            List<VehicleDataRequest> requests = new List<VehicleDataRequest>();
            requests.AddRange(base.GetVehicleDataRequests());
            string[] colorNames = Enum.GetNames(typeof(eColor));
            string[] doorAmountNames = Enum.GetNames(typeof(eDoorsAmount));
            string colorMessage = string.Format("Choose color:{0}1.{1}{0}2.{2}{0}3.{3}{0}4.{4}{0}", Environment.NewLine, colorNames[0], colorNames[1], colorNames[2], colorNames[3]);
            string doorsAmountMessage = string.Format("Choose doors amount:{0}1.{1}{0}2.{2}{0}3.{3}{0}4.{4}{0}", Environment.NewLine, doorAmountNames[0], doorAmountNames[1], doorAmountNames[2], doorAmountNames[3]);
            requests.Add(new VehicleDataRequest(colorMessage, VehicleDataRequest.eRequestType.NumericRange, 1, 4));
            requests.Add(new VehicleDataRequest(doorsAmountMessage, VehicleDataRequest.eRequestType.NumericRange, 1, 4));

            return requests;
        }

        public override string ToString()
        {
            return string.Format("{0}Color: {1}, Number of doors: {2}{3}", 
                base.ToString(), m_Color, m_DoorsAmount,  Environment.NewLine);
        }

        // Properties
        public eColor Color
        {
            get => m_Color;
            set => m_Color = value;     // @ Add validations and exceptions
        }

        public eDoorsAmount DoorsAmount
        {
            get => m_DoorsAmount;
            set => m_DoorsAmount = value;       // @ Add validations and exceptions
        }
    }
}
