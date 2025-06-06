using DittoBox.API.ContainerManagement.Domain.Models.Entities;

namespace DittoBox.API.ContainerManagement.Domain.Services.Application
{
    public interface IContainerService
    {
		public Task<Container> RegisterContainer(string uuid);
        public Task<Container> CreateContainer(string uiid, string name, string description, int accountId, int groupId);
        public Task<Container?> GetContainerById(int id);
        public Task UpdateContainer(Container container);
		public Task<IEnumerable<Container>> GetContainers();
        public Task<IEnumerable<Container>> GetContainersByGroupId(int groupId);

        public Task<IEnumerable<Container>> GetContainersByAccountId(int accountId);
		public Task<Container?> GetContainerByUuid(string uuid);
    }
}
