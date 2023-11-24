using Microsoft.EntityFrameworkCore;
using StrayHome.Application.Contracts.Persistence;
using StrayHome.Domain.Entities;
using StrayHome.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrayHome.Infrastructure.Repositories
{
    public class NewsRepository : INewsRepository
    {
        private readonly StrayHomeContext _context;

        public NewsRepository(StrayHomeContext context)
        {
            _context = context;
        }

        public async Task<News> CreateNews(News toCreate)
        {
            _context.News.Add(toCreate);

            await _context.SaveChangesAsync();

            return toCreate;
        }

        public async Task DeleteNews(Guid newsId)
        {
            var hopItem = _context.News
                .FirstOrDefault(p => p.ID == newsId);

            if (hopItem is null) return;

            _context.News.Remove(hopItem);

            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<News>> GetAllNews()
        {
            return await _context.News.ToListAsync();
        }

        public async Task<News> GetNewsById(Guid newsId)
        {
            return await _context.News.FirstAsync(p => p.ID == newsId);
        }

        public async Task<News> UpdateNews(News toCreate)
        {
            var news = await _context.News.FirstOrDefaultAsync(p => p.ID == toCreate.ID);
            news.Text = toCreate.Text;
            news.Title = toCreate.Title;
            news.PublicationDate = toCreate.PublicationDate;
            news.ShelterID = toCreate.ShelterID;
            await _context.SaveChangesAsync();

            return news;
        }
    }
}

