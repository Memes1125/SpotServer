   M S B A M L   `   `   `  ����F  BSpotyClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:SpotyClient.View.PagesSpotyClient.View.Pages  5      ^ ZEnterwell.Clients.Wpf.Notifications, Version=1.4.2.0, Culture=neutral, PublicKeyToken=null�gclr-namespace:Enterwell.Clients.Wpf.Notifications.Controls;assembly=Enterwell.Clients.Wpf.Notifications,Enterwell.Clients.Wpf.Notifications.Controls 5      Q MWPFTextBoxAutoComplete, Version=1.0.0.2, Culture=neutral, PublicKeyToken=null_Dclr-namespace:WPFTextBoxAutoComplete;assembly=WPFTextBoxAutoCompleteWPFTextBoxAutoComplete 5      ?$clr-namespace:SpotyClient.ComponentsSpotyClient.Components  5	      '    !SpotyClient.View.Pages.SearchPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:SpotyClient.View.Pages     5      |controlsgclr-namespace:Enterwell.Clients.Wpf.Notifications.Controls;assembly=Enterwell.Clients.Wpf.Notifications     5      Z	behaviorsDclr-namespace:WPFTextBoxAutoComplete;assembly=WPFTextBoxAutoComplete     5      8convert$clr-namespace:SpotyClient.Components     5	        N� Title$  
SearchPage��5       N� 
Background 5      �� 5   
    �� ImageSource$ /Resource/bgvs.png��6    � 	Resources 5         listPanelTemplate-   'SpotyClient.Components.ImgPathConverter  pathConverter��%O   &	        &	 (     �� 5   
   .R�5      � 5        5   
   6#   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5       � ColumnDefinitions 5   
   �� 5       �� 5!      .+�5#   
   O  IEnterwell.Clients.Wpf.Notifications.Controls.NotificationMessageContainer  $��1��6L   $��75��6\   $	��220��6h   $��Right=�6t   $	��Top=�6�      Manager 60   �� *	Manager+6�   �� 5$   
   $��50��6   $��2��6   $��1��60   $��Center=�6A   $��30(�6^   $��
Поиск��6l    
 Lables#��[ 6|   
�������6�   �� 5%   
   $��25��6   $��1��6   $	��Top=�6)   $��5 0 5 0q�6A   $��Поиск трека��6R   $	��Top=�6h   $��Center=�6�   #��[ 6�   $��11(�6�   
�������6�   �� 5&   
   $��25��6   $��1��6   $��1��6)   $	��Top=�69   $��5 0 5 0q�6Q   $��Поиск альбома��6b   $	��Top=�6z   $��Center=�6�   #��[ 6�   $��11(�6�   
�������6�   �� 5'   
   $��
10 25 0 10q�5)        TextBoxGray#��[ 5*      $��Center=�5+      $��1��5,      ��5(      �� *SearchTrack+ �� UpdateSourceTrigger$ PropertyChanged=�1  +WPFTextBoxAutoComplete.AutoCompleteBehavior   AutoCompleteItemsSource 5-      �� *TracksItems+�� 5/   
   $��
10 25 0 10q�51      #��[ 52      $��Center=�53      $��1��54      $��2��6   ��50      �� *SearchAlbum+$ PropertyChanged=� 55      �� *AlbumsItems+�� 58   
   #��[  5:        
ListAlbums#��[ 5;      $
��Auto=�5<        _ListBoxItemStyle#���  5=      
������ $��2��5>   +   	 �� SelectionMode$	 Extended=�5?      $��0q�5@      $��0 0 10 0q�6&   ��58      �� *Traks+
 �� SelectedItem
 59      �� *SelectedTrak+��5A      �� 5B      .R�5C      ��  �� Orientation$ Vertical=�6!   $��20q�68   .+�5D      �� 
�������$��5 5 5 5q�65    �� CornerRadius$ 150,150,150,150��6O   ._�5E      �� $	��150��6h   $	��150��6t   $��Center=�6�   $��UniformToFill=�6�   ��6$   �� *Image+ �� 	Converter# [  J� Clip 5F   "   @� 5G   &    @� Center$ 75 75&�66    @� RadiusX$ 75Q�6E    @� RadiusY$ 75Q�6R   5I      5J      �� 5K      $��Center=�69   $��Center=�6]   
�������$��15(�6�   $
��Bold"�6�   ��6    �� *Name+6�   5L      5M       � ContextMenu 5O      �� 5P      
�������.@�5Q      m� $��Слушать��6    m� Command 60   �� *Play+m� 5R      $&�� Добавить в Альбом��6    6:   �� *
AddInAlbum+m� 5S      $(��"Добавить в Любимое��6    6;   �� *
AddLikes+5T      5V      �� 5X   
   $��2��6   $��2��6   #��[  5Z      
������ #���  5]      #��[ 5^      $	 Extended=�5_      $
��Auto=�5`      ��5Y      �� *Albums+
 5[      �� *SelectedAlbum+��5a      �� 5b      .R�5c      �� $ Vertical=�6!   $��20q�68   .+�5d      �� 
�������$��5 5 5 5q�69   $ 150,150,150,150��6S   ._�5e      �� $	��150��6g   $	��150��6s   $��Center=�6�   $��UniformToFill=�6�   ��6$   �� *Image+# [  5f   "   @� 5g   &   $ 75 75&�66   $ 75Q�6E   $ 75Q�6R   5i      5j      �� 5k      
�������$��Center=�6L   $��Center=�6p   $��15(�6�   $
��Bold"�6�   ��6    �� *Name+6�   5l      5m       5o      �� 5p      
�������.@�5q      m� $!��Слушать альбом��6    67   �� *	PlayAlbum+m� 5r      $(��"Добавить в Любимое��6    6;   �� *AddLikesAlbumCommand+5s      5u      5v      5w      