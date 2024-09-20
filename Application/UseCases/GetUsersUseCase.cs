using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class GetUsersUseCase
    {
        private readonly ApplicationDbContext _context;

        public GetUsersUseCase(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> ExecuteAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
