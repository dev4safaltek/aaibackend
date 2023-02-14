namespace AAI.RepositoryContract.ErrorLog
{
    /// <summary>
    /// Error Log Repository to log errors
    /// </summary>
    public interface IErrorLogRepository
    {
        /// <summary>
        /// Insert new errror log into the database.
        /// </summary>
        /// <param name="model">Error log view model object</param>
        //Task InsertErrorLogAsync(ErrorLogViewModel model);
    }
}
