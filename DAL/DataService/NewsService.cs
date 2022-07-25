using DAL.DataService.IDataService;
using DAL.Db;
using DAL.Db.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataService
{
    public class NewsService : INewsService
    {
        private NewsDbContext? _dbcontext;

        public NewsService()
        {
        }

        public async Task<News> Find(int id)
        {
            try
            {
                _dbcontext = new NewsDbContext();
                var Result = await _dbcontext.News.Where(i=>i.IsDeleted==false && i.NewsId==id).FirstOrDefaultAsync();
                if (Result == null) Result = new News();

                return Result;
            }
            catch (Exception er)
            {
                return new News();
            }
        }
        public async Task<IEnumerable<News>> GetAll()
        {
            try
            {
                _dbcontext = new NewsDbContext();
                var Data = await _dbcontext.News.Where(i => i.IsDeleted == false).Include(i=>i.Priority).ToListAsync();

                Dictionary<int,int> ASCOrder = new Dictionary<int, int>()
                {
                    {1, 1},
                    {2, 2},
                    {3, 3}
                };
                Dictionary<int,int> DSCOrder = new Dictionary<int, int>()
                {
                    {1, 1},
                    {2, 2},
                    {3, 3}
                };
                NewsReOrder(ref Data,ASCOrder);

                return Data;
            }
            catch (Exception er)
            {
                return new List<News>();
            }
        }
        public async Task<News> Insert(News news)
        {
            try
            {
                _dbcontext = new NewsDbContext();

                await _dbcontext.News.AddAsync(news);
                var result = await _dbcontext.SaveChangesAsync();
                if (result > 0) return news;
                else return news;

            }
            catch (Exception er)
            {
                return new News();
            }
        }
        public async Task<News> Update(News news)
        {
            try
            {
                _dbcontext = new NewsDbContext();

                _dbcontext.Update(news);
                var result = await _dbcontext.SaveChangesAsync();
                if (result > 0) return news;
                else return news;

            }
            catch (Exception er)
            {
                return new News();
            }
        }
        public void DeleteNews(int newsId)
        {
            _dbcontext = new NewsDbContext();

            News? news = _dbcontext.News.FirstOrDefault(ni => ni.NewsId == newsId);
            if (news == null) news = new News();
            if (news != null)
            {
                news.IsDeleted = true;
                _dbcontext.SaveChanges();
            }
        }

        public void NewsReOrder(ref List<News> news, Dictionary<int, int> newsItems)
        {
            try
            {
                var TempData = news;
                _dbcontext = new NewsDbContext();

                //List<News> newsList = _dbcontext.News.Where(n => newsItems.Keys.Contains(n.NewsId)).Include(i=>i.Priority).ToList();
                //TempData.ForEach(n => n.PriorityId = newsItems.First(f => f.Key == n.NewsId).Value);
                TempData = TempData.OrderBy(n => n.PriorityId).ToList();

                news = TempData;
                newsItems.Clear();
            }
            catch (Exception er)
            {
                throw;
            }
        }

    }
}
