   M S B A M L   `   `   `  ���� F  BDataControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullJ4clr-namespace:DataControl.Utils;assembly=DataControlDataControl.Utils  B >OPD_GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:OPD_GUI.UserControlsOPD_GUI.UserControls .   (OPD_GUI.UserControls.AdminProductControl   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Cda4clr-namespace:DataControl.Utils;assembly=DataControl     4local"clr-namespace:OPD_GUI.UserControls     $��Arial)�$��14(�.����   �� CornerRadius$  20��$
��Auto��$
��Auto��$��Center=�._�� -   $��RadioBtnGrid��$
}�True��$��	10,0,10,0q� � ColumnDefinitions �� $	��250 ��� $
��Auto ��� $
��Auto �.+��� $��0�� � 	Resources  �� 
TargetType �� Property �� Value �� 
TargetType �� 
Background � Cursor	 �� Bullet
 �� Triggers P� Property P� Value �� 
TargetName��%�  '	�       �� " 	�.���  � �� �� " 	�.R��� 
 �����$
 Hand��	 � $��16��$��16��.+��� $��
RadioOuter��
������ 
�������$��2q�$  2���� $��	RadioMark��$  0��$��4q����	#FFADADAD$y�Hidden=�._��� $��3,1,0,0q����	#FF3E3E3E$��Calibri)�$��12(��� 
 P�  �@d�	IsChecked$
 trueY�. ��� $ 	RadioMark�� � y�$ Visible=��� $ 
RadioOuter�� � �� �	#FFADADAD.+��� $��WrapWithOverflow=�$��Center=� �� TextAlignment$ Center=�Choose Product Type	� -   $��AllProductsBtn�� 	� 	GroupName$ ProductsBtn��$��All Products��	� -   $ ProductsBtn��$��Pedal��	� -   $ ProductsBtn��$��Board��	� -   $ ProductsBtn��$��	Component���� $��30���� $��2��
�������$  10��$	��1.5q�$��0,0,0,0q�
���   �._��� -   $��EditProductStck��.+��� $��Edit New Product��$��Center=�
��� � �� -   $��EditProductGrid�� ��%�   '��       '�� W     '	� �     �� " ��.���  � ��$
 Left=���  � ��$ 0,10,0,0q���  � ��$ 12(��� " ��.���  � ��$ 0,10,0,0q���  � ��$ 10(��� " 	�.���  � ��$ 0,10,0,0q� �� $	��100 ��� $	��250 � � RowDefinitions �� �� �� �� �� �� �� �� .+��� $��Product Name :��$��0��$��0���� -   $��EditProductName��$�� ��$	��120��$��1��$��0���� $��Product Price :��$��0��$��1���� -	   $��EditProducPrice��$�� ��$	��120��$��1��$��1���� $��Pedal Description��$��0��$��2���� -
   $��EditPedalDescription��${�False��$��1��$��2��$��Description��$	��120���� $��0��$��3��$��Board Dimensions:���� -   $��EditDimensionBlck��${�False��$��3��$��1���� -   $��EditBoardWidth��$��W��$��30�� X �� -   $��EditBoardHeight��$��H��$��30���� $��QTY/Lot��$��0��$��4���� -   $��EditQuantity��${�False��$��4��$��1��$��Qty/Lot��$	��120���� $��Effect Type :��$��0��$��5���� -   $��EditEffectTypeCmb��$��20��$��5��$
��Left=�$��1��$	��140���� $��Component Type :��$��0��$��6���� -   $��EditComponentTypeCmb��$��20��$��6��$
��Left=�$��1��$	��140��{��� *	IsChecked+ �� ElementName$ ComonentPTRadio���� $��0,10,0,0q��� -    ��Name$ EditProductBtn��$��0,0,0,10q�$	��150��$��30��$��Edit Product��&   System.Windows.Controls.DataGrid  -     Name$ 
ProductsDG��$
��Auto��$
��Auto�� J� Opacity$	 0.7Q�$��1��   AutoGenerateColumns$
 True��   CanUserAddRows$ False��$��50,0,0,0q�   CanUserDeleteRows$ False��   
IsReadOnly$
 True��$��11(�$��Arial)�����  �� Source$	 lst���� $��2��
�������$  10��$	��1.5q�$��20,0,0,0q�
���   �._��� -   $��AddProductStck��.+��� $��Add New Product��$��Center=�
��� � �� -   $��AddProductGrid�� ��%�   '��       '�� A     '	� j     �� " ��.���  � ��$
 Left=���  � ��$ 0,10,0,0q��� " ��.���  � ��$ 0,10,0,0q��� " 	�.���  � ��$ 0,10,0,0q� �� �� $	��150 � �� �� �� �� �� �� �� �� .+��� $��Product Name :��$��0��$��0���� -   $��AddProductName��$�� ��$	��120��$��1��$��0���� $��Product Price :��$��0��$��1���� -   $��AddProducPrice��$�� ��$	��120��$��1��$��1��	� -   $��PedalPTRadio��$��2��$��0��$��Pedal��$ AddPT���� -   $��AddPedalDescription��$��1��$��2��$��Description��$	��120��{��� *	IsChecked+$ PedalPTRadio��	� -   $��BoardPTRadio��$��3��$��0��$��Board��$ AddPT���� $��3��$��1���� -   $��AddBoardWidth��$��W��$��30��{��� *	IsChecked+$ BoardPTRadio�� X �� -   $��AddBoardHeight��$��H��$��30��{��� *	IsChecked+$ BoardPTRadio��	� -   $��ComonentPTRadio��$��4��$��0��$��	Component��$ AddPT���� -   $��AddQuantity��$��4��$��1��$��Qty/Lot��$	��120��{��� *	IsChecked+$ ComonentPTRadio���� $��Effect Type :��$��0��$��5���� -   $��EffectTypeCmb��$��20��$��5��$
��Left=�$��1��$	��120���� $��Component Type :��$��0��$��6���� -   $��ComponentTypeCmb��$��20��$��6��$
��Left=�$��1��$	��120��{��� *	IsChecked+$ ComonentPTRadio���� $��Initial Inventory :��$��0��$��7���� -    $��AddInventoryTxt��$��7��$��1��$��1��$��50�� �� TextAlignment$ Center=��� $��0,20,0,0q��� -!   $��
ProductImg��$��	0,10,0,10q�$��/images/blank.jpg��$	��100��$	��150���� $��	0,20,0,10q��� -"   $ AddProductBtn��$	��150��$��30��$��Add Product��