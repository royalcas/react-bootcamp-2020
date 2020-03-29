using HealthApp.Domain;
using HealthApp.Domain.Contracts;
using System;
using System.Collections.Generic;

namespace HealthApi.Application.Services
{
	public class UserProfileService: ApplicationRepositoryService<IUserProfileRepository, UserProfile>, IUserProfileService
	{
		public UserProfileService(IUserProfileRepository repository, IUnitOfWork unitOfWork)
			:base(repository, unitOfWork)
		{
		}
    }
}
