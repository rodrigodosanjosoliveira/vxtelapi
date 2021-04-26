using System;

using static System.DateTime;
using static System.Guid;

namespace VxTel.Domain.Entities
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = NewGuid();
            DateCreated = Now;
        }
        public Guid Id { get; private set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}