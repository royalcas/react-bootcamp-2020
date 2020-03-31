using HealthApi.Application.Models;
using HealthApp.Domain;
using HealthApp.Domain.Contracts;

namespace HealthApi.Application.Services
{
	public class UserProfileService: ApplicationRepositoryService<IUserProfileRepository, UserProfileModel, UserProfile>, IUserProfileService
	{
		public UserProfileService(IUserProfileRepository repository, IUnitOfWork unitOfWork)
			:base(repository, unitOfWork)
		{
		}
    }
}
