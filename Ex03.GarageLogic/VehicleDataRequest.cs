using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace Ex03.GarageLogic
{
    public class VehicleDataRequest<T>
    {
        // Private Members
        private string m_Message;
        private T m_Type;

        // Constructors
        public VehicleDataRequest(string i_Message, T i_Type)
        {
            m_Message = i_Message;
            m_Type = i_Type;
        }

        // Enums
        public enum eRequestType
        {
            Bool = 1,
            Number = 2
        }

        // Properties
        public string Message
        {
            get => m_Message;
            set => m_Message = value;
        }

        public eRequestType Type
        {
            get => m_Type;
            set => m_Type = value;
        }
    }
}
