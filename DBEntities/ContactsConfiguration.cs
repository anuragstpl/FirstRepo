using ContactsApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsApi.DBEntities
{
    public class ContactsConfiguration : IEntityTypeConfiguration<Contacts>
    {
        public void Configure(EntityTypeBuilder<Contacts> builder)
        {
            builder.ToTable("Contacts", "DotNetCoreDB");
            builder.HasKey(p => p.ID);

            builder.Property(p => p.FirstName).HasColumnType("nvarchar(200)").IsRequired();
            builder.Property(p => p.Username).HasColumnType("nvarchar(200)").IsRequired();
            builder.Property(p => p.Password).HasColumnType("nvarchar(200)").IsRequired();
            builder.Property(p => p.AnniversaryDate).HasColumnType("datetime2").IsRequired();
            builder.Property(p => p.Company).HasColumnType("nvarchar(200)").IsRequired();
            builder.Property(p => p.DateOfBirth).HasColumnType("datetime2").IsRequired();
            builder.Property(p => p.Email).HasColumnType("nvarchar(200)").IsRequired();
            builder.Property(p => p.IsFamilyMember).HasColumnType("bit").IsRequired();
            builder.Property(p => p.JobTitle).HasColumnType("nvarchar(200)").IsRequired();
            builder.Property(p => p.LastName).HasColumnType("nvarchar(200)").IsRequired();
            builder.Property(p => p.MobilePhone).HasColumnType("nvarchar(200)").IsRequired();
        }
    }
}
