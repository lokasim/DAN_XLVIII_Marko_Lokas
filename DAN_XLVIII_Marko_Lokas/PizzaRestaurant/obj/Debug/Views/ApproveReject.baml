   M S B A M L   `   `   `  ����J  FPizzaRestaurant, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:PizzaRestaurant.ViewsPizzaRestaurant.Views  5   	   )    #PizzaRestaurant.Views.ApproveReject   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:PizzaRestaurant.Views     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.3.1513, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � WindowStartupLocation$  CenterScreen=�5	   	    � Title$ Approve/Reject��5
   	    � WindowStyle$
 None=�5   	   $	��600��5   	   $	��720��5   	   .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   6*   �� 5      $��* �6   6)   �� 5      $��50 �6   6*   �� 5      $��70 �6   6*   .+�5   
   � ���#4caf50$��0��5       � ColumnDefinitions 5      �� 5      $	��110 �6#   61   �� 5      $��* �6#   6/   �� 5      $��50 �6#   60   .+�5      �� $��0��6   $��25(�5      $
��Bold"�5      
�������$
��20 0q�5       $��Center=�5!      Order6:   �� 5"      -   5         ��Name$ txtOrderNumber��5$      $��1��5"      $��25(�5#      $
��Bold"�5%      
�������$��-15 0q�5'      $��Center=�5(      $
��Left=�5)      65   �� 5*      -   5         ��Name$
 Exit��5+      $��2��5*      $��Right=�5,       0  ,MaterialDesignFloatingActionMiniAccentButton#��[  5.       � ToolTip$ 	Exit form��5/      ���	#FFC34A4A���	#FFC34A4A$
��14 0q�52      $��22��53      $��22��54      $y�Visible=�55      ��5-      �� *Exit+ �� UpdateSourceTrigger$ PropertyChanged=�.��56      '  !MaterialDesignThemes.Wpf.PackIcon  	   Kind$	 Close=�6*   $��16��57   *   $��16��58   *   59      5:      � 5;   
   $��1��6   .+�5<      �� $��1��6   $��20q�5=      $��16(�5>      Ordering Date:66   �� 5?      -   5        $ txtOrderingDate��5@      $��1��5?      $��130 20q�5A      $��16(�5B      6(   &   System.Windows.Controls.DataGrid  5C      -   5        $��DataGridOrder��5C      $��1��5D      
   
IsReadOnly
 . $��14(�5H      $	��365��5I      $
��auto��5J      $��
10 50 10 0q�5K      
�������   AlternatingRowBackground
 �����$��Center=�5N      $	��Top=�5O      $��Center=�5P         HeadersVisibility$ Column=�5Q         AutoGenerateColumns .     HorizontalGridLinesBrush
 �   �
�������$��2q�5U      
�������$��Medium"�5W      ��5E      �� *OrderItemList+$ PropertyChanged=� �� SelectedItem 5F      �� *	OrderItem+$ PropertyChanged=�   Columns 5X      0  *System.Windows.Controls.DataGridTextColumn  5Y      ,  &System.Windows.Controls.DataGridColumn   Header$ Quantity��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 5Z   )   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5[   )   �� *ProductQuantity+ �� StringFormat$
 {0}x��   ElementStyle 5\      �� 5]      .�5^   "   ��  �� Property � �� �� Value$
 Wrap=�5_   )   5`      5b        5c      $
 Item��6)   $	 200 5d   )    5e   )   �� *Expr2+ 5f      �� 5g      .�5h   "   ��  � ��$
 Wrap=�5i   )   5j      5l        5m      $ Category��6)   $	 120 5n   )    5o   )   �� *Expr3+ 5p      �� 5q      .�5r   "   ��  � ��$
 Wrap=�5s   )   5t      5v        5w      $ Price (RSD)��6)   $	 120 5x   )    5y   )   �� *ProductPrice+$ N2�� 5z      �� 5{      .�5|   "   ��  � ��$
 Wrap=�5}   )   �� 5~   "    � ��$ Right=�5   )   5�      5�        5�      $ 	Sum (RSD)��6)   $	 120 5�   )    5�   )   �� *
OrderSum+$ N2�� 5�      �� 5�      .�5�   "   ��  � ��$
 Wrap=�5�   )   �� 5�   "    � ��$ Right=�5�   )   5�      5�      5�      5�      � 5�   
   $��2��6   .+�5�      � $��2��6   $	��Top=�5�      $��Right=�5�      $	��240��5�      
���   �$��0 0 20 0q�5�      6'   � 5�      $��2��6   $	��Top=�5�      $��Right=�5�      $	��240��5�      
���   �$��0 4 20 0q�5�      6'   � 5�      $	��Top=�6   $��	0 10 20 0q�5�      $��Right=�5�      .+�5�      �� $��20(�6   $	��Top=�5�      	TotalSum:6?   �� 5�      -   5        $ txtTotalSum��5�      $��90 0 0 0q�5�      $��20(�5�      $	��Top=�5�      $
��Bold"�5�      5�   3   5�      5�      � 5�   
   $��3��6    5�      �� 5�      6%   �� 5�      6%   .+�5�      �� -   5        $ btnDiscardOrder��5�      $��0��5�        MaterialDesignRaisedButton#��[ 5�      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 20��5�      $ Discard order��5�      $��	120 0 0 0q�5�      $	��120��5�      $��40��5�      $��18(�5�      $��Center=�5�      $��Discard��5�      
����������	#FFC34A4A��5�      �� *DiscardOrder+$ PropertyChanged=���5�      Z� 6.   �� 5�      -   5        $ btnAcceptOrder��5�      $��1��5�      #��[ 5�      $ 20��5�      $ Accept order��5�      $��	0 0 120 0q�5�      $	��120��5�      $��40��5�      $��18(�5�      $��Center=�5�      $��Accept��5�      
����������	#FF8BC34A��5�      �� *AcceptOrder+$ PropertyChanged=���5�      Z� 6.   5�      5�      5�      