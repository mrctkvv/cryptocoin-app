   M S B A M L   `   `   `  ����E  ACryptoCoin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:CryptoCoin.ViewsCryptoCoin.Views  5      =#clr-namespace:CryptoCoin.ViewModelsCryptoCoin.ViewModels  5      !    CryptoCoin.Views.ChartsView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:CryptoCoin.Views     5      :
viewModels#clr-namespace:CryptoCoin.ViewModels     5        N� Title$  
ChartsView��5      .��5      �  � RowDefinitions 5   
   �� 5      $��70 �6   �� 5      .+�5   
   �� $��0��6   $
��10,5q�6"    �� Orientation$ 
Horizontal=�60   .+�5      �  � ColumnDefinitions 5      �� 5      �� 5      �� 5      $��90 �6'   �� 5      $��90 �6'    5      �� 5      �� 5      .+�5       �� $��0��6   $��0��5!      $��	Search By��5"      $��14(�5#      
���   �$��	Bodoni MT)�5$   /   �� 5&      -   5         ��Name$ ModelsSearchBy��5)      $��0��5&      $��1��5'       �� SelectedIndex$ 0��5(      $��	Bodoni MT)�5)   3   .@�5*      �� $��Id��6    �� 5+      $
��Name��6    ��5,      �� 5-       �� 
TargetType" ��6    .�5.      ��  �� Property � �� �� Value
 �����6;   �� 5/       � ��$ Fonts/#Ubuntu)�6<   �� 50       � ��$ Center=�6K   �� 51       � ��$ Center=�6I   52      54      �� 56      -   5        $��SearchStringTextBox��5>      $��1��56      $��1��57      
�������
�������$��Italic$�5:      $��5q�5;      $	��180��5<      $��20,0,0,0q�5=      5>      �� 5@      -   5        $��	SearchBtn��5C      $��1��5@      $��2��6&   $��Search��5A      	 �� 	IsDefault$
	 True��5D      �� 5F      -   5        $��ClearBtn��5I      $��1��5F      $��3��6&   $��Clear��5G      
 �� IsCancel$

 True��5J      5K      5L      � 5N   
   $��1��6    5O      �� 5P      �� 5Q      .+�5S      �� -   5        $��	CoinsGrid��5S   M   $��1��6   ��6$   �� *SelectedModels+ �� View 5T      �� 5U      .P�5V      �� $��Id��6)    �� DisplayMemberBinding 5W   )   �� *Id+�� 5X      $
��Name��6)    5Y   )   �� *Name+�� 5Z      $��Symbol��6)   -   5        
BaseSymbol�� 5[   )   �� *Symbol+5\   )   �� 5]      $��Price��6)    5^   )   �� *
PriceUsd+5_      ��5b      �� 5c      " ��6    �� Triggers 5d      P� 5e       P� Property �@J�IsMouseOver P� Value$
 True��6=   . �5f   "   ��  � �� �#d2afff6?   5g      P� 5h       �@��
IsSelected$
 True��6<   . �5i   "   ��  � �� �#e6d7ff6?   5j      5l      ��5n      �� 5o      " ��6   .�5p      -   5        �� 5q       � �� �#d2afff67   �� 5r       � �� �#5a228b67   �� 5s       �@J�Opacity$	 0.7Q�64   �� 5t       � ��$ 13(�65   5u      5x       � 5z      -   5          �Name$ ChartsFrame��5z   $   $��1��6   $��20,0,0,0q�69   5{      5|      5}      