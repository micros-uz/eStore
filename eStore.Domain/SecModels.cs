using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eStore.Domain
{
    public class Membership
    {
        public Membership()
        {
            Roles = new List<Role>();
            OAuthMemberships = new List<OAuthMembership>();
        }

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

        public ICollection<Role> Roles { get; set; }

        //[ForeignKey("UserId")]
        public ICollection<OAuthMembership> OAuthMemberships { get; set; }
    }

    //[Table("webpages_OAuthMembership")]
    public class OAuthMembership
    {
        //[Key, Column(Order = 0), StringLength(30)]
        public string Provider { get; set; }

        //[Key, Column(Order = 1), StringLength(100)]
        public string ProviderUserId { get; set; }

        public int UserId { get; set; }

        //[Column("UserId"), InverseProperty("OAuthMemberships")]
        public Membership User { get; set; }
    }

    //[Table("webpages_Roles")]
    public class Role
    {
        public Role()
        {
            Members = new List<Membership>();
        }

        //[Key]
        public int RoleId { get; set; }
        //[StringLength(256)]
        public string Name { get; set; }

        public string Desc{ get; set; }

        public ICollection<Membership> Members { get; set; }
    }
     
}
