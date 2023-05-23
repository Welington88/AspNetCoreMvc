using Microsoft.AspNetCore.Identity;

namespace AspNetMvcRoles.Models
{
	public class User : IdentityUser
    {
		public bool IsActive { get; set; }
	}
}

