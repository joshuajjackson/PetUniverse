﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Austin Gee
    /// Created: 2/6/2020
    /// Approver: Mohamed Elamin, 02/07/2020
    /// 
    /// This is a simple interface for methods that have to do with Adoption Customer
    /// data access.
    /// </summary>

    public interface IAdoptionCustomerAccessor
    {

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 2/6/2020
        /// Approver: Mohamed Elamin, 02/07/2020
        /// 
        /// Select Active Customers
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="active"></param>
        /// <returns>List of active customers</returns>
        List<AdoptionCustomerVM> SelectAdoptionCustomersByActive(bool active);

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 2/6/2020
        /// Approver: Mohamed Elamin, 02/07/2020
        /// 
        /// Select Customer by email
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="email"></param>
        /// <returns>List of customers</returns>
        AdoptionCustomerVM SelectAdoptionCustomerByEmail(string email);
    }
}