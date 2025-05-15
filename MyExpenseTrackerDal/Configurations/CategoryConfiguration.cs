using Microsoft.EntityFrameworkCore;
using MyExpenseTrackerEntity.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyExpenseTrackerDal.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Type)
                .IsRequired();

            builder.HasMany(x => x.Transactions)
                .WithOne(t => t.Category)
                .HasForeignKey(t => t.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);













        }

       


    }
}
