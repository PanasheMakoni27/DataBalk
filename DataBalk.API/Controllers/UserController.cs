using System.Threading.Tasks;
using System;
using log4net;
using Microsoft.AspNetCore.Mvc;
using DataBalk.Bl;

namespace DataBalk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IDataBalkDBProcedures _DataBalkDataAccess;
        //Logs controller
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public UserController (IDataBalkDBProcedures dataBalkDataAccess)
        {
            _DataBalkDataAccess = dataBalkDataAccess;
        }
        /// <summary>
        /// Get all of the users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var result = await _DataBalkDataAccess.pr_GetAllUsersAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }
        /// <summary>
        /// Delete user
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteUser")]
        public async Task<IActionResult> DeleteUser(int UserID)
        {
            try
            {
                var result = await _DataBalkDataAccess.pr_DeleteUserAsync(UserID);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }
        /// <summary>
        /// Get user
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetUser")]
        public async Task<IActionResult> GetUser(int UserID)
        {
            try
            {
                var result = await _DataBalkDataAccess.pr_GetUserAsync(UserID);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }
        /// <summary>
        /// Register user
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("RegisterUser")]
        public async Task<IActionResult> RegisterUser(string Username, string Email, string Password)
        {
            try
            {
                var result = await _DataBalkDataAccess.pr_RegisterUserAsync(Username,Email,Password);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }
        /// <summary>
        /// Update user
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser(string Username, string Email, string Password)
        {
            try
            {
                var result = await _DataBalkDataAccess.pr_UpdateUserAsync(Username, Email, Password);
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

