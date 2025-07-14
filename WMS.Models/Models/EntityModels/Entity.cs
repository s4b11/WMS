using System;

namespace WMS.Core.Models
{
    public abstract class Entity : EntityBase
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; } = false;

        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }


        int? _requestedHashCode;

        public bool IsTransient()
        {
            return this.Id == default;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity))
                return false;

            if (Object.ReferenceEquals(this, obj))
                return true;

            if (this.GetType() != obj.GetType())
                return false;

            Entity item = (Entity)obj;

            if (item.IsTransient() || this.IsTransient())
                return false;
            else
                return item.Id == this.Id;
        }

        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!_requestedHashCode.HasValue)
                    _requestedHashCode =
                    Id.GetHashCode() ^
                    31;

                return _requestedHashCode.Value;
            }
            else
                return base.GetHashCode();

        }

        public static bool operator ==(Entity left, Entity right)
        {
            if (Object.Equals(left, null))
                return (Object.Equals(right, null)) ? true : false;
            else
                return left.Equals(right);
        }

        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }
    }
}