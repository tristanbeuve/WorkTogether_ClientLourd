   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApp1.WindowsWpfApp1.Windows  5   	   !    WpfApp1.Windows.WindowLogin   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfApp1.Windows     5   	     � Title$  	Connexion��5   	   $	��250��6   $	��400��6+   $	��250��6:   $	��400��6J   .��5	      �    AppBackgroundStyle#��[  6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $	��100��6   $b��\C:\Users\JuryEpreuve.WORKTOGETHER\source\repos\WorkTogether_ClientLourd\WpfApp1\img\logo.png��6    $��1��6�   $��0��6�   �� 5   
   $��1��6   $��1��6$   $��WorkTogether��61   $��Center=�6E   $��Center=�6b   �� 5      $��0��6   $��2��6%   $��Nom d'utilisateur :��62   $��Center=�6P   �� 5       -   5        $��txtUsername��5    4   $��1��6   $��2��6'   $��Center=�6G   $��Center=�6b   $	��200��6   �� 5"      $��0��6   $��3��6$   $��Mot de passe :��61   $��Center=�6J   G� 5#      -   5        $��txtPassword��5#   7   $��1��6   $��3��6*   $��Center=�6J   $��Center=�6e   $	��200��6�   �� 5%   
   -   5         ��Name$	 Log��5%      $��1��6   $��5��6.   $��Se Connecter��6;   $
��Left=�6l   $��Center=�6�     ButtonStyleLogin#��[ 6�   �� 5(   
   -   5        $ Close��5(      $��1��6    $��5��60   $��Fermer��6=   $��Bottom=�6h   $��Right=�6�   #��[ 6�   5-      5.      