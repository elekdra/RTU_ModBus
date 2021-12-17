// -----------------------------------------------------------------------
// <copyright file="ErrorCodes.cs" company="Ametek">
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
    /// Error code class definition
    /// </summary>
    public class ErrorCodes
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorCodes" /> class.
        /// </summary>
        public ErrorCodes()
        {
            this.ErrList = null;
        }
        #endregion

        #region Member variables
        /// <summary>
        /// Gets or sets variable value
        /// Variable to store the list of all error codes
        /// </summary>
        public CloneableList<ErrorValue> ErrList { get; set; }
        #endregion
    }
}
