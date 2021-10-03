using System;
using System.Diagnostics.CodeAnalysis;

namespace Todo.Domain.Entities
{
    public abstract class Entity
    {
        public string Id { get; set; }

        [ExcludeFromCodeCoverage]
        protected Entity()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}