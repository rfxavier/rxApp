using System.Data.Entity.ModelConfiguration;

namespace rxApp.Domain.Entities
{
    public class GetLockSaldoCofreConfig : EntityTypeConfiguration<GetLockSaldoCofre>
    {
        public GetLockSaldoCofreConfig()
        {
            // Primary Key
            this.HasKey(t => t.id);

            this.ToTable("saldo_cofre_snapshot");
        }
    }
}