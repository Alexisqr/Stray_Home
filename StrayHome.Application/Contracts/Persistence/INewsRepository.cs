using StrayHome.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Application.Contracts.Persistence
{
    public interface INewsRepository
    {
        Task<ICollection<News>> GetAllNews();

        Task<News> GetNewsById(Guid newsId);

        Task<News> CreateNews(News toCreate);

        Task<News> UpdateNews(News toUpdate);

        Task DeleteNews(Guid newsId);
    }
}
