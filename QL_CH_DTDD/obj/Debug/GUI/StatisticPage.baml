   M S B A M L   `   `   `  ����U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf  5      E AQL_CH_DTDD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:QL_CH_DTDD.GUIQL_CH_DTDD.GUI 5      "   QL_CH_DTDD.GUI.StatisticPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      >lvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf  5      (localclr-namespace:QL_CH_DTDD.GUI  5      -   5          N� 
Background
  ����� N� Title$ StatisticPage��5      .��5      � .+�5   
   �� $
��1200��6   $��60��6   $	��Top=�6*   .+�5      (  "System.Windows.Controls.DatePicker  -   5        $��StarDate��5   T   $��14(�5      $
��Bold"�6(   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Từ ngày��6:    (  $MaterialDesignFloatingHintDatePicker#��[  5       J� RenderTransformOrigin$ 1.114,0.397&�6d    �� Left$	 157��6�   
 �� Top$ 3��6�   $	��120��6�     5      -   5        $��endDate��5   T   $��14(�5      $
��Bold"�6(   $ Đến ngày��6:   #��[  5      $ 1.114,0.397&�6c   $	 292��6�   $ 3��6�   $	��120��6�   �� 5      -   5         ��Name$ report��5      $��Thống kê��6%   $ 13��68   $ 52��6]   6p   �� 5      $��THỐNG KÊ��6   $��20(�6(   
���   �$
��Bold"�6I   $��Center=�6[   $	��Top=�6x   $��50��6�   $	 549��6�   $ 14��6�   5      �� 5   
   $��	0,60,0,10q�6   .+�5      #   LiveCharts.Wpf.CartesianChart  -   5        $��ToTalproduct��5   !   $	��294��66   $	��532��6C   $ 30��6O   $ 2��6`   &    LiveCharts.Wpf.Charts.Base.Chart   AxisX 5         LiveCharts.Wpf.Axis     FontSize$ 14Q�6    	   
FontWeight$	 SemiBold"�6.   
   Labels
 6D   �� *Labels+   	Separator 5         LiveCharts.Wpf.Separator  5      {�.     Step$ 1Q�6>   5!      5#        5%      -   5        $��
Totalprice��5%   !   $	��296��63   $	��532��6@   $	 626��6L    5'        $ 14Q�6    $	 SemiBold"�6.   
 6D   �� *Labels+ 5(        5)      {�.  $ 1Q�6>   5+        5,      6"   5.        50      -   5        $��TotalProfit��50   !   $	��273��64   $	��532��6A   $	 344��6M   $	 339��6_    52        $ 14Q�6    $	 SemiBold"�6.   
 6D   �� *Labels+ 53        54      {�.  $ 1Q�6>   56      58      �� 5:      $;��5Tổng sản phẩm bán được của từng loại��6   $��18(�6C   $��SemiBold"�6Q   
���  ��$	 139��6x   $	 307��6�   �� 5;      $1��+Doanh thu bán được của từng loại��6   $��18(�6?   $��SemiBold"�6M   
���  ��$	 755��6t   $	 307��6�   �� 5<      $5��/Lợi nhuận bán được của từng loại��6   $��18(�6?   $��SemiBold"�6M   
���  ��$	 472��6t   $	 608��6�   5=      5?      5@      