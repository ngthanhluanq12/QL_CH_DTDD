   M S B A M L   `   `   `  ����E  AQL_CH_DTDD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:QL_CH_DTDD.GUIQL_CH_DTDD.GUI  5      #    QL_CH_DTDD.GUI.AddProductPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      (localclr-namespace:QL_CH_DTDD.GUI  5      -   5          N� 
Background  �#ffffff N� Title$ AddProductPage��5
      .��5      � .+�5   
   �� $��THÊM MỚI SẢN PHẨM��6   $��20(�6-   
���   �$��
0 15 30 30q�6N   $
��Bold"�6b   $��Center=�6t   $	��Top=�6�   $��50��6�   �� 5   
   -   5        $��editProductName��5      $��65,97,835,561q�6)   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tên sản phẩm��6@   $	��300��6n   $��18(�6{   
������ $
��Bold"�5       %  !MaterialDesignFloatingHintTextBox#��[  6$   �� 5   
   -   5        $��categoriesComboBox��5      $	��300��6d   $��50��6p   $��18(�6|    �� Left$	 361��6�   $��438,109,462,561q�6�   
 �� Top$ 39��5      $  Chọn loại sản phẩm��6#   $
��Bold"�6W   ��5      �� 5      .R�5      �� ��6    �� *	tenLoai+5      5      �� 5   
   -   5        $��editProductDes��5      $��65,356,835,302q�6(   $ Mô Tả��6@   $	��300��6g   $��18(�6t   
������ $
��Bold"�5      #��[  6$   �� 5   
   -   5        $��editProductCost��5      $��813,356,87,302q�6)   $% Giá vốn/số lượng nhập��6A   $	��300��6x   $��18(�6�   
������ $
��Bold"�5      #��[  6$   �� 5    
   -   5        $��editProductNum��5       $��813,226,87,432q�6(   $ Số lượng nhập��6@   $	��300��6o   $��18(�6|   
������ $
��Bold"�5"      #��[  6$   �� 5$   
   -   5        $��editProductPrice��5$      $��438,226,462,432q�6*   $ Giá sản phẩm(đ)��6C   $	��300��6t   $��18(�6�   
������ $
��Bold"�5&      #��[  6$   �� 5(   
   -   5        $��editProductType��5(      $��65,226,835,432q�6)   $ 
Mã loại��6A   $	��300��6j   $��18(�6w   
������ $
��Bold"�5)      #��[  6$   {�.  6_   (  "System.Windows.Controls.DatePicker  5+   
   -	   5        $��editProductDate��5,   S   $	��300��5+      $��18(�6!   $
��Bold"�6/   $ Ngày nhập kho��6A    ( $MaterialDesignFloatingHintDatePicker#��[ 5,      $��813,73,87,561q�6j   $��86��6�   5-      �� 5/   
   $��Ảnh sản phẩm��6   $��18(�6'   $
��Bold"�65   $	��200��6G   $��40��6S   $��521,378,479,302q�6_   �� 50   
   -
   5        $��btnAddImageProduct��50      $��40��6L   $��40��6W   $��438,368,712,302q�6c    / +MaterialDesignFloatingActionMiniLightButton#��[ 51      .��52      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$	 Add=�6&   $��40��61   $��40��6=   53      �� 55   
   -   5        $��
imgProduct��55      $	��172��6"   $	��230��6.   $��/GUI/images/cellphone.png��6<   $��515,448,513,42q�6_   �� 56   
   -   5         ��Name$ saveProduct��56      $
��Lưu��6&   $	��200��6N   $��50��6Z   $��18)�6f   $
��Bold"�6v   $��860,493,140,177q�6�   �� 57   
   -   5        $ CancelProduct��57      $��Hủy��6(   $	��200��6R   $��50��6^   $��18)�6j   $
��Bold"�6z   $��860,586,140,84q�6�   59      5:      