   M S B A M L   `   `   `  ���� B  >OPD_GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:OPD_GUI.UserControlsOPD_GUI.UserControls  $    OPD_GUI.UserControls.MyAccount   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     4local"clr-namespace:OPD_GUI.UserControls     $
��1180��$	��730��$��14(�.��� 
������ $
��1180��$	��730��  � ColumnDefinitions  �� $��* ��� $��* � � RowDefinitions �� �� .+��� -   $��	MyDetails��$��0��$��0��$	��300��$	��250��$��20,20,20,20q�
������� �� CornerRadius$ 30��$	��Top=�._��� $��0��$��0��$��10,10,10,10q�$
��Left=� � 	Resources  �� 
TargetType �� Property �� Value��%\   '��       �� " ��.���  � ��$ 16(���  � ��
 �   ���  � ��$	 200��.+��� $��
My Details��$��Center=�
��� � ��� $��
First Name���� -   $��fName��$��
First Name���� $��	Last Name���� -   $��lName��$��	Last Name���� $��	User Name���� -   $��UserName��${�False��$��Username���� $��Email���� -   $��email��${�False��$��Email���� �� -   $��UpdateDetailsBtn��$��Updtae Details���� -   $��
MyPassword��$��1��$��0��$	��300��$��250                 ��$��20,20,20,20q�
�������$ 30��$	��Top=�._��� $��10,10,10,10q�$
��Auto��$
��Left=� ��%\   '��       �� " ��.���  � ��$ 16(���  � ��
 �   ���  � ��$	 200��.+��� $��My Password��$��Center=�
��� � ��� $��Current Password��G� -   $��CurPass���� $��New Password��G� -	   $��NewPass���� $��Verify New Password��G� -
   $��VerPass���� $��10q��� -   $��UpdatePasswordBtn��$��Updtae Password��$��Bottom=��� -   $��MyOrders��$��0��$��1��$��2��$	��300��$	��700��$��20,20,20,20q�
�������$ 30��$	��Top=�._��  �� $��50 ��� .+��� $��0��$��	My Orders��$��Center=�
��� � �$��26(���  �� Orientation$ 
Horizontal=�$��1��.+��� $��10,10,10,10q�.+��� $��Pick start Date :��(  "System.Windows.Controls.DatePicker  -   $��	startDate���� $��Pick end Date :��  -   $��endDate���� -   $��filterByDates��$��0,5,0,5q�$��Filter By Dates���� �� -   $��resetFilters��$��0,5,0,5q�$��Reset Filter���� $��Stretch=�$��1��$��2q�
���   �&   System.Windows.Controls.DataGrid  -   $��OrderDG��$
��Auto��$
��Auto��$��Center=�$��20,20,20,20q�$��14(�   RowStyle �� )  #System.Windows.Controls.DataGridRow"  .���  �@J�IsHitTestVisible$ False��