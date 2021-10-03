using System;

namespace Todo.Domain.Entities
{
    public abstract class Entity
    {
        public string Id { get; set; }

        protected Entity()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}