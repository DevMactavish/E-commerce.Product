using Ecommerce.Product.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Ecommerce.Product.Domain.Extension;

public static class ChangeTrackerExtension
{
    public static void SetAuditProperties(this ChangeTracker changeTracker)
    {
        changeTracker.DetectChanges();
        var entities =changeTracker
            .Entries()
            .Where(t => t is { Entity: Entity, State: EntityState.Deleted });
        if(!entities.Any())
            return;
        foreach(var entry in entities)
        {
            var entity = (Entity)entry.Entity;
            entity.IsDeleted = true;
            entry.State = EntityState.Modified;
        }
    }
}