   M S B A M L   `   `   `  ����B  >OPD_GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:OPD_GUIOPD_GUI  5   	   F BDataControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullJ4clr-namespace:DataControl.Utils;assembly=DataControlDataControl.Utils 5   	   J4clr-namespace:DataControl.Model;assembly=DataControlDataControl.Model 5   	       OPD_GUI.MainWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:OPD_GUI     5   	   Bu4clr-namespace:DataControl.Utils;assembly=DataControl     5   	   Ba4clr-namespace:DataControl.Model;assembly=DataControl     5   	     � Title$  Oren Pildus Designs��5
   	   $	��800��6%   $
��1280��62   $��
Bebas Neue)�5   	   $��20(�6!   
������� � WindowStyle$
 None=�6B    � Icon$ /images/pedal.png��6U    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�6&   ��5      �� 5   
    �� ImageSource$  /Images/mainbackground.jpg��6    j� Stretch$
 Fill=�6>    j� TileMode$
 None=�6M   .��5      � -   5        $��grid1��5      $	��Top=�5      $
��Left=�6     � ShowGridLines$ false��5      $
��1280��6/   
������ 	 � ColumnDefinitions	 5   
   �� 5      $	��100 �6   �� 5      
 � RowDefinitions
 5   
   �� 5      $��70 �6   �� 5       � 	Resources 5!   
    �� 
TargetType �� Property �� Value �� 
TargetType J� Opacity �� CornerRadius ��Name �� Triggers P� 
SourceName P� Property P� Value �� 
TargetName��%�  '��       '�� J     '�� A    �� 5"      " ��6   .�5#      ��  � ��
 �   �6?   5$      �� 5%      " ��6   .�5(      ��  � ��$ 20(�6-   6:   �� 5)       � ��$
 Bold"�6/   6>   �� 5*       � ��$	 120��6+   69   �� 5+       � ��$ 0q�64   6@   �� 5,       � ��$ Center=�68   �� 5-       � �� 5.      �� 5/      " ��6*   .R�50      �� $��Border��6%   
������ $	 0.9Q�6L   $ 5��6Z   $��	0,10,0,10q�6k   ._�51   "   �� $ ContentSite��63   $��Center=�52   !   $
��Left=�53   !   $��Header��54   !   $
��10,2q�55   !   56       57      P� 58   "   $ Border��6N    �@J�IsMouseOver$
 True��6A   . �59   &   �� $ Border��6-    � ��
 �����6W   �� 5:   &   $ Border��6-    �@J�Opacity$	 0.5Q�6T   5;   #   5=      5?      5@      �� 5A      " ��6   .�5B      ��  � ��
 ���� 6E   �� 5C       � ��$ 0q�64   6@   5D      5E      .+�5H   
   � $��2��6   	 5I      �� 5J      $	��220 �6#   61   �� 5K      $��70 �6#   60   �� 5L      $	��920 �6#   61   �� 5M      $��70 �6#   60   .+�5O      �� 
���   �$��2��6'   $��0��6;   
�������$��4��6Y   �� 5Q      -   5        $��lblHello��5Q      $
��Left=�6$   $��Center=�6?   $��Hello��6Z   $��0��5R      �� 5T      -   5        $��40��5T      $��40��6   $��/images/logout2.png��6+   $��0��6H   $��Center=�5U      $��Right=�6/    � Cursor$
 Hand��5V   H   �� 5Y      -   5        $��ShoppingCartStackPanel��5Y      $��1��67   $��0,5,0,0q�6G   .+�5Z      �� $��images/ShoppingCart.png��6   $��40��6:   $��40��6E   �� 5[      -   5        $��ShoppingCartCount��5\      $	��(0)��65   $��16(�6@   $
 Hand��6N   
��� ���$��Center=�5]   4   5^      5_      �� 5b      -   5        $��EffectStackPanel��5b      $��Center=�5c      $��Center=�6+    �� Orientation$ 
Horizontal=�5d      $��2��62   $��5,5,5,5q�6B    5e      ��%�   '��       �� 5f      " ��6   .�5g      ��  � ��
 �OO/�6O   �� 5h       �@�Cursor$
 Hand��63   6B   5i      5j      5k      �� 5p      -   5        $��40��5p      $��40��6   $��/images/exit.png��6+   $��3��6E   $��Center=�6U   $
 Hand��5q   F   5u      �� 5y   
   -   5        $��ProductStackPanel��5z      $��1��5y      $��0��6"   $��2��62    �� TabStripPlacement$
 Left=�5z   .   $��0, 0, 0, 10q�5{      5~      5      5�      