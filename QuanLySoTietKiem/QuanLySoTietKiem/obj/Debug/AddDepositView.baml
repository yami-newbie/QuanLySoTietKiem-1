   M S B A M L   `   `   `  ����K  GQuanLySoTietKiem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:QuanLySoTietKiemQuanLySoTietKiem  5   	   %    QuanLySoTietKiem.AddDepositView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:QuanLySoTietKiem     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
   	   -   5        $��window��5	   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	    � 
ResizeMode$ NoResize=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � WindowStartupLocation$ CenterScreen=�5   	   $	��600��5   	   $	��500��6   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      6   .+�5   
   � $��0��6   $��5q�6   .+�5      �� $��Center=�6   $��DemiBold"�5      $��0��5       $��15q�5!       $  MaterialDesignHeadline5TextBlock#��[ 5"      $ ��Lập phiếu gởi tiền��5#      5$      � 5%   
   $��1��6   .+�5&      ��  �� Orientation$ 
Horizontal=�6   .+�5'      #  MaterialDesignThemes.Wpf.Card  $��10 0 0 0q�5(      $��0q�5)      $	��150��5*      .��5+      �  5,      �� 5-      $
��Auto �6-   �� 5.      $
��Auto �6,   �� 5/      $
��Auto �6,   .+�51      �� $��Center=�52      $��0��53      $��
16 16 16 4q�54      #��[ 55      $��Số dư cũ��56      �� 57      $��1��58         MaterialDesignLightSeparator#��[ 59      �� 5;      $��2��5<      $��	16 0 16 8q�5=      $��Center=�5>      $��Center=�5?         MaterialDesignBody2TextBlock#��[ 5@      ��5A      �� *SoDuCu+�� 5B      $��2��5C      $ 
Horizontal=�5D      $��	16 0 16 8q�5E      $��Right=�5F      5G      5H      5I        5K      $��10 0 0 0q�5L      $��0q�5M      $	��150��5N      .��5O      �  5P      �� 5Q      $
��Auto �6-   �� 5R      $
��Auto �6,   �� 5S      $
��Auto �6,   .+�5U      �� $��Center=�5V      $��0��5W      $��
16 16 16 4q�5X      #��[ 5Y      $
��Lãi��5Z      �� 5[      $��1��5\      #��[ 5]      �� 5_      $��2��5`      $��	16 0 16 8q�5a      $��Center=�5b      $��Center=�5c      #��[ 5d      ��5e      �� *Lai+�� 5f      $��2��5g      $ 
Horizontal=�5h      $��	16 0 16 8q�5i      $��Right=�5j      5k      5l      5m        5o      $��10 0 0 0q�5p      $��0q�5q      $	��150��5r      .��5s      �  5t      �� 5u      $
��Auto �6-   �� 5v      $
��Auto �6,   �� 5w      $
��Auto �6,   .+�5y      �� $��Center=�5z      $��0��5{      $��
16 16 16 4q�5|      #��[ 5}      $��Số dư mới��5~      �� 5      $��1��5�      #��[ 5�      �� 5�      $��2��5�      $��	16 0 16 8q�5�      $��Center=�5�      $��Center=�5�      #��[ 5�      ��5�      �� *	SoDuMoi+�� 5�      $��2��5�      $ 
Horizontal=�5�      $��	16 0 16 8q�5�      $��Right=�5�      5�      5�      5�      5�      5�      � 5�   
   $��0,20,0,0q�6   $��2��6!   .+�5�      � $	��350��5�      $��50��5�      $	��Top=�5�      .+�5�      �� $��SemiBold"�5�      $��18(�5�      $
��Left=�5�      $��Mã sổ tiết kiệm��5�      $��Center=�6,   �� 5�      $	��180��5�      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Mã sổ tiết kiệm��5�       ! MaterialDesignOutlinedTextBox#��[ 5�      $��Center=�5�      $��Right=�5�      ��5�      �� *MaSo+ �� UpdateSourceTrigger$ PropertyChanged=�.��5�   3   .  (System.Windows.Interactivity.Interaction   Triggers 5�      /  )System.Windows.Interactivity.EventTrigger  5�      	   	EventName$	 TextChanged��6)   .  (System.Windows.Interactivity.TriggerBase
   Actions.
 5�      6  0System.Windows.Interactivity.InvokeCommandAction     Command 64   �� *TextChangeCommand+5�      .��5�   .   5�      5�      � 5�      $	��450��5�      $��50��5�      $	��Top=�5�      .+�5�      �� 
�������
�������$��Right=�5�      $��50��5�        MaterialDesignFlatButton#��[ 5�      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��5�      ��5�      �� *SearchMaSoCommand+.��5�      '	  !MaterialDesignThemes.Wpf.PackIcon	  $��Center=�6.    	  Kind$ Search=�6K   
���   �$��20��6l   $��20��6w   $��Center=�6�   5�      5�      � 5�      $	��350��6   $��0,60,0,0q�5�      $��50��5�      $	��Top=�5�      .+�5�      �� $��SemiBold"�5�      $��18(�5�      $
��Left=�5�      $��	Số CMND��5�      $��Center=�6$   �� 5�      {�.  $	��180��5�      $ 	Số CMND��5�      #��[ 5�      $��Center=�5�      $��Right=�5�      ��5�      �� *CMND+$ PropertyChanged=�5�      5�      � 5�      $	��350��6   $��	0,120,0,0q�5�      $��50��5�      $	��Top=�5�      .+�5�      �� $��SemiBold"�5�      $��18(�5�      $
��Left=�5�      $��Tên khách hàng��5�      $��Center=�6+   �� 5�      $	��180��5�      {�.  $ Tên khách hàng��5�      #��[ 5�      $��Center=�5�      $��Right=�5�      ��5�      �� *TenKhachHang+$ PropertyChanged=�5�      5�      � 5�      $	��350��6   $��	0,180,0,0q�5�      $��50��5�      $	��Top=�5�      .+�5�      �� $��SemiBold"�5�      $��18(�5�      $
��Left=�5�      $��Số tiền gởi��5�      $��Center=�6(   �� 5�      $	��180��5�      $ Số tiền gởi��5�      #��[ 5�      $��Center=�5�      $��Right=�5�      ��5�      �� *	SoTienGoi+$ PropertyChanged=�.��5�   3    5�        5�      $	 TextChanged��6)   .
 5�         64   �� *DepositChangedCommand+5�      .��5�   .   5�      5�      � 5�      $	��220��6   $��0,0,0,20q�5�      $��50��5�      $��Bottom=�5�      .+�5      �� 
���"�"�
���"�"�$
��Left=�5     $	��100��5       MaterialDesignRaisedButton#��[ 5     $ 10��5     ��5     �� *SaveCommand+.��5     �� $
��Lưu��6    5	     �� 5
     
�������
�������$��Right=�5     $	��100��5     #��[ 5     $ 10��5     ��5     �� *ExitCommand+��5     ��  �� ElementName$ window��.��5     �� $��Bỏ qua��6    5     5     5     5     5     