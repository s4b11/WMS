using System;
using WMS.Core.Models;

namespace WMS.Models
{
    public abstract class EntityGuid : Entity
    {
        public Guid UniqueGuId { get; set; }
    }
}