   M S B A M L   `   `   `  ���� B  >OPD_GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:OPD_GUI.UserControlsOPD_GUI.UserControls  .    (OPD_GUI.UserControls.AdminProductControl   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     4local"clr-namespace:OPD_GUI.UserControls     $��Arial)�$��14(�.����   �� CornerRadius$  20��$
��1000��$	��600��$��Center=�����  �� ImageSource$! /Images/adminbackground.jpg�� j� Stretch$
 Fill=� j� TileMode$
 None=�._�� $
}�True��$��20,20,20,20q� � ColumnDefinitions �� $	��100 ��� .+��� $��0�� � 	Resources  �� 
TargetType �� Property �� Value	 �� 
TargetType
 �� 
Background � Cursor �� Bullet �� Triggers P� Property P� Value �� 
TargetName��%�  '	�       �� " 	�.���  � �� �� "	 	�.R��� 

 �����$
 Hand�� � $��16��$��16��.+��� $��
RadioOuter��
������ 
�������$��2q�$  2���� $��	RadioMark��$  0��$��4q����	#FFADADAD$y�Hidden=�._��� $��3,1,0,0q����	#FF3E3E3E$��Calibri)�$��12(���  P�  �@d�	IsChecked$
 trueY�. ��� $ 	RadioMark�� � y�$ Visible=��� $ 
RadioOuter�� � �� �	#FFADADAD.+�	� -   $��AllProductsBtn�� 	� 	GroupName$ ProductsBtn��$��All Products��	� -   $ ProductsBtn��$��Pedal��	� -   $ ProductsBtn��$��Board��	� -   $ ProductsBtn��$��	Component��&   System.Windows.Controls.DataGrid  -   $��
ProductsDG�� J� Opacity$	 0.7Q�$��1��   AutoGenerateColumns$
 True��   CanUserAddRows$ False��   CanUserDeleteRows$ False��$��11(�$��Arial)�����  �� Source$	 lst��