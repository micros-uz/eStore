using System.Collections.Generic;
namespace eStore.Domain
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public ICollection<Role> Roles { get; set; }
    }
}
