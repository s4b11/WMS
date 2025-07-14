using System;
using WMS.Dtos;

namespace WMS.Dtos
{
    public abstract class EntityDto : EntityBaseDto
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}