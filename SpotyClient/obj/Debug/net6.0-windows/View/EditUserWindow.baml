   M S B A M L   `   `   `  ����F  BSpotyClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:SpotyClient.ComponentsSpotyClient.Components  5   	   3clr-namespace:SpotyClient.ViewSpotyClient.View  5   	   %    SpotyClient.View.EditUserWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8convert$clr-namespace:SpotyClient.Components     5   	   0localclr-namespace:SpotyClient.View     5   	   -   5          � WindowStartupLocation$  CenterScreen=�5   	    � WindowStyle$
 None=�5	   	    � AllowsTransparency$
 True��6    � 
ResizeMode$ 	CanResize=�5   	    � Title$ EditUserWindow��5   	   $	��400��6    $	��300��6-   ��5   
   �� 5       �� ImageSource$ ../Resource/bgvs.png��6    � 	Resources 5   
   -   'SpotyClient.Components.ImgPathConverter   pathConverter��%   &	          5      6'   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      �� 5      .+�5   
   �� $��20��6*   $��20��66   $	��Top=�6A   
������ $��0q�6r   $��Right=�6�   $��0 0 5 0q�6�   ��6   �� *Exit+.��5      �� $��/Resource/chrest.png��6   5      �� 5    
   $��0 25 0 0q�66    � DataContext 6   �� *
EditUser+.+�5!      �� $.��(Придумайте псевдоним:��6   $��Center=�5"      $��0 5 0 0q�5#      $
��Bold"�5$      
�������$��15(�69   
������ 6G   �� 5&      $��	0 10 0 10q�6,     TextBoxGray#��[ 6?   ��6   �� *Name+6?   5'      �� 5)   
   $��1��6   .+�5*      �� $ ��Ваша картинка:��6   $��Center=�5+      $��0 5 0 5q�5,      $
��Bold"�5-      
�������$��15(�69   � 5/      	 � ColumnDefinitions	 50      �� 51      �� 52      .+�54      �� $��70��6   $��70��6$   $��0��6/   $��	0 20 0 20q�6?    6R   �� *
EditUser+��6s   �� *Image+
 �� 	Converter#
 [  �� 55      $'��!Добавить каритнку��69   $��Center=�6U   $��Center=�6r   $��1��6�     ButtonForImage#��[ 6�   ��6   �� *SelectImage+6�   56      58      �� 59   
   $��2��6     GreenButton#��[ 6;   $��Сохранить��6`   ��6   �� *
SaveUser+6`   5:      5;      