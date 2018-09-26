using MemBankCoreAngular.DAL.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using static MemBankCoreAngular.Global.Constants;
using MemBankCoreAngular.Models;

namespace MemBankCoreAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private TagRepository _repository;

        public TagController(TagRepository repository)
        {
            this._repository = repository;
        }

        //[HttpGet("[action]")]
        //public IEnumerable<Tag> GetForParentType (int parentTypeId)
        //{

        //}

        [HttpGet]
        public ActionResult<List<Tag>> GetAll()
        {
            return this._repository.GetAll().ToList();
        }

        [HttpGet("{id}", Name = "GetById")]
        public ActionResult<Tag> GetById(int id)
        {
            var data = this._repository.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            return data;
        }

        [HttpGet("GetTagCloudData/{parentTypeId}")]
        public ActionResult<List<TagCloudData>> GetTagCloudData(int parentTypeId)
        {
            var data = this._repository.GetTagCloudData(parentTypeId);
            if (data == null)
            {
                return NotFound();
            }
            return data.ToList();
        }
    }
}
