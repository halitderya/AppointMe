   M S B A M L   `   `   `  ���� L  HICPartners.DevxUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:ICPartners.DevxUI.UserControlsICPartners.DevxUI.UserControls  5    /ICPartners.DevxUI.UserControls.UCStatusSelector   a ]DevExpress.Xpf.Core.v18.1, Version=18.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     >local,clr-namespace:ICPartners.DevxUI.UserControls     -   .��� .+��� -   $��StackPanelStatus��$��Stretch=�$��Stretch=�  �� Orientation$  
Horizontal=�.+�0   *ICPartners.DevxUI.UserControls.CustomTile2  -     Name$ 
ButtonOpen��0   *ICPartners.DevxUI.UserControls.CustomTile2   Click$ Button_Click��j fDevExpress.Xpf.LayoutControl.v18.1, Version=18.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a'  !DevExpress.Xpf.LayoutControl.Tile   Size$ 
ExtraSmall=�$��1q�$��Black"�
��� ���
���   �$��12(�,  &DevExpress.Xpf.Core.ContentControlBase   Content ��  �� Padding$ 3q�$
��Open��  -   $ ButtonCancelled��$ Button_Click��$ 
ExtraSmall=�$��1q�$��Black"�
���  ��
���   �$��12(� �� $ 3q�$��	Cancelled��  -   $ ButtonCompletedNoPayment��$ Button_Click��$��1q�$ 
ExtraSmall=�$��12(�
��� ���
���   � �� $  Vertical=�.+��� $ 3q�$��12(�$��	Completed��$��Black"�
���   ��� $ 3q�$��12(�$��(Unpaid)��
���   �  -   $ ButtonCompleted��$ Button_Click��$ 
ExtraSmall=�$��1q�
���"�"�
���   �$��12(� �� $  Vertical=�.+��� $ 3q�$��Complete��$��Black"��� $ 3q�$��(Paid)��