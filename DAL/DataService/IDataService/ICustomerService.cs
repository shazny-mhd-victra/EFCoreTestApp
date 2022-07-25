using DAL.Models;

namespace DAL.DataService.IDataService
{
    public interface ICustomerService
    {
        Task<CustomerModel> Find(int id);
        Task<IEnumerable<CustomerModel>> GetAll();
        Task<CustomerModel> Insert(CustomerModel customer);
        Task<CustomerModel> Update(CustomerModel customer);
    }
}