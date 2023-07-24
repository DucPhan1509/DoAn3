﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace DoAn3.Models
{
    public class TaiKhoan : IdentityUser
    {
        public TaiKhoan()
        {
            FeedBacks = new HashSet<FeedBack>();
            ThanhToans = new HashSet<ThanhToan>();
        }

        public int AccountId { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool? DoNotDisturb { get; set; }
        public bool? CallerTunes { get; set; }
        public int RoleId { get; set; }

        public virtual ChucVu Role { get; set; } = null!;
        public virtual ICollection<FeedBack> FeedBacks { get; set; }
        public virtual ICollection<ThanhToan> ThanhToans { get; set; }
    }
}
