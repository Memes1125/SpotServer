   M S B A M L   `   `   `  ����F  BSpotyClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:SpotyClient.View.PagesSpotyClient.View.Pages  5      ^ ZEnterwell.Clients.Wpf.Notifications, Version=1.4.2.0, Culture=neutral, PublicKeyToken=null�gclr-namespace:Enterwell.Clients.Wpf.Notifications.Controls;assembly=Enterwell.Clients.Wpf.Notifications,Enterwell.Clients.Wpf.Notifications.Controls 5      ?$clr-namespace:SpotyClient.ComponentsSpotyClient.Components  5      /    )SpotyClient.View.Pages.MyMediaLibraryPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:SpotyClient.View.Pages     5      |controlsgclr-namespace:Enterwell.Clients.Wpf.Notifications.Controls;assembly=Enterwell.Clients.Wpf.Notifications     5      8convert$clr-namespace:SpotyClient.Components     5        N� Title$  MyMediaLibraryPage��5       N� 
Background 5      �� 5   
    �� ImageSource$ /Resource/bgvs.png��6    � 	Resources 5         listPanelTemplate-   'SpotyClient.Components.ImgPathConverter  pathConverter��%O   &	        &	 (     �� 5   
   .R�5      � 5        5   
   6#   5      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      .+�5   
   O  IEnterwell.Clients.Wpf.Notifications.Controls.NotificationMessageContainer  $��1��6L   $��75��6\   $	��220��6h   $��Right=�6t   $	��Top=�6�      Manager 60   �� *	Manager+6�   � 5   
   $��0��6    5       �� 5!      $
��auto �6    �� 5"      .+�5%      �� $��Любимые Треки��6    
 Lables#��[ 6,   
�������$��10 5 0 0q�6_   � 5&      $��0 30 0 0q�6    5'      �� 5(      �� 5)      .+�5+      �� $	��790��6   
������ ._�5,      � .+�5-      �� $��#��6    $��20��6,   $��20��6:   $
��Left=�6H   $��	-70 0 0 0q�6j   �� 5.      $
��name��6    $	��300��6/   $	��300��6>   $��Center=�6M   �� 5/      $��duration��6    $	��300��63   $	��300��6B   $��Center=�6Q   50      51      52      �� 53      -   5         ��Name$
 list��53   #   $��1��6   
������ $��0q�6�   ��6J   �� *
UserTracks+ �� SelectedItem 6m   �� *SelectedUserTrack+��54      �� 55      .R�56      �  � Orientation$ 
Horizontal=�6$   $	��790��6=   
������ .+�57      �� $��50��6?   $��50��6M   $
��Left=�6[   $��Center=�6v   ��6$   �� *Number+6v   � 58      	 � ColumnDefinitions	 59   "   �� 5:   &   �� 5;   &   .+�5=   "   �� $��45��6�   $��45��6�   $��40 5 0 0q�6�   ��6(   �� *traksL.Image+
 �� 	Converter#
 [  �� UpdateSourceTrigger$ PropertyChanged=�6�   � 5>   "   $��1��6'   $��252.5��67   $��252.5��6H    5?   &   �� 5@   *   $
��auto �68   �� 5A   *   $
��auto �68   .+�5C   &   �� $��70 0 0 0q�6,   
�������$��15(�6r   $
��Bold"�6�   $
��Left=�6�   ��6>   �� *traksL.Name+6�   5D   #   5E      � 5F      	 5G   "   �� 5H   &   $
��auto �67   �� 5I   &   $
��auto �67   .+�5K   "   �� $��	110 0 0 0q�6L   $��1��6_   $	��190��6o   $	��190��6~   
�������$��Center=�6�   ��6(   �� *traksL.Duration+6�   5L      5M      5N       � ContextMenu 5P      �� 5Q      
�������.@�5R      m� $��Слушать��6#    m� Command 64   �� *Play+m� 5S      $&�� Добавить в альбом��6#    6>   �� *
AddInAlbum+m� 5T      $��Удалить��6#    64   �� *DeleteTrack+5U      5W      5X      � 5Z   
   $��1��6    5[      �� 5\      $
��auto �6    �� 5]      .+�5`      �� $#��Любимые Альбомы��6   #��[ 6.   
�������$��10 5 0 0q�6a   �� 5a      $��2��6   #��[  5c        
ListAlbums#��[ 5e      
������ $��Visible=�5g        _ListBoxItemStyle#���  5h      ��5b      �� *LikesAlbums+ 5d      �� *SelectedLikesAlbum+��5i      �� 5j      .R�5k      ��  �� Orientation$ Vertical=�6%   $��20q�6<   .+�5l      �� ���#ffff$��5 5 5 5q�69    �� CornerRadius$ 150,150,150,150��6S   ._�5m   "   �� $	��150��6r   $	��150��6~   $��Center=�6�   $��UniformToFill=�6�   ��6(   �� *Albums.Image+#
 [  J� Clip 5n   &   @� 5o   *    @� Center$ 75 75&�6:    @� RadiusX$ 75Q�6I    @� RadiusY$ 75Q�6V   5q   #   5r      �� 5s      
�������$��Center=�6W   $��Center=�6{   ��6$   �� *Albums.Name+6{   5t      5u       5w      �� 5x      
�������.@�5y      m� $!��Слушать альбом��6#    6;   �� *	PlayAlbum+m� 5z      $��Удалить��6#    64   �� *DeleteAlbum+5{      5}      5~      5      5�      