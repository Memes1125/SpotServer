   M S B A M L   `   `   `  ����F  BSpotyClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:SpotyClient.ViewSpotyClient.View  5   	   ?$clr-namespace:SpotyClient.ComponentsSpotyClient.Components  5   	   %    SpotyClient.View.AddTrackWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:SpotyClient.View     5   	   8convert$clr-namespace:SpotyClient.Components     5   	   -   5          � WindowStartupLocation$  CenterScreen=�5	   	    � WindowStyle$
 None=�5
   	    � AllowsTransparency$
 True��6    � 
ResizeMode$ 	CanResize=�5   	    � Title$ AddAlbumWindow��5   	   $	��550��6    $	��300��6-   ��5   
   �� 5       �� ImageSource$ ../Resource/bgvs.png��6    � 	Resources 5   
   -   'SpotyClient.Components.ImgPathConverter   pathConverter/   )SpotyClient.Components.TrackPathConverter  trackPathConverter��%:   &	        &	        5      6'     5      6)   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      .+�5!   
   �� $��20��6*   $��20��66   $	��Top=�6A   
������ $��0q�6r   $��Right=�6�   $��0 5 5 0q�6�   ��6   �� *Exit+.��5"      �� $��/Resource/chrest.png��6   5#      �� 5$   
   $��0 15 0 0q�6    � DataContext 6(   �� *
AddTrack+.+�5%      �� $"��Название трека:��6   $��Center=�5&      $��0 5 0 0q�5'      $
��Bold"�5(      
�������$��15(�69   
������ 6G   �� 5*      $��	0 10 0 10q�6Q     TextBoxGray#��[ 6d   ��6   �� *Name+	 �� UpdateSourceTrigger$	 PropertyChanged=�6d   5+      �� 5-   
   $��1��6   $��0 5 0 0q�6"    63   �� *
AddTrack+.+�5.      �� $*��$Длительность трека:��6   $��Center=�5/      $��0 5 0 0q�50      $
��Bold"�51      
�������$��15(�69   
������ 6G   �� 53      $��	0 10 0 10q�6b   #��[ 6u   ��6   �� *
Duration+$	 PropertyChanged=�
 �� Mode$
 TwoWay=�6u   54      �� 56   
   $��2��6   .+�57      �� $(��"Изображение трека:��6   $��Center=�58      $��0 5 0 5q�59      $
��Bold"�5:      
�������$��15(�69   � 5<       � ColumnDefinitions 5=      �� 5>      �� 5?      .+�5A      �� $��70��6   $��70��6%   $��0��60   $��	0 10 0 10q�6@   ��6S   �� *Image+ �� 	Converter# [   6�   �� *
AddTrack+�� 5C      $'��!Добавить каритнку��69   $��Center=�6U   $��Center=�6r   $��1��6�     ButtonForImage#��[ 6�   ��6   �� *SelectImage+6�   5D      5E      �� 5F   
   $��3��6   .+�5G      �� $��Файл трека:��6   $��Center=�5H      $��0 5 0 5q�5I      $
��Bold"�5J      
�������$��15(�69   � 5L      .+�5M      r�  r� LoadedBehavior$ Manual=�6    r� Source 67   �� *Track1+# [ �� 5N      $��Выбрать файл��69   $��Center=�6P   $��Center=�6m   $��1��6�   #��[ 6�   ��6   �� *SelectTrack+6�   5O      5P      � 5R   
   $��4��6   $��0 30 0 0q�6    5S      �� 5T      �� 5U      .+�5Y      �� $	��140��6   $��Сохранить��6!   $��Center=�6S   $��Center=�6n     GreenButton#��[ 6�   $��5 80 0 0q�6�   ��65   �� *	SaveTrack+6�   �� 5Z      $	��140��6   $��
Назад��6!   $��Center=�6J   $��Center=�6e   $��1��6�   #��[ 6�   $��5 80 0 0q�6�   ��61   �� *Back+6�   5[      5\      5]      