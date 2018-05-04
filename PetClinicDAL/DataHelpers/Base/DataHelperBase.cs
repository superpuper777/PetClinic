using System;
using System.Threading.Tasks;

namespace PetClinicDAL.DataHelpers.Base
{
    public class DataHelperBase
    {
        protected async Task<TResult> QueryAsync<TContext, TResult>(Func<TContext, Task<TResult>> call)
            where TContext : IDisposable
        {
            using (var context = (TContext)Activator.CreateInstance(typeof(TContext)))
            {
                return await call(context);
            }
        }

        protected async Task QueryAsync<TContext>(Func<TContext, Task> call)
            where TContext : IDisposable
        {
            using (var context = (TContext)Activator.CreateInstance(typeof(TContext)))
            {
                await call(context);
            }
        }
    }
}