   M S B A M L   `   `   `  ����E  AQL_CH_DTDD, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:QL_CH_DTDD.GUIQL_CH_DTDD.GUI  5          QL_CH_DTDD.GUI.OrderPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      (localclr-namespace:QL_CH_DTDD.GUI  5        N� 
Background  �#ffffff N� Title$ 	OrderPage��5
      .��5      � .+�5   
   �� $��TẠO ĐƠN HÀNG��6   $��20(�6(   
���   �$��
0 15 30 30q�6I   $
��Bold"�6]   $��Center=�6o   $	��Top=�6�   $��50��6�   �� 5   
   -   5        $��oderCustomerName��5      $��65,97,835,561q�6*   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tên khách hàng��6A   $	��300��6q   $��18(�6~   
������ {�.  $
��Bold"�5       %  !MaterialDesignFloatingHintTextBox#��[  6$   �� 5   
   -   5        $��OderproductName��5      $��443,97,457,561q�6)   $ Tên sản phẩm��6A   $	��300��6o   $��18(�6|   
������ 
���  ��$
��Bold"�5      #��[  6$   �� 5   
   -   5        $��oderAddress��5      $��65,356,457,302q�6%   $ Địa chỉ khách hàng��6=   $��18(�6r   
������ {�.  $
��Bold"�5      #��[  6$   �� 5   
   -   5        $��ProductCost��5      $��813,356,87,302q�6%   $ Tổng tiền (đ)��6=   $	��300��6l   $��18(�6y   
������ {�.  
���  ��$
��Bold"�5      #��[  6$   �� 5   
   -   5        $��oderNumberProduct��5      $��808,226,242,432q�6+   $ Nhập số lượng��6D   $	��150��6s   $��18(�6�   
������ {�.  $
��Bold"�5      #��[  6$   �� 5    
   -   5        $��oldNumberProduct��5       $��963,226,87,432q�6*   $ 	Tồn kho��6B   $	��150��6k   $��18(�6x   
������ {�.  
���  ��$
��Bold"�5"      #��[  6$   �� 5$   
   -   5        $��oderProductPrice��5$      $��443,226,457,432q�6*   $ Giá bán (đ)��6C   $	��300��6p   $��18(�6}   
������ {�.  
���  ��$
��Bold"�5&      #��[  6$   �� 5(   
   -   5        $��CustomerPhone��5(      $��65,226,835,432q�6'   $ Số điện thoại��6?   $	��300��6n   $��18(�6{   
������ {�.  $
��Bold"�5*      #��[  6$   (  "System.Windows.Controls.DatePicker  5.   
   -	   5        $��editProductDate��50   S   $	��300��5.      $��18(�6"   $
��Bold"�60   $ 
Ngày bán��6B   {�.   ( $MaterialDesignFloatingHintDatePicker#��[ 50      $��813,73,87,561q�6j   $��86��6�   51      �� 53   
   -
   5        $��oderMoneyCustomer��53      $��65,493,835,165q�6+   $# Số tiền khách đưa (đ)��6C   $	��300��6z   $��18(�6�   
������ {�.  
���  ��$
��Bold"�55      #��[  6$   �� 57   
   -   5        $��oderMoneychange��57      $��443,493,457,165q�6)   $" Số tiền trả lại (đ)��6B   $	��300��6w   $��18(�6�   
������ {�.  
���  ��$
��Bold"�59      #��[  6$   �� 5;   
   -   5         ��Name$ saveProduct��5;      $��Lưu đơn hàng��6&   {�.  $	��200��6O   $��50��6[   $��18)�6g   $
��Bold"�6w   $��860,493,140,177q�6�   �� 5<   
   -   5        $ CancelProduct��5<      $��Tạo mới đơn��6(   {�.  $	��200��6Q   $��50��6]   $��18)�6i   $
��Bold"�6y   $��860,562,140,108q�6�   �� 5=   
   -   5        $ listProduct��5=      $��Danh sách đơn hàng��6&   $	��200��6^   $��50��6j   $��18)�6v   $
��Bold"�6�   $��860,634,140,36q�6�   5?      5@      