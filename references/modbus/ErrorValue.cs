// -----------------------------------------------------------------------
// <copyright file="ErrorValue.cs" company="Ametek">
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
    /// Error Value class definition
    /// </summary>
    public class ErrorValue : ICloneable
    {
        #region Cosntructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorValue" /> class.
        /// </summary>
        public ErrorValue()
        {
            this.ErrCode = string.Empty;
            this.Description = "Undefined";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorValue" /> class.
        /// </summary>
        /// <param name="ec"> error code </param>
        /// <param name="desc"> erro rdescription </param>
        public ErrorValue(string ec, string desc)
        {
            this.ErrCode = ec;
            this.Description = desc;
        }
        #endregion

        #region Clone Method
        /// <summary>
        /// Implementation of inherited method from ICloneable class
        /// </summary>
        /// <returns> object type</returns>
        public object Clone()
        {
            ErrorValue other = (ErrorValue)this.MemberwiseClone();
            return other;
        }
        #endregion

        #region Member Variables
        /// <summary>
        /// Gets or sets Error code string
        /// </summary>
        public string ErrCode { get; set; }

        /// <summary>
        /// Gets or sets error description string
        /// </summary>
        public string Description { get; set; }
        #endregion
    }
}
