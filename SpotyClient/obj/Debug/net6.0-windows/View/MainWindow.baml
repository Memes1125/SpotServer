   M S B A M L   `   `   `  ����F  BSpotyClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:SpotyClientSpotyClient  5   	   !    SpotyClient.View.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:SpotyClient     5   	   -   5          � WindowStyle$
  None=�5   	    � AllowsTransparency$
 True��6    � 
ResizeMode$ 	CanResize=�5	   	    � WindowStartupLocation$ CenterScreen=�5   	    � Title$ 
MainWindow��5   	   $	��450��6   $	��300��6,   $	��450��6;   $	��300��6K   ��5   
   �� 5   
    �� ImageSource$ ../Resource/bgvs.png��6   .��5      �  � RowDefinitions 5   
   �� 5      �� 5      $	��130 �6   �� 5      $��50 �6   .+�5   
   �� $��20��6*   $��20��66   $	��Top=�6A   
������ $��0q�6r   $��Right=�6�   $��0 5 5 0q�6�   ��6   �� *Exit+.��5      �� $��/Resource/chrest.png��6   5      �� 5   
   .+�5      �� $��/Resource/MEMEFY.png��6   $��50��62   $��Center=�6>   $��0 25 0 0q�6[   �� 5      $#��Миллионы треков��6   $��Center=�6.   $��0 70 0 0q�6K   $��20(�6]   $
��Bold"�6k   
�������6}   �� 5      $��
В Memefy.��6   $��Center=�6(   $��0 5 0 0q�6E   $��20(�6V   $
��Bold"�6d   
�������6v   5      �� 5    
   $��1��6   $��Center=�6"   $��0 0 0 80q�6=   .+�5!      �� $B��<Зарегистрироватся как слушатель��6      GreenButton#��[  6[   ��6?   �� *	RegUser+6[   5"      �� 5$   
   $��1��6   $��Center=�6"   $��0 10 0 0q�6=   .+�5%      �� $<��6Зарегистрироватся как артист��6   #��[  6Z   ��6<   �� *	RegArtist+6Z   5&      �� 5'   
   $��2��6   $��Center=�6"   $��	0 10 0 10q�6=   .+�5(      �� $��
Войти��6     
MenuButton#��[ 6@   ��6%   �� *SingIn+6@   5)      5*      5+      