   M S B A M L   `   `   `  ����K  GQuanLySoTietKiem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:QuanLySoTietKiemQuanLySoTietKiem  5      (    "QuanLySoTietKiem.SavingAccountView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:QuanLySoTietKiem     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5         MaterialDesignBody#���   5	      $��Regular"�5
      $��13(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5      .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      6   .+�5   
   � $��0��6   $��5q�6   .+�5      #  MaterialDesignThemes.Wpf.Card  .��5      �� $��Right=�6    �� Orientation$ 
Horizontal=�69   .+�5      �� $��Right=�5        MaterialDesignRaisedButton#���  5      +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth2=�5      
����  ���5      �� *AddFormCommand+.��5!      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$	 Add=�62   $��20��6=   $��20��6H   5"      5#      5%      5&        5'   
   $��1��6   $��5q�6+   .��5(      � .+�5)      � $��10q�6   $	��350��6#   $
��Left=�6/   .+�5*      �� $��10q�5,      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tìm kiếm��5-       ! MaterialDesignOutlinedTextBox#��[ 5.      ��5+      �� *Query+5.      5/      � 50      $��	380 0 0 0q�6   $	��250��6*   $
��Left=�66   .+�51      �� $��10 10 10 10q�53      $��10q�55      $ 
Tiêu chí��56       " MaterialDesignOutlinedComboBox#��[ 57       �� SelectedItem 52      �� *SelectedFilter+��54      �� *
FilterList+57      58      � 59      $��	650 0 0 0q�6   $	��140��6*   $
��Left=�66   .+�5:      �� $	��110��6   
���"�"�
���"�"�
�������   MaterialDesignOutlinedButton#��[ 5?      $��Tìm kiếm��5@      ��5;      �� *SearchCommand+5@      5A      � 5B      $��	800 0 0 0q�6   $
��Left=�6+   .+�5C      �� $��Right=�5E      
�������#���  5G      
�������y�5C      �� *ClosedSavingVisible+��5D      �� *RestoreFormCommand+.��5I      �� $ 
Horizontal=�6%   .+�5J        $ Delete=�66   $��20��6D   $��20��6O   �� 5K      $��5 0 5 0q�6(   Sổ đóng6B   5L      5N      5O      5P      5Q        5R   
   $��5q�6   $��2��6)   .��5S      �� $
��Auto=�6   .��5T      �� -  'MaterialDesignThemes.Wpf.ListViewAssist   ListViewItemPadding$ 
23 10 0 10q�6   ��6Z   �� *List+ 6w   �� *SelectedItem+	 � 	Resources	 5U        ColHeaderText
 �� 
TargetType �� Property �� Value��%x   &	       �� 5V      "
 ��66   .�5W      ��  � ��$ 15(�69   �� 5X       � ��$
 Bold"�6;   5Y      5Z       �� View 5[      �� 5\      .P�5]      ��  �� DisplayMemberBinding 6.   �� *MaSo+.��5^   "   �� $��Mã sổ��6,   #��[ 6:   6c   5`      �� 5a       6.   �� *LOAITIETKIEM.TenLoaiTietKiem+.��5b   "   �� $��Loại tiết kiệm��6,   #��[ 6C   6l   5d      �� 5e       6.   �� *KHACHHANG.TenKhachHang+.��5f   "   �� $��Tên khách hàng��6,   #��[ 6C   6l   5h      �� 5i       6.   �� *	SoTienGoi+.��5j   "   �� $��Số dư(VNĐ)��6,   #��[ 6?   6h   5l      �� 5m       6.   �� *
NgayMoSo+ �� StringFormat$ 
dd/MM/yyyy��.��5n   "   �� $��Ngày mở sổ��6,   #��[ 6?   6h   5p      �� 5q       6.   �� *NgayTinhLaiGanNhat+$ 
dd/MM/yyyy��.��5r   "   �� $��Ngày cập nhật��6,   #��[ 6B   $	��100��6i   6w   5t      5u      5w      5x      5y      5z      5{      