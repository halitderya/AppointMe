   M S B A M L   `   `   `  ���� L  HICPartners.DevxUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:ICPartners.DevxUI.WindowsICPartners.DevxUI.Windows  %    ICPartners.DevxUI.Windows.Login   a ]DevExpress.Xpf.Core.v18.1, Version=18.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     9local'clr-namespace:ICPartners.DevxUI.Windows     ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  -     � AllowsTransparency  . 
������  � WindowState$ Normal=� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=� � Title$ Login��$	��270��$	��400�� � 	Resources    ShakeScreen �� TargetProperty W� From	 W� To	 g� Duration
 g� AutoReverse g� RepeatBehavior g� FillBehavior��%`   &	        �� $
 Left�.��W� $	 500X�$	 515X�$	 0:0:0.05D�
 . $ 3x��$
 Stop=�.����  �� CornerRadius$ 30��
������� �� Padding$ 6q�._�� $��10,10,10,10q� � ColumnDefinitions �� �� �� �� �� ��  � RowDefinitions �� $��4* ��� $��3* ��� $��3* ��� $��4* ��� $��3* ��� $��5* �.+�� $��1��$��1��$��4�� �� $��1* ��� $��8* �.+��� $��0��$%��/Source/LoginMenu/icon_user.png��$��24��$��2q�$
��auto���� -   $��tbName��$��20(�
������ $��1��$��Stretch=� �� TextAlignment$ Center=�$��Stretch=�� $��2��$��4��$��1��
������  �� $��1* ��� $��8* �.+��� $)��#/Source/LoginMenu/icon_password.png��$��0��$��24��$
��auto��$��2q�G� -   $��
tbPassword��
������ $��Stretch=�$��Center=�$��Stretch=�$��1���� -   $��InfoBox��$��1��$��3��$��40,2,2,2q�
���  ��$��4���� -   $��LoginBtn�� �� 	IsDefault . $��2q�$��4��$��3��$��2��.���� $��4��$��3��$��2��$��Stretch=�$��Stretch=� �� Orientation$ 
Horizontal=�.+��� $��3,3,10,3q�$G��A/ICPartners.DevxUI;component/Source/if_Complete_Symbol_381607.png��$��24��$
��auto���� $��Login��$��Center=�$��Right=�$��16(�&   DevExpress.Xpf.Core.SimpleButton  -   $��0q�$��2q�$��4��$��1��$��16(�$��2��.���� $��4��$��3��$��2��$��Stretch=�$��Stretch=�$ 
Horizontal=�.+��� $��3,3,10,3q�$=��7/ICPartners.DevxUI;component/Source/if_Block_381636.png��$��24��$
��auto���� $��Cancel��$��Center=�$��Right=�$��16(�