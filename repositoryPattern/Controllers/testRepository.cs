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
    public class testRepository : ControllerBase
    {
        //E
        private ISchoolRepository _schoolRepository;
        private IStudentRepository _studentRepository;
        private IUnitOfWork _unitOfWork;
        
        public testRepository(IUnitOfWork unitOfWor,ISchoolRepository schoolRepository, IStudentRepository studentRepository)
        {
            _schoolRepository = schoolRepository;
            _studentRepository = studentRepository;
            _unitOfWork = unitOfWor;
        }

        //GET: api/<testRepository>
        [HttpGet]
        public async Task<IEnumerable<School>> Get()
        {
            return await _schoolRepository.All();
        }


        //GET api/<testRepository>/5
        [HttpGet("{id}")]
        public async Task<School> Get(int id)
        {
            return await _schoolRepository.GetById(id);
        }


        //POST api/<testRepository>
        [HttpPost]
        public async Task Post([FromBody] School newEnttiy)
        {
            await _schoolRepository.Add(newEnttiy);
            await _schoolRepository.save();
        }


        //PUT api/<testRepository>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] School updateEnttiy)
        {
            await _schoolRepository.Upsert(updateEnttiy, x => x.Id == id);
            await _schoolRepository.save();
        }


        //DELETE api/<testRepository>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            await _schoolRepository.Delete(id);
            await _schoolRepository.save();
            return true;
        }

    }
}
