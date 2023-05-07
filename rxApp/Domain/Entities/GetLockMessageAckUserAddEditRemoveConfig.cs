using System.Data.Entity.ModelConfiguration;

namespace rxApp.Domain.Entities
{
    public class GetLockMessageAckUserAddEditRemoveConfig : EntityTypeConfiguration<GetLockMessageAckUserAddEditRemove>
    {
        public GetLockMessageAckUserAddEditRemoveConfig()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            this.ToTable("message_user_add_edit_remove");
        }
    }
}