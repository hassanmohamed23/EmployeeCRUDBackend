using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.IServices;

namespace ASAPAssignmentAPI.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeService _employeeService;
        private readonly ResultViewModel Result;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
            Result = new ResultViewModel();
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ResultViewModel> GetAll()
        {
            Result.Data = await _employeeService.GetAllAsync();
            Result.IsSucess = true;
            return Result;
        }

        [Route("GetById/{employeeId}")]
        [HttpGet ]
        public async Task<ResultViewModel> GetById(int employeeId )
        {
            Result.Data = await _employeeService.GetByIdAsync(employeeId);
            Result.IsSucess = true;
            return Result;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ResultViewModel> Add(Employee employee)
        {
            Result.Data = await _employeeService.AddAsync(employee);
            Result.IsSucess = true;
            Result.Message = "Added employee successFully";
            return Result;
        }

        [HttpPost]
        [Route("Update")]
        public async Task<ResultViewModel> Update(Employee person)
        {
            Result.Data = await _employeeService.UpdateAsync(person);
            Result.IsSucess = true;
            Result.Message = "updated employee successFully";
            return Result;
        }

        [HttpDelete]
        [Route("Delete/{employeeId}")]
        public async Task<ResultViewModel> Delete(int employeeId)
        {
            Result.Data = await _employeeService.DeleteAsync(employeeId);
            Result.IsSucess = true;
            Result.Message = "Deleted employee successFully";

            return Result;

        }
    }
}
