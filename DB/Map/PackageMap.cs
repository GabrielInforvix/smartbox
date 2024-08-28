using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartBox.Model;

namespace smartbox.DB.Map
{
    public class PackageMap : IEntityTypeConfiguration<PackageModel>
    {
        public void Configure(EntityTypeBuilder<PackageModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.custumerId).IsRequired();
            builder.Property(x => x.delivered_at).IsRequired();
            builder.Property(x => x.picked_up_at).IsRequired();
            builder.Property(x => x.state).IsRequired();
            builder.Property(x => x.created_at).IsRequired();
            builder.Property(x => x.updated_at);
        }
    }
}
