   M S B A M L   `   `   `  ����E  AQL_CH_DTDD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:QL_CH_DTDD.GUIQL_CH_DTDD.GUI  5           QL_CH_DTDD.GUI.ProductPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      (localclr-namespace:QL_CH_DTDD.GUI  5      -   5          N� 
Background  �#ffffff N� Title$ ProductPage��5
       � 	Resources 5      .   (QL_CH_DTDD.GUI.NumberToCurrenceConverter   curencyConverter��%   &	          5   
   6*   5      .��5      ]� ��. .+�5   
   �� $��Bottom=�6   $��30��6,   .@�5      �� -   5        $��infoTextBlock��5      $��14(�6-   $��SemiBold"�6;   5      �� 5   
   $��Bottom=�6    �� Orientation$ 
Horizontal=�6-   $��40��6F   $��0 0 20 0q�6R   $��Right=�6d   .+�5      �� -   5         ��Name$ previousButton��5   )   $��
5, 0, 5, 0q�6   $��<��6A   $��25(�6P   $
��Bold"�6^   $��0, -5, 0, 0q�6p   $��80��6�   $��35��6�   5      �� 5      -   5        $��pagesComboBox��5   ]   $��
5, 0, 5, 0q�6I   $��80��6r   $��35��6}   ��5      �� 5      .R�5      �� ��6$   ��  �� Path$ .�5      5      �� 5       -   5        $ 
nextButton��5    )   $��
5, 0, 5, 0q�6   $��>��6=   $��25(�6L   $
��Bold"�6Z   $��0, -5, 0, 0q�6l   $��80��6�   $��35��6�   6�   5!      �� 5"   
   $	��Top=�6   $ 
Horizontal=�6*   $��50��6C   .+�5#      �� $��Thêm mới sản phẩm��6   $��18(�60   $
��Bold"�6>   
���  ��$��10 0 0 0q�6a   �� 5$      -   5        $ 
AddProduct��5$      $��40��6C   $��40��6N   $��	20 0 20 0q�6Z    / +MaterialDesignFloatingActionMiniLightButton#��[ 5%      .��5&      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$	 Add=�6*   $��40��65   $��40��6A   5'      �� 5)      -   5         ��Name$ keywordTextBox��5)      $��14(�6/   $��SemiBold"�6=   $��30��6S   $	��200��6_   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$! Tìm theo tên sản phẩm��5*      $
��Left=�6M   $��
10 0 20 10q�6h   6|   �� 5,      -   5        $ 	findPrice��5,      $��Tìm theo giá��6@   �� 5-      -	   5        $ 
startprice��5-      $��30��6+   $	��150��67   $
��Left=�6C   $��
20 0 20 10q�6^   $
 Từ��5.      $��14(�6;   $��SemiBold"�6I   
���  ��5/   F   �� 50      -
   5        $ endprice��50      $��30��6)   $	��150��65   $
��Left=�6A   $��	0 0 10 10q�6\   $ Đến��51      $��14(�6;   $��SemiBold"�6I   
���  ��52   D   �� 55      -   5        	 ��Name$	 categoriesComboBox��55      $	��200��63   $��30��6?   $��10  0 10 10q�6K   $��14(�6`   $��SemiBold"�56      $$ Lọc theo loại sản phẩm��6.   ��57      �� 58      .R�59      �� ��6$   �� *	tenLoai+5:      5<      5>      �� 5@   
   -   5        $��IphoneComboBox��5A      $��Disabled=�5@      $��Disabled=�6I   
 �� Left$
 37��5A   m   
 �� Top$ 56��6~    5B        employeeContextMenu��%!   &	       �� 5C      5E      5F      ��5G      �� 5H       �� 
TargetType" ��6   .�5I      ��  �� Property �@�ContextMenu �� Value# [ 64   6c   5J      ��5L      �� 5M      .R�5N      � 5O      ��5Q      �� 5R      .R�5S      �� $ Vertical=�6!   $	��300��68   $��40 50 40 40q�6E   .+�5T      �� $	��150��6;   $	��150��6G   $��Center=�6T   ��6    �� *	hinhAnh+6T   �� 5U      $��15(�6@   $
��Bold"�6N   $��Center=�6`   ��6$   �� *
tenSanPham+6`   �� 5W      $
��Bold"�6i   $��15(�6{   $��Center=�6�   
���  ����6$   �� *giaBan+ �� 	Converter# [  6�   5X      5Y      5[      5\      5]      