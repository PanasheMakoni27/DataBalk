using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBalk.Bo;

namespace DataBalk.Bl
{
    public interface IDataBalkDBProcedures
    {
        Task<int> pr_CreateTaskAsync(string Title, string Description, int? Assignee, DateTime? DueDate);
        Task<int> pr_DeleteTaskAsync(int? TaskID);
        Task<int> pr_DeleteUserAsync(int? UserID);
        Task<List<pr_GetActiveTaskResult>> pr_GetActiveTaskAsync();
        Task<List<pr_GetAllTasksResult>> pr_GetAllTasksAsync();
        Task<List<pr_GetAllUsersResult>> pr_GetAllUsersAsync();
        Task<List<pr_GetExpiredTaskResult>> pr_GetExpiredTaskAsync();
        Task<List<pr_GetTaskResult>> pr_GetTaskAsync(int? TaskID);
        Task<List<pr_GetTaskByDateResult>> pr_GetTaskByDateAsync(DateTime? Date);
        Task<List<pr_GetUserResult>> pr_GetUserAsync(int? UserID);
        Task<int> pr_RegisterUserAsync(string Username, string Email, string Password);
        Task<int> pr_UpdateTaskAsync(string Title, string Description, int? Assignee, DateTime? DueDate);
        Task<int> pr_UpdateUserAsync(string Username, string Email, string Password);

    }
}
