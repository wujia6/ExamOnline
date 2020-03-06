using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExamUI.Controllers
{
    [Authorize(Roles = "admin")]
    public class PermssionController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Settings()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> AddAsync(PermissionDto model)
        {

        }
    }
}
