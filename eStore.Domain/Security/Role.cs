using System.Collections.Generic;

namespace eStore.Domain.Security
{
    public class Role
    {
        public Role()
        {
            Members = new List<User>();
        }
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public ICollection<User> Members { get; set; }
    }
}
