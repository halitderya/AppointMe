   M S B A M L   `   `   `  ���� L  HICPartners.DevxUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:ICPartners.DevxUI.UserControlsICPartners.DevxUI.UserControls  0    *ICPartners.DevxUI.UserControls.CustomTile2   a ]DevExpress.Xpf.Core.v18.1, Version=18.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     >local,clr-namespace:ICPartners.DevxUI.UserControls     j fDevExpress.Xpf.LayoutControl.v18.1, Version=18.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol  =core2http://schemas.devexpress.com/winfx/2008/xaml/core    � 	Resources  0   *ICPartners.DevxUI.UserControls.CustomTile2 �� 
TargetType �� Property �� Value �� 
TargetType �� Padding J� RenderTransformOrigin0  *DevExpress.Xpf.Core.FrameworkElementHelper   	IsClipped �� CornerRadius'  !System.Windows.VisualStateManager	   VisualStateGroups%  System.Windows.VisualStateGroup
   Transitions%  System.Windows.VisualTransition	   To   GeneratedDuration   From   States   System.Windows.VisualState   
Storyboard �� 
TargetName �� TargetProperty	 W� To g� Duration+  %DevExpress.Xpf.Core.MultiplyConverter   Key ��Name g� FillBehavior R� KeyTime R� Value  System.Windows.Visibility �� ElementName �� Path  MultiplyConverter �� 	Converter �� ConverterParameter O� KeyTime O� Value9	  3System.Windows.Media.Animation.EasingDoubleKeyFrame 	  EasingFunction.
  (System.Windows.Media.Animation.CubicEase7  1System.Windows.Media.Animation.EasingFunctionBase   
EasingMode,  &DevExpress.Xpf.Core.ContentControlBase    ContentH  BDevExpress.Xpf.LayoutControl.MaximizableHeaderedContentControlBase!   CurrentContentTemplate'  !DevExpress.Xpf.LayoutControl.Tile"   PreviousContent4  .DevExpress.Xpf.Core.HeaderedContentControlBase#   Header$   HeaderTemplate %   HorizontalHeaderAlignment&   VerticalHeaderAlignment' �� RelativeSource��%�  '        7  �� "  .���  � �� �� "  .R��� $
��root��$ 5q�#��z��$ 0.5,0.5&� . $ 8��	   CommonStates��
   $ Pressed��$ 0:0:0.1D�  $ Pressed��$ 0:0:0.1D�.   
Normal��  	MouseOver��  Pressed��. �� .��W� $
 root��$ (RenderTransform).ScaleX�$
 0.97X�$ 0D�W� $
 root��$ (RenderTransform).ScaleY�$
 0.97X�$ 0D�z���   ��  MultiplyConverter  �� $ ContentChangeStoryboard��ContentChangeStoryboard  $
 Stop=�.��T� $ previousContent��$ 
Visibility�$ 0:0:0.15D�$
 Stop=�.�i� $ 0��  Visible=�W� $ previousContent��$ (RenderTransform).Y�$ 0:0:0.15D� �� $
 root��$ ActualHeight�8   $ -1��U� $ content��$ (RenderTransform).Y�$ 0:0:1D�.\�n� $ 0�� �� $
 root��$ ActualHeight�n� $ 0:0:0.15�� �� $
 root��$ ActualHeight��� $ 0:0:0.4��$ 20Q�	  $ 0:0:1��$ 0Q� 
  $ EaseOut=�._�� .+��� $��content��#��z  #��z! #��z��#��z��z�T� �� $��previousContent��#��z" #��z! #��z��#��z��$y�	Collapsed=�z�T� �� #��z# #��z$ #��z% #��z& #��z��y��� *CalculatedHeaderVisibility+' �� *TemplatedParent+.  � 