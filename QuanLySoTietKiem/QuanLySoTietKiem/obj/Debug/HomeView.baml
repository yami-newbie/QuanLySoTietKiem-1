   M S B A M L   `   `   `  ����K  GQuanLySoTietKiem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:QuanLySoTietKiemQuanLySoTietKiem  5      U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5          QuanLySoTietKiem.HomeView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:QuanLySoTietKiem     5      Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
      .chart1!http://schemas.syncfusion.com/wpf  5       
  HomeVM  � DataContext#  [  5	        MaterialDesignBody#���  5      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5      .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      6%   �� 5      6%   �� 5      6%   .+�5       � $��0��6   .+�5!      �� $	��180��6   $��
20,0,20,40q�6)   
������� �� RadiusY$ 10��6J    �� RadiusX$ 10��6W    J� Effect 5"      3  -System.Windows.Media.Effects.DropShadowEffect  5#         
BlurRadius$ 20Q�6+   	   Color$	 	#FFDEDEDE��6;   
   RenderingBias$
 Quality=�6M      ShadowDepth$ 1Q�6e   5%      � 5&      $��0,0,0,50q�6   $	��160��6)   .+�5'      � $��35��6   $��50��6&   ���	#FFFFAF24$
��Left=�6I   $	��Top=�6d   $��40 -6q�6|    5(        5)      $ 20Q�6/   $	 	#FFECECEC��6?   $
 Quality=�6Q   $ 1Q�6i   .+�5+      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ AccountDetailsOutline=�62   $��Center=�6O   $��Bottom=�6l   $��5q�6�   
�������$��20��6�   $��20��6�   5,      �� 5-      $��Khách hàng��6    $��Right=�62   $��Champagne & Limousines)�6N   $��0,6,25,0q�6v   $	��Top=�6�   
�������$��25(�6�   �� 5.       �� Orientation$ 
Horizontal=�6!   $��Right=�6:   $	��Top=�6V   $��35 50q�6n   .+�5/      �� $��Champagne & Limousines)�6>   $��Center=�6f   
�������$��50(�6�   $��0,5,5,0q�6�   ��6$   �� *
countCus+6�   �� 50      $��Người��6$   $��Champagne & Limousines)�61   $	��0 5q�6Y   
�������$��20(�6x   $��Bottom=�6�   51      �� 52      $ 
Horizontal=�6!   $��Bottom=�6:   $��	30,0,10,0q�6U    � Cursor$
 Hand��6h   .+�53        $
 User=�62   
���  ��$��10��6O   $��10��6Z   $��Center=�6f   $	��5 0q�6�   �� 54      $,��&Bao gồm đang dùng và từng dùng��6$   $��10(�6J   ���	#FF8522BD6X   55      56      57      � 58      $��1��6   .+�59      �� $	��180��6   $��
20,0,20,40q�6)   
�������$ 10��6J   $ 10��6W    5:        5;      $ 20Q�6+   $	 	#FFDEDEDE��6;   $
 Quality=�6M   $ 1Q�6e   5=      � 5>      $��0,0,0,50q�6   $	��160��6)   .+�5?      � $��35��6   $��50��6&   ���	#FF41A43C$
��Left=�6I   $	��Top=�6d   $��40 -6q�6|    5@        5A      $ 20Q�6/   $	 	#FFECECEC��6?   $
 Quality=�6Q   $ 1Q�6i   .+�5C        $ BookEdit=�62   $��Center=�6B   $��Bottom=�6_   $��5q�6z   
�������$��20��6�   $��20��6�   5D      �� 5E      $��Sổ hoạt động��6    $��Right=�64   $��Champagne & Limousines)�6P   $��0,6,25,0q�6x   $	��Top=�6�   
�������$��25(�6�   �� 5F      $ 
Horizontal=�6!   $��Right=�6:   $	��Top=�6V   $��35 50q�6n   .+�5G      �� $��Champagne & Limousines)�6?   $��Center=�6g   
�������$��50(�6�   $��0,5,5,0q�6�   ��6$   �� *	countSoMo+6�   �� 5H      $
��Sổ��6$   $��Champagne & Limousines)�6.   $	��0 5q�6V   
�������$��20(�6u   $��Bottom=�6�   5I      �� 5J      $ 
Horizontal=�6!   $��Bottom=�6:   $��	30,0,10,0q�6U   $
 Hand��6h   .+�5K        $ Calendar=�62   
���  ��$��10��6S   $��10��6^   $��Center=�6j   $	��5 0q�6�   �� 5L      $4��.Tổng sổ tiết kiệm đang hoạt động��6$   $��10(�6L   ���	#FF8522BD6Z   5M      5N      5O      � 5P      $��2��6   .+�5Q      �� $	��180��6   $��
20,0,20,40q�6)   
�������$ 10��6J   $ 10��6W    5R        5S      $ 20Q�6+   $	 	#FFDEDEDE��6;   $
 Quality=�6M   $ 1Q�6e   5U      � 5V      $��0,0,0,50q�6   $	��160��6)   .+�5W      � $��35��6   $��50��6&   ���	#FFCF1F1F$
��Left=�6I   $	��Top=�6d   $��40 -6q�6|    5X        5Y      $ 20Q�6/   $	 	#FFECECEC��6?   $
 Quality=�6Q   $ 1Q�6i   .+�5[        $ AlertOctagramOutline=�62   $��Center=�6N   $��Bottom=�6k   $��5q�6�   
�������$��20��6�   $��20��6�   5\      �� 5]      $��Sổ đã đóng��6    $��Right=�62   $��Champagne & Limousines)�6N   $��0,6,25,0q�6v   $	��Top=�6�   
�������$��25(�6�   �� 5^      $ 
Horizontal=�6!   $��Right=�6:   $	��Top=�6V   $��35 50q�6n   .+�5_      �� $��Champagne & Limousines)�6A   $��Center=�6i   
�������$��50(�6�   $��0,5,5,0q�6�   ��6$   �� *countSoDong+6�   �� 5`      $
��Sổ��6$   $��Champagne & Limousines)�6.   $	��0 5q�6V   
�������$��20(�6u   $��Bottom=�6�   5a      �� 5b      $ 
Horizontal=�6!   $��Bottom=�6:   $��	30,0,10,0q�6U   $
 Hand��6h   .+�5c        $ AlertOutline=�62   
���  ��$��10��6W   $��10��6b   $��Center=�6n   $	��5 0q�6�   �� 5d      $5��/Tổng sổ tiết kiệm ngưng hoạt động��6$   $��10(�6M   ���	#FF8522BD6[   5e      5f      5g      5h      � 5i   
   $��1��6    5j      �� 5k      $
��Auto �6    60   �� 5l      6#   .+�5n      � $��0��6   .+�5o      �� $��30,0,0,0q�5p      $��Right=�5q      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Năm thống kê:��5r       & "MaterialDesignFloatingHintComboBox#��[ 5u      ��5s      �� *	listNam+ �� SelectedItem 5t      �� *SelectedNam+ �� UpdateSourceTrigger$ PropertyChanged=���5v      �� 5w      .R�5x      $� 5y      5{      5|      � 5}      $��1��6    5~      �� 5      $	��300��6'   68   �� 5�      6)   .+�5�      � $��0��6   .+�5�        LiveCharts.Wpf.PieChart  -   5        $��Chart��5�   #   &   LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$	 Top=�5�         InnerRadius$ 60Q�6,   $��0,0,30,0q�6=      Series 5�   1   �� *SeriesCollection1+   ChartLegend 5�      "  LiveCharts.Wpf.DefaultLegend  5�         
BulletSize$ 20Q�60   6B      DataTooltip 5�      #  LiveCharts.Wpf.DefaultTooltip  5�         
BulletSize$ 20Q�61   6C   5�      5�      � 5�      $��1��6   $��Stretch=�6'   $��Stretch=�6E   .+�5�      #	  LiveCharts.Wpf.CartesianChart	  $	 Top=�6M    6)   �� *SeriesCollection+   AxisX 5�      
  LiveCharts.Wpf.Axis
  $��Bottom=�6'    
  Title$  Biểu đồ thống kê��6B    
  Labels 6\   �� *Labels+6x      AxisY 5�      
  $ Tiền��6'    
  LabelFormatter 64   �� *	Formatter+6[   5�      5�      �� 5�      $ 
Horizontal=�6   $��Bottom=�66   $��0,0,0,0q�6Q   $
 Hand��6b   .+�5�        $ Calendar=�6.   
���  ��$��10��6O   $��10��6Z   $��Center=�6f   $	��5 0q�6�   �� 5�      $^��XTổng sổ tiết kiệm đang hoạt động tương ứng với các loại kì hạn��6    $��10(�6f   
�������6t   5�      5�      5�      5�      5�      