   M S B A M L   `   `   `  ����J  FPizzaRestaurant, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:PizzaRestaurant.ViewsPizzaRestaurant.Views  5      )    #PizzaRestaurant.Views.ArchivedOrder   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:PizzaRestaurant.Views     5      V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5      � .+�5   
   � $	��950��6   $	��500��5      
�������  � RowDefinitions  5      �� 5      $��75 �6    �� 5      $
��355* �6    .+�5      � $��0��6   .+�5      �� -   5         ��Name$ lblCreateOrder��5      $��32,15,300,0q�5      ���#4caf50$
��Bold"�5      $��30(�5      $��64��5      .��6%   Archived orders66   �� 5      $��0��6   $��0q�5      $��
30,65,30,0q�5      $��10��5      ���#4caf50 �� CornerRadius$ 5��5       $��Stretch=�5!      $��Stretch=�5"      67   �� 5#      -   5         ��Name$ 	msgDelete��5$      $��Right=�5#      $��Center=�5%      $��
0 15 322 0q�5&      $��16(�5'      ���	#FFC34A4A5(   5   �� 5)      -   5         ��Name$ OrderNumber��5,      $��
0,-6,152,0q�5)       � ToolTip$, &Enter the order number to delete it...��5*       �� 	MaxLength$ 9��5+      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Enter the order number��5-      $	��160��5.      $��Center=�5/      $��Right=�50      $��45��52       %  !MaterialDesignFloatingHintTextBox#��[  53      $��Center=�54      $��14(�55      6*   �� 56      -   5         ��Name$ btnAddReport��56        MaterialDesignRaisedButton#��[ 57      +  %MaterialDesignThemes.Wpf.ButtonAssist	   CornerRadius$	 	0 20 20 0��58      $ Delete order��59      $��0 0 32 0q�5:      $	��120��5;      
�������$��40��5>      $��Center=�5?      $��Right=�5@      $��Delete order��5A      ���	#FFC34A4A��5=      �� *Delete+
 �� UpdateSourceTrigger$
 PropertyChanged=���5C      Z� 62   5D      � 5E      -   5         �Name$ GridOrderList��5G      $��32q�5E      $��1��5F      .+�5H      �� -   5        $ 
msgNoOrder��5I      $��20(�5H      $y�	Collapsed=�5J      
��� ���$��Italic$�5L      0.You currently do not have any archived orders.6_   �� 5M      -   5        $��lvOrder��5M      
���   �$y�Visible=�5P      ��5N      �� *AllOrderItemList+$
 PropertyChanged=� �� View 5Q      �� 5R      $��Visible=�6#   .P�5S      �� $��	Item Name��6-    �� DisplayMemberBinding 5T   -   �� *Expr2+�� 5U      $��Category��6-    5V   -   �� *Expr3+�� 5W      $��Quantity��6-    5X   -   �� *ProductQuantity+ �� StringFormat$
 {0}x���� 5Y      $��ProductPrice (RSD)��6-    5Z   -   �� *ProductPrice+$ N2���� 5[      $��Sum Price (RSD)��6-    5\   -   �� *
OrderSum+$ N2��5]       �� 
GroupStyle 5_      (  "System.Windows.Controls.GroupStyle  5`         ContainerStyle 5a      �� 5b   "    �� 
TargetType" ��6(   .�5c   &   ��  �� Property � �� �� Value 5d   *   �� 5e   .   .R�5f   2   9�  9� 
IsExpanded .  
�������$	��310��5h   ;   ��.  $��0 0 0 1q�5j   ;   ��5k   6   �� 5l   :    �� Orientation$ 
Horizontal=�6E   .+�5m   >   �� $��18(�5n   H   
��� ���$��Italic$�5p   H   $��Bottom=�5q   H   ��5m   H   �� *Name+5q   H   �� 5r   >   $	�� / ��6H   $��18(�5s   H   
��� ���$��Italic$�5u   H   $��Bottom=�5v   H   �� 5w   >   $��Items: ��6H   $��14(�5x   H   
��� ���$��Italic$�5z   H   $��Bottom=�5{   H   �� 5|   >   $��14(�5}   H   
��� � �$��Italic$�5   H   $��Bottom=�5�   H   ��5|   H   �� *	ItemCount+5�   H   5�   ;   .��5�   6   �� $
��Auto=�6C   .��5�   :   �� 5�   7   5�   3   5�   /   5�   '   5�   #   5�      5�      5�      � 5�      -   5        $ GridViewOrderItem��5�      $��1��5�      $y�	Collapsed=�5�      $��400 32 32 32q�5�      .+�5�      � $��5��6   $
��auto��5�      
��� ���$
��Left=�5�      64   �� 5�      $
��10 0q�6   $��20(�5�      
��� ���Neki tekst tamo5�   A   5�      5�      5�      5�      