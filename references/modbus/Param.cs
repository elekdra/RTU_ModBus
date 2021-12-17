// -----------------------------------------------------------------------
// <copyright file="Param.cs" company="Ametek">
// Copyright (c) 2012 Ametek. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace WDGModbusLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    /// <summary>
    /// Parameter Class definition
    /// </summary>
    public class Param : ICloneable
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Param"/> class
        /// Parameterized constructor
        /// </summary>
        /// <param name="p_id"> parameter identifier </param>
        /// <param name="d_type"> data type </param>
        /// <param name="d_size"> data size </param>
        /// <param name="mb_raddr"> modbus register address </param>
        public Param(Int16 p_id, DataType d_type, Int16 d_size, UInt16 mb_raddr)
        {
            this.ParamId = p_id;
            this.Datatype = d_type;
            this.DataSize = d_size;
            this.ModbusRegAddr = mb_raddr;
            this.SVal = string.Empty;
            this.FVal = 0;
            this.IVal = 0;
            this.NVal = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Param"/> class
        /// Parameterless constructor
        /// </summary>
        public Param()
        {
            this.ParamId = 0;
            this.Datatype = DataType.DATA_NONE;
            this.DataSize = 0;
            this.ModbusRegAddr = 0;
            this.SVal = string.Empty;
            this.FVal = 0;
            this.IVal = 0;
            this.NVal = 0;
        }
        #endregion

        #region Clone Method
        /// <summary>
        /// Implementation of Inherited Method 
        /// from ICloenable class
        /// </summary>
        /// <returns> object type</returns>
        public object Clone()
        {
            Param other = (Param)this.MemberwiseClone();
            return other;
        }
        #endregion

        #region Set Paramters
        /// <summary>
        /// Sets the string property value
        /// </summary>
        /// <param name="text">value to set</param>
        public void SetString(string text)
        {
            this.SVal = text;
        }

        /// <summary>
        /// Sets the float property value
        /// </summary>
        /// <param name="val">value to set</param>
        public void SetFloat(float val)
        {
            this.FVal = val;
        }

        /// <summary>
        /// Sets the integer property value
        /// </summary>
        /// <param name="val">value to set</param>
        public void SetInt(Int32 val)
        {
            this.IVal = val;
        }

        /// <summary>
        /// Sets the unsigned integer property value
        /// </summary>
        /// <param name="val">value to set</param>
        public void SetUInt(UInt32 val)
        {
            this.NVal = val;
        }
        #endregion

        #region Get Paramters
        /// <summary>
        /// Gets the String property value
        /// </summary>
        /// <returns> String value </returns>
        public string GetString()
        {
            return this.SVal;
        }

        /// <summary>
        /// Gets the Float property value
        /// </summary>
        /// <returns> Float value </returns>
        public float GetFloat()
        {
            return this.FVal;
        }

        /// <summary>
        /// Gets the integer property value
        /// </summary>
        /// <returns> integer value </returns>
        public Int32 GetInt()
        {
            return this.IVal;
        }

        /// <summary>
        /// Gets the unsinged integer property value
        /// </summary>
        /// <returns> unsinged integer value </returns>
        public UInt32 SetUInt()
        {
            return this.NVal;
        }
        #endregion

        #region Member Variables
        
        /// <summary>
        /// Gets or sets Parameter Identifier
        /// </summary>
        public Int16 ParamId { get; set; }
        
        /// <summary>
        /// Gets or sets Data type of parameter
        /// </summary>
        public DataType Datatype { get; set; }
        
        /// <summary>
        /// Gets or sets Size of data used for parameter
        /// </summary>
        public Int16 DataSize { get; set; }
        
        /// <summary>
        /// Gets or sets Modbus Register Address for parameter
        /// </summary>
        public UInt16 ModbusRegAddr { get; set; }
        
        /// <summary>
        /// Gets or sets String Value
        /// </summary>
        public string SVal { get; set; }
        
        /// <summary>
        /// Gets or sets Float Value
        /// </summary>
        public float FVal { get; set; }
        
        /// <summary>
        /// Gets or sets Signed Integer Value
        /// </summary>
        public Int32 IVal { get; set; }
        
        /// <summary>
        /// Gets or sets Unsigned Integer Value
        /// </summary>
        public UInt32 NVal { get; set; }

        #endregion
    }
}
