   M S B A M L   `   `   `  ����B  >OPD_GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:OPD_GUIOPD_GUI  5   	       OPD_GUI.LoginScreen   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:OPD_GUI     5   	     � Title$  Login��5   	   $	��550��6   $	��300��6$   $��12(�60    � WindowStartupLocation$ CenterScreen=�6>   ��5
      �� 5   
    �� ImageSource$  /Images/mainbackground.jpg��6    j� Stretch$
 Fill=�6>    j� TileMode$
 None=�6M   .��5      �� ���#0f0f2D �� CornerRadius$ 20��6"   $��20q�64    J� Opacity$	 0.9Q�6@   ._�5   
   �� $��20q�6   .+�5      �� $��/images/logo_small.png��6   $	��150��64   6B   �� 5      $��Login��6   
�������$��25(�67   $��Center=�6E   �� 5      6   �� 5      $��Email��6   
�������6$   �� 5      -   5        $��txtEmail��5      $�� ��6&   ���#545d6a
�������$��18(�6V   �� 5      $��Password��6   
�������$��14(�6;   $��0q�6I   G� 5      -   5        $��txtPassword��5       G� Password$  ��6-   ���#545d6a
�������$��18(�6b   �� 5      $��8(�6   $��30��6%    �� TextAlignment$ Center=�61   $��0,5,0,0q�6H   $��Center=�6Y   $��Center=�5      $
��Wrap=�63   
�������$j��dPassword must be at leat 8 charachters, min 1 Uppercase [A-Z],min 1 number [0-9], min 1 symbol [~-?]��6Z   �� 5      -   5        $��	btnSubmit��5    O   $��Login��5      
�������$��14(�5      $
��Bold"�5      $��20q�6'   $	��106��5      $��Center=�6!   	 J� RenderTransformOrigin$	 0.5,0.5&�5      $��Normal$�65   $��Normal&�5       $��1��6*   z�5!      V� 5"      .~�5#      �� �� 5$      
 �� AngleY$
 -0.171Q�6(   �� 5%      T� 5&       T� Y$ -0.08Q�6-   5'      ��5*      �� 5+       �� 
TargetType" ��6   .�5,      ��  �� Property � �� �� Value �#04c58267   �� 5-       �@�Cursor$
 Hand��63    �� Triggers 5/      P� 50       P� Property �@J�IsMouseOver P� Value$
 True��6=   . �51   "   ��  � �� �	#FF0485586?   52      54      ��57      �� 58       �� 
TargetType" ��6&   .R�59      �� $
��Auto��6!   $��25��6.   $ 10��5:      #��z��5;      ._�5<      �� $��Center=�6/   $��Center=�5=   /   5>      5?      5A      �� 5D      6   �� 5F      -   5        $��	btnSignUp��5L   O   $��Sign Up��5F      
�������$��14(�5H      $
��Bold"�5I      $��20q�6'   $	��106��5J      $��Center=�6!   $	 0.5,0.5&�5K      $��Normal$�65   $��Normal&�5L      $��1��6*   z�5M      V� 5N      .~�5O      �� �� 5P      $
 -0.171Q�6(   �� 5Q      T� 5R      $ -0.08Q�6-   5S      ��5V      �� 5W      " ��6   .�5X      ��  � �� �#04c58267   �� 5Y       �@�Cursor$
 Hand��63    5[      P� 5\       �@J�IsMouseOver$
 True��6=   . �5]   "   ��  � �� �	#FF0485586?   5^      5`      ��5c      �� 5d      " ��6&   .R�5e      �� $
��Auto��6!   $��25��6.   $ 10��5f      #��z��5g      ._�5h      �� $��Center=�6/   $��Center=�5i   /   5j      5k      5m      5o      5q      5r      