   M S B A M L   `   `   `  ����K  GQuanLySoTietKiem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:QuanLySoTietKiemQuanLySoTietKiem  5      #    QuanLySoTietKiem.CustomerView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:QuanLySoTietKiem     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5         
CustomerVM  � DataContext#  [  5
        MaterialDesignBody#���  5      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5      .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      6   .+�5   
   � $��0��6   $��5q�6   .+�5      #  MaterialDesignThemes.Wpf.Card  .��5      �� $��Right=�6    �� Orientation$ 
Horizontal=�69   .+�5      �� $��Right=�5        MaterialDesignRaisedButton#���  5       +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth2=�5!      
����  ���5      �� *AddFormCommand+.��5$      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$	 Add=�62   $��20��6=   $��20��6H   5%      5/      50      51        52   
   $��1��6   $��5q�6+   .��53      � .+�54      � $��10q�6   $	��350��6#   $
��Left=�6/   .+�55      �� $��10q�57      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tìm kiếm��58       ! MaterialDesignOutlinedTextBox#��[ 59      ��56      �� *Query+59      5:      � 5;      $��	380 0 0 0q�6   $	��250��6*   $
��Left=�66   .+�5<      �� $��10 10 10 10q�5>      $��10q�5@      $ 
Tiêu chí��5A       " MaterialDesignOutlinedComboBox#��[ 5B       �� SelectedItem 5=      �� *SelectedFilter+��5?      �� *
FilterList+5B      5C      � 5D      $��	650 0 0 0q�6   $	��140��6*   $
��Left=�66   .+�5E      �� $	��110��6   
���"�"�
���"�"�
�������   MaterialDesignOutlinedButton#��[ 5J      $��Tìm kiếm��5K      ��5F      �� *SearchCommand+5K      5L      5M      5N      � 5O   
   $��2��6   $��5q�6   $��Stretch=�6'   .+�5P        .��5Q      �� $
��Auto=�6   .��5R      �� -  'MaterialDesignThemes.Wpf.ListViewAssist	   ListViewItemPadding$	 
23 10 0 10q�6   ��6_   �� *List+ 6|   �� *SelectedItem+
 �� Mode$
 TwoWay=�.  (System.Windows.Interactivity.Interaction   Triggers 5S      /  )System.Windows.Interactivity.EventTrigger  5T         	EventName$ MouseDoubleClick��6-   .	  (System.Windows.Interactivity.TriggerBase 	  Actions. 5U   "   6
  0System.Windows.Interactivity.InvokeCommandAction
   
  Command 68   �� *EditFormCommand+5V       � 	Resources 5X        ColHeaderText �� 
TargetType �� Property �� Value��%x   &	       �� 5Y      " ��6:   .�5Z   "   ��  � ��$ 17(�6=   �� 5[   "    � ��$
 Bold"�6?   5\      5]       �� View 5^      �� 5_      .P�5`   "   ��  �� DisplayMemberBinding 63   �� *MaKhachHang+.��5a   &   �� $��Mã khách hàng��60   #��[ 6F   6o   5c   #   �� 5d   "    62   �� *TenKhachHang+.��5e   &   �� $��Tên khách hàng��60   #��[ 6G   6p   5g   #   �� 5h   "    62   �� *CMND+.��5i   &   �� $��	Số CMND��60   #��[ 6@   6i   5k   #   �� 5l   "    62   �� *DiaChi+.��5m   &   �� $��Địa chỉ��60   #��[ 6@   6i   5o   #   5p      5r      5s      5t      5u      5v      5w      