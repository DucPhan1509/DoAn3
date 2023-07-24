using System;
using System.Collections.Generic;

namespace DoAn3.Models
{
    public partial class ThongTin
    {
        public ThongTin()
        {
            ThanhToans = new HashSet<ThanhToan>();
        }

        public int DetailId { get; set; }
        public int? ServiceId { get; set; }
        public double? Price { get; set; }

        public virtual DichVu? Service { get; set; }
        public virtual ICollection<ThanhToan> ThanhToans { get; set; }
    }
}
