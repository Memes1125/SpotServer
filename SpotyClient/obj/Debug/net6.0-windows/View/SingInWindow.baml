   M S B A M L   `   `   `  ����F  BSpotyClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:SpotyClient.ViewSpotyClient.View  5   	   ?$clr-namespace:SpotyClient.ComponentsSpotyClient.Components  5   	   #    SpotyClient.View.SingInWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:SpotyClient.View     5   	   ;
components$clr-namespace:SpotyClient.Components     5   	   -   5          � WindowStartupLocation$  CenterScreen=�5   	    � WindowStyle$
 None=�5	   	    � AllowsTransparency$
 True��6    � 
ResizeMode$ 	CanResize=�5   	    � Title$ SingInWindow��5   	   $	��400��6   $	��300��6+   ��5   
   �� 5       �� ImageSource$ ../Resource/bgvs.png��6   .��5      �  � RowDefinitions 5   
   �� 5      �� 5      $
��auto �6   .+�5   
   �� $��20��6*   $��20��66   $	��Top=�6A   
������ $��0q�6r   $��Right=�6�   $��0 0 5 0q�6�   ��6   �� *Exit+.��5      �� $��/Resource/chrest.png��6   5      �� 5   
    � DataContext 6   �� *Entry+.+�5!      �� $��Почта:��6   $��Center=�6%   $��Center=�6B   $
��Bold"�6]   
�������$��15(�6�   
������ $��0 25 0 0q�6�   �� 5"         TextBoxGray#��[  6-   $��0 10 0 0q�6R   ��6   �� *Email+6R   �� 5$      $��Пароль:��6   $��Center=�6&   $��Center=�6C   $
��Bold"�6^   
�������$��15(�6�   
������ $��0 25 0 0q�6�   0   *SpotyClient.Components.BindablePasswordBox  5%      $��	0 10 0 10q�6-      Password 6@   �� *
Password+	 �� UpdateSourceTrigger$	 PropertyChanged=�
 �� Mode$
 TwoWay=�5)      � 5*   
   $��1��6   $
��auto��6    � ColumnDefinitions 5+      �� 5,      $
��auto �6#   �� 5-      $
��auto �6#   .+�50      �� $	��140��6   $��1��6"   $��	5 10 5 10q�6J   $��Вход��6]   $��Bottom=�6l   $��Center=�6�     GreenButton#��[ 6�   ��6/   �� *SingIn+6�   �� 51      $	��140��6.   $��
Назад��6:   $��1��6J     ButtonForImage#��[ 6Z   $��	5 10 5 10q�6�   ��6   �� *Back+6�   52      54      55      