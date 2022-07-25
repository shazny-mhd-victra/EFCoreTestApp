using DAL.Db.Entities;

namespace DAL.DataService.IDataService
{
    public interface INewsService
    {
        void DeleteNews(int newsId);
        Task<News> Find(int id);
        Task<IEnumerable<News>> GetAll();
        Task<News> Insert(News news);
        Task<News> Update(News news);
        void NewsReOrder(ref List<News> news, Dictionary<int, int> newsItems);
    }
}