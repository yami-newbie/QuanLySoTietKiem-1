   M S B A M L   `   `   `  ����K  GQuanLySoTietKiem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:QuanLySoTietKiemQuanLySoTietKiem  5   	   "    QuanLySoTietKiem.LoginWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:QuanLySoTietKiem     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  66   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	   	   -   5          �Name$  window��5   	    � Title$ LoginWinDow��5
      $	��420��6   $	��800��6)    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	      LoginVM � DataContext# [  5   	   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ MouseLeftButtonDown��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction  	   Command	 6$   �� *DragMoveCommand+
   CommandParameter
 6H   ��  �� ElementName$ window��5      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��300 �6   6-   �� 5      $
��Auto �6   6.   .+�5   
   � $��0��6   $��2��6   $��0,0,464.6,0q�63    � RowDefinitions 5      �� 5      6"   �� 5      6"   .+�5       � $��0��6   .+�5!      �� $��/Images/logo.jpg��6   $��Center=�62   $	��300��6O   $	��250��6[   $��40,0,-35.2,-50q�6h   6�   5#      � 5$      $��1��6   .+�5%      �� $��/Images/5869.jpg��6   $��-37,20,-108.6,0q�62   5&      5'      � 5(   
   $��1��6   $��115,0,-0.4,0q�6   .+�5)      �� -   5         ��Name$ btnExit��5*   %   $��Right=�5)   e   $	��Top=�6�    & "MaterialDesignFloatingActionButton#��[ 6�   
������  � ToolTip$ Close��5*      $��0,10,-24.4,0q�66   
���  ����5)      �� *ExitCommand+��65   �� $ window��.��5+      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Close=�6*   
���   �$��50��6J   $��50��6U   6c   5-      � 5.       50      �� 51      $��50 �6$   62   �� 52      $��50 �6$   62   �� 53      $	��200 �6$   63   �� 54      $��50 �6$   62   .+�57      �� $��4��6    �� CornerRadius$ 0,180,0,150��6*   $	��Top=�6E   $	��390��6]   $��-78,15,-23.,-60q�6j   ��58      �� 59      .��5:      �  � Color$ 	#FFE63070��6+    � Offset$ 0Q�6=   � 5;      $ 	#FFFE8704��6+   $ 1Q�6=   5<      5>      � 5?      $��1��6   .+�5@      (� $
��auto��6   $
��auto��6+   $��Center=�69   $��0,0,30,0q�6V   .��5A        $ PiggyBankOutline=�62   
�������$
��auto��6]   $
��auto��6j   $��Center=�6x   5C      5D      � 5E      $��2��6   .+�5F      �� $��Đăng Nhập ��6    $��Center=�62   $	��180��6O   $��30(�6[   $��5q�6i   
�������$
��Bold"�6�   5G      � 5H      $��2��6   
������ $��-28,41.6,27.8,10.4q�6=   $��2��6Y   .+�5I      �� 
������ 
�������$��1q�6J   $ 10,10,10,10��6^   $	��350��6y   $	��200��6�   $��10,10,-8,-9.2q�6�   ._�5J      �� $��5q�6%   $	��200��60   .+�5K      #  MaterialDesignThemes.Wpf.Card  $	��300��62   $	��200��6>   $��Center=�6K   $��Center=�6h   
������ $��2q�6�   
��� � �.��5M   "   � $	��200��6'    5O   &   �� 5P   *   $
��Auto �68   6H   �� 5Q   *   $��70 �68   6F   �� 5R   *   $��70 �68   6F   .+�5V   &   � $��0��6+   $��5q�68   .+�5W   *     $
 User=�6B   $��50��6N   $��35��6Y   
�������$��Center=�6x    J� RenderTransformOrigin$ 0.372,2.143&�6�   $��0,10,0,-8.2q�6�   �� 5X   *   $	��190��5Z   -   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tên đăng nhập��5[   -   
������� % !MaterialDesignFloatingHintTextBox#��[ 5]   -   $��Center=�5^   -   ��5Y   -   �� *
UserName+5^   -   5_   '   � 5`   &   $��1��6-   $��5q�6:    5a   *   �� 5b   .   $
��Auto �6<   6L   �� 5c   .   6?   .+�5e   *   � $��0��6/   .+�5f   .     $ Password=�6F   $��50��6V   $��30��6a   
�������$��Bottom=�6�   $��	0,10,0,-5q�6�   G� 5g   .   -   5         G�Name$ PasswordBox��5h   1   $	��190��5i   1   
�������$ Mật khẩu��5k   1      
Foreground
 �� ��.  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush
 �� �� ) %MaterialDesignFloatingHintPasswordBox#��[ 5n   1   $��Center=�5o   1    5p   2     5q   6   $ PasswordChanged��6E   . 5r   :     	 6P   �� *PasswordChangedCommand+
 6{   �� $ PasswordBox��5s   7   5u   /   5v   +   � 5w   *   $��1��6/    5x   .   �� 5y   2   $
��274* �6C   �� 5z   2   $	��17* �6C   .+�5|   .   �� -   5        $��Quên mật khẩu?��5|   8   $��Right=�6N   $��Center=�6j   $��13(�6�   
���� ��$��0,6,9.4,0.8q�6�   $��2��6�   6�   5~   +   5�   '   � 5�   &   $��2��6+   .+�5�   *   � .+�5�   .   �� $	��Top=�5�   1   $��0,10,0,0q�5�   1   $	��290��5�   1   $��40��5�   1    " MaterialDesignRaisedDarkButton#��[ 5�   1   +	  %MaterialDesignThemes.Wpf.ButtonAssist 	  CornerRadius$ 25��5�   1   $ Đăng nhập��5�   1   $��Đăng nhập��5�   1   $
��Bold"�5�   1   ��5�   1   �� *LoginCommand+��5�   1   �� $ window��5�   /   5�   +   �� 5�   *   $&�� Muốn thay đổi mật khẩu?��64   $��Bottom=�6S   $��0,0,0,1q�6n   $
��Left=�6   
���   �6�   �� 5�   *   $��Bottom=�64   $��Center=�6O   $��60,0,0,2q�6l   $��13(�6~   
���� ��$
��Bold"�6�   �� 5�   .    �� Command 68   �� *RegisterCommand+ �� CommandParameter 6\   �� $ window��.�6�   Đổi mật khẩu5�   /   5�   +   5�   '   5�   #   5�      5�      5�      5�      5�      5�      5�      5�      