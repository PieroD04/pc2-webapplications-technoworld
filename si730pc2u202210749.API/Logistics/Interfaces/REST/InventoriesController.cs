using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using si730pc2u202210749.API.Logistics.Domain.Model.Commands;
using si730pc2u202210749.API.Logistics.Domain.Model.Queries;
using si730pc2u202210749.API.Logistics.Domain.Services;
using si730pc2u202210749.API.Logistics.Interfaces.REST.Resources;
using si730pc2u202210749.API.Logistics.Interfaces.REST.Transform;
using Swashbuckle.AspNetCore.Annotations;

namespace si730pc2u202210749.API.Logistics.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class InventoriesController(IInventoryQueryService inventoryQueryService, IInventoryCommandService inventoryCommandService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [SwaggerOperation(
        Summary = "Get all inventories.",
        Description = "Retrieves all inventories.",
        OperationId = "GetAllInventories",
        Tags = new[] { "Inventories" }
    )]
    public async Task<IActionResult> GetAllInventories()
    {
        var getAllInventoriesQuery = new GetAllInventoriesQuery();
        var inventories = await inventoryQueryService.Handle(getAllInventoriesQuery);
        var inventoryResources = inventories.Select(InventoryResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(inventoryResources);
    }
    
    [HttpGet("{inventoryId:int}")]
    [SwaggerOperation(
        Summary = "Get a inventory by its identifier.",
        Description = "Retrieves a inventory by its identifier.",
        OperationId = "GetInventoryById",
        Tags = new[] { "Inventories" }
    )]
    public async Task<IActionResult> GetInventoryById(int inventoryId)
    {
        var getInventoryByIdQuery = new GetInventoryByIdQuery(inventoryId);
        var inventory = await inventoryQueryService.Handle(getInventoryByIdQuery);
        if (inventory == null) return NotFound();
        var inventoryResource = InventoryResourceFromEntityAssembler.ToResourceFromEntity(inventory);
        return Ok(inventoryResource);
    }
    
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a inventory.",
        Description = "Creates a inventory.",
        OperationId = "CreateInventory",
        Tags = new[] { "Inventories" }
    )]
    public async Task<IActionResult> CreateInventory(CreateInventoryResource resource)
    {
        var createInventoryCommand = CreateInventoryCommandFromResourceAssembler.ToCommandFromResource(resource);
        var inventory = await inventoryCommandService.Handle(createInventoryCommand);
        if (inventory is null) return BadRequest();
        var inventoryResource = InventoryResourceFromEntityAssembler.ToResourceFromEntity(inventory);
        return CreatedAtAction(nameof(GetInventoryById), new { inventoryId = inventoryResource.Id }, inventoryResource);
    }
    
    [HttpPut("{inventoryId:int}")]
    [SwaggerOperation(
        Summary = "Update a inventory.",
        Description = "Updates a inventory by its identifier.",
        OperationId = "UpdateInventoryById",
        Tags = new[] { "Inventories" }
    )]
    public async Task<IActionResult> UpdateInventory(int inventoryId, UpdateInventoryResource resource)
    {
        var existingInventory = await inventoryQueryService.Handle(new GetInventoryByIdQuery(inventoryId));
        if (existingInventory is null) return NotFound();
        
        var updateInventoryCommand = UpdateInventoryCommandFromResourceAssembler.ToCommandFromResource(inventoryId, resource);
        var inventory = await inventoryCommandService.Handle(updateInventoryCommand);
        if (inventory is null) return NotFound();
        var inventoryResource = InventoryResourceFromEntityAssembler.ToResourceFromEntity(inventory);
        return Ok(inventoryResource);
    }
    
    [HttpDelete("{inventoryId:int}")]
    [SwaggerOperation(
        Summary = "Delete a inventory.",
        Description = "Deletes a inventory.",
        OperationId = "DeleteInventory",
        Tags = new[] { "Inventories" }
    )]
    public async Task<IActionResult> DeleteInventory(int inventoryId)
    {
        var deleteInventoryCommand = new DeleteInventoryCommand(inventoryId);
        var inventory = await inventoryCommandService.Handle(deleteInventoryCommand);
        if (inventory is null) return NotFound();
        var inventoryResource = InventoryResourceFromEntityAssembler.ToResourceFromEntity(inventory);
        return Ok(inventoryResource);
    }
    
}