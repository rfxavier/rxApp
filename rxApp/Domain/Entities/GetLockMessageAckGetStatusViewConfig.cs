using System.Data.Entity.ModelConfiguration;

namespace rxApp.Domain.Entities
{
    public class GetLockMessageAckGetStatusViewConfig : EntityTypeConfiguration<GetLockMessageAckGetStatusView>
    {
        public GetLockMessageAckGetStatusViewConfig()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            this.ToTable("message_get_status_view");
        }
    }
}