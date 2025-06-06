using DittoBox.API.ContainerManagement.Application.Commands;
using DittoBox.API.ContainerManagement.Interface.Resources;

namespace DittoBox.API.ContainerManagement.Application.Handlers.Interfaces
{
    public interface ICreateTemplateCommandHandler
    {
        public Task<TemplateResource> Handle(CreateTemplateCommand command);
    }
}