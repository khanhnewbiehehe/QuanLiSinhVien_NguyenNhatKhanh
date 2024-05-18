using System;
using System.Collections.Generic;

namespace QuanLiSinhVien.Models;

public partial class Giangvien
{
    public string MaGv { get; set; } = null!;

    public string TenGv { get; set; } = null!;

    public DateTime Ngaysinh { get; set; }

    public string Cccd { get; set; } = null!;

    public string Sdt { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Hocvi { get; set; } = null!;

    public string MaKhoa { get; set; } = null!;

    public virtual ICollection<Lhp> Lhps { get; set; } = new List<Lhp>();

    public virtual ICollection<Lsh> Lshes { get; set; } = new List<Lsh>();

    public virtual Khoa MaKhoaNavigation { get; set; } = null!;
}
