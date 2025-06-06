using DittoBox.API.ContainerManagement.Domain.Models.Entities;
using DittoBox.API.Shared.Domain.Repositories;

namespace DittoBox.API.ContainerManagement.Domain.Repositories
{
    public interface IContainerRepository : IBaseRepository<Container>
    {
        public Task<IEnumerable<Container>> GetContainersByGroupId(int groupId);
        public Task<IEnumerable<Container>> GetContainersByAccountId(int accountId);
		public Task<Container?> GetContainerByUuid(string uuid);
    }
}
