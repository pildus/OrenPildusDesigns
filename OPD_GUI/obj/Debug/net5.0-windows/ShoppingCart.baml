   M S B A M L   `   `   `  ����B  >OPD_GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:OPD_GUIOPD_GUI  5   	       OPD_GUI.ShoppingCart   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:OPD_GUI     5   	     � Title$  ShoppingCart��5   	   $	��550��6   $	��750��6+   $��30(�5   	   
������� � WindowStyle$
 None=�6*    � 
ResizeMode$ NoResize=�5	   	   $��
Bebas Neue)�6    � AllowsTransparency$
 True��5
   	    J� Opacity$
 0.95Q�6#    � WindowStartupLocation$ CenterScreen=�5   	    � Icon$ /images/ShoppingCart.png��6.   ��5      �� 5   
    �� ImageSource$ /images/background.jpg��6   6<   .��5      �� 
���   �$��5q�6!   ._�5      � 
������  � ColumnDefinitions 5      �� 5      6)   �� 5      6)   	 � RowDefinitions	 5      �� 5      $��50 �6$   62   �� 5      6&   �� 5      $��50 �6$   62   
 � 	Resources
 5       �� 
TargetType �� Property �� Value��%}   '��       �� 5       " ��6   .�5!      ��  � ��$ 18(�65   6B   �� 5"       � ��
 �  ��6E   5#      5$      .+�5&      �� $��Shopping Cart��6   $��Center=�6,   $��0��6I   $��0��6Y   $��2��6f   6|   �� 5)      $
��Auto=�6   $��1��6>   $��2��6K   .��5*      �� -   5        $��MainDisplay��5*      5,      5.      �� 5/      -   5        $��Continue��5/      $��10,10,10,10q�6%   $��1��6:   $��2��6J   $��Continue Shopping��6W   6�   �� 50      -   5        $��Checkout��50      $��10,10,10,10q�6%   $��0��6:   $��2��6J   $��CheckOut��6W   6�   53      55      56      