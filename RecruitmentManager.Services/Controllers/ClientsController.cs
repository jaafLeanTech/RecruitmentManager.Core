using Microsoft.AspNetCore.Mvc;
using RecruitmentManager.Core.Core.V1;
using RecruitmentManager.Entities.DTOs;
using RecruitmentManager.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecruitmentManager.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ClientCore _clientCore;
        
        public ClientController()
        {
            _clientCore = new ClientCore();
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IEnumerable<Client>> Get()
        {
            
            return await _clientCore.GetClientAsync();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<Client> Post([FromBody] ClientCreateDto client)
        {
            return await _clientCore.CreateClientAsync(client);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<bool> Put([FromBody] Client client)
        {
            return await _clientCore.UpdateClientAsync(client);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
