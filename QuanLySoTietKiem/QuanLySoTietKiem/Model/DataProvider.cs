﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySoTietKiem.Model
{
    public class DataProvider
    {
        public QuanLySoTietKiemEntities1 DB;
        private static DataProvider _ins;
        public static DataProvider Ins
        {
            get
            {
                if (_ins == null)
                    _ins = new DataProvider();
                return _ins;
            }
            set
            {
                _ins = value;
            }
        }
        public DataProvider()
        {
            DB = new QuanLySoTietKiemEntities1();
        }
    }
}
