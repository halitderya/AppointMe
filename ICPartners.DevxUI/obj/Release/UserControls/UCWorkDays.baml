   M S B A M L   `   `   `  ���� L  HICPartners.DevxUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:ICPartners.DevxUI.UserControlsICPartners.DevxUI.UserControls  I EICPartners.DAL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:ICPartners.DAL;assembly=ICPartners.DALICPartners.DAL K*clr-namespace:ICPartners.DevxUI.ViewModelsICPartners.DevxUI.ViewModels  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem M IICPartners.Domains, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS<clr-namespace:ICPartners.Domains;assembly=ICPartners.DomainsICPartners.Domains /    )ICPartners.DevxUI.UserControls.UCWorkDays   a ]DevExpress.Xpf.Core.v18.1, Version=18.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     >local,clr-namespace:ICPartners.DevxUI.UserControls     f	 bDevExpress.Xpf.Grid.v18.1.Core, Version=18.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa
 ]DevExpress.Xpf.Grid.v18.1, Version=18.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid 	 
 ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  >DAL4clr-namespace:ICPartners.DAL;assembly=ICPartners.DAL  ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  ;
ViewModels*clr-namespace:ICPartners.DevxUI.ViewModels  3System&clr-namespace:System;assembly=mscorlib  JDomains<clr-namespace:ICPartners.Domains;assembly=ICPartners.Domains    � 	Resources  <  6DevExpress.Xpf.Core.DataSources.EntitySimpleDataSource   EntitySimpleDataSource4  .DevExpress.Xpf.Core.DataSources.DataSourceBase   ContextType&   ICPartners.DAL.ICPartnersContext   Path7  1DevExpress.Xpf.Core.DataSources.DesignDataManager   
DesignData8  2DevExpress.Xpf.Core.DataSources.DesignDataSettings   RowCount  EntityResourceSource;  5DevExpress.Xpf.Core.DataSources.IEnumerableDataSource  IEnumerableDataSource   DataObjectType  ICPartners.Domains.OffDay��%�   &	        &	 )     &	 T       "  $ OffDays��   $ 5��  "  $ 	Resources��   $ 5��     "  $ 5��.���  � ColumnDefinitions �� �� ��  � RowDefinitions �� $��8* ��� $��1* �.+�% 
 DevExpress.Xpf.Grid.GridControl  -     Name$ gridworkdays��$��3��)	 	 #DevExpress.Xpf.Grid.DataControlBase	 	  ItemsSource	 �� *Data+
 �� Source#
 [     View #
 
 DevExpress.Xpf.Grid.TableView
  -    
 Name$ 	tableview�� 
  	AutoWidth .   
  NewItemRowPosition$ Bottom=� 
  AllowChangeBandParent .  & 
  DevExpress.Xpf.Grid.GridViewBase   ShowGroupPanel .  & 	  DevExpress.Xpf.Grid.DataViewBase    AllowMoveColumnToDropArea .   
  AllowBandMoving .      RowCellMenuCustomizations '  !DevExpress.Xpf.Bars.BarButtonItem  -     Name$ deleteRowItem��!  DevExpress.Xpf.Bars.BarItem   Content)  #DevExpress.Xpf.Core.ObjectConverter$ Delete   -   $ copyCellDataItem��$ Copy Cell Data    Columns. $ 
 DevExpress.Xpf.Grid.GridColumn  $ 	 DevExpress.Xpf.Grid.ColumnBase   	FieldName$ ResourceRefID��   IsSmart . $ 	 DevExpress.Xpf.Grid.BaseColumn   Header$ Resource    EditSettings :  4DevExpress.Xpf.Editors.Settings.ComboBoxEditSettings  <  6DevExpress.Xpf.Editors.Settings.LookUpEditSettingsBase   DisplayMember$ ResourceName��   ValueMember$ 
ResourceID��   ItemsSource �� *Data+#
 [   $ OffDaysType�� .    $
 Text��$ Value��  $ 
OffWeekDay�� .    $
 Text��$ Value��  $ OffDaysStart�� .  6  0DevExpress.Xpf.Editors.Settings.DateEditSettings    $ 
OffDaysEnd�� .    �� -    ��Name$ 
SaveButton��$��2��{�.  $��2��$��20(�.��� $��Stretch=�$��Stretch=�   �� 
TargetType  �� Property! �� Value��%F   '��       �� " ��.���   � ��$! 5q���   � ��$! Center=� �� $��3* ��� $	��10* �.+��� $-��'../Source/if_Complete_Symbol_381607.png��$��2q�$��0��$��Stretch=�$��Stretch=��� $��1���� $
�Save��