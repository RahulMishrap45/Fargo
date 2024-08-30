using Dapper;
using Dapper.FastCrud;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using HelperClasses;

namespace Repository
{
    public abstract class BaseRepository
    {
        protected IDbConnection DbContext { get; set; }
        protected BaseRepository()
        {
            DbContext = DbContext ?? new SqlConnection(AppSettings.GetConnectionString());          
        }
        protected virtual void Insert<TEntity>(TEntity model)
        {
            this.DbContext.InsertAsync(model);
        }
        protected async virtual Task<bool> Delete<TEntity>(TEntity model)
        {
            return await this.DbContext.DeleteAsync(model);
        }
        protected virtual List<TResult> Read<TResult>(Func<TResult, bool> predicate)
        {
            return DbContext.Find<TResult>().Where(predicate).Select(a => a).ToList();
        }
        protected virtual List<TResult> GetSPResults<TResult>(string spName, object parameters)
        {
            List<TResult> results = new List<TResult>();
            results = DbContext.Query<TResult>(spName, parameters, commandType: CommandType.StoredProcedure).ToList();
            return results;
        }
    }
}
