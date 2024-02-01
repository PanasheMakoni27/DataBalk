using System.Threading.Tasks;
using System;
using log4net;
using Microsoft.AspNetCore.Mvc;
using DataBalk.Bl;

namespace DataBalk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TaskController : ControllerBase
    {
        private readonly IDataBalkDBProcedures _DataBalkDataAccess;
        //Logs controller
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public TaskController(IDataBalkDBProcedures dataBalkDataAccess)
        {
            _DataBalkDataAccess = dataBalkDataAccess;
        }
        /// <summary>
        /// Get all active tasks
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetActiveTask")]
        public async Task<IActionResult> GetActiveTasks()
        {
            try
            {
                var result = await _DataBalkDataAccess.pr_GetActiveTaskAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }
        /// <summary>
        /// Get all tasks
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllTasks")]
        public async Task<IActionResult> GetAllTasks()
        {
            try
            {
                var result = await _DataBalkDataAccess.pr_GetAllTasksAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }
        /// <summary>
        /// Get expired tasks
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetExpiredTask")]
        public async Task<IActionResult> GetExpiredTasks()
        {
            try
            {
                var result = await _DataBalkDataAccess.pr_GetExpiredTaskAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }
        /// <summary>
        /// Get specific task tasks
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetSpecificTask")]
        public async Task<IActionResult> GetSpecificTask(int TaskID)
        {
            try
            {
                var result = await _DataBalkDataAccess.pr_GetTaskAsync(TaskID);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }
        /// <summary>
        /// Get tasks by date
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetTaskByDate")]
        public async Task<IActionResult> GetTaskByDate(DateTime? Date)
        {
            try
            {
                var result = await _DataBalkDataAccess.pr_GetTaskByDateAsync(Date);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }
        /// <summary>
        /// Update task
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateTask")]
        public async Task<IActionResult> UpdateTask(string Title, string Description, int? Assignee, DateTime? DueDate)
        {
            try
            {
                var result = await _DataBalkDataAccess.pr_UpdateTaskAsync(Title,Description,Assignee,DueDate);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }
        /// <summary>
        /// Create task
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateTask")]
        public async Task<IActionResult> CreateTask(string Title, string Description, int? Assignee, DateTime? DueDate)
        {
            try
            {
                var result = await _DataBalkDataAccess.pr_CreateTaskAsync(Title, Description, Assignee, DueDate);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }
        /// <summary>
        /// Delete task
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteTask")]
        public async Task<IActionResult> DeleteTask(int TaskID)
        {
            try
            {
                var result = await _DataBalkDataAccess.pr_DeleteTaskAsync(TaskID);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }
    }
}


