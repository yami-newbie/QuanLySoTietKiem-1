   M S B A M L   `   `   `  ����K  GQuanLySoTietKiem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:QuanLySoTietKiemQuanLySoTietKiem  5   	   /    )QuanLySoTietKiem.RestoreSavingAccountView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:QuanLySoTietKiem     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   -   5          �Name$  window��5   	   $	��600��5   	   $	��500��6      MaterialDesignBody#���   5
   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	    � 
ResizeMode$ NoResize=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      6   �� 5      $
��auto �6   6,   .+�5   
   � $��0��6   $��20q�6   .+�5      �� $��Center=�6   $/��)Danh sách sổ tiết kiệm bị đóng��5      $��22(�5      $
��Bold"�5      5       � 5!   
   $��10q�6   $��1��6   .+�5"      �� $
��Auto=�6   .��5#      �� -  'MaterialDesignThemes.Wpf.ListViewAssist   ListViewItemPadding$ 
23 10 0 10q�6   ��6Z   �� *
ListDaDong+ �� SelectedItem 6}   �� *SelectedItemDaXoa+ �� View 5$      �� 5%      .P�5&      �� $��Mã số��6-   	 �� DisplayMemberBinding	 6<   �� *MaSo+6d   �� 5'      $��Loại Tiết Kiệm��6-   	 6E   �� *LOAITIETKIEM.TenLoaiTietKiem+6�   �� 5(      $��Tên khách Hàng��6-   	 6E   �� *KHACHHANG.TenKhachHang+6   5)      5+      5,      5-      � 5.   
   $��2��6   $��5q�6   .+�5/      � $	��280��6   $��0,0,0,20q�50      $��50��51      $��Bottom=�52      .+�54      �� 
�������
�������$��Center=�59      $	��130��5:        MaterialDesignRaisedButton#��[ 5;      +  %MaterialDesignThemes.Wpf.ButtonAssist
   CornerRadius$
 10��5<      ��55      �� *DeletePerformantlyCommand+��56      ��  �� ElementName$ window��.��5=      �� $��Xóa vĩnh viễn��6    5>      5?      5A      5B      5C      