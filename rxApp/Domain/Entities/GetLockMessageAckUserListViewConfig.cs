using System.Data.Entity.ModelConfiguration;

namespace rxApp.Domain.Entities
{
    public class GetLockMessageAckUserListViewConfig : EntityTypeConfiguration<GetLockMessageAckUserListView>
    {
        public GetLockMessageAckUserListViewConfig()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            this.ToTable("message_get_userlist_view");
        }
    }
}