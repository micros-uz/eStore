using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eStore.Domain
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
    public class Membership
    {
        public int UserId { get; set; }
        public DateTime? CreateDate { get; set; }
        public string ConfirmationToken { get; set; }
        public bool? IsConfirmed { get; set; }
        public DateTime? LastPasswordFailureDate { get; set; }
        public int PasswordFailuresSinceLastSuccess { get; set; }
        public string Password { get; set; }
        public DateTime? PasswordChangedDate { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordVerificationToken { get; set; }
        public DateTime? PasswordVerificationTokenExpirationDate { get; set; }
    }

    public class OAuthMembership
    {
        public string Provider { get; set; }
        public string ProviderUserId { get; set; }
        public int UserId { get; set; }

    }
    public class Role
    {
        public Role()
        {
            Members = new List<User>();
        }
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Desc{ get; set; }
        public ICollection<User> Members { get; set; }
    }
     
}
