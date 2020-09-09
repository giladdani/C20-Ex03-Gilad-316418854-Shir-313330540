using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Runtime.InteropServices.ComTypes;

namespace Ex03.GarageLogic
{
    public class VehicleDataRequest
    {
        // Private Members
        private string m_Message;
        private eRequestType m_Type;
        private float? m_MinValue;
        private float? m_MaxValue;

        // Constructors
        public VehicleDataRequest(string i_Message, eRequestType i_Type)
        {
            m_Message = i_Message;
            m_Type = i_Type;
        }

        public VehicleDataRequest(string i_Message, eRequestType i_Type, float i_MinValue, float i_MaxValue)
        {
            m_Message = i_Message;
            m_Type = i_Type;
            m_MinValue = i_MinValue;
            m_MaxValue = i_MaxValue;
        }

        // Enums
        public enum eRequestType
        {
            YesOrNo = 1,
            String = 2,
            Number = 3,
            NumericRange = 4
        }

        // Public Methods
        public bool IsGivenDataValid(string i_GivenData)
        {
            bool isValid;
            switch(m_Type)
            {
                case eRequestType.YesOrNo:
                    {
                        isValid = isYesOrNo(i_GivenData);
                        break;
                    }
                case eRequestType.String:
                    {
                        isValid = isValidString(i_GivenData);
                        break;
                    }
                case eRequestType.Number:
                    {
                        isValid = isNumber(i_GivenData);
                        break;
                    }
                case eRequestType.NumericRange:
                    {
                        isValid = isNumber(i_GivenData) && isNumberInRange(i_GivenData);
                        break;
                    }
                default:
                    {
                        isValid = false;
                        break;
                    }
            }

            return isValid;
        }

        // Private Methods
        private bool isYesOrNo(string i_String)
        {
            string stringInLowercase = i_String.ToLower();

            return stringInLowercase == "yes" || stringInLowercase == "no";
        }

        private bool isValidString(string i_String)
        {
            bool isValid = !string.IsNullOrEmpty(i_String);

            return isValid;
        }

        private bool isNumber(string i_String)
        {
            return int.TryParse(i_String, out _);
        }

        private bool isNumberInRange(string i_String)
        {
            bool isValid = true;
            int stringAsNumber = int.Parse(i_String);
            if(stringAsNumber > m_MaxValue || stringAsNumber < m_MinValue)
            {
                isValid = false;
            }

            return isValid;
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

        public float MinValue
        {
            get
            {
                if(m_MinValue.HasValue)
                {
                    return m_MinValue.Value;
                }
                else
                {
                    throw new Exception("MinValue was not set.");
                }
            }

            set => m_MinValue = value;
        }

        public float MaxValue
        {
            get
            {
                if (m_MaxValue.HasValue)
                {
                    return m_MaxValue.Value;
                }
                else
                {
                    throw new Exception("MaxValue was not set.");
                }
            }

            set => m_MaxValue = value;
        }
    }
}
