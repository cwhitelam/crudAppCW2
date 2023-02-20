// using crudApp.Data;
// using crudApp.Models;
// using Microsoft.EntityFrameworkCore;
//
//
// namespace crudApp.Services
// {
//     public class UserService  
//     {
//         private readonly AppDbContext _context;
//
//         public UserService(AppDbContext context)
//         {
//             _context = context;
//         }
//
//         public async Task<List<User>?> GetUsersAsync()
//         {
//             return await _context.Users.ToListAsync();
//         }
//
//         public async Task<User?> GetUserAsync(int id)
//         {
//             return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
//         }
//
//         public async Task AddUserAsync(User? user)
//         {
//             _context.Users.Add(user);
//             await _context.SaveChangesAsync();
//         }
//
//         public async Task UpdateUserAsync(User user)
//         {
//             _context.Entry(user).State = EntityState.Modified;
//             await _context.SaveChangesAsync();
//         }
//
//         public async Task DeleteUserAsync(int id)
//         {
//             var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
//             _context.Users.Remove(user);
//             await _context.SaveChangesAsync();
//         }
//     }
// }