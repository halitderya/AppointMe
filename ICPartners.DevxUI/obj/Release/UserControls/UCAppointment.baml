   M S B A M L   `   `   `  ���� L  HICPartners.DevxUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:ICPartners.DevxUI.UserControlsICPartners.DevxUI.UserControls  5clr-namespace:ICPartners.DevxUIICPartners.DevxUI  I EICPartners.DAL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:ICPartners.DAL;assembly=ICPartners.DALICPartners.DAL K*clr-namespace:ICPartners.DevxUI.ViewModelsICPartners.DevxUI.ViewModels  2    ,ICPartners.DevxUI.UserControls.UCAppointment   a ]DevExpress.Xpf.Core.v18.1, Version=18.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     f bDevExpress.Xpf.Grid.v18.1.Core, Version=18.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa ]DevExpress.Xpf.Grid.v18.1, Version=18.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  :d2http://schemas.microsoft.com/expression/blend/2008  8local,clr-namespace:ICPartners.DevxUI.UserControls  *rootclr-namespace:ICPartners.DevxUI  ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  >DAL4clr-namespace:ICPartners.DAL;assembly=ICPartners.DAL  ;
ViewModels*clr-namespace:ICPartners.DevxUI.ViewModels  j	 fDevExpress.Xpf.LayoutControl.v18.1, Version=18.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol 	 g
 cDevExpress.Xpf.Scheduling.v18.1, Version=18.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aOdxschtBhttp://schemas.devexpress.com/winfx/2008/xaml/scheduling/themekeys 
 Ddxsch8http://schemas.devexpress.com/winfx/2008/xaml/scheduling 
 ] YDevExpress.Mvvm.v18.1, Version=18.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aAdxmvvm2http://schemas.devexpress.com/winfx/2008/xaml/mvvm   Ldxschv?http://schemas.devexpress.com/winfx/2008/xaml/scheduling/visual 
 -     � DataContext  1  +DevExpress.Mvvm.UI.ViewModelSourceExtension     Type7   1ICPartners.DevxUI.ViewModels.AppointmentViewModel"   � 	Resources 1   +ICPartners.DevxUI.ViewModels.ColorConverter     KeyColorConverter  �� !resourceHeaderContentTemplate  .R��  � RowDefinitions �� $��* ��� $
��Auto �.+��� $	��120��$	��120��$��Center=�$	��Top=� �� BitmapScalingMode$ NearestNeighbor=�$��Uniform=����� *Resource.CustomFields.Photo+�� $��1��.+��� $��Center=�$
��Bold"����� *Resource.Caption+�� $ appointmentFlyoutContentTemplate  .R�0 	 *DevExpress.Xpf.LayoutControl.LayoutControl  $	��250��$	��150�� J� IsHitTestVisible .  . 	 (DevExpress.Xpf.LayoutControl.LayoutGroup   Orientation$ Vertical=�4 	 .DevExpress.Xpf.LayoutControl.LayoutControlBase   Padding$ 11q�.+���  �� Orientation$ Vertical=�.+�< 
 6DevExpress.Xpf.Scheduling.Visual.DayAppointmentControl  $��35��	 K� ZIndex$	 0��$	��Top=�9 
 3DevExpress.Xpf.Scheduling.Visual.AppointmentControl
   ShowRecurrenceImage
 .     ShowReminderImage .     
ShowStatus .  '	  !DevExpress.Xpf.Core.Native.Chrome 	  Content �� ��C� *G
 
 ADevExpress.Xpf.Scheduling.Themes.SchedulerFlyoutThemeKeyExtension
  �  �DevExpress.Xpf.Utils.Themes.ThemeKeyExtensionInternalBase`1[[DevExpress.Xpf.Scheduling.Themes.SchedulerFlyoutThemeKeys, DevExpress.Xpf.Scheduling.v18.1, Version=18.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a]]   ResourceKey$ Appointment=�+�� $ 
Horizontal=�.+�4 
 .DevExpress.Xpf.Scheduling.Visual.FastTextBlock     Text$ #��   FontSize$ 12Q�   
FontWeight$
 Bold"�   
Foreground
 �   �  $ 12Q�
 �   � �� *Appointment.Id+  $��0,5,0,0q�$	��Top=�$ Vertical=�$ 0q�.+�- 	 'DevExpress.Xpf.LayoutControl.LayoutItem  ��C� *
  $ LayoutItem_Start=�+  ��C� *
  $ LayoutItem_End=�+  $��0,5,0,0q�$	��Top=�$ Vertical=�$ 0q�.+�  ��C� *
  $ LayoutItem_Resources=�+�� $ 
Horizontal=�.+�  $ Job(s): ��$ 12Q�$
 Bold"�
 �   �  $ 12Q�
 �   � �� * Appointment.CustomFields[Jobs]+ �� 	Converter 3   -ICPartners.DevxUI.ViewModels.JobNameConverter  �� $ 
Horizontal=�.+�  $ 
Customer: ��$ 12Q�$
 Bold"�
 �   �  $ 12Q�
 �   � �� *)'Appointment.CustomFields[CustomerRefId]+ 8   2ICPartners.DevxUI.ViewModels.CustomerNameConverter  ��   ��C� *
  $ LayoutItem_Description=�+�� appointmentContentTemplate  .R�> 
 8DevExpress.Xpf.Scheduling.Visual.AppointmentContentPanel  ����  �� Color �� * Appointment.CustomFields[Jobs]+  ColorConverter# [  �� Mode$ OneWay=�   IntervalSubject J 
 DDevExpress.Xpf.Scheduling.Visual.AppointmentIntervalSubjectPresenter     Location C 
 =DevExpress.Xpf.Scheduling.Visual.AppointmentLocationPresenter     Description �� $��0,0,0,0q�.+�  $ Normal"�
 �   �$ 8Q�   WordWrap .  �� *)'Appointment.CustomFields[CustomerRefId]+     $ Normal"�   	FontStyle$ Italic$�$ 8Q�   FontStretch$ ExtraCondensed&�
 �   � �� * Appointment.CustomFields[Jobs]+   F 
 @DevExpress.Xpf.Scheduling.Visual.AppointmentDescriptionPresenter  $ Normal"�$��0,1,0,0q� .    Images = 
 7DevExpress.Xpf.Scheduling.Visual.AppointmentImagesPanel  ��  �� 
TargetType< 
 6DevExpress.Xpf.Scheduling.Visual.ResourceHeaderControl"  .��� 4 
 .DevExpress.Xpf.Scheduling.Visual.HeaderControl �� Property �@ ContentOrientation �� Value$ 
Horizontal=���  � ��
 �����.���   � ColumnDefinitions  �� �� $
��auto � �� $��4* �.+�0 
 *DevExpress.Xpf.Scheduling.SchedulerControl  -   !  Name$! MainScheduler��$��0��+"   $AllowAppointmentDragBetweenResources" .  $  appointmentFlyoutContentTemplate#   FlyoutContentTemplate## [ $
��Left=�$��0��$	��Top=�$   	GroupType$$ Resource=�%   AllowInplaceEditor% .  &   FirstDayOfWeek$& Monday=�'   WorkDays$' EveryDay=�(   AppointmentItems( / 
 )DevExpress.Xpf.Scheduling.AppointmentItem  -   	Customers��)   OptionsWindows) . 
 (DevExpress.Xpf.Scheduling.OptionsWindows  *   AppointmentWindowType/   )ICPartners.DevxUI.CustomAppointmentWindow"*  2  ,DevExpress.Mvvm.UI.Interactivity.Interaction+   	Behaviors+ '  !DevExpress.Mvvm.UI.EventToCommand  �  �DevExpress.Mvvm.UI.Interactivity.EventTriggerBase`1[[System.Windows.DependencyObject, WindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35]],   	EventName$, AppointmentsUpdated��-   PassEventArgsToCommand$- FalseX�+  %DevExpress.Mvvm.UI.EventToCommandBase.   Command. �� *AppointmentsUpdatedCommand+/   
DataSource/ * 
 $DevExpress.Xpf.Scheduling.DataSource  -   0 �Name$
0 fefe��1   DateTimeSavingMode$1 Appointment=�2   AppointmentsSource2 �� *Appointments+$ TwoWay=�3 �� UpdateSourceTrigger$3 PropertyChanged=� 4   AppointmentStatusesSource4 �� *StatusState+5   ResourcesSource5 �� *	Resources+ 6   AppointmentStatusMappings6 9  
 3DevExpress.Xpf.Scheduling.AppointmentStatusMappings   7    Brush7! 
 1DevExpress.Xpf.Scheduling.Common.MappingConverter$7 Brush! 	8    Id$8 Id! 9    Caption$9 Caption! :   AppointmentMappings: 3" 
 -DevExpress.Xpf.Scheduling.AppointmentMappings"  ; "  Start$; 	StartDate! 	< "  Id$< AppointmentID! 
= "  End$= EndDate! > "  StatusId$> AppointmentStatus! ? "  
ResourceId$? ResourceRefID! ,# 
 &DevExpress.Xpf.Scheduling.MappingsBase@ #  CustomFieldMappings.@ 2$ 
 ,DevExpress.Xpf.Scheduling.CustomFieldMapping$  A $  Mapping$
A Jobs! B $  Name$
B Jobs��$  $A CustomerRefId! $B CustomerRefId��$  $A 
UpdateDate! $B 
UpdateDate��$  $A ParentID! $B ParentID��$  $A ChargedAmount! $B ChargedAmount��$  $A Remarks! $B Remarks��$  $A 
ColorBrand! $B 
ColorBrand��$  $A 	ColorCode! $B 	ColorCode��$  $A ColorQuantity! $B ColorQuantity��$  $A ColorActivator! $B ColorActivator��C   ResourceMappingsC 0% 
 *DevExpress.Xpf.Scheduling.ResourceMappings%  D %  Caption$D ResourceName! 	E %  Id$E 
ResourceID! F %  Visible$F ResourceVisibility! G %  GroupG '& 
 !DevExpress.Xpf.Scheduling.Mapping&  H &  ConversionBehavior$H BetweenFieldAndMapping=�I &  	FieldName$I Index��J &  	ConverterJ Z� .@ $  $A ResourceImage! $B Photo��K   Views.K '' 
 !DevExpress.Xpf.Scheduling.DayView'  -   L ' Name$L dayView1��(( 
 "DevExpress.Xpf.Scheduling.ViewBase"M (  NavigationButtonsVisibility$M Never=�N (  ResourcesPerPage$N 5Q�+) 
 %DevExpress.Xpf.Scheduling.DayViewBaseO )  ShowAllDayAreaO .  P )  ShowWorkTimeOnlyP . Q )  SnapToCellsMode$Q Never=�  appointmentContentTemplate!R )  AppointmentContentTemplate#R [ S )  	TimeScale$S 00:15:00h� ! resourceHeaderContentTemplate$T (  ResourceHeaderContentTemplate#T [ U (  ShowResourceNavigatorU .  'V )   ShowTimeIndicatorOverAppointmentV . 8*  2DevExpress.Xpf.Editors.DateNavigator.DateNavigator*  $��1��W *  ShowWeekNumbersW .  X *  AllowMultipleRangesX .  Y *  StyleSettingsY C+ 
 =DevExpress.Xpf.Scheduling.SchedulerDateNavigatorStyleSettings+  Z +  	SchedulerZ �� [ �� ElementName$[ MainScheduler��