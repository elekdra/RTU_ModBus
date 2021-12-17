// -----------------------------------------------------------------------
// <copyright file="VI_Device.cs" company="Ametek">
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
    /// Definition of VI_Device Class
    /// </summary>
    public class VI_Device : ICloneable
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="VI_Device" /> class.
        /// </summary>
        public VI_Device()
        {
            this.DeviceName = string.Empty;
            this.DevModbusAddr = 0;
            this.DeviceExists = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VI_Device" /> class.
        /// </summary>
        /// <param name="mb_addr"> modbus address of device </param>
        public VI_Device(byte mb_addr)
        {
            this.DeviceName = string.Empty;
            this.DevModbusAddr = mb_addr;
            this.DeviceExists = false;
        }
        #endregion

        #region Clone Method
        /// <summary>
        /// Implementation of inherited method from ICloneable class.
        /// </summary>
        /// <returns>object type</returns>
        public object Clone()
        {
            VI_Device other = (VI_Device)this.MemberwiseClone();
            other.ParamList = (CloneableList<Param>)this.ParamList.Clone();
            return other;
        }
        #endregion

        #region Member Variables
        /// <summary>
        /// Gets or sets list of paramter IDs supported by device
        /// </summary>
        public CloneableList<Param> ParamList { get; set; }

        /// <summary>
        /// Gets or sets modbus Address assigned to device
        /// </summary>
        public byte DevModbusAddr { get; set; }

        /// <summary>
        /// Gets or sets Name assigned to device
        /// </summary>
        public string DeviceName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the device exists on modbus
        /// </summary>
        public Boolean DeviceExists { get; set; }
        #endregion
    }
}
