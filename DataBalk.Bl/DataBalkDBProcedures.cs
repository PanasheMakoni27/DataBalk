using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBalk.Bo;
using Dapper;
using log4net;
using System.Data.SqlClient;
using System.Data;
using System.Xml.Linq;

namespace DataBalk.Bl
{
    public class DataBalkDBProcedures:IDataBalkDBProcedures
    {
        private readonly IConnectionManager _connectionManager;
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public DataBalkDBProcedures(IConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
        }

        public virtual async Task<int> pr_CreateTaskAsync(string Title, string Description, int? Assignee, DateTime? DueDate)
        {
            try
            {
                using (var connection = _connectionManager.DefaultConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@Title", Title);
                    parameters.Add("@Description", Description);
                    parameters.Add("@Assignee", Assignee);
                    parameters.Add("@DueDate", DueDate);
                    parameters.Add("@ReturnVal", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue); // Add the return value parameter

                    await connection.ExecuteAsync("[dbo].[pr_CreateTask]", param: parameters, commandType: CommandType.StoredProcedure);

                    int returnValue = parameters.Get<int>("@ReturnVal");

                    return returnValue;
                }
            }
            catch (SqlException sqlEx)
            {
                Log.Error($"SQL Error: {sqlEx.Message}");
                throw new Exception("An error occurred while processing your request. Please try again later.");
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw; // Rethrow the original exception for other unexpected errors
            }

        }

        public virtual async Task<int> pr_DeleteTaskAsync(int? TaskID)
        {
            try
            {
                using (var connection = _connectionManager.DefaultConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@TaskID", TaskID);
                    parameters.Add("@ReturnVal", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue); // Add the return value parameter

                    await connection.ExecuteAsync("[dbo].[pr_DeleteTask]", param: parameters, commandType: CommandType.StoredProcedure);

                    int returnValue = parameters.Get<int>("@ReturnVal");

                    return returnValue;
                }
            }
            catch (SqlException sqlEx)
            {
                Log.Error($"SQL Error: {sqlEx.Message}");
                throw new Exception("An error occurred while processing your request. Please try again later.");
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw; // Rethrow the original exception for other unexpected errors
            }

        }

        public virtual async Task<int> pr_DeleteUserAsync(int? UserID)
        {
            try
            {
                using (var connection = _connectionManager.DefaultConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@UserID", UserID);
                    parameters.Add("@ReturnVal", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue); // Add the return value parameter

                    await connection.ExecuteAsync("[dbo].[pr_DeleteUser]", param: parameters, commandType: CommandType.StoredProcedure);

                    int returnValue = parameters.Get<int>("@ReturnVal");

                    return returnValue;
                }
            }
            catch (SqlException sqlEx)
            {
                Log.Error($"SQL Error: {sqlEx.Message}");
                throw new Exception("An error occurred while processing your request. Please try again later.");
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw; // Rethrow the original exception for other unexpected errors
            }

        }

        public virtual async Task<List<pr_GetActiveTaskResult>> pr_GetActiveTaskAsync()
        {
            try
            {
                using (var connection = _connectionManager.DefaultConnection())
                {

                    var result = await connection.QueryAsync<pr_GetActiveTaskResult>("[dbo].[pr_GetActiveTask]", commandType: CommandType.StoredProcedure);

                    return result.ToList();
                }
            }
            catch (SqlException sqlEx)
            {
                Log.Error($"SQL Error: {sqlEx.Message}");
                throw new Exception("An error occurred while processing your request. Please try again later.");
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw; // Rethrow the original exception for other unexpected errors
            }

        }

        public virtual async Task<List<pr_GetAllTasksResult>> pr_GetAllTasksAsync()
        {
            try
            {
                using (var connection = _connectionManager.DefaultConnection())
                {

                    var result = await connection.QueryAsync<pr_GetAllTasksResult>("[dbo].[pr_GetAllTasks]", commandType: CommandType.StoredProcedure);

                    return result.ToList();
                }
            }
            catch (SqlException sqlEx)
            {
                Log.Error($"SQL Error: {sqlEx.Message}");
                throw new Exception("An error occurred while processing your request. Please try again later.");
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw; // Rethrow the original exception for other unexpected errors
            }

        }

        public virtual async Task<List<pr_GetAllUsersResult>> pr_GetAllUsersAsync()
        {
            try
            {
                using (var connection = _connectionManager.DefaultConnection())
                {

                    var result = await connection.QueryAsync<pr_GetAllUsersResult>("[dbo].[pr_GetAllUsers]", commandType: CommandType.StoredProcedure);

                    return result.ToList();
                }
            }
            catch (SqlException sqlEx)
            {
                Log.Error($"SQL Error: {sqlEx.Message}");
                throw new Exception("An error occurred while processing your request. Please try again later.");
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw; // Rethrow the original exception for other unexpected errors
            }

        }

        public virtual async Task<List<pr_GetExpiredTaskResult>> pr_GetExpiredTaskAsync()
        {
            try
            {
                using (var connection = _connectionManager.DefaultConnection())
                {

                    var result = await connection.QueryAsync<pr_GetExpiredTaskResult>("[dbo].[pr_GetExpiredTask]", commandType: CommandType.StoredProcedure);

                    return result.ToList();
                }
            }
            catch (SqlException sqlEx)
            {
                Log.Error($"SQL Error: {sqlEx.Message}");
                throw new Exception("An error occurred while processing your request. Please try again later.");
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw; // Rethrow the original exception for other unexpected errors
            }

        }

        public virtual async Task<List<pr_GetTaskResult>> pr_GetTaskAsync(int? TaskID)
        {
            try
            {

                using (var connection = _connectionManager.DefaultConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@UserID", TaskID);
                    parameters.Add("@returnValue", dbType: DbType.Int32, direction: ParameterDirection.Output);

                    var results = await connection.QueryAsync<pr_GetTaskResult>("[dbo].[pr_GetTask]", parameters, commandType: CommandType.StoredProcedure);

                    int returnValue = parameters.Get<int>("@returnValue");

                    return results.ToList();
                }
            }
            catch (SqlException sqlEx)
            {
                Log.Error($"SQL Error: {sqlEx.Message}");
                throw new Exception("An error occurred while processing your request. Please try again later.");
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw; // Rethrow the original exception for other unexpected errors
            }


        }

        public virtual async Task<List<pr_GetTaskByDateResult>> pr_GetTaskByDateAsync(DateTime? Date)
        {
            try
            {
                using (var connection = _connectionManager.DefaultConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@Date", Date);
                    parameters.Add("@returnValue", dbType: DbType.Int32, direction: ParameterDirection.Output);

                    var results = await connection.QueryAsync<pr_GetTaskByDateResult>("[dbo].[pr_GetTaskByDate]", parameters, commandType: CommandType.StoredProcedure);

                    int returnValue = parameters.Get<int>("@returnValue");

                    return results.ToList();
                }

              
            }
            catch (SqlException sqlEx)
            {
                Log.Error($"SQL Error: {sqlEx.Message}");
                throw new Exception("An error occurred while processing your request. Please try again later.");
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw; // Rethrow the original exception for other unexpected errors
            }
        }

        public virtual async Task<List<pr_GetUserResult>> pr_GetUserAsync(int? UserID)
        {
            try
            {
                using (var connection = _connectionManager.DefaultConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@UserID", UserID);
                    parameters.Add("@returnValue", dbType: DbType.Int32, direction: ParameterDirection.Output);

                    var results = await connection.QueryAsync<pr_GetUserResult>("[dbo].[pr_GetUser]", parameters, commandType: CommandType.StoredProcedure);

                    int returnValue = parameters.Get<int>("@returnValue");

                    return results.ToList();
                }


            }
            catch (SqlException sqlEx)
            {
                Log.Error($"SQL Error: {sqlEx.Message}");
                throw new Exception("An error occurred while processing your request. Please try again later.");
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw; // Rethrow the original exception for other unexpected errors
            }
        }

        public virtual async Task<int> pr_RegisterUserAsync(string Username, string Email, string Password)
        {
            try
            {
                using (var connection = _connectionManager.DefaultConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@Username", Username);
                    parameters.Add("@Email", Email);
                    parameters.Add("@Password", Password);
                    parameters.Add("@ReturnVal", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue); // Add the return value parameter

                    await connection.ExecuteAsync("[dbo].[pr_RegisterUser]", param: parameters, commandType: CommandType.StoredProcedure);

                    int returnValue = parameters.Get<int>("@ReturnVal");

                    return returnValue;
                }
            }
            catch (SqlException sqlEx)
            {
                Log.Error($"SQL Error: {sqlEx.Message}");
                throw new Exception("An error occurred while processing your request. Please try again later.");
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw; // Rethrow the original exception for other unexpected errors
            }

        }

        public virtual async Task<int> pr_UpdateTaskAsync(string Title, string Description, int? Assignee, DateTime? DueDate)
        {
            try
            {
                using (var connection = _connectionManager.DefaultConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@Title", Title);
                    parameters.Add("@Description", Description);
                    parameters.Add("@Assignee", Assignee);
                    parameters.Add("@DueDate", DueDate);
                    parameters.Add("@ReturnVal", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue); // Add the return value parameter

                    await connection.ExecuteAsync("[dbo].[pr_UpdateTask]", param: parameters, commandType: CommandType.StoredProcedure);

                    int returnValue = parameters.Get<int>("@ReturnVal");

                    return returnValue;
                }
            }
            catch (SqlException sqlEx)
            {
                Log.Error($"SQL Error: {sqlEx.Message}");
                throw new Exception("An error occurred while processing your request. Please try again later.");
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw; // Rethrow the original exception for other unexpected errors
            }

        }

        public virtual async Task<int> pr_UpdateUserAsync(string Username, string Email, string Password)
        {
            try
            {
                using (var connection = _connectionManager.DefaultConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@Username", Username);
                    parameters.Add("@Email", Email);
                    parameters.Add("@Password", Password);
                    parameters.Add("@ReturnVal", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue); // Add the return value parameter

                    await connection.ExecuteAsync("[dbo].[pr_UpdateUser]", param: parameters, commandType: CommandType.StoredProcedure);

                    int returnValue = parameters.Get<int>("@ReturnVal");

                    return returnValue;
                }
            }
            catch (SqlException sqlEx)
            {
                Log.Error($"SQL Error: {sqlEx.Message}");
                throw new Exception("An error occurred while processing your request. Please try again later.");
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw; // Rethrow the original exception for other unexpected errors
            }

        }
    }
}
