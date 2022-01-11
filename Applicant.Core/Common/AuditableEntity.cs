using System;

namespace Applicant.Core.Common
{
    public abstract class AuditableEntity<T>
    {
        public T Id { get; set; }
        public DateTime? Created { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public Guid? LastModifiedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
