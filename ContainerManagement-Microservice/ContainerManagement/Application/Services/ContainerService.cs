using DittoBox.API.ContainerManagement.Domain.Models.Entities;
using DittoBox.API.ContainerManagement.Domain.Repositories;
using DittoBox.API.ContainerManagement.Domain.Services.Application;
using DittoBox.API.Shared.Domain.Repositories;

namespace DittoBox.API.ContainerManagement.Application.Services
{
	public class ContainerService(
		IContainerRepository containerRepository,
		IUnitOfWork unitOfWork
	) : IContainerService
	{
		public async Task<Container> CreateContainer(string uiid, string name, string description, int accountId, int groupId)
		{
			var container = await containerRepository.GetContainerByUuid(uiid) ?? throw new Exception("Container hasn't been self registered yet. Make sure to turn it on first.");

			container.Name = name;
			container.Description = description;
			container.AccountId = accountId;
			container.GroupId = groupId;

			await containerRepository.Update(container);
			await unitOfWork.CompleteAsync();
			return container;
		}
		public async Task<Container?> GetContainerById(int id)
		{
			return await containerRepository.GetById(id);
		}

		public async Task<IEnumerable<Container>> GetContainersByGroupId(int groupId)
		{
			return await containerRepository.GetContainersByGroupId(groupId);
		}

		public async Task<IEnumerable<Container>> GetContainers()
		{
			return await containerRepository.GetAll();
		}

		public async Task UpdateContainer(Container container)
		{
			await containerRepository.Update(container);
			await unitOfWork.CompleteAsync();
		}

		public Task<IEnumerable<Container>> GetContainersByAccountId(int accountId)
		{
			return containerRepository.GetContainersByAccountId(accountId);
		}

		public async Task<Container> RegisterContainer(string uuid)
		{
			var container = new Container() { Uiid = uuid };
			await containerRepository.Add(container);
			return container;
		}

		public async Task<Container?> GetContainerByUuid(string uuid)
		{
			return await containerRepository.GetContainerByUuid(uuid);
		}
	}
}
