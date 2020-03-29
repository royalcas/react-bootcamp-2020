using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace HealthApi.Identity
{
	public interface IIdentityUserProvider
	{
		string Id { get; }
		string Name { get; }
		string Email { get; }

		IEnumerable<Claim> GetClaimsIdentity();
		bool IsAuthenticated();
	}
}