   M S B A M L   `   `   `  ����F  BSpotyClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:SpotyClient.ViewSpotyClient.View  5   	   ?$clr-namespace:SpotyClient.ComponentsSpotyClient.Components  5   	   +    %SpotyClient.View.RegisterArtistWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:SpotyClient.View     5   	   ;
components$clr-namespace:SpotyClient.Components     5   	   -   5          � WindowStartupLocation$  CenterScreen=�5   	    � WindowStyle$
 None=�5	   	    � AllowsTransparency$
 True��6    � 
ResizeMode$ 	CanResize=�5   	    � Title$ RegisterArtistWindow��5   	   $	��670��6&   $	��300��63   ��5   
   �� 5       �� ImageSource$ ../Resource/bgvs.png��6   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      .+�5   
   �� $��20��6*   $��20��66   $	��Top=�6A   
������ $��0q�6r   $��Right=�6�   $��0 0 5 0q�6�   ��6   �� *Exit+.��5      �� $��/Resource/chrest.png��6   5      �� 5    
   $��1��6   $��0 15 0 0q�6"    � DataContext 64   �� *	AddArtist+.+�5!      �� $.��(Придумайте псевдоним:��6   $��Center=�5"      $��0 5 0 0q�5#      $
��Bold"�5$      
�������$��15(�69   
������ 6G   �� 5&      $��	0 10 0 10q�6,      TextBoxGray#��[  6?   ��6   �� *Name+6?   5'      �� 5)   
   $��2��6    6"   �� *	AddArtist+.+�5*      �� $&�� Какая у вас почта?��6   $��Center=�5+      $��0 5 0 0q�5,      $
��Bold"�5-      
�������$��15(�69   �� 5/      $��	0 10 0 10q�6-   #��[  6@   ��6   �� *Email+6@   �� 50      $Q��KУкажите правильную форму Email'a - name@domain.suffix��6   $
��Wrap=�6U   $	��250��6i   ���#ff0033$��SemiBold"�6�   $��11(�6�   $��	35 -5 5 0q�6�   51      �� 53   
   $��3��6    6"   �� *	AddArtist+.+�54      �� $(��"Придумайте пароль:��6   $��Center=�55      $��0 5 0 0q�56      $
��Bold"�57      
�������$��15(�69   0   *SpotyClient.Components.BindablePasswordBox  59      $��	0 10 0 10q�6-      Password 6@   �� *
Password+	 �� UpdateSourceTrigger$	 PropertyChanged=�
 �� Mode$
 TwoWay=��� 5:      $����Пароль должен содержать буквы, цифры,     (@, _ , - также допускаются) и состоять из 8-20 символов��6   $	��250��6�   ���#ff0033$��SemiBold"�6�   $��11(�6�   $
��Wrap=�6�   $��	20 -5 5 0q�6�   5;      �� 5=   
   $��4��6   .+�5>      �� $*��$Подтвердите пароль:��6   $��Center=�5?      $��0 5 0 0q�5@      $
��Bold"�5A      
�������$��15(�69     5C      $��	0 10 0 10q�6-    6@   �� *PasswordConfirm+$	 PropertyChanged=�$
 TwoWay=�5D      �� 5F   
   $��5��6   .+�5G      �� $ ��Ваша картинка:��6   $��Center=�5H      $��0 5 0 5q�5I      $
��Bold"�5J      
�������$��15(�69   � 5L       � ColumnDefinitions 5M      �� 5N      �� 5O      .+�5Q      �� $��70��6   $��70��6$   $��0��6/   $��	0 10 0 10q�6?   ��6R   �� *Image+�� 5S      $'��!Добавить каритнку��69   $��Center=�6U   $��Center=�6r   $��1��6�     ButtonForImage#��[ 6�   ��6   �� *SelectImage+6�   5T      5V      � 5X   
   $��6��6   $
��auto��6    5Y      �� 5Z      $
��auto �6#   �� 5[      $
��auto �6#   .+�5_      �� $	��140��6   $*��$Зарегистрироваться��6!   $��Center=�6]   $��Center=�6x     GreenButton#��[ 6�   $��5 0 0 0q�6�   ��6>   �� *
SaveArtist+6�   �� 5`      $	��140��6   $��
Назад��6!   $��Center=�6J   $��Center=�6e   $��1��6�   #��[ 6�   ��61   �� *Back+6�   5a      5b      5c      