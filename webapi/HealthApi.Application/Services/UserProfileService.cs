using HealthApp.Domain;
using HealthApp.Domain.Contracts;
using System;
using System.Collections.Generic;

namespace HealthApi.Application.Services
{
	public class UserProfileService: ApplicationRepositoryService<UserProfile>, IUserProfileService
	{
		public UserProfileService(IUserProfileRepository repository)
			:base(repository)
		{
		}
    }
}
