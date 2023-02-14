using AAI.RepositoryContract.ErrorLog;
using AAI.ServiceContract.ErrorLog;
using Microsoft.AspNetCore.Http;

namespace AAI.Service.ErrorLog
{
    /// <summary>
    /// Error log service
    /// </summary>
    public class ErrorLogService : BaseService, IErrorLogService
    {
        private readonly IErrorLogRepository _errorLogRepository;
        public ErrorLogService(IHttpContextAccessor accessor, IErrorLogRepository errorLogRepository) : base(accessor, null)
        {
            _errorLogRepository = errorLogRepository;
        }

        /// <summary>
        /// Insert new errror log into the database.
        /// </summary>
        /// <param name="model">Error log view model object</param>
        //public async Task InsertErrorLogAsync(ErrorLogViewModel model)
        //{
        //    await _errorLogRepository.InsertErrorLogAsync(model);
        //}
    }
}
