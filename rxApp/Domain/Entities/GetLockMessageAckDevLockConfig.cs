using System.Data.Entity.ModelConfiguration;

namespace rxApp.Domain.Entities
{
    public class GetLockMessageAckDevLockConfig: EntityTypeConfiguration<GetLockMessageAckDevLock>
    {
        public GetLockMessageAckDevLockConfig()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            this.ToTable("message_dev_lock");
        }
    }
}