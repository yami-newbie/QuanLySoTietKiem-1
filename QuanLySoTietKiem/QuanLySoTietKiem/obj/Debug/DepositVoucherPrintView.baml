   M S B A M L   `   `   `  ����K  GQuanLySoTietKiem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:QuanLySoTietKiemQuanLySoTietKiem  5   	   .    (QuanLySoTietKiem.DepositVoucherPrintView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:QuanLySoTietKiem     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   -   5          �Name$  window��5   	      MaterialDesignBody#���   5
      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignFont#���  5       � 
ResizeMode$ NoResize=�5   	    � Title$ DepositVoucherPrintView��5   	   $	��550��6)   $	��700��66   .��5      � .+�5   
   � .+�5      �� $��20 100 20 100q�5      $��Right=�5      $	��Top=�5      
����  �  MaterialDesignRaisedButton#���  5      
���������5      �� *PrintCommand+��5      ��  �� ElementName$ print��.��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Printer=�6.   $��20��6=   $��20��6H   �� 5      $��5 0 5 0q�6    In65   5       5!      5"      � 5#   
   -   5         �Name$ print��5#      	 � RowDefinitions	 5$      �� 5%      $	��120 �6    �� 5&      $
��auto �6    �� 5'      .+�5*      � $��0��6   .+�5+      �� $
��Left=�6   $��/Images/logo.jpg��63   6O   �� 5,      
����  �$
��Bold"�62   $��30(�6D   $��Center=�6R   $��Center=�6m   $��PHIẾU GỞI TIỀN��6�   6�   � 5-      $	��Top=�6   $��Right=�6/   $��0 0 20 0q�6K   	 5.      �� 5/      �� 50      .+�52      �� $ 
Horizontal=�6!   $��1��6:   .+�53      �� $��Mã số phiếu: ��54      
����  �$
��Bold"�56      $��14(�6+   $��Center=�57      $��Right=�64   �� 58      $��10 0 0 0q�6%   
����  �$
��Bold"�5:      $��14(�6+   $��Center=�5;      $��Right=�64   ��5<      �� *SelectedItem.MaPhieuGoiTien+5=      �� 5>      $��	0 40 0 0 q�6!   $ 
Horizontal=�64   $��1��6M   .+�5?      �� $��Ngày gởi: ��5@      $��0��5A      
����  �$
��Bold"�5C      $��14(�6+   $��Center=�5D      $��Right=�64   �� 5E      $��1��5F      
����  �$
��Bold"�5H      $��14(�6+   $��Center=�5I      $��Right=�64   ��5J      �� *SelectedItem.NgayGoi+
 �� StringFormat$
 
dd/MM/yyyy��5K      5L      5M      � 5N      $��1��6   .+�5O      �� $��0 0 0 20q�6   
���   �$��2q�6B   $	��top=�6V   $	��400��6n   6|   5P      � 5Q      $��2��6   $	��Top=�6    
�������.+�5R      � $��100 20 100 20q�6   $	��Top=�6.   .+�5S      �� $ 
Horizontal=�6!   $	��Top=�6:   .+�5T      �� $��Mã sổ tiết kiệm: ��5U      
����  �$
��Bold"�5W      $��14(�6+   $��Center=�5X      $��Right=�64   �� 5Y      $��10 0 0 0q�6%   
����  �$
��Bold"�5[      $��14(�6+   $��Center=�5\      $��Right=�64   ��5]      �� *SelectedItem.MaSo+5^      �� 5_      $��0 50 0 0q�6!   $ 
Horizontal=�63   $	��Top=�6L   .+�5`      �� $��Loại tiết kiệm: ��5a      
����  �$
��Bold"�5c      $��14(�6+   $��Center=�5d      $��Right=�64   �� 5e      $��10 0 0 0q�6%   
����  �$
��Bold"�5g      $��14(�6+   $��Center=�5h      $��Right=�64   ��5i      �� *64SelectedItem.SOTIETKIEM.LOAITIETKIEM.TenLoaiTietKiem+5j      �� 5k      $��	0 100 0 0q�6!   $ 
Horizontal=�64   $	��Top=�6M   .+�5l      �� $��Số tiền gởi: ��5m      
����  �$
��Bold"�5o      $��14(�6+   $��Center=�5p      $��Right=�64   �� 5q      $��10 0 0 0q�6%   
����  �$
��Bold"�5s      $��14(�6+   $��Center=�5t      $��Right=�64   ��5u      �� *SelectedItem.SoTienGoi+5v      �� 5w      $��	0 150 0 0q�6!   $ 
Horizontal=�64   $	��Top=�6M   .+�5x      �� $��Người gởi: ��5y      
����  �$
��Bold"�5{      $��14(�6+   $��Center=�5|      $��Right=�64   �� 5}      $��10 0 0 0q�6%   
����  �$
��Bold"�5      $��14(�6+   $��Center=�5�      $��Right=�64   ��5�      �� *0.SelectedItem.SOTIETKIEM.KHACHHANG.TenKhachHang+5�      �� 5�      $��	0 200 0 0q�6!   $ 
Horizontal=�64   $	��Top=�6M   .+�5�      �� $��Số CMND: ��5�      
����  �$
��Bold"�5�      $��14(�6+   $��Center=�5�      $��Right=�64   �� 5�      $��10 0 0 0q�6%   
����  �$
��Bold"�5�      $��14(�6+   $��Center=�5�      $��Right=�64   ��5�      �� *(&SelectedItem.SOTIETKIEM.KHACHHANG.CMND+5�      �� 5�      $��	0 250 0 0q�6!   $ 
Horizontal=�64   $	��Top=�6M   .+�5�      �� $��Địa chỉ: ��5�      
����  �$
��Bold"�5�      $��14(�6+   $��Center=�5�      $��Right=�64   �� 5�      $��10 0 0 0q�6%   
����  �$
��Bold"�5�      $��14(�6+   $��Center=�5�      $��Right=�64   ��5�      �� **(SelectedItem.SOTIETKIEM.KHACHHANG.DiaChi+5�      5�      5�      5�      5�      5�      