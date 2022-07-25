using DAL.AppDbContext;
using DAL.DataService.IDataService;
using DAL.Models;
using DAL.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataService
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<CustomerModel> repo;

        public CustomerService(IRepository<CustomerModel> repo)
        {
            this.repo = repo;
        }

        public async Task<CustomerModel> Find(int id)
        {
            try
            {
                return await repo.Get(id);
            }
            catch (Exception er)
            {
                return new CustomerModel();
            }
        }
        public async Task<IEnumerable<CustomerModel>> GetAll()
        {
            try
            {
                return await repo.GetAll();
            }
            catch (Exception er)
            {
                return new List<CustomerModel>();
            }
        }
        public async Task<CustomerModel> Insert(CustomerModel customer)
        {
            try
            {
                await repo.Insert(customer);
                var result = await repo.Save();
                if (result > 0) return customer;
                else return customer;

            }
            catch (Exception er)
            {
                return new CustomerModel();
            }
        }
        public async Task<CustomerModel> Update(CustomerModel customer)
        {
            try
            {
                await repo.Update(customer);
                var result = await repo.Save();
                if (result > 0) return customer;
                else return customer;

            }
            catch (Exception er)
            {
                return new CustomerModel();
            }
        }

    }
}
