//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLySoTietKiem.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class BCDOANHSOTHEONGAY
    {
        public int MaBaoCaoDoanhSo { get; set; }
        public Nullable<System.DateTime> Ngay { get; set; }
        public Nullable<int> LoaiTietKiem { get; set; }
        public Nullable<int> TongThu { get; set; }
        public Nullable<int> TongChi { get; set; }
        public Nullable<int> ChenhLech { get; set; }
    
        public virtual LOAITIETKIEM LOAITIETKIEM1 { get; set; }
    }
}