   M S B A M L   `   `   `  ����B  >OPD_GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:OPD_GUIOPD_GUI  5   	       OPD_GUI.SignupScreen   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:OPD_GUI     5   	   -   5          � Title$  Sign Up��5   	   $	��580��6   $	��300��6&   $��12(�62    � WindowStartupLocation$ CenterScreen=�6A   ��5      �� 5   
    �� ImageSource$  /Images/mainbackground.jpg��6    j� Stretch$
 Fill=�6>    j� TileMode$
 None=�6M   .��5      �� ���#0f0f2d �� CornerRadius$ 20��6"   $��20q�64    J� Opacity$	 0.9Q�6@   ._�5   
   �� $��20q�6   .+�5      �� $��Sign Up��6   
�������$��25(�69   $��Center=�6G   �� 5      6   �� 5      $��
First Name��6   
�������6)   �� 5      -   5        $��txtFName��5      ���#545d6a
�������$��18(�6N   �� 5      $��	Last Name��6   
�������6(   �� 5      -   5        $��txtLName��5      ���#545d6a
�������$��18(�6N   �� 5      $��Email��6   
�������6$   �� 5      -   5        $��txtEmail��5      ���#545d6a
�������$��18(�6N   �� 5      $��Username��6   
�������6'   �� 5      -   5        $��txtUsername��5      ���#545d6a
�������$��18(�6Q   �� 5      $��Password��6   
�������6'   G� 5      -   5        $��txtPassword��5      ���#545d6a
�������$��18(�6U   �� 5      $��Verify Password��6   
�������6.   G� 5      -   5        $��txtVerPassword��5      ���#545d6a
�������$��18(�6X   �� 5      $��8(�6   $��30��6%    �� TextAlignment$ Center=�61   $��0,5,0,0q�6H   $��Center=�6Y   $��Center=�6v   $
��Wrap=�6�   
�������$j��dPassword must be at leat 8 charachters, min 1 Uppercase [A-Z],min 1 number [0-9], min 1 symbol [~-?]��6�   �� 5       -   5        $��	btnSignUp��5&   O   $��Sign Up��5       
�������$��14(�5"      $
��Bold"�5#      $��20q�6'   $	��106��5$      $��Center=�6!    J� RenderTransformOrigin$ 0.5,0.5&�5%      $��Normal$�65   $��Normal&�5&      $��1��6*   z�5'      V� 5(      .~�5)      �� �� 5*      	 �� AngleY$	 -0.171Q�6(   �� 5+      T� 5,      
 T� Y$
 -0.08Q�6-   5-      ��50      �� 51       �� 
TargetType" ��6   .�52      ��  �� Property � �� �� Value �#04c58267   �� 53       �@�Cursor$
 Hand��63    �� Triggers 55      P� 56       P� Property �@J�IsMouseOver P� Value$
 True��6=   . �57   "   ��  � �� �	#FF0485586?   58      5:      ��5=      �� 5>       �� 
TargetType" ��6&   .R�5?      �� $
��Auto��6!   $��25��6.   $ 10��5@      #��z��5A      ._�5B      �� $��Center=�6/   $��Center=�5C   /   5D      5E      5G      5I      5J      5K      