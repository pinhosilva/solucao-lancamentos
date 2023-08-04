using System;

namespace Infrastructure.Core
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public Guid EntityId { get; set; }
    }
}