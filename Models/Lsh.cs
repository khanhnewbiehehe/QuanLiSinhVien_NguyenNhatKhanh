using System;
using System.Collections.Generic;

namespace QuanLiSinhVien.Models;

public partial class Lsh
{
    public string MaLsh { get; set; } = null!;

    public string MaGv { get; set; } = null!;

    public int? Siso { get; set; }

    public virtual Giangvien MaGvNavigation { get; set; } = null!;

    public virtual ICollection<Sinhvien> Sinhviens { get; set; } = new List<Sinhvien>();
}
