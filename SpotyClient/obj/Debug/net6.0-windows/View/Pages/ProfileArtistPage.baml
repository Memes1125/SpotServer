   M S B A M L   `   `   `  ����F  BSpotyClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:SpotyClient.ComponentsSpotyClient.Components  5      ?$clr-namespace:SpotyClient.View.PagesSpotyClient.View.Pages  5      ^ ZEnterwell.Clients.Wpf.Notifications, Version=1.4.2.0, Culture=neutral, PublicKeyToken=null�gclr-namespace:Enterwell.Clients.Wpf.Notifications.Controls;assembly=Enterwell.Clients.Wpf.Notifications,Enterwell.Clients.Wpf.Notifications.Controls 5      .    (SpotyClient.View.Pages.ProfileArtistPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8convert$clr-namespace:SpotyClient.Components     5      6local$clr-namespace:SpotyClient.View.Pages     5      |controlsgclr-namespace:Enterwell.Clients.Wpf.Notifications.Controls;assembly=Enterwell.Clients.Wpf.Notifications     5        N� Title$  ProfileArtistPage��5       � 	Resources 5      -   'SpotyClient.Components.ImgPathConverter   pathConverter  listPanelTemplate��%_   &	        &	        5   
   6#   �� 5   
   .R�5      � $
��auto��6   5      5      .��5      � ���#3B3B3B � RowDefinitions 5   
   �� 5      �� 5      .+�5   
   �� $��2��6   .��5      �� .+�5      �� 
�������.+�5      �  � ColumnDefinitions 5      �� 5      $	��210 �6/   �� 5      �� 5       $	��125 �6/   .+�5#      �� $	��250��6�   $
��auto��6�   $��3��6�   $
��Fill=�6�    � DataContext 6    �� *ProfileArtist+��6F   �� *Image+ �� 	Converter# [  5%      O  IEnterwell.Clients.Wpf.Notifications.Controls.NotificationMessageContainer  5&      $��3��6\   $��Right=�6q   $	��Top=�6�      Manager 6@   �� *	Manager+6�   �� 5(      $��2��6    $
��Bold"�6s   $��60(�6�   $
��Left=�6�   $��Bottom=�6�   $��	15 0 0 30q�6�   
������� 64   �� *ProfileArtist+��6Z   �� *Name+6�   �� 5)      $��2��6!   $ ��Редактировать��61     GreenButtonProfile#��[ 6b   $��Center=�6�   $��Center=�6�   $��0 0 0 0q�6�   ��6I   �� *Edit+6�   5*      5+      � 5-      $��1��6    5.      �� 5/      �� 50      .+�53      �� ���#3B3B3B.+�54      �� $!��Создать альбом��6!     AddAlbum#��[ 6W   $
��Left=�6y   $��	10 10 0 0q�6�   ��6:   �� *
NewAlbum+6�   �� 55      $��Ваши Альбомы��6    $
��Left=�67   $��	10 10 0 0q�6Y    
 Lables#��[ 6l   �� 56      -   5        $��2��56   "   #��[ 58        
ListAlbums#��[ 5:        _ListBoxItemStyle#���  5;      ��57      �� *AlbumsArtist+ �� SelectedItem 59      �� *SelectedAlbumsArtist+��5=      �� 5>   "   .R�5?   &   ��  �� Orientation$ Vertical=�61   $��20q�6H   .+�5@   *   �� ���	#FF000000$��5 5 5 5q�6I   	 �� CornerRadius$	 150,150,150,150��6c   ._�5A   .   �� $	��150��6~   $	��150��6�   $��Center=�6�   $��UniformToFill=�6�   ��64   �� *Albums.Image+# [  
 J� Clip
 5B   2   @� 5C   6    @� Center$ 75 75&�6F    @� RadiusX$ 75Q�6U    @� RadiusY$ 75Q�6b   5E   /   5F   +   �� 5G   *   
�������$��15(�6d   $
��Bold"�6r   $��Center=�6�   $��Center=�6�   ��60   �� *Albums.Name+6�   5H   '   5I   #    � ContextMenu 5K      �� 5L   "   
�������.@�5M   &   m� $ ��Редактировать��6/    m� Command 6F   �� *	EditAlbum+m� 5N   &   $!��Слушать альбом��6/    6G   �� *	PlayAlbum+m� 5O   &   $��Удалить��6/    6@   �� *DeleteAlbum+5P   #   5R      5S      �� 5W      $��2��6!   ���#3B3B3B.+�5X      �� $��Создать трек��6!   #��[ 6U   $��90��6w   $
��Left=�6�   $��	10 10 0 0q�6�   ��68   �� *
AddTrack+6�   �� 5Y      $��Ваши Треки��6    $
��Left=�65   $��	10 10 0 0q�6W   #��[ 6j   �� 5Z      -   5        $��2��5Z   "   #��[ 5\      #��[ 5^      #���  5_      ��5[      �� *ArtistTracks+ 5]      �� *SelectedTrack+��5a      �� 5b   "   .R�5c   &   �� $ Vertical=�61   $��20q�6H   .+�5d   *   �� ���	#FF000000$��5 5 5 5q�6I   $	 150,150,150,150��6c   ._�5e   .   �� $	��150��6~   $	��150��6�   $��Center=�6�   $��UniformToFill=�6�   ��64   �� *Tracks.Image+# [  
 5f   2   @� 5g   6   $ 75 75&�6F   $ 75Q�6U   $ 75Q�6b   5i   /   5j   +   �� 5k   *   
�������$��15(�6d   $
��Bold"�6r   $��Center=�6�   $��Center=�6�   ��60   �� *Tracks.Name+6�   5l   '   5m   #    5o      �� 5p   "   
�������.@�5q   &   m� $ ��Редактировать��6/    6F   �� *	EditTrack+m� 5r   &   $��Играть��6/    6?   �� *Play+m� 5s   &   $&�� Добавить в Альбом��6/    6J   �� *
AddInAlbum+m� 5t   &   $��Удалить��6/    6@   �� *DeleteTrack+5u   #   5w      5x      5z      5{      5|      5}      5~      