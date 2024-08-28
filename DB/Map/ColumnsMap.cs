using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartBox.Model;

namespace smartbox.DB.Map
{
    public class ColumnsMap : IEntityTypeConfiguration<ColumnsModel>
    {
        public void Configure(EntityTypeBuilder<ColumnsModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.boxesId).IsRequired();
            builder.Property(x => x.pos).IsRequired().HasMaxLength(15);
            builder.Property(x => x.created_at).IsRequired();
            builder.Property(x => x.updated_at);
        }
    }
}
