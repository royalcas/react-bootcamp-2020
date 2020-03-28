using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HealthApp.Domain;
using HealthApp.Domain.Contracts;

namespace HealthApi.Persistence.Repository
{
	public class UserProfileRepository : Repository<UserProfile>, IUserProfileRepository
	{
		public UserProfileRepository(HealthAppContext context)
			:base(context)
		{
		}
	}
}
