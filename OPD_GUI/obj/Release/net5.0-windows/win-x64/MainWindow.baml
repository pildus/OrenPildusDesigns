   M S B A M L   `   `   `  ���� B  >OPD_GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:OPD_GUIOPD_GUI  F BDataControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullJ4clr-namespace:DataControl.Utils;assembly=DataControlDataControl.Utils J4clr-namespace:DataControl.Model;assembly=DataControlDataControl.Model     OPD_GUI.MainWindow   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     'localclr-namespace:OPD_GUI     Bu4clr-namespace:DataControl.Utils;assembly=DataControl     Ba4clr-namespace:DataControl.Model;assembly=DataControl       � Title$  Oren Pildus Designs��$	��800��$
��1280��$��
Bebas Neue)�$��20(�
������� � WindowStyle$
 None=� � Icon$ /images/pedal.png�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=�����  �� ImageSource$  /Images/mainbackground.jpg�� j� Stretch$
 Fill=� j� TileMode$
 None=�.��� -   $��grid1��$	��Top=�$
��Left=� � ShowGridLines$ false��$
��1280��
������ 	 � ColumnDefinitions	 �� $	��100 ��� 
 � RowDefinitions
 �� $��70 ���  � 	Resources  �� 
TargetType �� Property �� Value �� 
TargetType J� Opacity �� CornerRadius ��Name �� Triggers P� 
SourceName P� Property P� Value �� 
TargetName��%�  '��       '�� %     '�� �    �� " ��.���  � ��
 �   ��� " ��.���  � ��$ 30(���  � ��$
 Bold"���  � ��$	 100����  � ��$ 0q���  � �� �� " ��.R��� $��Border��
������ $	 0.9Q�$ 5��$��	0,10,0,10q�._��� $ ContentSite��$��Center=�$
��Left=�$��Header��$
��10,2q� P� $ Border�� �@J�IsMouseOver$
 True��. ��� $ Border�� � ��
 ��  ��� " ��.���  � ��
 ���� ��  � ��$ 0q�.+�� $��2��	 �� $	��220 ��� $��70 ��� $	��920 ��� $��70 �.+��� 
���   �$��2��$��0��
�������$��4���� -   $��lblHello��$
��Left=�$��Center=�$��Hello��$��0���� -   $��40��$��40��$��/images/logout2.png��$��0��$��Center=�$��Right=� � Cursor$
 Hand���� -   $��ShoppingCartStackPanel��$��1��$��0,5,0,0q�.+��� $��images/ShoppingCart.png��$��40��$��40���� -   $��ShoppingCartCount��$	��(0)��$��16(�$
 Hand��
��� ���$��Center=��� -   $��EffectStackPanel��$��Center=�$��Center=� �� Orientation$ 
Horizontal=�$��2��$��5,5,5,5q� ��%N   '��       �� " ��.���  � ��
 �OO/���  �@�Cursor$
 Hand���� -   $��40��$��40��$��/images/exit.png��$��3��$��Center=�$
 Hand���� -   $��ProductStackPanel��$��1��$��0��$��2�� �� TabStripPlacement$
 Left=�$��0, 0, 0, 10q�