   M S B A M L   `   `   `  ����E  ACryptoCoin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:CryptoCoin.ViewsCryptoCoin.Views  5      =#clr-namespace:CryptoCoin.ViewModelsCryptoCoin.ViewModels  5      '    !CryptoCoin.Views.FullCurrencyView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:CryptoCoin.Views     5      :
viewModels#clr-namespace:CryptoCoin.ViewModels     5        N� Title$  FullCurrencyView��5      .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       .+�5"   
   �� $��0��6   $��0��6$   $��2��61   $��Currency Information��5#      $��20(�5$      
�������$��	ExtraBold"�5&      $��	Bodoni MT)�6+   �� 5(   
   -   5        $��Id��5(   <   $��0��6   $��1��6$   $	��ID:��61   $��	Bodoni MT)�6F   �� 5)   
   $��1��6   $��1��6$   $��	Bodoni MT)�6K   ��61   �� *
Model.Id+6K   �� 5+   
   $��0��6   $��2��6$   $
��Rank��61   $��	Bodoni MT)�6=   �� 5,   
   $��1��6   $��2��6$   $��	Bodoni MT)�6M   ��61   �� *
Model.Rank+6M   �� 5.   
   $��0��6   $��3��6$   $��Symbol��61   $��	Bodoni MT)�6?   �� 5/   
   $��1��6   $��3��6$   $��	Bodoni MT)�6O   ��61   �� *Model.Symbol+6O   �� 51   
   $��0��6   $��4��6$   $
��Name��61   $��	Bodoni MT)�6=   �� 52   
   $��1��6   $��4��6$   $��	Bodoni MT)�6M   ��61   �� *
Model.Name+6M   �� 54   
   $��0��6   $��5��6$   $��Supply��61   $��	Bodoni MT)�6?   �� 55   
   $��1��6   $��5��6$   $��	Bodoni MT)�6O   ��61   �� *Model.Supply+6O   �� 57   
   $��0��6   $��6��6$   $��
Max supply��61   $��	Bodoni MT)�6C   �� 58   
   $��1��6   $��6��6$   $��	Bodoni MT)�6R   ��61   �� *Model.MaxSupply+6R   �� 5:   
   $��0��6   $��7��6$   $��Market cap USD��61   $��	Bodoni MT)�6G   �� 5;   
   $��1��6   $��7��6$   $��	Bodoni MT)�6U   ��61   �� *Model.MarketCapUsd+6U   �� 5=   
   $��0��6   $��8��6$   $��Volume per 24 hours��61   $��	Bodoni MT)�6L   �� 5>   
   $��1��6   $��8��6$   $��	Bodoni MT)�6V   ��61   �� *Model.VolumeUsd24Hr+6V   �� 5@   
   $��0��6   $��9��6$   $��	Price USD��61   $��	Bodoni MT)�6B   �� 5A   
   $��1��6   $��9��6$   $��	Bodoni MT)�6Q   ��61   �� *Model.PriceUsd+6Q   �� 5C   
   $��0��6   $��10��6$   $!��Change percent per 24 hours��62   $��	Bodoni MT)�6U   �� 5D   
   $��1��6   $��10��6$   $��	Bodoni MT)�6[   ��62   �� *Model.ChangePercent24Hr+6[   �� 5F   
   $��0��6   $��11��6$   $��VWAp per 24 hours��62   $��	Bodoni MT)�6K   �� 5G   
   $��1��6   $��11��6$   $��	Bodoni MT)�6R   ��62   �� *Model.VWap24Hr+6R   �� 5I   
   $��0��6   $��12��6$   $��Explorer��62   $��	Bodoni MT)�6B   �� 5J   
   $��1��6   $��12��6$   $��	Bodoni MT)�62   �� 5K      -   5        ��5K      �� *Model.Explorer+.�6k   .�5L      �� 
����  �$��	Underline{�6N   $��	Bodoni MT)�6j   ��6   �� *Model.Explorer+6j   5M      5N      5O      5P      