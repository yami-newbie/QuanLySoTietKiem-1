   M S B A M L   `   `   `  ����K  GQuanLySoTietKiem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:QuanLySoTietKiemQuanLySoTietKiem  5   	   "    QuanLySoTietKiem.EnhanceView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:QuanLySoTietKiem     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#���   5	   	   $��Regular"�5
   	   $��13(�5   	     � 
ResizeMode$  NoResize=�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � WindowStartupLocation$ CenterScreen=�5   	    � Title$  ��5   	   $	��700��6   $	��510��6     	EnhanceVM � DataContext# [ 5   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      6   .+�5   
   � $��0��6   $��10q�6   .+�5      �� 
�������$��Center=�5      $��DemiBold"�5      $��0��5       $��
16 16 16 4q�5!       $  MaterialDesignHeadline5TextBlock#��[ 5"      $��Quản trị hệ thống��5#      5%      � 5&   
   $��1��6   .+�5'      ��  �� Orientation$ 
Horizontal=�6   .+�5(      �� $��50��5+      $	��170��5,      
���   ����#D3DCD2   MaterialDesignOutlinedButton#��[ 50      $��LOẠI TIẾT KIỆM��51      ��5*      �� *CategoryCommand+��5-      �� *BackgroundColor[0]+51      �� 52      
���   ����#D3DCD2$��50��57      $	��170��58      #��[ 59      $��NGƯỜI DÙNG��5:      ��53      �� *UserCommand+��55      �� *BackgroundColor[1]+5:      �� 5;      
���   ����#D3DCD2$��50��5@      $	��170��5A      #��[ 5B      $ ��TIỀN GỞI TỐI THIỂU��5C      ��5<      �� *MinimalDepositCommand+��5>      �� *BackgroundColor[2]+5C      5D      5E      � 5F   
   $��2��6   $��10q�6   .+�5G      �� ��6   �� *CurrentView+6?   5H      5I      5J      