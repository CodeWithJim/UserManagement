using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class DeleteUserUseCase
    {
        private readonly ApplicationDbContext _context;

        public DeleteUserUseCase(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ExecuteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
