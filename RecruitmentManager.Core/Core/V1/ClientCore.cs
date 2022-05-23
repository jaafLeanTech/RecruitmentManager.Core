using Microsoft.EntityFrameworkCore;
using RecruitmentManager.DataAccess.Context;
using RecruitmentManager.Entities.DTOs;
using RecruitmentManager.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentManager.Core.Core.V1
{
    public class ClientCore
    {

        private readonly SqlServerContext _context;
        
        public ClientCore()
        {
            _context = new SqlServerContext();
        }

        public async Task<List<Client>> GetClientAsync()
        {
            return await _context.Client.ToListAsync();
        }

        public async Task<Client> CreateClientAsync(ClientCreateDto client)
        {
            Client newClient = new();

            newClient.Name = client.Name;
            newClient.Address = client.Address;
            newClient.PhoneNumber = client.PhoneNumber;

            var newClientCreated = _context.Client.Add(newClient);

            await _context.SaveChangesAsync();

            return newClientCreated.Entity;
        }

        public async Task<bool> UpdateClientAsync(Client clientToUpdated)
        {
            Client client = _context.Client.Find(clientToUpdated.IdClient);

            client.Name = clientToUpdated.Name;
            client.Address = clientToUpdated.Address;
            client.PhoneNumber = clientToUpdated.PhoneNumber;

            var clientUpdated = _context.Client.Update(client);

            int recordsAffected = await _context.SaveChangesAsync();

            return (recordsAffected == 1);
        }
    }
}
