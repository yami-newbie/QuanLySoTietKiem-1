   M S B A M L   `   `   `  ����K  GQuanLySoTietKiem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:QuanLySoTietKiemQuanLySoTietKiem  5      #    QuanLySoTietKiem.WithdrawView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:QuanLySoTietKiem     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	         
WithdrawVM  � DataContext#  [  5        MaterialDesignBody#���  5
      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5      .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      6   .+�5   
   � $��0��6   $��5q�6   .+�5      #  MaterialDesignThemes.Wpf.Card  .��5      �� $��Right=�5        MaterialDesignRaisedButton#���  5      
����  ���5      �� *
AddCommand+.��5!      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$	 Add=�6.   $��20��69   $��20��6D   5"      5#      5$        5%   
   $��1��6   $��5q�6+   .��5&      � .+�5'      � $��10q�6   $	��350��6#   $
��Left=�6/   .+�5(      �� $��10q�5*      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tìm kiếm��5+       ! MaterialDesignOutlinedTextBox#��[ 5,      ��5)      �� *Query+5,      5-      � 5.      $��	380 0 0 0q�6   $	��250��6*   $
��Left=�66   .+�5/      �� $��10 10 10 10q�51      $��10q�53      $ 
Tiêu chí��54       " MaterialDesignOutlinedComboBox#��[ 55       �� SelectedItem 50      �� *SelectedFilter+��52      �� *
FilterList+55      56      � 57      $��	650 0 0 0q�6   $	��140��6*   $
��Left=�66   .+�58      �� $	��110��6   
���"�"�
���"�"�
�������   MaterialDesignOutlinedButton#��[ 5=      $��Tìm kiếm��5>      ��59      �� *SearchCommand+5>      5?      � 5@      $��	800 0 0 0q�6   $
��Left=�6+   .+�5A      �� $��Right=�5C      
����  �#���  5E      
���������5B      �� *PrintWindowCommand+.��5G      ��  �� Orientation$ 
Horizontal=�6%   .+�5H        $ Printer=�66   $��20��6E   $��20��6P   �� 5I      $��5 0 5 0q�6(   In6=   5J      5L      5M      5N      5O      � 5Q   
   $��2��6   $��5q�6   $��Stretch=�6'   .+�5R        .��5S      �� $
��Auto=�6   .��5T      �� -  'MaterialDesignThemes.Wpf.ListViewAssist   ListViewItemPadding$ 
23 10 0 10q�6   ��6^   �� *List+ 6{   �� *SelectedItem+	 �� Mode$	 TwoWay=�
 � 	Resources
 5U        ColHeaderText �� 
TargetType �� Property �� Value��%x   &	       �� 5V      " ��6:   .�5W   "   ��  � ��$ 16(�6=   �� 5X   "    � ��$
 Bold"�6?   5Y      5Z       �� View 5[      �� 5\      .P�5]   "   ��  �� DisplayMemberBinding 61   �� *MaPhieuRutTien+.��5^   &   �� $��Mã phiếu rút tiền��60   #��[ 6J   6s   5_   #   �� 5`   "    62   �� *#!SOTIETKIEM.KHACHHANG.TenKhachHang+.��5a   &   �� $��Tên khách hàng��60   #��[ 6G   6p   5b   #   �� 5c   "    62   �� *MaSo+.��5d   &   �� $��Mã sổ tiết kiệm��60   #��[ 6H   6q   5e   #   �� 5f   "    62   �� *	NgayRut+ �� StringFormat$ 
dd/MM/yyyy��.��5g   &   �� $��
Ngày rút��60   #��[ 6A   6j   5h   #   �� 5i   "    62   �� *	SoTienRut+.��5j   &   �� $��Số tiền rút(VNĐ)��60   #��[ 6I   6r   5k   #   5l      5n      5o      5p      5q      5r      5t      