using Microsoft.EntityFrameworkCore;

namespace API_CRUD_User.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }

        public DbSet<UserViewModel> Users { get; set; }
    }
}
