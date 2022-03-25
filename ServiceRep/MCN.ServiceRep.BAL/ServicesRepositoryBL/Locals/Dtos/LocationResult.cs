using System;
using System.Collections.Generic;
using System.Text;

namespace MCN.ServiceRep.BAL.ServicesRepositoryBL.Locals.Dtos
{
   public class LocationResult
    {
        public string Name { get; set; }
        public string BusinessOverview { get; set; }
        public string PinLocation { get; set; }
        public string Profile { get; set; }
        public int UserRating { get; set; }
        public int PriceRating { get; set; }
        public string OpenTime { get; set; }
        public string Phone { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? ReviewsCount { get; set; }
        public int? FollowerCount { get; set; }
        public List<QuickFact> QuickFacts { get; set; }
        public List<PinsDto> PinsDtos { get; set; }
        public List<Follower> Followers { get; set; }
        public List<Reviews> Reviews { get; set; }
        public List<OpeningHour> OpeningHours { get; set; }
        public List<LocationResultImage> LocationResultImages { get; set; }
    }
}
