   M S B A M L   `   `   `  ����K  GQuanLySoTietKiem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:QuanLySoTietKiemQuanLySoTietKiem  5      !    QuanLySoTietKiem.ReportView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:QuanLySoTietKiem     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	         ReportVM  � DataContext#  [  5        MaterialDesignBody#���  5
      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5      .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      6   �� 5      6   .+�5   
   � $��0��6    5      �� 5      $
��Auto �6    60   �� 5      6"   .+�5      � $��0��6    � ColumnDefinitions 5      �� 5      $
��Auto �6'   66   �� 5       6)   �� 5!      6)   .+�5#      � $��0��6   .+�5$      �� $��5,10,0,0q�5%      $/��)Báo cáo doanh số hoạt động ngày��5&      $��30(�5'      $
��Bold"�5(      5*      � 5+      $��1��6   $��Center=�6'   .+�5,      �� $
��Left=�5.      $��Bottom=�5/      
��� � �  MaterialDesignRaisedButton#���  51      
���������5-      �� *	ExcelDate+.��53      ��  �� Orientation$ 
Horizontal=�6%   .+�54      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ MicrosoftExcel=�66   $��20��6L   $��20��6W   �� 55      $��5 2 5 0q�6(   Xuất excel6E   56      58      59      � 5:      $��2��6   $	��Top=�6'   $��Right=�6?   .+�5;      (  "System.Windows.Controls.DatePicker  -   5        $��LocaleDatePicker��5>      $
��Bold"�5<      $��	0,10,10,0q�5=      $	��120��5?      $��18(�5@      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Locale Date��5A         SelectedDate 5B      �� *	DateInput+	 �� UpdateSourceTrigger$	 PropertyChanged=�
 �� StringFormat$
 
dd/MM/yyyy��5D      5E      � 5F      $��1��6   $��5q�6    $��Stretch=�6+   .+�5G      #  MaterialDesignThemes.Wpf.Card  $��Stretch=�6&   .��5H      �� $
��Auto=�6#   .��5I      �� -   5         ��Name$ ListTK1��5I   #   -  'MaterialDesignThemes.Wpf.ListViewAssist   ListViewItemPadding$ 
23 10 0 10q�64   ���	#DDEE0303$��Stretch=�6�   $��Stretch=�6  ���	#FFFAFAFA$
��Bold"�6B  ��6s   �� *List1+ �� SelectedItem 6�   �� *SelectedItem+ �� Mode$ OneWayToSource=� �� View 5J      �� 5K   "   .P�5L   &   ��  �� Width$
 Auto��65   $	��STT��6B    �� DisplayMemberBinding 6O   �� *STT+6v   �� 5M   &   $
 Auto��65   $��Loại tiết kiệm��6B    6Z   �� *LoaiTietKiem+6�   �� 5N   &   $
 Auto��65   $��Tổng thu(VNĐ)��6B    6Y   �� *	TongThu+6�   �� 5O   &   $
 Auto��65   $��Tổng chi(VNĐ)��6B    6Y   �� *	TongChi+6�   �� 5P   &   $
 Auto��65   $��Chênh lệch(VNĐ)��6B    6[   �� *	ChenhLech+6�   5Q   #   5S      5T      5U      5V      5X      � 5Y   
   $��1��6    5Z      �� 5[      $
��Auto �6    60   �� 5\      6"   .+�5^      � $��0��6    5_      �� 5`      $
��Auto �6'   66   �� 5a      6)   �� 5b      $
��Auto �6'   66   .+�5d      � $��0��6   .+�5e      �� $��5,10,0,0q�5f      $'��!Báo cáo Mở/Đóng sổ tháng��5g      $��28(�5h      $
��Bold"�5i      5j      � 5k      $��1��6   $��Center=�6'   .+�5l      �� $
��Left=�5n      $��Bottom=�5o      
��� � �#���  5q      
���������5m      �� *
ExcelMonth+.��5s      �� $ 
Horizontal=�6%   .+�5t        $ MicrosoftExcel=�66   $��20��6L   $��20��6W   �� 5u      $��5 2 5 0q�6(   Xuất excel6E   5v      5x      5y      � 5{      $��2��6   $	��Top=�6'   $��Right=�6?    5|      �� 5}      6.   �� 5~      6-   �� 5      6-   .+�5�      � $��0��6   .+�5�      �� $��0,0,10,0q�5�      $ Loại tiết kiệm��5�      $��17(�5�      $
��Bold"�5�       �� DisplayMemberPath$ TenLoaiTietKiem��5�       & "MaterialDesignFloatingHintComboBox#��[ 5�      ��5�      �� *ListLoaiTietKiem+ 5�      �� *SelectedLoai+$	 PropertyChanged=���5�      �� 5�   "   .R�5�   &   $� 5�   #   5�      5�      � 5�      $��1��6   .+�5�      �� $ Tháng��5�      $��17(�5�      $
��Bold"�5�      #��[ 5�      ��5�      �� *
cbxThang+ 5�      �� *SelectedThang+$	 PropertyChanged=���5�      �� 5�   "   .R�5�   &   $� 5�   #   5�      5�      � 5�      $��2��6   .+�5�      �� $
 Năm��5�      $��	10,0,10,0q�5�      $��17(�5�      $
��Bold"�5�      #��[ 5�      ��5�      �� *cbxNam+ 5�      �� *SelectedNam+$	 PropertyChanged=���5�      �� 5�   "   .R�5�   &   $� 5�   #   5�      5�      5�      5�      � 5�      $��1��6   $��5q�6    $��Stretch=�6+   .+�5�        $��Stretch=�6&   $��Stretch=�6B   .��5�      �� $
��Auto=�6#   .��5�      �� $ 
23 10 0 10q�6$   ���	#DDEE0303$��Stretch=�6�   $��Stretch=�6�   ���	#FFFAFAFA$
��Auto=�63  $
��Auto=�6e  ��.  � UseLayoutRounding .   J� SnapsToDevicePixels . ���	#89FABF07$
��Bold"�6  ��6c   �� *List2+ 6�   �� *SelectedItem+$ OneWayToSource=� 5�      �� 5�   "   .P�5�   &   �� $	��STT��67    6D   �� *STT+6k   �� 5�   &   $	 200��65   $��Ngày��6A    6O   �� *Ngay+$
 
dd/MM/yyyy��6�   �� 5�   &   $	 150��65   $��Tổng sổ mở��6A    6U   �� *SoMo+6}   �� 5�   &   $	 150��65   $��Tổng sổ đóng��6A    6W   �� *SoDong+6�   �� 5�   &   $	 500��65   $��Chênh lệch��6A    6U   �� *
ChenhLech2+6�   5�   #   5�      5�      5�      5�      5�      5�      5�      