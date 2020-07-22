using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using dotNetCore31.DataAccess.DataModels;
using dotNetCore31.DataAccess.Infrastructure.Helpers.Connection;
using dotNetCore31.DataAccess.IRepositories;

namespace dotNetCore31.DataAccess.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IConnectionHelper _connectionHelper;

        public CustomerRepository(IConnectionHelper connectionHelper)
        {
            this._connectionHelper = connectionHelper;
        }

        /// <summary>
        /// 取得客戶清單
        /// </summary>
        /// <param name="customerIds">客戶編號(多筆)</param>
        /// <returns></returns>
        public async Task<IEnumerable<CustomersDataModel>> GetCustomerListAsync(IEnumerable<string> customerIds)
        {
            using (var conn = this._connectionHelper.GetNorthwindConnection())
            {
                var result = await conn.QueryAsync<CustomersDataModel>
                (
                    this.GetCustomerListAsyncSQL,
                    new { CustomerIDs = customerIds }
                );

                return result;
            }
        }

        /// <summary>
        /// 取得客戶清單 SQL
        /// </summary>
        private string GetCustomerListAsyncSQL =>
                     @"SELECT
                       [CustomerID],
                       [CompanyName],
	                   [ContactName],
	                   [ContactTitle],
	                   [Address],
	                   [City],
	                   [Region],
	                   [PostalCode],
	                   [Country],
	                   [NUM-3] AS [NUM_3],
	                   [ALPHA-2] AS [ALPHA_2],
	                   [ALPHA-3] AS [ALPHA_3],
	                   [Phone],
	                   [Fax]
                       FROM [dbo].[Customers]
                       WHERE [CustomerID] IN @CustomerIDs";

        /// <summary>
        /// 新增客戶資料
        /// </summary>
        /// <param name="customersCreateDataModel">客戶CreateDataModel</param>
        /// <returns></returns>
        public async Task<int> CreateCustomerAsync(CustomersCreateDataModel customersCreateDataModel)
        {
            using (var conn = this._connectionHelper.GetNorthwindConnection())
            {
                var result = await conn.ExecuteAsync
                (
                    this.CreateCustomerAsyncSQL,
                    customersCreateDataModel
                );
                return result;
            }
        }

        /// <summary>
        /// 新增客戶資料 SQL
        /// </summary>
        private string CreateCustomerAsyncSQL =>
            @"INSERT INTO [dbo].[Customers] 
              ([CustomerID]
              ,[CompanyName]
              ,[ContactName]
              ,[ContactTitle]
              ,[Address]
              ,[City]
              ,[Region]
              ,[PostalCode]
              ,[Country]
              ,[NUM-3]
              ,[ALPHA-2]
              ,[ALPHA-3]
              ,[Phone]
              ,[Fax])
               VALUES
              (@CustomerID
              ,@CompanyName
              ,@ContactName
              ,@ContactTitle
              ,@Address
              ,@City
              ,@Region
              ,@PostalCode
              ,@Country
              ,@NUM_3
              ,@ALPHA_2
              ,@ALPHA_3
              ,@Phone
              ,@Fax);";

        /// <summary>
        /// 更新客戶資料
        /// </summary>
        /// <param name="customersUpdateDataModel">客戶UpdateDataModel</param>
        /// <returns></returns>
        public async Task<int> UpdateCustomerAsync(CustomersUpdateDataModel customersUpdateDataModel)
        {
            using (var conn = this._connectionHelper.GetNorthwindConnection())
            {
                var result = await conn.ExecuteAsync
                (
                    this.UpdateCustomerAsyncSQL,
                    customersUpdateDataModel
                );
                return result;
            }
        }

        /// <summary>
        /// 更新客戶資料 SQL
        /// </summary>
        private string UpdateCustomerAsyncSQL =>
            @"UPDATE [dbo].[Customers] 
              SET [CompanyName] = @CompanyName
                 ,[ContactName] = @ContactName
                 ,[ContactTitle] = @ContactTitle
                 ,[Address] = @Address
                 ,[City] = @City
                 ,[Region] = @Region
                 ,[PostalCode] = @PostalCode
                 ,[Country] = @Country
                 ,[NUM-3] = @NUM_3
                 ,[ALPHA-2] = @ALPHA_2
                 ,[ALPHA-3] = @ALPHA_3
                 ,[Phone] = @Phone
                 ,[Fax] = @Fax 
              WHERE [CustomerID] = @CustomerID ";

        /// <summary>
        /// 刪除客戶資料
        /// </summary>
        /// <param name="customerId">客戶編號</param>
        /// <returns></returns>
        public async Task<int> DeleteCustomerAsync(string customerId)
        {
            using (var conn = this._connectionHelper.GetNorthwindConnection())
            {
                var result = await conn.ExecuteAsync
                (
                    this.DeleteCustomerAsyncSQL,
                    new { CustomerID = customerId }
                );
                return result;
            }
        }

        /// <summary>
        /// 刪除客戶資料 SQL
        /// </summary>
        private string DeleteCustomerAsyncSQL =>
            @"DELETE [dbo].[Customers] 
              WHERE [CustomerID] = @CustomerID";
    }
}
