   M S B A M L   `   `   `  ����E  AQL_CH_DTDD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:QL_CH_DTDD.GUIQL_CH_DTDD.GUI  5      $    QL_CH_DTDD.GUI.EditProductPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      (localclr-namespace:QL_CH_DTDD.GUI  5      -   5          N� 
Background  �#ffffff N� Title$ EditProductPage��5
      .��5      � .+�5   
   �� $��SỬA/XÓA SẢN PHẨM��6   $��20(�6,   
���   �$��
0 15 30 30q�6M   $
��Bold"�6a   $��Center=�6s   $	��Top=�6�   $��50��6�   �� 5   
   -   5        $��editProductName��5      $��65,97,835,561q�6E   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tên sản phẩm��6\   $	��300��6�   $��18(�6�   
������ $
��Bold"�5       %  !MaterialDesignFloatingHintTextBox#��[  6$   ��5   )   �� *
tenSanPham+5   $   �� 5   
   -   5        $��categoriesComboBox��5      $	��300��6e   $��50��6q   $��18(�6}    �� Left$	 361��6�   $��438,109,462,561q�6�   
 �� Top$ 39��5      $  Chọn loại sản phẩm��6#   $
��Bold"�6W   ��5      �� 5      .R�5      �� ��6    �� *	tenLoai+5      5      �� 5   
   -   5        $��editProductDes��5      $��65,356,835,302q�6?   $ Mô Tả��6W   $	��300��6~   $��18(�6�   
������ $
��Bold"�5      #��[  6$   ��5   (   �� *moTa+5   $   �� 5   
   -   5        $��editProductCost��5      $��813,356,87,302q�6A   $% Giá vốn/số lượng nhập��6Y   $	��300��6�   $��18(�6�   
������ $
��Bold"�5      #��[  6$   ��5   )   �� *giaVon+5   $   �� 5    
   -   5        $��editProductNum��5       $��813,226,87,432q�6A   $ Số lượng nhập��6Y   $	��300��6�   $��18(�6�   
������ $
��Bold"�5"      #��[  6$   ��5    (   �� *	soLuong+5"   $   �� 5$   
   -   5        $��editProductPrice��5$      $��438,226,462,432q�6C   $ Giá sản phẩm(đ)��6\   $	��300��6�   $��18(�6�   
������ $
��Bold"�5&      #��[  6$   ��5$   *   �� *giaBan+5&   $   �� 5(   
   -   5        $��editProductType��5(      $��65,226,835,432q�6I   $ 
Mã loại��6a   $	��300��6�   $��18(�6�   
������ $
��Bold"�5)      #��[  6$   {�.  ��5(   )   �� *loaiSanPhamId+5)   _   (  "System.Windows.Controls.DatePicker  5+   
   -	   5        $��editProductDate��5+      $	��300��5,      $��18(�6!   $
��Bold"�6/   $ Ngày nhập kho��6A    ( $MaterialDesignFloatingHintDatePicker#��[ 5-      $��813,73,87,561q�6S   $��86��6j   5.      �� 50   
   $��Ảnh sản phẩm��6   $��18(�6'   $
��Bold"�65   $	��200��6G   $��40��6S   $��521,378,479,302q�6_   �� 51   
   -
   5        $��btnAddImageProduct��51      $��40��6L   $��40��6W   $��438,368,712,302q�6c    / +MaterialDesignFloatingActionMiniLightButton#��[ 52      .��53      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$	 Add=�6&   $��40��61   $��40��6=   54      �� 56   
   -   5        $��
imgProduct��56      $	��172��6"   $	��230��6.   $��515,448,513,42q�6V   ��6<   �� *Avatar+6V   �� 57   
   -   5         ��Name$ updateProduct��57      $
��Lưu��6(   $	��200��6R   $��50��6^   $��18)�6j   $
��Bold"�58      $��860,477,140,193q�6#   �� 59   
   -   5        $ deleteProduct��59      $
��Xóa��6(   $	��200��6R   $��50��6^   $��18)�6j   $
��Bold"�6z   $��860,543,140,127q�6�   �� 5:   
   -   5        $ CancelProduct��5:      $��Hủy��6(   $	��200��6S   $��50��6_   $��18)�6k   $
��Bold"�6{   $��860,610,140,60q�6�   5<      5=      