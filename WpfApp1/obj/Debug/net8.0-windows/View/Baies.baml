   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:WpfApp1.ViewWpfApp1.View  5          WpfApp1.View.Baies   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:WpfApp1.View     5      .��5	      �   � ShowGridLines$  False��6    � ColumnDefinitions 5
   
   �� 5      $	��100 �6   �� 5      $��2* �6   �� 5      $	��100 �6    � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��2* �6   �� 5      $��50 �6   �� 5      $��50 �6   .+�5   
   �� $
��auto��6   $b��\C:\Users\JuryEpreuve.WORKTOGETHER\source\repos\WorkTogether_ClientLourd\WpfApp1\img\logo.png��6   $��1��6�   $��0��6�   $	��Top=�6�   �� 5   
   $��1��6   $��0��6!   $��Baies��6.   $��Center=�6>   $
��Bold"�6[   $��75(�6m   &   System.Windows.Controls.DataGrid  5   
   -   5        $��DatagridBaie��5   r      AutoGenerateColumns$ False��6V   $��1��6�   $��1��6�      SelectionMode$ Single=�6J  ��6   �� *Baie+ �� SelectedItem 60   �� *SelectedBaie+   
IsReadOnly 6�   ��  �� Path$
 User� �� Current	 �� Source#	 Z  %  !SharedObjectToisReadOnlyConverter
 �� 	Converter#
 [   �� ConverterParameter$ 
ROLE_ADMIN��   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Identifiant :��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6S   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *Id+6S     5      $ 	Numéro :��6%   $ * 6R    67   �� *Numero+6R     5      $ Nombre d'unités :��6%   $ * 6c    6@   �� *NbrEmplacement+6c     5      $ Statut :��6%   $ * 6R    67   �� *Status+6R   5!      �� 5%   
   -   5         ��Name$ Ajouter��5%      $��Ajouter��6"   $	��100��6K   $
��Left=�6[   $��50��6v   $��2��6�   $��1��6�     ButtonStyle#��[ 6L  y�6�   �� $
 User�#	 Z  ' #SharedUserRoleToVisibilityConverter#
 [ $ 
ROLE_ADMIN��6L  �� 5&   
   -   5        $ 	Supprimer��5&      $��	Supprimer��6$   $	��100��6Q   $��Center=�6a   $��50��6~   $��2��6�   $��1��6�   #��[ 6T  y�6�   �� $
 User�#	 Z #
 [ $ 
ROLE_ADMIN��6T  �� 5'   
   -   5        $ Modifier��5'      $��Modifier��6#   $	��100��6N   $��Right=�6^   $��50��6{   $��2��6�   $��1��6�   #��[ 6Q  y�6�   �� $
 User�#	 Z #
 [ $ 
ROLE_ADMIN��6Q  5(      5)      