using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuanLySoTietKiem.Model;
using QuanLySoTietKiem.ViewModel;
using System;
using System.Linq;
using System.Windows;

namespace TestSTK
{
    [TestClass]
    public class LoginTest
    {
        [TestMethod]
        public void LoginTest1()
        {
            LoginViewModel login = new LoginViewModel();
            login.UserName = "admin";
            login.Password = "admin";
            login.IsLogin = false;
            //var acc = DataProvider.Ins.DB.NGUOIDUNGs.Where( p=>p.TenDangNhap == login.UserName);
            NGUOIDUNG acc = new NGUOIDUNG();
            var result = login.CheckAccount(ref acc);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void LoginTest2()
        {
            LoginViewModel login = new LoginViewModel();
            login.UserName = "admin";
            login.Password = "6f4w";
            login.IsLogin = false;
            //var acc = DataProvider.Ins.DB.NGUOIDUNGs.Where( p=>p.TenDangNhap == login.UserName);
            NGUOIDUNG acc = new NGUOIDUNG();
            var result = login.CheckAccount(ref acc);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void LoginTest3()
        {
            LoginViewModel login = new LoginViewModel();
            login.UserName = "6f4w";
            login.Password = "65_#$!aad";
            login.IsLogin = false;
            //var acc = DataProvider.Ins.DB.NGUOIDUNGs.Where( p=>p.TenDangNhap == login.UserName);
            NGUOIDUNG acc = new NGUOIDUNG();
            var result = login.CheckAccount(ref acc);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void LoginTest4()
        {
            LoginViewModel login = new LoginViewModel();
            login.UserName = "6f4w";
            login.Password = "87";
            login.IsLogin = false;
            //var acc = DataProvider.Ins.DB.NGUOIDUNGs.Where( p=>p.TenDangNhap == login.UserName);
            NGUOIDUNG acc = new NGUOIDUNG();
            var result = login.CheckAccount(ref acc);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void LoginTest5()
        {
            LoginViewModel login = new LoginViewModel();
            login.UserName = "65_#$!aad";
            login.Password = "87";
            login.IsLogin = false;
            //var acc = DataProvider.Ins.DB.NGUOIDUNGs.Where( p=>p.TenDangNhap == login.UserName);
            NGUOIDUNG acc = new NGUOIDUNG();
            var result = login.CheckAccount(ref acc);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void LoginTest6()
        {
            LoginViewModel login = new LoginViewModel();
            login.UserName = "65_#$!aad";
            login.Password = "Anfio%566";
            login.IsLogin = false;
            //var acc = DataProvider.Ins.DB.NGUOIDUNGs.Where( p=>p.TenDangNhap == login.UserName);
            NGUOIDUNG acc = new NGUOIDUNG();
            var result = login.CheckAccount(ref acc);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void LoginTest7()
        {
            LoginViewModel login = new LoginViewModel();
            login.UserName = "87";
            login.Password = "Anfio%566";
            login.IsLogin = false;
            //var acc = DataProvider.Ins.DB.NGUOIDUNGs.Where( p=>p.TenDangNhap == login.UserName);
            NGUOIDUNG acc = new NGUOIDUNG();
            var result = login.CheckAccount(ref acc);
            Assert.IsFalse(result);
        }
    }
    [TestClass]
    public class ChangePassTest
    {
        [TestMethod]
        public void TestChangePass1()
        {
            var result = ChangePassFunction("admin", "admin", "4651");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestChangePass2()
        {
            var result = ChangePassFunction("admin", "admin", "%%%%%%");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestChangePass4()
        {
            var result = ChangePassFunction("admin", "qoqdns", "gow#$54");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestChangePass5()
        {
            var result = ChangePassFunction("qojp%", "admin", "gow#$54");
            Assert.IsFalse(result);
        }
        public bool ChangePassFunction(string user, string oldpass, string newpass)
        {
            RegisterViewModel registerView = new RegisterViewModel();
            registerView.TenDangNhap = user;
            registerView.MatKhauCu = oldpass;
            registerView.MatKhauMoi = newpass;
            return registerView.f_DoiMatKhau();
        }
    }
    [TestClass]
    public class AddDepositTest
    {
        public bool Test(string Maso, string SoTienrut)
        {
            WithdrawViewModel withdrawView = new WithdrawViewModel();
            withdrawView.MaSo = Maso;
            withdrawView.SoTienRut = SoTienrut;
            return withdrawView.checkTienRut(Maso);
        }

        [TestMethod]
        public void TestAddDeposit1()
        {
            var result = Test("-1", "-1");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestAddDeposit2()
        {
            var result = Test("0", "-1");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestAddDeposit3()
        {
            var result = Test("0", "0");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestAddDeposit4()
        {
            var result = Test("1", "0");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestAddDeposit5()
        {
            var result = Test("2", "100");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestAddDeposit6()
        {
            var result = Test("7", "100");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestAddDeposit7()
        {
            var result = Test("7", "10000000");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestAddDeposit8()
        {
            var result = Test("abc", "10000000");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestAddDeposit9()
        {
            var result = Test("2", "abc");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestAddDeposit10()
        {
            var result = Test("1", "10000000");
            Assert.IsFalse(result);
        }
    }
    [TestClass]
    public class AddSavingAccountTest
    {
        public bool Test(string cmnd, string sotien, string loaitietkiem)
        {
            SavingAccountViewModel saving = new SavingAccountViewModel(new NGUOIDUNG());
            saving.CMND = cmnd;
            saving.SoTienGoi = sotien;
            saving.SelectedLoai = DataProvider.Ins.DB.LOAITIETKIEMs.Where(p => p.TenLoaiTietKiem == loaitietkiem).SingleOrDefault();
            return saving.CheckSavingAccount();
        }
        [TestMethod]
        public void TestAddSavingAccount1()
        {
            var result = Test("-1", "-1", null);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestAddSavingAccount2()
        {
            var result = Test("0", "0", "Không kì hạn");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestAddSavingAccount3()
        {
            var result = Test("0", "1", "Không kì hạn");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestAddSavingAccount4()
        {
            var result = Test("123", "1", null);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestAddSavingAccount5()
        {
            var result = Test("123", "10000000", "Không kì hạn");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestAddSavingAccount6()
        {
            var result = Test("123", "1", "Không kì hạn");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestAddSavingAccount7()
        {
            var result = Test("123", "-1", "Kì hạn 3 tháng");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestAddSavingAccount8()
        {
            var result = Test("123", "abc", "Kì hạn 3 tháng");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestAddSavingAccount9()
        {
            var result = Test("1651", "10000000", "Kì hạn 3 tháng");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestAddSavingAccount10()
        {
            var result = Test("1651", "1", "Không kì hạn");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestAddSavingAccount11()
        {
            var result = Test("abc", "abc", "Không kì hạn");
            Assert.IsFalse(result);
        }
    }
    [TestClass]
    public class AddKhachHangTest
    {
        public bool Test(string name, string cmnd, string diachi)
        {
            CustomerViewModel customerView = new CustomerViewModel();
            customerView.TenKhachHang = name;
            customerView.CMND = cmnd;
            customerView.DiaChi = diachi;
            KHACHHANG kh = null;
            return customerView.AddKhachHang(ref kh);
        }
        [TestMethod]
        public void TestAddKhachHang1()
        {
            var result = Test("abcd", "123456", "123456");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestAddKhachHang2()
        {
            var result = Test("abcd", "abcdef", "abcdef");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestAddKhachHang3()
        {
            var result = Test("abcd", null, "(*&^%$");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestAddKhachHang4()
        {
            var result = Test(null, "123456", "abcdef");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestAddKhachHang5()
        {
            var result = Test("%%%#^", "(*&^%$", "abcdef");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestAddKhachHang6()
        {
            var result = Test("%%%#^", "abcdef", "123456");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestAddKhachHang7()
        {
            var result = Test("%%%#^", null, "abcdef");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestAddKhachHang8()
        {
            var result = Test("Anh", "123", "abcdef");
            Assert.IsFalse(result);
        }
    }
    [TestClass]
    public class EditCustomerTest
    {
        public bool Test(string name, string cmnd, string diachi)
        {
            CustomerViewModel customerView = new CustomerViewModel();
            customerView.SelectedItem = DataProvider.Ins.DB.KHACHHANGs.Where(p => p.CMND == "123").FirstOrDefault();
            customerView.TenKhachHang = name;
            customerView.DiaChi = diachi;
            customerView.CMND = cmnd;
            var kh = DataProvider.Ins.DB.KHACHHANGs.Where(x => x.MaKhachHang == 1).SingleOrDefault();
            return customerView.EditCustomer(ref kh);
        }
        [TestMethod]
        public void TestEditCustomer1()
        {
            var result = Test(null, "456", "việt nam");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestEditCustomer2()
        {
            var result = Test("", null, "việt nam");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestEditCustomer3()
        {
            var result = Test("yami", "78221", "4152");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestEditCustomer4()
        {
            var result = Test("yami", "456", "%$%45");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestEditCustomer5()
        {
            var result = Test("416---", "%%%%", "%$%45");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestEditCustomer6()
        {
            var result = Test("416---", "78221", "4152");
            Assert.IsTrue(result);
        }
    }
    [TestClass]
    public class AddLoaiTietKiemTest
    {
        public bool Test(string name, string thoigian, string laisuat, string yesno)
        {
            CategoryViewModel categoryView = new CategoryViewModel();
            categoryView.TenLoaiTietKiem = name;
            categoryView.ThoiGianGoiToiThieu = thoigian;
            categoryView.LaiSuat = laisuat;
            categoryView.SelectedYesNo = yesno;
            LOAITIETKIEM ltk = null;
            return categoryView.CheckAddLoai(ref ltk);
        }
        [TestMethod]
        public void TestAddLoaiTietKiem1()
        {
            var result = Test("Không kì hạn", "-1", "-0.5", "Có");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestAddLoaiTietKiem2()
        {
            var result = Test(null, "0", "1", "Có");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestAddLoaiTietKiem3()
        {
            var result = Test("^*&561", "12", "0", "Có");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestAddLoaiTietKiem4()
        {
            var result = Test("Kì hạn 6 tháng", null, null, "Không");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestAddLoaiTietKiem5()
        {
            var result = Test("Kì hạn 6 tháng", "abc", "1", "Không");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestAddLoaiTietKiem6()
        {
            var result = Test("Kì hạn 6 tháng", "12", "100", "Không");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestAddLoaiTietKiem7()
        {
            var result = Test("Kì hạn 6 tháng", "1", "0", "Có");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestAddLoaiTietKiem8()
        {
            var result = Test("Kì hạn 6 tháng", "12", "1", "Có");
            Assert.IsTrue(result);
        }
    }
    [TestClass]
    public class CheckAddUserTest
    {
        public bool Test(string username, string password, string tenthat, string tennhom)
        {
            UserViewModel userView = new UserViewModel();
            userView.TenDangNhap = username;
            userView.Password = password;
            userView.TenThat = tenthat;
            userView.SelectedGroup = DataProvider.Ins.DB.NHOMNGUOIDUNGs.Where(p => p.TenNhom == tennhom).FirstOrDefault();
            NGUOIDUNG user = null;
            return userView.CheckAddUser(ref user);
        }
        [TestMethod]
        public void TestCheckAddUser1()
        {
            var result = Test("admin", "!165Af6", "uoifnoajs", "admin");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestCheckAddUser2()
        {
            var result = Test("admin", null, "16542", "staff");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestCheckAddUser3()
        {
            var result = Test("16s5f^%$", null, "uoifnoajs", "staff");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestCheckAddUser4()
        {
            var result = Test("16s5f^%$", "!165Af6", null, "admin");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestCheckAddUser5()
        {
            var result = Test("16s5f^%$", "'@#4615", "16542", "staff");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestCheckAddUser6()
        {
            var result = Test(null, "'@#4615", "uoifnoajs", "admin");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestCheckAddUser7()
        {
            var result = Test("yamq", null, "uoifnoajs", "staff");
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void TestCheckAddUser8()
        {
            var result = Test("yamq", "'@#4615", "16542", "admin");
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestCheckAddUser9()
        {
            var result = Test("yamq", "!165Af6", "uoifnoajs", "staff");
            Assert.IsTrue(result);
        }
    }
}
