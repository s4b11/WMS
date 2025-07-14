using System;
using WMS.Dtos;

namespace WMS.Dtos
{
    public abstract class EntityGuidDto : EntityDto
    {
        public Guid UniqueGuId { get; set; }
    }
}