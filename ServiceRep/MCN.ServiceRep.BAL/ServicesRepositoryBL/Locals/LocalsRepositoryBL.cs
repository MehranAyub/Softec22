using MCN.ServiceRep.BAL.ContextModel;
using MCN.ServiceRep.BAL.ServicesRepositoryBL.Locals.Criteria;
using MCN.ServiceRep.BAL.ServicesRepositoryBL.Locals.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;

namespace MCN.ServiceRep.BAL.ServicesRepositoryBL.Locals
{
   public class LocalsRepositoryBL:ILocalsRepositoryBL
    {
        private RepositoryContext _repositoryContext;
        public  LocalsRepositoryBL(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public Result<LocationResult> Locations(SearchCriteria criteria)
        {
            List<LocationResult> localsDtos = new List<LocationResult>();
            LocationResult localsDto = new LocationResult();
            localsDto.Name = "Assian Market";
            localsDto.PinLocation = "406 Main Street, Boonton, NJ 07005";
            localsDto.Profile = "food1-300x300.png";
            localsDto.PriceRating = 3;
            localsDto.UserRating = 4;

            localsDto.OpenTime = "Today, 9AM-9PM";
            localsDto.Phone = "(973) 877-3759";
            localsDto.QuickFacts = new List<QuickFact> { new QuickFact { Name = "Parking Place", Code = "car" }, new QuickFact { Name = "Full Halal Menu", Code = "child" }, new QuickFact { Name = "Alcohol-Free", Code = "glass-martini" }, new QuickFact { Name = "Delivery Availables", Code = "envelope" } };
            localsDto.PinsDtos = new List<PinsDto> { new PinsDto { Name = "Assian" } };
            localsDtos.Add(localsDto);

            LocationResult localsDto1 = new LocationResult();
            localsDto1.Name = "Turkish Market";
            localsDto1.Profile = "food2-300x300.png";
            localsDto1.PinLocation = "405 Main Street,Bonton NJ 0705";
            localsDto1.PriceRating = 1;
            localsDto1.UserRating = 2;
            localsDto1.OpenTime = "Today 09 Am - 09 PM";
            localsDto1.Phone = "(973)-877-3759";
            localsDto1.QuickFacts = new List<QuickFact> { new QuickFact { Name = "Parking Place", Code = "car" }, new QuickFact { Name = "Full Halal Menu", Code = "child" }, new QuickFact { Name = "Alcohol-Free", Code = "glass-martini" }, new QuickFact { Name = "Delivery Availables", Code = "envelope" } };
            localsDto1.PinsDtos = new List<PinsDto> { new PinsDto { Name = "Assian" }, new PinsDto { Name = "Middle East" } };
            localsDtos.Add(localsDto1);

            LocationResult localsDto2 = new LocationResult();
            localsDto2.Name = "Turkish Market";
            localsDto2.Profile = "food3-300x300.png";
            localsDto2.PinLocation = "405 Main Street,Bonton NJ 0705";
            localsDto2.PriceRating = 3;
            localsDto2.UserRating = 1;
            localsDto2.OpenTime = "Today 09 Am - 09 PM";
            localsDto2.Phone = "(973)-877-3759";
            localsDto2.QuickFacts = new List<QuickFact> {  new QuickFact { Name = "Delivery Availables", Code = "envelope" } };
            localsDto2.PinsDtos = new List<PinsDto> { new PinsDto { Name = "Assian" }, new PinsDto { Name = "Middle west" } };
            localsDtos.Add(localsDto2);

            LocationResult localsDto3 = new LocationResult();
            localsDto3.Name = "Turkish Market";
            localsDto3.Profile = "food4-300x300.png";
            localsDto3.PinLocation = "405 Main Street,Bonton NJ 0705";
            localsDto3.PriceRating = 3;
            localsDto3.UserRating = 3;
            localsDto3.OpenTime = "Today 09 Am - 09 PM";
            localsDto3.Phone = "(973)-877-3759";
            localsDto3.QuickFacts = new List<QuickFact> { new QuickFact { Name = "Parking Place", Code = "car" }, new QuickFact { Name = "Full Halal Menu", Code = "child" }, new QuickFact { Name = "Alcohol-Free", Code = "glass-martini" }, new QuickFact { Name = "Delivery Availables", Code = "envelope" } };
            localsDto3.PinsDtos = new List<PinsDto> { new PinsDto { Name = "Assian" }, new PinsDto { Name = "Middle East" } };
            localsDtos.Add(localsDto3);

            LocationResult localsDto4 = new LocationResult();
            localsDto4.Name = "Turkish Market";
            localsDto4.Profile = "food5-300x300.png";
            localsDto4.PinLocation = "405 Main Street,Bonton NJ 0705";
            localsDto4.PriceRating = 3;
            localsDto4.UserRating = 5;
            localsDto4.OpenTime = "Today 09 Am - 09 PM";
            localsDto4.Phone = "(973)-877-3759";
            localsDto4.QuickFacts = new List<QuickFact> { new QuickFact { Name = "Parking Place", Code = "car" }, new QuickFact { Name = "Full Halal Menu", Code = "child" }, new QuickFact { Name = "Alcohol-Free", Code = "glass-martini" } };
            localsDto4.PinsDtos = new List<PinsDto> { new PinsDto { Name = "Assian" }, new PinsDto { Name = "Middle East" } };
            localsDtos.Add(localsDto4);

            LocationResult localsDto5 = new LocationResult();
            localsDto5.Name = "Turkish Market";
            localsDto5.Profile = "food6-300x300.png";
            localsDto5.PinLocation = "405 Main Street,Bonton NJ 0705";
            localsDto5.PriceRating = 3;
            localsDto5.UserRating = 2;
            localsDto5.OpenTime = "Today 09 Am - 09 PM";
            localsDto5.Phone = "(973)-877-3759";
            localsDto5.QuickFacts = new List<QuickFact> {  new QuickFact { Name = "Full Halal Menu", Code = "child" }, new QuickFact { Name = "Alcohol-Free", Code = "glass-martini" }, new QuickFact { Name = "Delivery Availables", Code = "envelope" } };
            localsDto5.PinsDtos = new List<PinsDto> { new PinsDto { Name = "Assian" }, new PinsDto { Name = "Middle East" } };
            localsDtos.Add(localsDto5);

            LocationResult localsDto6 = new LocationResult();
            localsDto6.Name = "Last Market";
            localsDto6.Profile = "food7-300x300.png";
            localsDto6.PinLocation = "405 Main Street,Bonton NJ 0705";
            localsDto6.PriceRating = 3;
            localsDto6.UserRating = 3;
            localsDto6.OpenTime = "Today 09 Am - 09 PM";
            localsDto6.Phone = "(973)-877-3759";
            localsDto6.QuickFacts = new List<QuickFact> { new QuickFact { Name = "Parking Place", Code = "car" },  new QuickFact { Name = "Alcohol-Free", Code = "glass-martini" }, new QuickFact { Name = "Delivery Availables", Code = "envelope" } };
            localsDto6.PinsDtos = new List<PinsDto> { new PinsDto { Name = "Assian" }, new PinsDto { Name = "Middle East" } };
            localsDtos.Add(localsDto6);





            var sortExpression = $@"{criteria.SortBy} {(criteria.SortDirection == SortDirection.Descending ? @"descending" : @"ascending")}";
            var pageNumber = criteria.PageNumber - 1;

           
            var resultData = localsDtos.AsQueryable().OrderBy(sortExpression)
                       .Skip(criteria.PageSize * pageNumber)
                       .Take(criteria.PageSize)
                       .ToList();
            var result = new Result<LocationResult>
            {
                Data = resultData,
                SelectedPage = criteria.PageNumber,
                TotalPages = (int)Math.Ceiling(localsDtos.Count() / (double)criteria.PageSize)
            };


            return result;
        }

         public List<MenuItem> MenuItem()
         {
            List<MenuItem> menuItems = new List<MenuItem>();
            MenuItem menu1 = new MenuItem();
            menu1.ID = 1;
            menu1.Name = "Food Services";
            menu1.Count = 654;
            menu1.Path = "item7-350x300.png";
            menuItems.Add(menu1);

            MenuItem menu2 = new MenuItem();
            menu2.ID = 2;
            menu2.Name = "Schools";
            menu2.Count = 545;
            menu2.Path = "item1-350x300.png";
            menuItems.Add(menu2);

            MenuItem menu3 = new MenuItem();
            menu3.ID = 3;
            menu3.Name = "Mosques";
            menu3.Count = 343;
            menu3.Path = "item2-350x300.png";
            menuItems.Add(menu3);

            MenuItem menu4 = new MenuItem();
            menu4.ID = 4;
            menu4.Name = "Market";
            menu4.Count = 234;
            menu4.Path = "item3-350x300.png";
            menuItems.Add(menu4);

            MenuItem menu5 = new MenuItem();
            menu5.ID = 5;
            menu5.Name = "News & Articles";
            menu5.Count = 4465;
            menu5.Path = "item4-350x300.png";
            menuItems.Add(menu5);

            MenuItem menu6 = new MenuItem();
            menu6.ID = 6;
            menu6.Name = "People";
            menu6.Count = 165;
            menu6.Path = "item5-350x300.png";
            menuItems.Add(menu6);

            MenuItem menu7 = new MenuItem();
            menu7.ID = 7;
            menu7.Name = "Others";
            menu7.Count = 265;
            menu7.Path = "item6-350x300.png";
            menuItems.Add(menu7);

            return menuItems;

        }

        public List<Offer> GetOffers()
        {
            List<Offer> offers = new List<Offer>();
            Offer offer1 = new Offer();
            offer1.ID = 1;
            offer1.Image = "happy-hour-40x40.png";
            offer1.Heading = "Happy hour 50% of promo";
            offer1.SubHeading = "Uncle Tonny pizza";
            offer1.ExpireTime = "22 December 2019";

            Offer offer2 = new Offer();
            offer2.ID = 2;
            offer2.Image = "happy-hour-40x40.png";
            offer2.Heading = "Happy hour 10% of promo";
            offer2.SubHeading = "Uncle Allen pizza";
            offer2.ExpireTime = "25 December 2019";

            Offer offer3 = new Offer();
            offer3.ID = 3;
            offer3.Image = "happy-hour-40x40.png";
            offer3.Heading = "Happy hour 80% of promo";
            offer3.SubHeading = "Uncle Chips";
            offer3.ExpireTime = "15 January 2019";

            Offer offer4 = new Offer();
            offer4.ID = 4;
            offer4.Image = "happy-hour-40x40.png";
            offer4.Heading = "Happy hour 100% of promo";
            offer4.SubHeading = "Babe Sandwitch";
            offer4.ExpireTime = "20 December 2019";

            Offer offer5 = new Offer();
            offer5.ID = 5;
            offer5.Image = "happy-hour-40x40.png";
            offer5.Heading = "Happy hour 100% of promo";
            offer5.SubHeading = "Burger";
            offer5.ExpireTime = "20 December 2019";

            offers.Add(offer1);
            offers.Add(offer2);
            offers.Add(offer3);
            offers.Add(offer4);
            offers.Add(offer5);

            return offers;
        }

        public List<LocalPopular> localPopulars()
        {
            List<LocalPopular> localPopulars = new List<LocalPopular>();

            LocalPopular localPopular1 = new LocalPopular();
            localPopular1.Heading = "Zubaidah's Halal American restaurent";
            localPopular1.ID = 1;
            localPopular1.By = "Zubaidah Amman";

            LocalPopular localPopular2 = new LocalPopular();
            localPopular2.Heading = "Zubaidah's Halal punjabi restaurent";
            localPopular2.ID = 2;
            localPopular2.By = "Zubaidah Amman";

            LocalPopular localPopular3 = new LocalPopular();
            localPopular3.Heading = "Neelum's  restaurent";
            localPopular3.ID = 3;
            localPopular3.By = "Zubaidah Amman";

            LocalPopular localPopular4 = new LocalPopular();
            localPopular4.Heading = "Zubaidah's Halal American restaurent";
            localPopular4.ID = 4;
            localPopular4.By = "Zubaidah Amman";

            localPopulars.Add(localPopular1);
            localPopulars.Add(localPopular2);
            localPopulars.Add(localPopular3);
            localPopulars.Add(localPopular4);

            return localPopulars;
        }

        public LocationResult GetLocationResultDetails(int locationResultID)
        {
             
            LocationResult localsDto = new LocationResult();
            localsDto.Name = "Assian Market";
            localsDto.PinLocation = "406 Main Street, Boonton, NJ 07005";
            localsDto.BusinessOverview = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.";
            localsDto.Profile = "resto-pic2.png";
            localsDto.PriceRating = 3;
            localsDto.UserRating = 4;
            localsDto.FollowerCount = localsDto.Followers?.Count();
            localsDto.LocationResultImages = new List<LocationResultImage> { new LocationResultImage { ID = 1, LocationResultID = 1, Order = 1, Path = "slide1" }, new LocationResultImage { ID = 2,LocationResultID=1,Order=2,Path="slide2" }, new LocationResultImage { ID = 3, LocationResultID = 1, Order = 3, Path = "slide3" }, new LocationResultImage { ID = 4, LocationResultID = 1, Order = 4, Path = "slide4" }, new LocationResultImage { ID = 5, LocationResultID = 1, Order = 5, Path = "slide5" }, new LocationResultImage { ID = 6, LocationResultID = 1, Order = 6, Path = "slide6" }, new LocationResultImage { ID = 7, LocationResultID = 1, Order = 7, Path = "slide7" }, new LocationResultImage { ID = 8, LocationResultID = 1, Order = 8, Path = "slide8" } };
            localsDto.QuickFacts = new List<QuickFact> { new QuickFact { Name = "Parking Place", Code = "car" }, new QuickFact { Name = "Full Halal Menu", Code = "child" }, new QuickFact { Name = "Alcohol-Free", Code = "glass-martini" }, new QuickFact { Name = "Delivery Availables", Code = "envelope" }, new QuickFact { Name = "Prayer Accomodation", Code = "user-circle" }, new QuickFact { Name = "Wifi Availables", Code = "wifi" }, new QuickFact { Name = "Credit Card", Code = "credit-card" }, new QuickFact { Name = "Public-transit access", Code = "train" } };
            localsDto.Reviews = new List<Reviews> { 
             new Reviews { ID = 1, LocationResultID = 1, FollowInd = true, Name = "Ankarian Sulaiman",Image="avatar1", PinLocation = " Picscataway Township, NJ", CreatedAt = DateTime.Now, ReviewDescription = "Cras sit amet nibh libero, in gravida nulla. Nulla vel metus scelerisque ante sollicitudin. Cras purus odio, vestibulum in vulputate at, tempus viverra turpis. Fusce condimentum nunc ac nisi vulputate fringilla. Donec lacinia congue felis in." } ,
            new Reviews { ID = 1, LocationResultID = 1, FollowInd = true, Name = "Deniz Ahamed",Image="avatar2", PinLocation = " Picscataway Township, NJ", CreatedAt = DateTime.Now, ReviewDescription = "Cras sit amet nibh libero, in gravida nulla. Nulla vel metus scelerisque ante sollicitudin. Cras purus odio." } };
            localsDto.ReviewsCount = localsDto.Reviews.Count() ;
            localsDto.OpeningHours = new List<OpeningHour> { new OpeningHour { ID=1,LocationResultID=1,Day="Sun",From="9AM",To="9pm "},
            new OpeningHour { ID=1,LocationResultID=1,Day="Mon",From="9AM",To="9pm "},
            new OpeningHour { ID=1,LocationResultID=1,Day="Tue",From="9AM",To="9pm "},
            new OpeningHour { ID=1,LocationResultID=1,Day="Wed",From="9AM",To="9pm "},
            new OpeningHour { ID=1,LocationResultID=1,Day="Thu",From="9AM",To="9pm "},
            new OpeningHour { ID=1,LocationResultID=1,Day="Fri",From="9AM",To="9pm "},
            new OpeningHour { ID=1,LocationResultID=1,Day="Sat",From="9AM",To="9pm "}};
            localsDto.Followers = new List<Follower> { new Follower { ID=1,LocationResultID=1,Name= "Anisa Sanari",Address= "Picscataway Township, NJ",Image="avatar3-60x60.png" } ,
             new Follower { ID=1,LocationResultID=1,Name= "Tony Ja",Address= "Picscataway Township, NJ",Image="avatar1-60x60.png" } ,
             new Follower { ID=1,LocationResultID=1,Name= "Miriam Whitterson",Address= "Picscataway Township, NJ",Image="avatar2-60x60.png" } ,
             new Follower { ID=1,LocationResultID=1,Name= "Denisz Youssef",Address= "Picscataway Township, NJ" ,Image="avatar4-60x60.png"} }; 
              
            localsDto.OpenTime = "Today, 9AM-9PM";
            localsDto.Phone = "(973) 877-3759";
            
            localsDto.PinsDtos = new List<PinsDto> { new PinsDto { Name = "Assian" } };


            return localsDto;

        }
    }
}
