   M S B A M L   `   `   `  ����F  BSpotyClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:SpotyClient.ComponentsSpotyClient.Components  5   	   3clr-namespace:SpotyClient.ViewSpotyClient.View  5   	   %    SpotyClient.View.AddAlbumWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8convert$clr-namespace:SpotyClient.Components     5   	   0localclr-namespace:SpotyClient.View     5   	   -   5          � WindowStartupLocation$  CenterScreen=�5	   	    � WindowStyle$
 None=�5
   	    � AllowsTransparency$
 True��6    � 
ResizeMode$ 	CanResize=�5   	    � Title$ AddAlbumWindow��5   	   $	��400��6    $	��300��6-   ��5   
   �� 5       �� ImageSource$ ../Resource/bgvs.png��6    � 	Resources 5   
   -   'SpotyClient.Components.ImgPathConverter   pathConverter��%   &	          5      6'   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      .+�5   
   �� $��20��6*   $��20��66   $	��Top=�6A   
������ $��0q�6r   $��Right=�6�   $��0 5 5 0q�6�   ��6   �� *Exit+.��5      �� $��/Resource/chrest.png��6   5       �� 5!   
   $��0 15 0 0q�6    � DataContext 6(   �� *
AddAlbum+.+�5"      �� $&�� Название альбома:��6   $��Center=�5#      $��0 5 0 0q�5$      $
��Bold"�5%      
�������$��15(�69   
������ 6G   �� 5'      $��	0 10 0 10q�6,     TextBoxGray#��[ 6?   ��6   �� *Name+6?   5(      �� 5*   
   $��1��6   .+�5+      �� $,��&Изображение альбома:��6   $��Center=�5,      $��0 5 0 5q�5-      $
��Bold"�5.      
�������$��15(�69   � 50      	 � ColumnDefinitions	 51      �� 52      �� 53      .+�55      �� $��70��6   $��70��6%   $��0��60   $��	0 10 0 10q�6@   ��6S   �� *Image+
 �� 	Converter#
 [   6�   �� *
AddAlbum+�� 57      $'��!Добавить каритнку��69   $��Center=�6U   $��Center=�6r   $��1��6�     ButtonForImage#��[ 6�   ��6   �� *SelectImage+6�   58      59      �� 5:   
   $��2��6   $y�Hidden=�6G    6"   �� *AddUserAlbum+6G   � 5;   
   $��2��6   	 5<      �� 5=      �� 5>      .+�5B      �� $	��140��6   $��Сохранить��6!   $��Center=�6S   $��Center=�6n     GreenButton#��[ 6�   $��5 80 0 0q�6�   ��65   �� *	SaveAlbum+6�   �� 5C      $	��140��6   $��
Назад��6!   $��Center=�6J   $��Center=�6e   $��1��6�   #��[ 6�   $��5 80 0 0q�6�   ��61   �� *Back+6�   5D      5G      5H      