using Domain.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class CreateUserUseCase
    {
        private readonly ApplicationDbContext _context;

        public CreateUserUseCase(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> ExecuteAsync(string name, string lastname, string dni)
        {
            var user = new User
            {
                Name = name,
                Lastname = lastname,
                Dni = dni
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }
}
