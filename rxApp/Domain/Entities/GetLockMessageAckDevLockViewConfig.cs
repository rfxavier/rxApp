using System.Data.Entity.ModelConfiguration;

namespace rxApp.Domain.Entities
{
    public class GetLockMessageAckDevLockViewConfig : EntityTypeConfiguration<GetLockMessageAckDevLockView>
    {
        public GetLockMessageAckDevLockViewConfig()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            this.ToTable("message_dev_lock_view");
        }
    }
}