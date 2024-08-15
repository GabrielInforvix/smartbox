using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartBox.Model;

namespace smartbox.DB.Map
{
    public class BoxesMap : IEntityTypeConfiguration<BoxesModel>
    {
        public void Configure(EntityTypeBuilder<BoxesModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.external_id).IsRequired();
            builder.Property(x => x.created_at).IsRequired();
            builder.Property(x => x.updated_at);
        }
    }
}
