using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataTransferObjects
{
    public class UserRoleUpdateDto
    {
        public string UserId { get; set; }
        public string UserEmail { get; set; }
        public IList<IdentityRole> AllRoles { get; set; }
        public IList<string> UserRoles { get; set; }
        public UserRoleUpdateDto()
        {
            AllRoles = new List<IdentityRole>();
            UserRoles = new List<string>();
        }
    }
}
