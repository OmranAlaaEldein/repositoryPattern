using Microsoft.AspNetCore.Mvc;
using repositoryPattern.Models;
using repositoryPattern.Repositories;
using repositoryPattern.Repositories.SchoolRepository;
using repositoryPattern.Repositories.StudentRepository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace repositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class testWarepperRepository : ControllerBase
    {
        //E
        private ISchoolRepository _schoolRepository;
        private IStudentRepository _studentRepository;
        private IUnitOfWork _unitOfWork;
        
        public testWarepperRepository(IUnitOfWork unitOfWor,ISchoolRepository schoolRepository, IStudentRepository studentRepository)
        {
            _schoolRepository = schoolRepository;
            _studentRepository = studentRepository;
            _unitOfWork = unitOfWor;
        }
       
        [HttpGet]
        public async Task<IEnumerable<School>> UnitAllItem()
        {
            return await _unitOfWork._schoolRepositoy.All();
        }

        // GET api/<testRepository>/5
        [HttpGet("{id}")]
        public async Task<School> UnitItem(int id)
        {
            return await _unitOfWork._schoolRepositoy.GetById(id);
        }


        // POST api/<testRepository>
        [HttpPost]
        public async Task UnitAdd([FromBody] School newEnttiy)
        {
            await _unitOfWork._schoolRepositoy.Add(newEnttiy);
            await _unitOfWork._schoolRepositoy.save();
        }


        [HttpPut("{id}")]
        public async Task UnitEdit(int id, [FromBody] School updateEnttiy)
        {
            await _unitOfWork._schoolRepositoy.Upsert(updateEnttiy, x => x.Id == id);
            await _unitOfWork._schoolRepositoy.save();
        }


        [HttpDelete("{id}")]
        public async Task<bool> UnitrRmove(int id)
        {
            await _unitOfWork._schoolRepositoy.Delete(id);
            await _unitOfWork._schoolRepositoy.save();
            return true;
        }
    }
}
