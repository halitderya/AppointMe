   M S B A M L   `   `   `  ���� L  HICPartners.DevxUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:ICPartners.DevxUI.UserControlsICPartners.DevxUI.UserControls  I EICPartners.DAL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:ICPartners.DAL;assembly=ICPartners.DALICPartners.DAL K*clr-namespace:ICPartners.DevxUI.ViewModelsICPartners.DevxUI.ViewModels  0    *ICPartners.DevxUI.UserControls.UCCustomer2   f bDevExpress.Xpf.Grid.v18.1.Core, Version=18.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa ]DevExpress.Xpf.Grid.v18.1, Version=18.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   a ]DevExpress.Xpf.Core.v18.1, Version=18.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     >local,clr-namespace:ICPartners.DevxUI.UserControls     ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  >DAL4clr-namespace:ICPartners.DAL;assembly=ICPartners.DAL  :	ViewModel*clr-namespace:ICPartners.DevxUI.ViewModels  ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  k	 gDevExpress.Xpf.ReportDesigner.v18.1, Version=18.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aXdxrudiKhttp://schemas.devexpress.com/winfx/2008/xaml/reports/userdesigner/internal 	   � 	Resources     CardViewTemplate<  6DevExpress.Xpf.Core.DataSources.EntitySimpleDataSource  EntitySimpleDataSource4  .DevExpress.Xpf.Core.DataSources.DataSourceBase   ContextType7   1ICPartners.DevxUI.ViewModels.AppointmentViewModel   Path7  1DevExpress.Xpf.Core.DataSources.DesignDataManager   
DesignData8  2DevExpress.Xpf.Core.DataSources.DesignDataSettings   RowCount��%D   &	        &	      ��   "  $ 	Customers��   $ 5��.���  � ColumnDefinitions �� $��1* ��� $��1* � � RowDefinitions �� $��1* ��� $	��10* �.+��� -   $��NewCard��.����  �� Orientation$ 
Horizontal=�.+��� $��Stretch=�$��Stretch=�$
��24px��$
��25px��$;��5/ICPartners.DevxUI;component/Source/UIMisc/create.png���� -    ��Name$ CreateTextBox��
������ $
��12px(�$
��Bold"�.��Create New Customer%  DevExpress.Xpf.Grid.GridControl  $��2��$��1��)  #DevExpress.Xpf.Grid.DataControlBase	   ItemsSource	 �� *Data+
 �� Source#
 [    View "  DevExpress.Xpf.Grid.CardView  -     Name$ CardView��$
��12px(�   ShowCardExpandButton .  &	   DevExpress.Xpf.Grid.DataViewBase 	  ShowSearchPanelMode$ Always=� 	  SearchPanelFindMode$ Always=�$ 	  UseLegacyColumnVisibleIndexes .     UseLightweightTemplates$
 NoneX�   AllowCardResizing .     
CardLayout$
 Rows=�&
   DevExpress.Xpf.Grid.GridViewBase 
  ShowGroupPanel .   	  SearchDelay$	 300��   CardHeaderBinding 1  +DevExpress.Xpf.DXBinding.DXBindingExtension  *><RowData.Row.CustomerName + ` ` + RowData.Row.CustomerSurname+   CardHeaderTemplate �� .R��� $
��auto��$
��auto��$ 
Horizontal=�.+��� $��0,0,5,0q�$
��16px(�
���\\��$
��Bold"���  *><RowData.Row.CustomerName + ` ` + RowData.Row.CustomerSurname+�� $��ButtonHistory��-   
������ $��0,0,5,0q�
 � Tag   *RowData.Row.CustomerID+.���� .+��� $
��16px��$
��auto��$<��6/ICPartners.DevxUI;component/Source/UIMisc/history.png���� $��ButtonDelete��-      *RowData.Row.CustomerID+.���� .+��� $
��16px��$
��auto��$;��5/ICPartners.DevxUI;component/Source/UIMisc/cancel.png��   Columns. $  DevExpress.Xpf.Grid.GridColumn  $  DevExpress.Xpf.Grid.ColumnBase   	FieldName$ 
CustomerID��$  DevExpress.Xpf.Grid.BaseColumn   Visible .     IsSmart .   $ CustomerTitle��   Header)  #DevExpress.Xpf.Core.ObjectConverter$ Title  .   $ CustomerName��$
 Name  .    Binding �� *CustomerName+ �� Mode$ TwoWay=�  �� NotifyOnSourceUpdated  . ! �� NotifyOnTargetUpdated! .   $ CustomerSurname��$ Surname  .  �� *CustomerSurname+$ TwoWay=�  . ! .   $ CustomerEmail��$ E-Mail  .  �� *CustomerEmail+$ TwoWay=�  . ! .   $ CustomerPhone��$ Phone  .  �� *CustomerPhone+$ TwoWay=�  . ! .   $ SecondPhone��$ Second Phone  .  �� *SecondPhone+$ TwoWay=�  . ! .   $ 
ThirdPhone��$ Third Phone  .  �� *
ThirdPhone+$ TwoWay=�  . ! .   $ CustomerAddress��$ Address  .  �� *CustomerAddress+$ TwoWay=�  . ! .   $ CustomerPostCode��$ Postcode  .  �� *CustomerPostCode+$ TwoWay=�  . ! .   $ CustomerCity��$
 City  .  �� *CustomerCity+$ TwoWay=�  . ! .   $ Remarks��$ Remarks  .  �� *	Remarks+$ TwoWay=�  . ! . "   EditSettings" 6  0DevExpress.Xpf.Editors.Settings.TextEditSettings  #   AcceptsReturn# . $   PrintTextWrapping$
$ WrapX�%   TextWrapping$% WrapWithOverflow=�