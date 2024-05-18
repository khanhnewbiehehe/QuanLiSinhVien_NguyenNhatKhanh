using System;
using System.Collections.Generic;

namespace QuanLiSinhVien.Models;

public partial class Sinhvien
{
    public string MaSv { get; set; } = null!;

    public string TenSv { get; set; } = null!;

    public DateTime Ngaysinh { get; set; }

    public string Cccd { get; set; } = null!;

    public string Sdt { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? MaLsh { get; set; }

    public virtual Lsh? MaLshNavigation { get; set; }
}
