   M S B A M L   `   `   `  ����J  FPizzaRestaurant, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:PizzaRestaurant.ViewsPizzaRestaurant.Views  5      $    PizzaRestaurant.Views.AllOrder   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:PizzaRestaurant.Views     5      V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5      � .+�5   
   � $	��950��6   $	��500��5      
�������  � RowDefinitions  5      �� 5      $��75 �6    �� 5      $
��355* �6    .+�5      � $��0��6   .+�5      �� -   5         ��Name$ lblCreateOrder��5      $��40,15,300,0q�5      ���#4caf50$
��Bold"�5      $��30(�5      $��64��5      .��6%   
Order list61   �� 5      $��0��6   $��0q�5      $��
30,65,30,0q�5      $��10��5      ���#4caf50 �� CornerRadius$ 5��5       $��Stretch=�5!      $��Stretch=�5"      67   5$      � 5%      -   5         �Name$ GridOrderList��5'      $��32q�5%      $��1��5&      .+�5(      �� -   5         ��Name$ 
msgNoOrder��5)      $��20(�5(      $y�	Collapsed=�5*      
��� ���$��Italic$�5,      *(There are currently no completed orders.6Y   �� 5-      -   5        $��lvOrder��5-      
���   �$y�Visible=�5/       �� View 50      �� 51      $��Visible=�6#   .P�52      �� $��	Item Name��6-    �� DisplayMemberBinding 53   -   �� *Expr2+�� 54      $��Category��6-    55   -   �� *Expr3+�� 56      $��Quantity��6-    57   -   �� *ProductQuantity+ �� StringFormat$
 {0}x���� 58      $��ProductPrice (RSD)��6-    59   -   �� *ProductPrice+$ N2���� 5:      $��Sum Price (RSD)��6-    5;   -   �� *
OrderSum+$ N2��5<       �� 
GroupStyle 5>      (  "System.Windows.Controls.GroupStyle  5?      	   ContainerStyle	 5@      �� 5A   "   
 �� 
TargetType"
 ��6(   .�5B   &   ��  �� Property � �� �� Value 5C   *   �� 5D   .   .R�5E   2   9�  9� 
IsExpanded .  
�������$	��310��5G   ;   ��.  $��0 0 0 1q�5I   ;   ��5J   6   �� 5K   :    �� Orientation$ 
Horizontal=�6E   .+�5L   >   �� $��18(�5M   H   
��� ���$��Italic$�5O   H   $��Bottom=�5P   H   ��5L   H   �� *Name+5P   H   �� 5Q   >   $	�� / ��6H   $��18(�5R   H   
��� ���$��Italic$�5T   H   $��Bottom=�5U   H   �� 5V   >   $��Items: ��6H   $��14(�5W   H   
��� ���$��Italic$�5Y   H   $��Bottom=�5Z   H   �� 5[   >   $��14(�5\   H   
��� � �$��Italic$�5^   H   $��Bottom=�5_   H   ��5[   H   �� *	ItemCount+5_   H   5`   ;   .��5b   6   �� $
��Auto=�6C   .��5c   :   �� 5d   7   5e   3   5f   /   5h   '   5i   #   5k      5m      5n      � 5o      -   5        $ GridViewOrderItem��5o      $��1��5p      $y�	Collapsed=�5q      $��400 32 32 32q�5r      .+�5s      � $��5��6   $
��auto��5t      
��� ���$
��Left=�5v      64   �� 5w      $
��10 0q�6   $��20(�5x      
��� ���Neki tekst tamo5y   A   5z      5{      5|      5}      