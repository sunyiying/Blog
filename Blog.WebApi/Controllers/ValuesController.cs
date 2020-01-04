using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Application.Interfaces;
using Blog.Application.ViewModel;
using Blog.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Blog.WebApi.Controllers
{
    /// <summary>
    /// ValuesController 测试
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IMemoryCache _cache;
        private readonly IStudentService _studentService;
        public ValuesController(IMemoryCache cache, IStudentService studentService)
        {
            this._cache = cache;
            this._studentService = studentService;
        }

        /// <summary>
        /// GET api/values
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }


        /// <summary>
        /// 根据ID 查询元素 GET api/values/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var a = HttpContext.User.Identity.IsAuthenticated;
            return "value";
        }

        //// POST api/values
        ///// <summary>
        ///// 创建元素
        ///// </summary>
        ///// <param name="value"></param>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        /// <summary>
        /// 创建元素 AddressViewModel
        /// </summary>
        /// <param name="addressView"></param>
        [HttpPost("Address")]
        public void Post(AddressViewModel addressView)
        {
        }

        /// <summary>
        /// 创建元素 StudentViewModel
        /// </summary>
        /// <param name="studentView"></param>
        [HttpPost("Student")]
        public async Task<IActionResult> Post(StudentViewModel studentView)
        {
            var res = await Task.Run(() => { return "ok111111111"; });
            return Ok(Task.FromResult(res).Result.ToString());
        }


        /// <summary>
        /// 根据Id 修改元素属性 // PUT api/values/5
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpPost("Regist")]
        public async Task<IActionResult> RegisterStudentAsync(StudentViewModel studentView)
        {
            this._studentService.Register(studentView);
            // 获取到缓存中的错误信息
            var errorData = _cache.Get("ErrorData");
            var notificacoes = await Task.Run(() => (List<string>)errorData);
            List<string> message = new List<string>();
            // 遍历添加到ViewData.ModelState 中
            notificacoes?.ForEach(c => message.Add(c));
            if (message != null && message.Count > 0)
                return Ok(message);
            else
                return Ok("success");
        }


    }
}
