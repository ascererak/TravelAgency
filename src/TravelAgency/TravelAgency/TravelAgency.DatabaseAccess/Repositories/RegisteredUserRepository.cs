using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TravelAgency.DatabaseAccess.Enitities.Users;
using TravelAgency.DatabaseAccess.Interfaces;
using TravelAgency.Interfaces.DatabaseAccess.Repositories;
using TravelAgency.Interfaces.Dto;

namespace TravelAgency.DatabaseAccess.Repositories
{
    internal class RegisteredUserRepository : IRegisteredUserRepository
    {
        private readonly ITravelAgencyDbContext context;
        private readonly IApplicationUserRepository applicationUserRepository;

        public RegisteredUserRepository(ITravelAgencyDbContext context, IApplicationUserRepository applicationUserRepository)
        {
            this.context = context;
            this.applicationUserRepository = applicationUserRepository;
        }

        public async Task<RegisteredUserData> AddAsync(RegisteredUserData registeredUserData)
        {
            context.Database.OpenConnection();

            var creatingResult = await context.RegisteredUsers.AddAsync(Map(registeredUserData));
            context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.RegisteredUsers ON;");
            await context.SaveChangesAsync();
            context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.RegisteredUsers OFF");

            context.Database.CloseConnection();

            return Map(creatingResult.Entity);
        }

        public async Task<RegisteredUserData> FindByIdAsync(int id)
            => Map(await context.RegisteredUsers.FindAsync(id));

        public RegisteredUserData FindByUser(UserData userData)
        {
            var user = context.RegisteredUsers.FirstOrDefault((client) => client.UserId == userData.Id);

            return Map(user);
        }

        public async Task<bool> UpdateAsync(RegisteredUserData registeredUserData)
        {
            RegisteredUser client = await context.RegisteredUsers.FindAsync(registeredUserData.Id);

            context.RegisteredUsers.Update(client);
            await context.SaveChangesAsync();
            return true;
        }

        private RegisteredUserData Map(RegisteredUser client)
            => new RegisteredUserData
            {
                UserId = client.UserId
            };

        private RegisteredUser Map(RegisteredUserData client)
            => new RegisteredUser
            {
                UserId = client.UserId
            };
    }
}
