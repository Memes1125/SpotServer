   M S B A M L   `   `   `  ����F  BSpotyClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:SpotyClient.ViewSpotyClient.View  5   	   ?$clr-namespace:SpotyClient.ComponentsSpotyClient.Components  5   	   -    'SpotyClient.View.RecoveryPasswordWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:SpotyClient.View     5   	   ;
components$clr-namespace:SpotyClient.Components     5   	     � Title$  RecoveryPasswordWindow��5	   	   $	��560��6(   $	��300��65   ��5      �� 5   
    �� ImageSource$ ../Resource/bgvs.png��6   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $-��'Востановление пароля��6    
  Lables#��[  6/   
�������$��Center=�6b   $��10q�6   �� 5   
   $��1��6    � DataContext 6"   �� *
Recovery+.+�5      �� $��
Почта��6   #��[  6$   
�������$��Center=�6W   $��5q�6t   �� 5        TextBoxGray#��[ 6-   $��0 0 0 10q�6R   ��6   �� *Email+6R   5      � 5   
   $��2��6    � ColumnDefinitions 5      �� 5       �� 5!      .+�5#      ��  6   �� *ContextAcceptCode+.+�5$      �� $��Код��6   #��[  6&   
�������$��Center=�6Y   $��5q�6v   �� 5%      #��[ 66   $	��100��6[   $��0 0 0 10q�6g   ��6   �� *
AcceptCode+6g   5&      �� 5'      $��Получить код��6   $��1��6J     ButtonForImage#��[ 6Z   ��6,   �� *
SandMail+6Z   5(      �� 5)   
   $��3��6    6"   �� *
Recovery+.+�5*      �� $��Новый пароль��6   #��[  6+   
�������$��Center=�6^   $��5q�6{   0   *SpotyClient.Components.BindablePasswordBox  5+      $��	0 10 0 10q�6-      Password 6@   �� *
Password+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=� � ToolTip 5,      _� 5-      .��6   ��Пароль должен содержать буквы, цифры, (@, _ , - также допускаются) и состоять из 8-20 символов5/      51      52      �� 54   
   $��4��6   .+�55      �� $*��$Подтвердите пароль:��6   #��[  62   
�������$��Center=�6e   $��5q�6�     56      $��	0 10 0 10q�6-    6@   �� *PasswordConfirm+$ PropertyChanged=�$ TwoWay=�57      � 59   
   $��5��6    5:      �� 5;      �� 5<      .+�5?      �� $	��140��6   $��Сохранить��6!   $��Center=�6R   $��Center=�6m     GreenButton#��[ 6�   $��5 80 0 0q�6�   ��65   �� *
SaveUser+6�   �� 5@      $	��140��6   $��
Назад��6!   $��Center=�6J   $��Center=�6e   $��1��6�   #��[ 6�   $��5 80 0 0q�6�   ��61   �� *Back+6�   5B      5C      5D      