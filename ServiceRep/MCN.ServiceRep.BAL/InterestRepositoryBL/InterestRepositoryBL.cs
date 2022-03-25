using MCN.ServiceRep.BAL.ContextModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCN.ServiceRep.BAL.ServicesRepositoryBL.IInterestRepositoryBL
{
    public class InterestDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Paid { get; set; }
        public string Description { get; set; }
        public double Cost { get; set; }
        public string Type { get; set; }
        public string Display { get; set; }
        public string Value { get; set; }

    }

    public class InterestFilterDto
    {
        public string Keyword { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public interface IInterestRepositoryBL
    {
        public List<InterestDto> GetInterests(InterestFilterDto filter);
    }
    //public class InterestRepositoryBL : BaseRepository, IInterestRepositoryBL
    //{
    //    public InterestRepositoryBL(RepositoryContext repository) : base(repository)
    //    {
            

    //    }

    //    public List<InterestDto> GetInterests(InterestFilterDto filter)
    //    {
    //        var result = repositoryContext.Interests.AsQueryable();
    //        if (!string.IsNullOrWhiteSpace(filter.Keyword))
    //        {
    //            result = result.Where(x => x.Title.Contains(filter.Keyword));
    //        }
    //        result = result.Skip(filter.PageNumber * filter.PageSize).Take(filter.PageSize);
    //        return result.Select(x => 
    //        new InterestDto  
    //        {
    //             Cost = x.Cost,
    //             Description = x.Description,
    //             Id = x.Id,
    //             Paid = x.Paid,
    //             Title = x.Title,
    //             Type  = x.Type,
    //             Display=x.Title,
    //             Value=x.Title
    //        }).ToList();
    //    }
    //}
}
