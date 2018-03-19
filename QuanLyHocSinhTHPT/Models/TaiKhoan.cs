﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocSinhTHPT.Models
{
    internal class TaiKhoan
    {
        public string TenTaiKhoan { get; set; }
        public string Matkhau { get; set; }

        public TaiKhoan(string Tk, string mk)
        {
            this.TenTaiKhoan = Tk;
            this.Matkhau = mk;
        }

        public TaiKhoan()
        {
            this.TenTaiKhoan = "";
            this.Matkhau = "";
        }
    }
}