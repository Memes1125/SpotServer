   M S B A M L   `   `   `  ����^  ZEnterwell.Clients.Wpf.Notifications, Version=1.4.2.0, Culture=neutral, PublicKeyToken=null�gclr-namespace:Enterwell.Clients.Wpf.Notifications.Controls;assembly=Enterwell.Clients.Wpf.Notifications,Enterwell.Clients.Wpf.Notifications.Controls  5      F BSpotyClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:SpotyClient.View.PagesSpotyClient.View.Pages 5      ?$clr-namespace:SpotyClient.ComponentsSpotyClient.Components 6:   %   SpotyClient.View.Pages.MainPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      |controlsgclr-namespace:Enterwell.Clients.Wpf.Notifications.Controls;assembly=Enterwell.Clients.Wpf.Notifications     5      6local$clr-namespace:SpotyClient.View.Pages     5      8convert$clr-namespace:SpotyClient.Components     6:     N� Title$  MainPage��5
       N� 
Background 5      �� 5   
    �� ImageSource$ /Resource/bgvs.png��6    � 	Resources 5      -  'SpotyClient.Components.ImgPathConverter   pathConverter  listPanelTemplate��%O   &	        &	        5   
   6#   �� 5   
   .R�5      � 5      5      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   O   IEnterwell.Clients.Wpf.Notifications.Controls.NotificationMessageContainer  $��1��6L   $��75��6\   $	��220��6h   $��Right=�6t   $	��Top=�6�      Manager 60   �� *	Manager+6�   � 5   
    5       �� 5!      $
��auto �6    �� 5"      .+�5%      �� $��Исполнители��6   $��Center=�6*    
 Lables#��[ 6G   
�������$��10 5 0 0q�6z   �� 5&      $��1��6   
������ #��[ 5)        
ListAlbums#��[ 5+      $��Visible=�5,        _ListBoxItemStyle#���  5-      ��5(      �� *	Artists+ �� SelectedItem 5*      �� *SelectedArtist+��5.      �� 5/      .R�50      ��  �� Orientation$ Vertical=�6%   $��20q�6<   .+�51      �� ���	#FF000000$��5 5 5 5q�6=    �� CornerRadius$ 150,150,150,150��6W   ._�52   "   �� $	��150��6k   $	��150��6w   $��Center=�6�   $��UniformToFill=�6�   ��6(   �� *Image+	 �� 	Converter#	 [  
 J� Clip
 53   &   @� 54   *    @� Center$ 75 75&�6:    @� RadiusX$ 75Q�6I    @� RadiusY$ 75Q�6V   56   #   57      �� 58      
�������$��15(�6Q   $
��Bold"�6_   $��Center=�6r   $��Center=�6�   ��6$   �� *Name+6�   59      5:      5<      5=      � 5>   
   $��1��6    5?      �� 5@      $
��auto �6    �� 5A      .+�5D      �� $��
Треки��6   $��Center=�6$   #��[ 6A   
�������$��10 5 0 0q�6t   �� 5E      $��1��6   
������ #��[ 5H      #��[ 5J      $��Visible=�5K      #���  5L      ��5G      �� *Tracks+ 5I      �� *SelectedTrack+��5O      �� 5P      .R�5Q      �� $ Vertical=�6%   $��20q�6<   .+�5R      �� ���	#FF000000$��5 5 5 5q�6>   $ 150,150,150,150��6X   ._�5S   "   �� $	��150��6k   $	��150��6w   $��Center=�6�   $��UniformToFill=�6�   ��6(   �� *Image+#	 [  
 5T   &   @� 5U   *   $ 75 75&�6:   $ 75Q�6I   $ 75Q�6V   5W   #   5X      �� 5Y      
�������$��15(�6Q   $
��Bold"�6_   $��Center=�6r   $��Center=�6�   ��6$   �� *Name+6�   5Z      5[       � ContextMenu 5]      �� 5^      
�������.@�5_      m� $(��"Добавить в любимое��6#    m� Command 6?   �� *AddLikesTrackCommand+m� 5`      $&�� добавить в альбом��6#    6>   �� *
AddInAlbum+m� 5a      $��Играть��6#    63   �� *Play+5b      5d      5e      � 5g   
   $��2��6    5h      �� 5i      $
��auto �6    �� 5j      .+�5m      �� $��Альбомы��6   $��Center=�6&   #��[ 6C   
�������$��10 5 0 0q�6v   �� 5n      $��1��6   
������ #��[ 5q      #��[ 5s      $��Visible=�5t      #���  5u      ��5p      �� *Albums+ 5r      �� *SelectedAlbum+��5x      �� 5y      .R�5z      �� $ Vertical=�6%   $��20q�6<   .+�5{      �� ���	#FF000000$��5 5 5 5q�6>   $ 150,150,150,150��6X   ._�5|   "   �� $	��150��6k   $	��150��6w   $��Center=�6�   $��UniformToFill=�6�   ��6(   �� *Image+#	 [  
 5}   &   @� 5~   *   $ 75 75&�6:   $ 75Q�6I   $ 75Q�6V   5�   #   5�      �� 5�      
�������$��15(�6Q   $
��Bold"�6_   $��Center=�6r   $��Center=�6�   ��6$   �� *Name+6�   5�      5�       5�      �� 5�      
�������.@�5�      m� $(��"Добавить в любимое��6#    6?   �� *AddLikesAlbumCommand+m� 5�      $!��Слушать альбом��6#    6;   �� *	PlayAlbum+5�      5�      5�      5�      5�      