using System.Data.Entity.ModelConfiguration;

namespace rxApp.Domain.Entities
{
    public class GetLockMessageAckGetStatusConfig: EntityTypeConfiguration<GetLockMessageAckGetStatus>
    {
        public GetLockMessageAckGetStatusConfig()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            this.ToTable("message_get_status");
        }
    }
}