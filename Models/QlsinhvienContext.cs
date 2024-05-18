using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QuanLiSinhVien.Models;

public partial class QlsinhvienContext : DbContext
{
    public QlsinhvienContext()
    {
    }

    public QlsinhvienContext(DbContextOptions<QlsinhvienContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Giangvien> Giangviens { get; set; }

    public virtual DbSet<Khoa> Khoas { get; set; }

    public virtual DbSet<Lhp> Lhps { get; set; }

    public virtual DbSet<Lsh> Lshes { get; set; }

    public virtual DbSet<Sinhvien> Sinhviens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-8E8BNI1;Initial Catalog=QLSINHVIEN;User ID=sa;Password=123456789;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Giangvien>(entity =>
        {
            entity.HasKey(e => e.MaGv).HasName("PK__GIANGVIE__7A3E2D751923F061");

            entity.ToTable("GIANGVIEN", tb => tb.HasTrigger("trg_GiangVien_Insert"));

            entity.Property(e => e.MaGv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("maGV");
            entity.Property(e => e.Cccd)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cccd");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Hocvi)
                .HasMaxLength(50)
                .HasColumnName("hocvi");
            entity.Property(e => e.MaKhoa)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("maKhoa");
            entity.Property(e => e.Ngaysinh)
                .HasColumnType("datetime")
                .HasColumnName("ngaysinh");
            entity.Property(e => e.Sdt)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sdt");
            entity.Property(e => e.TenGv)
                .HasMaxLength(50)
                .HasColumnName("tenGV");

            entity.HasOne(d => d.MaKhoaNavigation).WithMany(p => p.Giangviens)
                .HasForeignKey(d => d.MaKhoa)
                .HasConstraintName("FK_GIANGVIEN_KHOA");
        });

        modelBuilder.Entity<Khoa>(entity =>
        {
            entity.HasKey(e => e.MaKhoa).HasName("PK__KHOA__C79B8C226816F4F9");

            entity.ToTable("KHOA");

            entity.Property(e => e.MaKhoa)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("maKhoa");
            entity.Property(e => e.TenKhoa)
                .HasMaxLength(50)
                .HasColumnName("tenKhoa");
        });

        modelBuilder.Entity<Lhp>(entity =>
        {
            entity.HasKey(e => e.MaLhp).HasName("PK__LHP__2620199485618322");

            entity.ToTable("LHP");

            entity.Property(e => e.MaLhp)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("maLHP");
            entity.Property(e => e.DenTiet).HasColumnName("denTiet");
            entity.Property(e => e.MaGv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("maGV");
            entity.Property(e => e.SoTc).HasColumnName("soTC");
            entity.Property(e => e.Soluong).HasColumnName("soluong");
            entity.Property(e => e.Soluongdk).HasColumnName("soluongdk");
            entity.Property(e => e.TenLhp)
                .HasMaxLength(50)
                .HasColumnName("tenLHP");
            entity.Property(e => e.Thu).HasColumnName("thu");
            entity.Property(e => e.TuTiet).HasColumnName("tuTiet");

            entity.HasOne(d => d.MaGvNavigation).WithMany(p => p.Lhps)
                .HasForeignKey(d => d.MaGv)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_LHP_GIANGVIEN");
        });

        modelBuilder.Entity<Lsh>(entity =>
        {
            entity.HasKey(e => e.MaLsh).HasName("PK__LSH__2621EE366A7478C1");

            entity.ToTable("LSH");

            entity.Property(e => e.MaLsh)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("maLSH");
            entity.Property(e => e.MaGv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("maGV");
            entity.Property(e => e.Siso).HasColumnName("siso");

            entity.HasOne(d => d.MaGvNavigation).WithMany(p => p.Lshes)
                .HasForeignKey(d => d.MaGv)
                .HasConstraintName("FK_LSH_GIANGVIEN");
        });

        modelBuilder.Entity<Sinhvien>(entity =>
        {
            entity.HasKey(e => e.MaSv).HasName("PK__SINHVIEN__7A227A64C3EF54D6");

            entity.ToTable("SINHVIEN", tb =>
                {
                    tb.HasTrigger("trg_SinhVien_Insert");
                    tb.HasTrigger("trg_UpdateSiSo_LSH");
                });

            entity.Property(e => e.MaSv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("maSV");
            entity.Property(e => e.Cccd)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cccd");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.MaLsh)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("maLSH");
            entity.Property(e => e.Ngaysinh)
                .HasColumnType("datetime")
                .HasColumnName("ngaysinh");
            entity.Property(e => e.Sdt)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("sdt");
            entity.Property(e => e.TenSv)
                .HasMaxLength(50)
                .HasColumnName("tenSV");

            entity.HasOne(d => d.MaLshNavigation).WithMany(p => p.Sinhviens)
                .HasForeignKey(d => d.MaLsh)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_SINHVIEN_LSH");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
