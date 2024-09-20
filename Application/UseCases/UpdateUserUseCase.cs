using Domain.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class UpdateUserUseCase
    {
        private readonly ApplicationDbContext _context;

        public UpdateUserUseCase(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> ExecuteAsync(int id, string name, string lastname, string dni)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return null;

            user.Name = name;
            user.Lastname = lastname;
            user.Dni = dni;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }
}
