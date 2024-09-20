using Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class UsersController : Controller
    {
        private readonly CreateUserUseCase _createUserUseCase;
        private readonly GetUsersUseCase _getUsersUseCase;
        private readonly UpdateUserUseCase _updateUserUseCase;
        private readonly DeleteUserUseCase _deleteUserUseCase;

        public UsersController(
            CreateUserUseCase createUserUseCase,
            GetUsersUseCase getUsersUseCase,
            UpdateUserUseCase updateUserUseCase,
            DeleteUserUseCase deleteUserUseCase)
        {
            _createUserUseCase = createUserUseCase;
            _getUsersUseCase = getUsersUseCase;
            _updateUserUseCase = updateUserUseCase;
            _deleteUserUseCase = deleteUserUseCase;
        }

        // GET: /Users
        public async Task<IActionResult> Index()
        {
            var users = await _getUsersUseCase.ExecuteAsync();
            return View(users);
        }

        // POST: /Users/Create
        [HttpPost]
        public async Task<IActionResult> Create(string name, string lastname, string dni)
        {
            await _createUserUseCase.ExecuteAsync(name, lastname, dni);
            return RedirectToAction(nameof(Index));
        }

        // POST: /Users/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(int id, string name, string lastname, string dni)
        {
            await _updateUserUseCase.ExecuteAsync(id, name, lastname, dni);
            return RedirectToAction(nameof(Index));
        }

        // POST: /Users/Delete
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _deleteUserUseCase.ExecuteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
