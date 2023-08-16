using System.Data.Entity.ModelConfiguration;

namespace rxApp.Domain.Entities
{
    public class GetLockSaldoCofreViewConfig : EntityTypeConfiguration<GetLockSaldoCofreView>
    {
        public GetLockSaldoCofreViewConfig()
        {
            // Primary Key
            this.HasKey(t => t.id);

            this.ToTable("saldo_cofre_view");
        }
    }
}