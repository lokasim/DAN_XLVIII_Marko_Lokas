   M S B A M L   `   `   `  ����J  FPizzaRestaurant, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:PizzaRestaurant.ViewsPizzaRestaurant.Views  5      '    !PizzaRestaurant.Views.CreateOrder   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:PizzaRestaurant.Views     5      V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5      � .+�5   
   � $	��950��6   $	��500��5      
�������  � RowDefinitions  5      �� 5      $��75 �6    �� 5      $
��355* �6    .+�5      � $��0��6   .+�5      �� -   5         ��Name$ lblCreateOrder��5      $��40,15,300,0q�5      ���#4caf50$
��Bold"�5      $��30(�5      $��64��5      .��6%   Create Order63   �� 5      $��0��6   $��0q�5      $��
30,65,30,0q�5      $��10��5      ���#4caf50 �� CornerRadius$ 5��5       $��Stretch=�5!      $��Stretch=�5"      67   5#      �� 5$      $	��Top=�6   $
��Left=�5%      $��1��5&      $��	32,32,0,0q�5'      .+�5(      �� -   5         ��Name$ btnAddReport��5(         MaterialDesignRaisedButton#��[  5)      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 20��5*       � ToolTip$ 
Add report��5+      $��0q�5,      $	��140��5-      
�������$��40��50      $��18(�51      $��Create order��52      
��� �����5/      �� *CreateOrderbtn+ �� UpdateSourceTrigger$ PropertyChanged=���54      Z� 62   55      � 56      -   5         �Name$ gridWaiting��5:      $��1��56      $	��400��57      $	��400��58      $��32 100 32 0q�59        5;      �� 5<      $��40 �6$   62   �� 5=      $
��100* �6$   64   .+�5?      �� $��20(�6   $��0��5@      
��� ���$��Italic$�5B      " Your order is awaiting approval.6Q   �� 5C      $��1��6   .��5D      �� -   5        $��lvOrderHoldOn��5D      
���   �$��0 0 0 10q�5F      $��1��5G       �� View 5H      �� 5I      .P�5J   "   �� $��	Item Name��61   	 �� DisplayMemberBinding	 5K   1   �� *Expr2+�� 5L   "   $��Category��61   	 5M   1   �� *Expr3+�� 5N   "   $��Quantity��61   	 5O   1   �� *ProductQuantity+
 �� StringFormat$

 {0}x���� 5P   "   $��ProductPrice (RSD)��61   	 5Q   1   �� *ProductPrice+$
 N2���� 5R   "   $��Sum Price (RSD)��61   	 5S   1   �� *
OrderSum+$
 N2��5T       �� 
GroupStyle 5V      (  "System.Windows.Controls.GroupStyle  5W         ContainerStyle 5X   "   �� 5Y   &    �� 
TargetType" ��6,   .�5Z   *   ��  �� Property � �� �� Value 5[   .   �� 5\   2   .R�5]   6   9�  9� 
IsExpanded . 
�������$��0 0 0 1q�5_   ?   ��5`   :   �� 5a   >    �� Orientation$ 
Horizontal=�6I   .+�5b   B   �� $��18(�5c   L   
��� ���$��Italic$�5e   L   $	��Top=�5f   L   ��5b   L   �� *Name+5f   L   �� 5g   B   $	�� / ��6L   $��18(�5h   L   
��� ���$��Italic$�5j   L   $��Bottom=�5k   L   �� 5l   B   $��Items: ��6L   $��14(�5m   L   
��� ���$��Italic$�5o   L   $��Bottom=�5p   L   �� 5q   B   $��14(�5r   L   
��� � �$��Italic$�5t   L   $��Bottom=�5u   L   ��5q   L   �� *	ItemCount+5u   L   5v   ?   .��5x   :   �� 5y   7   5z   3   5|   +   5}   '   5      5�      5�      5�      5�      5�      5�      