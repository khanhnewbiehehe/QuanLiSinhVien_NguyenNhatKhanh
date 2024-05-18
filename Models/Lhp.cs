using System;
using System.Collections.Generic;

namespace QuanLiSinhVien.Models;

public partial class Lhp
{
    public string MaLhp { get; set; } = null!;

    public string TenLhp { get; set; } = null!;

    public int SoTc { get; set; }

    public int TuTiet { get; set; }

    public int DenTiet { get; set; }

    public int Thu { get; set; }

    public int Soluong { get; set; }

    public int? Soluongdk { get; set; }

    public string? MaGv { get; set; }

    public virtual Giangvien? MaGvNavigation { get; set; }
}
