   M S B A M L   `   `   `  ���� L  HICPartners.DevxUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:ICPartners.DevxUI.WindowsICPartners.DevxUI.Windows  1    +ICPartners.DevxUI.Windows.CreateNewCustomer   a ]DevExpress.Xpf.Core.v18.1, Version=18.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     9local'clr-namespace:ICPartners.DevxUI.Windows     ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  -     � WindowStartupLocation$  CenterOwner=� � WindowStyle$
 None=� � Title$ Create New Customer��$	��350��$	��600�� � 	Resources ,  &DevExpress.Xpf.Editors.EnumItemsSource     KeyEnumItemsSource     EnumType)   #ICPartners.DevxUI.Windows.TitleList"  .��� $��10q� � ColumnDefinitions �� �� ��  � RowDefinitions �� �� �� �� �� .+��� -   $��buttoncancel��$��1��$��4��.����  �� Orientation$ 
Horizontal=�.+��� $;��5/ICPartners.DevxUI;component/Source/UIMisc/cancel.png��$��10q��� $��Cancel��$��16(�$��Center=�$��20,0,0,0q��� -   $��
buttonsave�� �� 	IsDefault . $��2��$��4��.���� $ 
Horizontal=�.+��� $9��3/ICPartners.DevxUI;component/Source/UIMisc/save.png��$��10q��� $
��Save��$��Black"�$��16(�$��Center=�$��20,0,0,0q�A� 	 A� Columns$	 1��
 A� Rows$
 2��$��0��$��0��.+��� $��16(�.��Title�� -   $��Title������   EnumItemsSource �� Source# [ A� $	 1��$
 2��$��0��$��1��.+��� $��16(�.��Name�� -   $
��Name��$��16(�A� $	 1��$
 2��$��0��$��2��.+��� $��16(�.��	Surname�� -   $��Surname��$��16(�A� $	 1��$
 2��$��1��$��0��.+��� $��16(�.��E-Mail�� -   $��Email��$��16(�A� $	 1��$
 2��$��1��$��1��.+��� $��16(�.��Phone�� -   $��Phone��$��16(�A� $	 1��$
 2��$��1��$��2��.+��� $��16(�.��
Postcode�� -	   $��Postcode��$��16(�A� $	 1��$
 2��$��2��$��0��$��2��.+��� $��16(�.��Adress�� -
   $��Adress��$��16(�A� $	 1��$
 2��$��2��$��2��.+��� $��16(�.��City�� -   $
��City��$��16(�