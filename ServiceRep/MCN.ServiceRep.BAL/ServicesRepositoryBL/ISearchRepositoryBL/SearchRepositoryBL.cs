using MCN.ServiceRep.BAL.ContextModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCN.ServiceRep.BAL.ServicesRepositoryBL.ISearchRepositoryBL
{
    public class SearchFilterDto
    {
        public double MinDistance { get; set; }
        public double MaxDistance { get; set; }
        public List<int> Interests { get; set; }
        public double SearchLat { get; set; }
        public double SearchLng { get; set; }
        public string Keyword { get; set; }

    }

    public class SearchResultDto
    {
        public int Id {get;set;}
        public string Email { get; set; }
        public string FirstName  { get; set; }
        public string LastName { get; set; } 
        public string Gender { get; set; }
        public string Title { get; set; }
        public double Distance { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public interface ISearchRepositoryBL
    {
        public List<SearchResultDto> GetSearchResults(SearchFilterDto filter);
    }
    public class SearchRepositoryBL : BaseRepository, ISearchRepositoryBL
    {
        public SearchRepositoryBL(RepositoryContext repository) : base(repository)
        {
            
        }

        public List<SearchResultDto> GetSearchResults(SearchFilterDto filter)
        {
            var query = "exec GetUserAddressByDistance {0}, {1}, {2}, {3}, {4}, {5}";
            var result = repositoryContext.GetUserAddressByDistances.FromSqlRaw(query,
                filter.SearchLat,
                filter.SearchLng,
                filter.Keyword.ToString(),
                filter.MinDistance,
                filter.MaxDistance,
                string.Join(",", filter.Interests)
                ).ToList();

            return result.Select(x => new SearchResultDto
            {
                Distance = x.Distance,
                Email = x.Email,
                FirstName = x.FirstName,
                Gender = x.Gender,
                Id = x.Id,
                LastName = x.LastName,
                Title = x.Title,
                Latitude=x.Latitude,
                Longitude=x.Longitude,

            }).ToList();
        }

    }
}
