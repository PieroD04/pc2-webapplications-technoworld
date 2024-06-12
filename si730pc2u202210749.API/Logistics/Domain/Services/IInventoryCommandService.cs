using si730pc2u202210749.API.Logistics.Domain.Model.Aggregates;
using si730pc2u202210749.API.Logistics.Domain.Model.Commands;

namespace si730pc2u202210749.API.Logistics.Domain.Services;

public interface IInventoryCommandService
{
    Task<Inventory?> Handle(CreateInventoryCommand createTemplateCommand);
    Task<Inventory?> Handle(UpdateInventoryCommand updateTemplateCommand);
    Task<Inventory?> Handle(DeleteInventoryCommand deleteTemplateCommand);
}