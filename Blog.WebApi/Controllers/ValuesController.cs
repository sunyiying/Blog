using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Application.ViewModel;
using Blog.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebApi.Controllers
{
    /// <summary>
    /// ValuesController 测试
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

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
        public void Post(StudentViewModel studentView)
        {
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


        /// <summary>
        /// 根据ID删除元素  // DELETE api/values/5
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
