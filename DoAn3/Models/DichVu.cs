using eProject3.Models;
using System;
using System.Collections.Generic;

namespace DoAn3.Models
{
    public partial class DichVu
    {
        public DichVu()
        {
            ThongTins = new HashSet<ThongTin>();
        }

        public int ServiceId { get; set; }
        public string? SerName { get; set; }
        public int? CatId { get; set; }
        public int? ProviderId { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public string? Thumb { get; set; }

        public virtual Loai? Cat { get; set; }
        public virtual Provider? Provider { get; set; }
        public virtual ICollection<ThongTin> ThongTins { get; set; }
    }
}
