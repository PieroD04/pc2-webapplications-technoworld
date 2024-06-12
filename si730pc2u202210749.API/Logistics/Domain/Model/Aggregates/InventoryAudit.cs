using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace si730pc2u202210749.API.Logistics.Domain.Model.Aggregates;
/// <summary>
/// Has CreatedDate and UpdatedDate properties to be used by Entity Framework Core
/// and be able to automatically set the values when the entity is created or updated.
/// </summary>
public partial class Inventory: IEntityWithCreatedUpdatedDate
{
    [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }
    [Column("UpdatedAt")] public DateTimeOffset? UpdatedDate { get; set; }
}