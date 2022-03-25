using System;
using System.Collections.Generic;
using System.Text;

namespace MCN.ServiceRep.BAL.ServicesRepositoryBL.Locals.Dtos
{
   public class Result<A> where A:class
    {
        /// <summary>
        /// Result Set of Search
        /// </summary>
        public IEnumerable<A> Data { get; set; }

        /// <summary>
        /// Selected Page
        /// </summary>
        public int SelectedPage { get; set; }

        /// <summary>
        /// Total Number of Pages
        /// </summary>
        public int TotalPages { get; set; }
    }
}
