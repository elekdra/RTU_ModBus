// -----------------------------------------------------------------------
// <copyright file="DataType.cs" company="Ametek">
// Copyright (c) 2012 Ametek. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace WDGModbusLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Enumeration definition
    /// for data types used in sensor
    /// </summary>
    public enum DataType
    {
        /// <summary>
        /// Data Type 2-byte usigned integer
        /// </summary>
        DATA_UINT16 = 1,

        /// <summary>
        /// Data Type 2-byte signed integer
        /// </summary>
        DATA_INT16,
        
        /// <summary>
        /// Data Type 4-byte unsigned integer
        /// </summary>
        DATA_UINT32,
        
        /// <summary>
        /// Data Type 4-byte signed integer
        /// </summary>
        DATA_INT32,
        
        /// <summary>
        /// Data Type Float
        /// </summary>
        DATA_FLOAT,
        
        /// <summary>
        /// Data Type Boolean
        /// </summary>
        DATA_BOOL,
        
        /// <summary>
        /// Data Type String
        /// </summary>
        DATA_STRING,
        
        /// <summary>
        /// Data Type IP address
        /// </summary>
        DATA_IP_ADDR,
        
        /// <summary>
        /// Data Type Time
        /// </summary>
        DATA_TIME,
        
        /// <summary>
        /// Data Type Date
        /// </summary>
        DATA_DATE,
        
        /// <summary>
        /// Data Type Undefined
        /// </summary>
        DATA_NONE
    }
}
