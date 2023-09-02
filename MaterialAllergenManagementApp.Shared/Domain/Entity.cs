using System;
using System.ComponentModel.DataAnnotations;

namespace MaterialAllergenManagementApp.Shared.Domain;

public class Entity
{
    [Key] public string Id { get; set; }
    public DateTime CreatedOn { get; set; }

    public Entity() : this(Guid.NewGuid().ToString(), DateTime.UtcNow) { }

    private Entity(string id, DateTime createdOn)
    {
        Id = id;
        CreatedOn = createdOn;
    }
}
