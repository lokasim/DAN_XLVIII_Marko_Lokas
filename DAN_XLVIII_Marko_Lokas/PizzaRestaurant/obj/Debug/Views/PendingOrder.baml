   M S B A M L   `   `   `  ����J  FPizzaRestaurant, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:PizzaRestaurant.ViewsPizzaRestaurant.Views  5      (    "PizzaRestaurant.Views.PendingOrder   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:PizzaRestaurant.Views     5      V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5      � .+�5   
   � $	��950��6   $	��500��5      
�������  � RowDefinitions  5      �� 5      $��75 �6    �� 5      $
��355* �6    .+�5      � $��0��6   .+�5      �� -   5         ��Name$ lblCreateOrder��5      $��40,15,300,0q�5      ���#4caf50$
��Bold"�5      $��30(�5      $��64��5      .��6%   Pending Order64   �� 5      $��0��6   $��0q�5      $��
30,65,30,0q�5      $��10��5      ���#4caf50 �� CornerRadius$ 5��5       $��Stretch=�5!      $��Stretch=�5"      67   5#      �� 5$      -   5         ��Name$ 
msgNoOrder��5%      
��� ���$��	32 20 0 0q�5&      $��1��5'      $��16(�5(      86Take a break, there are currently no orders pending...6^   �� 5)      -   5         ��Name$ msgOrder��5*      $	��Top=�5)      $
��Left=�5+      $��1��5,      $��	32,20,0,0q�5-      .+�5.      �� 
��� ���$��0q�5/      $��16(�50      /-Click on the order to approve or reject it...6Y   &   System.Windows.Controls.DataGrid  52      -   5        $!��DataGridOrderEmployeeHoldOn��52      $��0��53      $��1��54         
IsReadOnly . $��14(�59      $
��auto��5:      $
��auto��5;      $��0 10 0 0q�5<         MinColumnWidth$ 75Q�5=      
�������   AlternatingRowBackground
 �����$��Center=�5@         MaxColumnWidth$	 200Q�5A      $	��Top=�5B      $��Right=�5C      	   HeadersVisibility$	 Column=�5D      
   AutoGenerateColumns
 .     HorizontalGridLinesBrush
 �   �
�������$��2q�5H      
�������$��Medium"�5J      ��55      �� *AllOrderList+ �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 56      �� *
AllOrder+$ PropertyChanged=�   Columns 5K      0  *System.Windows.Controls.DataGridTextColumn  5L      ,  &System.Windows.Controls.DataGridColumn   Header$ Order��6-   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5M   -   �� *	OrderID+   ElementStyle 5N      �� 5O   "   .�5P   &   ��  �� Property � �� �� Value$
 Wrap=�5Q   -   5R   #   5T        5U      $ DateTime Ordering��6-    5V   -   �� *DateTimeOrder+ �� StringFormat$ dd. MMMM yyyy. HH:mm�� 5W      �� 5X   "   .�5Y   &   ��  � ��$
 Wrap=�5Z   -   5[   #   5]        5^      $ Total Price (RSD)��6-    5_   -   �� *
TotalPrice+$ N2�� 5`      �� 5a   "   .�5b   &   ��  � ��$
 Wrap=�5c   -   5d   #   5f      5h      5i      5j      5k      5l      