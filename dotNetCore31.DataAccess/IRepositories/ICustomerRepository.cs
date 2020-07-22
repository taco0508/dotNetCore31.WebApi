using System.Collections.Generic;
using System.Threading.Tasks;
using dotNetCore31.DataAccess.DataModels;

namespace dotNetCore31.DataAccess.IRepositories
{
    public interface ICustomerRepository
    {
        /// <summary>
        /// 取得客戶清單
        /// </summary>
        /// <param name="customerIds">客戶編號(多筆)</param>
        /// <returns></returns>
        Task<IEnumerable<CustomersDataModel>> GetCustomerListAsync(IEnumerable<string> customerIds);

        /// <summary>
        /// 新增客戶資料
        /// </summary>
        /// <param name="customersCreateDataModel">客戶CreateDataModel</param>
        /// <returns></returns>
        Task<int> CreateCustomerAsync(CustomersCreateDataModel customersCreateDataModel);

        /// <summary>
        /// 更新客戶資料
        /// </summary>
        /// <param name="customersUpdateDataModel">客戶UpdateDataModel</param>
        /// <returns></returns>
        Task<int> UpdateCustomerAsync(CustomersUpdateDataModel customersUpdateDataModel);
    }
}
