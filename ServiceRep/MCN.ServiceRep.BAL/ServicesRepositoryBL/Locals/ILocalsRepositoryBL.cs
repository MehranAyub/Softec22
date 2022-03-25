using MCN.ServiceRep.BAL.ServicesRepositoryBL.Locals.Criteria;
using MCN.ServiceRep.BAL.ServicesRepositoryBL.Locals.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCN.ServiceRep.BAL.ServicesRepositoryBL.Locals
{
  public  interface ILocalsRepositoryBL
    {
        Result<LocationResult> Locations(SearchCriteria criteria);
        List<MenuItem> MenuItem();
        List<Offer> GetOffers();
        List<LocalPopular> localPopulars();
        LocationResult GetLocationResultDetails(int locationResultID);
    }
}
