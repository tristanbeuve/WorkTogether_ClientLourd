   M S B A M L   `   `   `  ���� B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:WpfApp1.ViewWpfApp1.View      WpfApp1.View.Baies   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ,localclr-namespace:WpfApp1.View     .���   � ShowGridLines$  False�� � ColumnDefinitions �� $	��100 ��� $��2* ��� $	��100 � � RowDefinitions �� $	��100 ��� $��2* ��� $��50 ��� $��50 �.+��� $
��auto��$b��\C:\Users\JuryEpreuve.WORKTOGETHER\source\repos\WorkTogether_ClientLourd\WpfApp1\img\logo.png��$��1��$��0��$	��Top=��� $��1��$��0��$��Baies��$��Center=�$
��Bold"�$��75(�&   System.Windows.Controls.DataGrid  -   $��DatagridBaie��   AutoGenerateColumns$ False��$��1��$��1��   SelectionMode$ Single=����� *Baie+ �� SelectedItem �� *SelectedBaie+   
IsReadOnly ��  �� Path$
 User� �� Current	 �� Source#	 Z  %  !SharedObjectToisReadOnlyConverter
 �� 	Converter#
 [   �� ConverterParameter$ 
ROLE_ADMIN��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Identifiant :��   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Id+  $ 	Numéro :��$ *  �� *Numero+  $ Nombre d'unités :��$ *  �� *NbrEmplacement+  $ Statut :��$ *  �� *Status+�� -    ��Name$ Ajouter��$��Ajouter��$	��100��$
��Left=�$��50��$��2��$��1��  ButtonStyle#��[ y��� $
 User�#	 Z  ' #SharedUserRoleToVisibilityConverter#
 [ $ 
ROLE_ADMIN���� -   $ 	Supprimer��$��	Supprimer��$	��100��$��Center=�$��50��$��2��$��1��#��[ y��� $
 User�#	 Z #
 [ $ 
ROLE_ADMIN���� -   $ Modifier��$��Modifier��$	��100��$��Right=�$��50��$��2��$��1��#��[ y��� $
 User�#	 Z #
 [ $ 
ROLE_ADMIN��