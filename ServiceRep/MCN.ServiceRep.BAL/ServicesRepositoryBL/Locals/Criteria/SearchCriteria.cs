using System;
using System.Collections.Generic;
using System.Text;

namespace MCN.ServiceRep.BAL.ServicesRepositoryBL.Locals.Criteria
{
   public class SearchCriteria
    {
        /// <summary>
        /// search by column What
        /// </summary>
        public string What { get; set; }
        /// <summary>
        /// search by column Where
        /// </summary>
        public string Where { get; set; }
        /// <summary>
        /// Page Number
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Page Size
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Property Name SortBy
        /// </summary>
        public string SortBy { get; set; }

        /// <summary>
        /// Order Type i.e Asc or Desc
        /// </summary>
        public SortDirection SortDirection { get; set; }
    }
    public enum SortDirection
    {
        Ascending,
        Descending
    }
}
