   M S B A M L   `   `   `  ����K  GQuanLySoTietKiem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:QuanLySoTietKiemQuanLySoTietKiem  5   	   %    QuanLySoTietKiem.RegisterWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:QuanLySoTietKiem     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  66   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   -   5        $��window��5   	     � Title$  Register��5	   	   $	��430��6   $	��800��6'    � 
ResizeMode$ NoResize=�5
   	    � WindowStyle$
 None=�5   	      
RegisterVM � DataContext# [  5   	    � WindowStartupLocation$ CenterScreen=�5   	   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ MouseLeftButtonDown��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *DragMoveCommand+	   CommandParameter	 6H   �� 
 �� ElementName$
 window��5      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��Auto �6   6.   �� 5      $
��Auto �6   6.   .+�5   
   � $��0��6   $��2��6   $��0,0,464.6,0q�63    � RowDefinitions 5      �� 5      6"   �� 5      6"   .+�5      � $��0��6   .+�5      �� $��/Images/logo.jpg��6   $��Center=�62   $	��300��6O   $	��250��6[   $��40,0,-35.2,-50q�6h   6�   5!      � 5"      $��1��6   .+�5#      �� $��/Images/5869.jpg��6   $��-37,20,-108.6,0q�62   5$      5%      � 5&   
   $��1��6   $��200,0,-0.4,0q�6   .+�5'      �  5(      �� 5)      $��4* �6$   �� 5*      $	��39* �6$   .+�5-      �� $��2��6    �� CornerRadius$ 50,50,50,50��6*   $	��420��6F   $	��Top=�6S   $��-80,4,-23.4,0q�6k   ��5.      �� 5/      .��50      �  � Color$ 	#FFE63070��6+    � Offset$ 0Q�6=   � 51      $ 	#FFFE8704��6+   $ 1Q�6=   52      ._�54      � $��	10,0,10,0q�6    55      �� 56      $
��Auto �6,   6<   �� 57      $
��Auto �6,   6<   �� 58      6/   �� 59      6/   �� 5:      6/   �� 5;      6/   �� 5<      6/   �� 5=      6/   �� 5>      $��80 �6,   6:   �� 5?      6/   .+�5B      � $��0��6   .+�5C      �� -   5         ��Name$ btnExit��5D   %   $��Right=�5C   w   $	��Top=�6�    & "MaterialDesignFloatingActionButton#��[ 6�   
������  � ToolTip$ Close��5D      $��0,10,0,0q�66   
���������5C   %   �� *SignInCommand+��6G   �� $
 window��.��5E   "   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Close=�6:   
�������$��50��6Y   $��50��6d   6r   5G      (� 5I      $
��auto��6&   $��70��63   $��Center=�6?   .��5J   "     $ PiggyBankOutline=�6:   
�������$��90��6e   $��50��6p   $��Center=�6|   5L      5M      � 5N      $��1��6   $��5q�6,   .+�5O      �� $��Đổi mật khẩu��6(   $��30(�6<   
�������$��Center=�6b   $
��Bold"�6   5P      � 5Q      $��2��6   .+�5R      �� $��Tên đăng nhập*��6(   
�������$��18(�6Q   $��20��6_   5S      � 5T      $��3��6   $��	20,0,20,0q�6,   .+�5U      �� $ 20,20,20,20��6%   
�������$��2q�6T   ._�5V   "   �� -   5         ��Name$ txtName��5Z   %   
���   �$��15(�5Y   %   $��Center=�63   $��20,0,0,0q�6U   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Nguyễn Văn A��5[   %   ��5W   '   �� *TenDangNhap+ �� UpdateSourceTrigger$ PropertyChanged=�5[   %   5\      5]      � 5^      $��4��6   .+�5_      �� $��Mật khẩu cũ*��6(   
�������$��18(�6O   $��20��6]   5`      � 5a      $��5��6   $��	20,0,20,0q�6,   .+�5b      �� $ 20,20,20,20��6%   
�������$��2q�6T   ._�5c   "   �� -   5        $ txtEmail��5g   %   
���   �$��15(�5f   %   $��Center=�63   $��20,0,0,0q�6U   $ *******��5h   %   ��5d   %   �� *	MatKhauCu+$ PropertyChanged=�5h   %   5i      5j      � 5k      $��6��6   .+�5l      �� $��Mật khẩu mới*��6(   
�������$��18(�6P   $��20��6^   5m      � 5n      $��7��6   $��	20,0,20,0q�6,   .+�5o      �� $ 20,20,20,20��6%   
�������$��2q�6T   ._�5p   "   �� -   5        $ txtPassword��5t   %   
���   �$��15(�5s   %   $��Center=�63   $��20,0,0,0q�6U   $ *******��5u   %   ��5q   %   �� *
MatKhauMoi+$ PropertyChanged=�5u   %   5v      5w      � 5x      $��8��6   .+�5y      �� $	��Top=�5z   1   $��0,20,0,0q�5{   1   $	��320��5|   1   $��50��5}   1    " MaterialDesignRaisedDarkButton#��[ 5~   1   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 25��5   1   $7 1MaterialDesignRaisedDarkButton with Round Corners��5�   1   $��Đổi mật khẩu��5�   1   $
��Bold"�5�   1   $��20(�5�   1   ��5�   !   �� *
DoiMatKhau+��5�   !   �� $
 window��5�      5�      � 5�      $��9��6    5�      �� 5�   "   65   �� 5�   "   65   .+�5�      � $��0��6#   .+�5�   "   �� $��Đã có tài khoản?��6,   $	��Top=�6D   $��Right=�6\   
���   �$��13(�6�   5�      � 5�      $��1��6#   .+�5�   "   �� $	��Top=�6,   $
��Left=�6D   
���� ��$��15(�6s   $��5,-3,0,0q�6�   $
��Bold"�6�   �� 5�   '    �� Command 61   �� *SignInCommand+ �� CommandParameter 6S   �� $
 window��.�6�   Đăng Nhập5�   '   5�   #   5�      5�      5�      5�      5�      5�      5�      5�      