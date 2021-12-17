// -----------------------------------------------------------------------
// <copyright file="CloneableList.cs" company="Ametek">
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
    /// Class to implement cloning of lists
    /// </summary>
    /// <typeparam name="T">List type</typeparam>
    public class CloneableList<T> : List<T>, ICloneable where T : ICloneable
    {
        /// <summary>
        /// Implementation of inherited Member function 
        /// </summary>
        /// <returns> object List type </returns>
        public object Clone()
        {
            var ret_obj = new CloneableList<T>();

            // this.ForEach(item => ret_obj.Add((T)item.Clone()));
            foreach (T item in this)
            {
                ret_obj.Add((T)item.Clone());
            }

            return ret_obj;
        }
    }
}
