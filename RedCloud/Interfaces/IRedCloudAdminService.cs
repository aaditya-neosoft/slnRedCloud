using RedCloud.Application.Features.RedCloudAdmins.Commands.CreateRedCloudAdmin;
using RedCloud.Domain.Entities;
using RedCloud.ViewModel;

namespace RedCloud.Interfaces
{
    public interface IRedCloudAdminService
    {

        Task<int> CreateAdminUser(RedCloudAdmin adminUser);
        Task EditAdminUser(RedCloudAdmin adminUser);

        Task<RedCloudAdminVM> GetAdminUserById(int Id);
        Task<IEnumerable<RedCloudAdminVM>> GetallRedCloudAdminUser();

        Task SoftDeleteRedCloudAdmin(int id);

        Task<RedCloudAdminVM> Block(int Id);
        Task<RedCloudAdminProfileVM> GetProfileById(int Id);
    }
}
