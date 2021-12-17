// -----------------------------------------------------------------------
// <copyright file="ByteOrder.cs" company="Ametek">
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
    /// Enumeration to indicate byte ordering
    /// </summary>
    public enum ByteOrder
    {
        /// <summary>
        /// Little Endian Byte Order
        /// </summary>
        LittleEndian = 0,

        /// <summary>
        /// Big Endian Byte Order
        /// </summary>
        BigEndian
    }
}
