   M S B A M L   `   `   `  ����E  AQL_CH_DTDD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:QL_CH_DTDD.GUIQL_CH_DTDD.GUI  5           QL_CH_DTDD.GUI.OderDetails   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      (localclr-namespace:QL_CH_DTDD.GUI  5      -   5          N� 
Background
  ����� N� Title$ OderDetails��5
       � 	Resources 5      .   (QL_CH_DTDD.GUI.NumberToCurrenceConverter   curencyConverter��%   &	          5   
   6*   5      .��5      � .+�5   
   �� $��CHI TIẾT ĐƠN HÀNG��6   $��20(�6-   
���   �$��
0 15 30 30q�6N   $
��Bold"�6b   $��Center=�6t   $	��Top=�6�   $��50��6�   �� 5   
   -   5        $��oderCustomerName��5      $��57,372,843,286q�6*   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tên khách hàng��6B   $	��300��6r   $��18(�6   
������ $
��Bold"�5       % !MaterialDesignFloatingHintTextBox#��[ 6$   �� 5   
   -   5        $��
imgProduct��5      $	��172��6"   $	��230��6.   $��/GUI/images/cellphone.png��6=   $��63,42,965,448q�6a   �� 5   
   -   5        $��oderproductName��5      $��421,185,479,473q�6)   $ Tên sản phẩm��6B   $	��300��6p   $��18(�6}   
������  �� 
IsReadOnly . $
��Bold"�5      #��[ 6$   �� 5   
   -   5        $��	productId��5      $��421,90,479,568q�6#   $ Mã Sản Phẩm��6;   $	��300��6h   $��18(�6u   
������  . $
��Bold"�5      #��[ 6$   �� 5   
   -   5        $��oderAddress��5      $��57,590,465,68q�6%   $ Địa chỉ khách hàng��6<   $��18(�6q   
������ $
��Bold"�5       #��[ 6$   �� 5"   
   -   5         ��Name$ Cancel��5"      $��Thoát��66   $	��200��6G   $��50��6S   $��18)�6_   $
��Bold"�6o    �� Left$	 915��6�   
 �� Top$ 94��6�   $��913,602,87,68q�6�   �� 5$   
   -   5        $��ProductCost��5$      $��813,284,87,374q�6%   $ Tổng tiền (đ)��6=   $	��300��6l   $��18(�6y   
������ 
���  �� . $
��Bold"�5&      #��[ 6$   ��5%   5   �� *
tongTien+ �� 	Converter# [  5&   $   �� 5(   
   -	   5        $��oderNumberProduct��5(      $��813,90,237,568q�6+   $ số lượng��6C   $	��150��6m   $��18(�6z   
������ $
��Bold"�5+      #��[ 6$   �� 5-   
   -
   5        $��oderProductPrice��5-      $��813,185,87,473q�6*   $ Giá bán (đ)��6B   $	��300��6o   $��18(�6|   
������ 
���  �� . $
��Bold"�5/      #��[ 6$   ��5.   5   �� *giaBan+# [  5/   $   �� 51   
   -   5        $��CustomerPhone��51      $��57,484,843,174q�6'   $ Số điện thoại��6?   $	��300��6n   $��18(�6{   
������ $
��Bold"�52      #��[ 6$   (  "System.Windows.Controls.DatePicker  56   
   -   5        $��editProductDate��58   S   $	��300��56      $��18(�6"   $
��Bold"�60   $ 
Ngày bán��6B    ( $MaterialDesignFloatingHintDatePicker#��[ 58      $��421,260,479,374q�6j   $��86��6�   59      5:      5;      