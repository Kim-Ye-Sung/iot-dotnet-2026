using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace BookRentalShopApi.Models;

public partial class BookRentalShopContext : DbContext
{
    public BookRentalShopContext()
    {
    }

    public BookRentalShopContext(DbContextOptions<BookRentalShopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Division> Divisions { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<Rental> Rentals { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseMySql("server=localhost;port=3306;database=bookrentalshop;user=root;password=my123456", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.45-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.BookIdx).HasName("PRIMARY");

            entity.ToTable("books");

            entity.HasIndex(e => e.DivCode, "fk_books_division_idx");

            entity.Property(e => e.BookIdx).HasColumnName("book_idx");
            entity.Property(e => e.Author)
                .HasMaxLength(45)
                .HasColumnName("author");
            entity.Property(e => e.BookName)
                .HasMaxLength(100)
                .HasColumnName("book_name");
            entity.Property(e => e.DivCode)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("div_code");
            entity.Property(e => e.Isbn)
                .HasMaxLength(200)
                .HasColumnName("isbn");
            entity.Property(e => e.Price)
                .HasPrecision(10)
                .HasColumnName("price");
            entity.Property(e => e.ReleaseDt).HasColumnName("release_dt");

            entity.HasOne(d => d.DivCodeNavigation).WithMany(p => p.Books)
                .HasForeignKey(d => d.DivCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_books_division");
        });

        modelBuilder.Entity<Division>(entity =>
        {
            entity.HasKey(e => e.DivCode).HasName("PRIMARY");

            entity.ToTable("division");

            entity.Property(e => e.DivCode)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("div_code");
            entity.Property(e => e.DivName)
                .HasMaxLength(45)
                .HasColumnName("div_name");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.MemberIdx).HasName("PRIMARY");

            entity.ToTable("members");

            entity.Property(e => e.MemberIdx).HasColumnName("member_idx");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Levels)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("levels");
            entity.Property(e => e.MemberName)
                .HasMaxLength(45)
                .HasColumnName("member_name");
            entity.Property(e => e.Mobile)
                .HasMaxLength(13)
                .HasColumnName("mobile");
        });

        modelBuilder.Entity<Rental>(entity =>
        {
            entity.HasKey(e => e.RentalIdx).HasName("PRIMARY");

            entity.ToTable("rentals");

            entity.HasIndex(e => e.BookIdx, "fk_rentals_books1_idx");

            entity.HasIndex(e => e.MemberIdx, "fk_rentals_members1_idx");

            entity.Property(e => e.RentalIdx).HasColumnName("rental_idx");
            entity.Property(e => e.BookIdx).HasColumnName("book_idx");
            entity.Property(e => e.MemberIdx).HasColumnName("member_idx");
            entity.Property(e => e.RentalDate).HasColumnName("rentalDate");
            entity.Property(e => e.ReturnDate).HasColumnName("returnDate");

            entity.HasOne(d => d.BookIdxNavigation).WithMany(p => p.Rentals)
                .HasForeignKey(d => d.BookIdx)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_rentals_books1");

            entity.HasOne(d => d.MemberIdxNavigation).WithMany(p => p.Rentals)
                .HasForeignKey(d => d.MemberIdx)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_rentals_members1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
