   M S B A M L   `   `   `  ����K  GQuanLySoTietKiem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:QuanLySoTietKiemQuanLySoTietKiem  5   	   +    %QuanLySoTietKiem.WithdrawVoucherPrint   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:QuanLySoTietKiem     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#���   5	      $��Regular"�5
      $��13(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignFont#���  5       � 
ResizeMode$ NoResize=�5   	    � Title$ DepositVoucherPrintView��5   	   $	��550��6)   $	��700��66   .��5      � .+�5   
   � .+�5      �� $��20 100 20 100q�5      $��Right=�5      $	��Top=�5      
����  �  MaterialDesignRaisedButton#���  5      
���������5      �� *PrintCommand+��5      ��  �� ElementName$ print��.��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Printer=�6.   $��20��6=   $��20��6H   �� 5      $��5 0 5 0q�6    In65   5      5       5!      � 5"   
   -   5         �Name$ print��5"       � RowDefinitions 5#      �� 5$      $	��120 �6    �� 5%      $
��auto �6    �� 5&      .+�5)      � $��0��6   .+�5*      �� $
��Left=�6   $��/Images/logo.jpg��63   6O   �� 5+      
����  �$
��Bold"�62   $��30(�6D   $��Center=�6R   $��Center=�6m   $��PHIẾU RÚT TIỀN��6�   6�   � 5,      $	��Top=�6   $��Right=�6/   $��0 0 20 0q�6K    5-      �� 5.      �� 5/      .+�51      �� $ 
Horizontal=�6!   $��1��6:   .+�52      �� $��Mã số phiếu: ��53      
����  �$
��Bold"�55      $��14(�6+   $��Center=�56      $��Right=�64   �� 57      $��10 0 0 0q�6%   
����  �$
��Bold"�59      $��14(�6+   $��Center=�5:      $��Right=�64   ��5;      �� *SelectedItem.MaPhieuRutTien+5<      �� 5=      $��	0 40 0 0 q�6!   $ 
Horizontal=�64   $��1��6M   .+�5>      �� $��Ngày rút: ��5?      $��0��5@      
����  �$
��Bold"�5B      $��14(�6+   $��Center=�5C      $��Right=�64   �� 5D      $��1��5E      
����  �$
��Bold"�5G      $��14(�6+   $��Center=�5H      $��Right=�64   ��5I      �� *SelectedItem.NgayRut+	 �� StringFormat$	 
dd/MM/yyyy��5J      5K      5L      � 5M      $��1��6   .+�5N      �� $��0 0 0 20q�6   
���   �$��2q�6B   $	��top=�6V   $	��400��6n   6|   5O      � 5P      $��2��6   $	��Top=�6    
�������.+�5Q      � $��100 20 100 20q�6   $	��Top=�6.   .+�5R      �� $ 
Horizontal=�6!   $	��Top=�6:   .+�5S      �� $��Mã sổ tiết kiệm: ��5T      
����  �$
��Bold"�5V      $��14(�6+   $��Center=�5W      $��Right=�64   �� 5X      $��10 0 0 0q�6%   
����  �$
��Bold"�5Z      $��14(�6+   $��Center=�5[      $��Right=�64   ��5\      �� *SelectedItem.MaSo+5]      �� 5^      $��0 50 0 0q�6!   $ 
Horizontal=�63   $	��Top=�6L   .+�5_      �� $��Loại tiết kiệm: ��5`      
����  �$
��Bold"�5b      $��14(�6+   $��Center=�5c      $��Right=�64   �� 5d      $��10 0 0 0q�6%   
����  �$
��Bold"�5f      $��14(�6+   $��Center=�5g      $��Right=�64   ��5h      �� *64SelectedItem.SOTIETKIEM.LOAITIETKIEM.TenLoaiTietKiem+5i      �� 5j      $��	0 100 0 0q�6!   $ 
Horizontal=�64   $	��Top=�6M   .+�5k      �� $��Số tiền rút: ��5l      
����  �$
��Bold"�5n      $��14(�6+   $��Center=�5o      $��Right=�64   �� 5p      $��10 0 0 0q�6%   
����  �$
��Bold"�5r      $��14(�6+   $��Center=�5s      $��Right=�64   ��5t      �� *SelectedItem.SoTienRut+5u      �� 5v      $��	0 150 0 0q�6!   $ 
Horizontal=�64   $	��Top=�6M   .+�5w      �� $��Người rút: ��5x      
����  �$
��Bold"�5z      $��14(�6+   $��Center=�5{      $��Right=�64   �� 5|      $��10 0 0 0q�6%   
����  �$
��Bold"�5~      $��14(�6+   $��Center=�5      $��Right=�64   ��5�      �� *0.SelectedItem.SOTIETKIEM.KHACHHANG.TenKhachHang+5�      �� 5�      $��	0 200 0 0q�6!   $ 
Horizontal=�64   $	��Top=�6M   .+�5�      �� $��Số CMND: ��5�      
����  �$
��Bold"�5�      $��14(�6+   $��Center=�5�      $��Right=�64   �� 5�      $��10 0 0 0q�6%   
����  �$
��Bold"�5�      $��14(�6+   $��Center=�5�      $��Right=�64   ��5�      �� *(&SelectedItem.SOTIETKIEM.KHACHHANG.CMND+5�      �� 5�      $��	0 250 0 0q�6!   $ 
Horizontal=�64   $	��Top=�6M   .+�5�      �� $��Địa chỉ: ��5�      
����  �$
��Bold"�5�      $��14(�6+   $��Center=�5�      $��Right=�64   �� 5�      $��10 0 0 0q�6%   
����  �$
��Bold"�5�      $��14(�6+   $��Center=�5�      $��Right=�64   ��5�      �� **(SelectedItem.SOTIETKIEM.KHACHHANG.DiaChi+5�      5�      5�      5�      5�      5�      