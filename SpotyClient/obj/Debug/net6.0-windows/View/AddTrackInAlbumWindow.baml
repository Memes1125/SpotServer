   M S B A M L   `   `   `  ����Q  MWPFTextBoxAutoComplete, Version=1.0.0.2, Culture=neutral, PublicKeyToken=null_Dclr-namespace:WPFTextBoxAutoComplete;assembly=WPFTextBoxAutoCompleteWPFTextBoxAutoComplete  5   	   F BSpotyClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:SpotyClient.ViewSpotyClient.View 5   	   ,   &SpotyClient.View.AddTrackInAlbumWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Z	behaviorsDclr-namespace:WPFTextBoxAutoComplete;assembly=WPFTextBoxAutoComplete     5   	   0localclr-namespace:SpotyClient.View     5   	   -   5          � WindowStartupLocation$  CenterScreen=�5   	    � WindowStyle$
 None=�5	   	    � AllowsTransparency$
 True��6    � 
ResizeMode$ 	CanResize=�5   	    � Title$ AddTrackInAlbumWindow��5   	   $	��500��6'   $	��300��64   ��5      �� 5   
    �� ImageSource$ ../Resource/bgvs.png��6   .��5      � .+�5   
   �� 
���   �$��1q�6%   
������  �� CornerRadius$ 5��6R   ._�5      �  � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $��* �6$   �� 5      $
��Auto �6$   .+�5      �� 
������ $��0q�62   $��20��6_   $��20��6k   $	��Top=�6v   $��Right=�6�   ��6F   �� *Exit+.��5      �� $��/Resource/chrest.png��6   5      �� 5      $��0��6    �� Orientation$ 
Horizontal=�6*   $��Center=�6C   $��0 20 0 5q�6`   .+�5       �� $��Поиск:��6    
�������$
��Bold"�6A   $��Center=�6T   $��0,0,5,0q�6o   �� 5!      $	��150��5#         TextBoxGray#��[  6%   $��30��5$      $��Center=�5%      ��5"      �� *
SearchText+	 �� UpdateSourceTrigger$	 PropertyChanged=�1   +WPFTextBoxAutoComplete.AutoCompleteBehavior
   AutoCompleteItemsSource
 5&      �� *	TestItems+5(      �� 5*      $��1��6   $��0q�6'   
������ $��5q�6�   ��6T   �� *
AlbumsUser+ �� SelectedItem 6w   �� *SelectedAlbumsUser+��5+      �� 5,      .R�5-      �� 
�������$��15(�6X   $
��Bold"�6f   $��Center=�6y   $��Center=�6�   ��6$   �� *Albums.Name+6�   5.      50      �� 52      $��2��6   $ 
Horizontal=�6*   $��Center=�6C   $��5 0 0 10q�6`   $	��300��6r   .+�53      �� $��Сохранить��6     GreenButton#��[ 61   $	��140��6V   $��35��6b   $��15,0,5,0q�6n   $
��Left=�6�   ��6�   �� *AddTrackInAlbum+6�   �� 54      $��
Назад��6     ButtonForImage#��[ 6-   $��5,0,5,0q�6U   ��6f   �� *ExitCommand+55      56      57      58      59      