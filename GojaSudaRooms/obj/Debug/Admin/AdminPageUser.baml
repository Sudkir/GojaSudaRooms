   M S B A M L   `   `   `  ����H  DGojaSudaRooms, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:GojaSudaRooms.AdminGojaSudaRooms.Admin  5      '    !GojaSudaRooms.Admin.AdminPageUser   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:GojaSudaRooms.Admin     5        N� Title$  AdminPageUser��5	       N� 
Background �#EEEEEE.��5      �  � RowDefinitions 5   
   �� 5      $��70 �6   �� 5      $	��330 �6   .+�5   
   � $��0��6    � Orientation$ 
Horizontal=�6!   $
��Left=�6:   $��Center=�6U   .+�5      �� -   5         ��Name$ 
btnBackFrm��5      $��<��6)      	ButtonTwo#��[  68   6[   5      �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   $��Center=�6W   �� 5   
   -   5         ��Name$ LvUser��5       $��1��6    �� View 5      �� 5      .P�5      �� $��Фамилия��6%    �� Width$	 100��66   	 �� DisplayMemberBinding	 6B   �� *
LastName+�� 5      $��Имя��6%   $	 100��62   	 6>   �� *	FirstName+�� 5      $��Отчество��6%   $	 100��67   	 6C   �� *
Patronymic+�� 5      $!��Номер телефона��6%   $	 100��6=   	 6I   �� *Phone+�� 5      $'��!Электронная почта��6%   $	 150��6@   	 6L   �� *Email+5      5!      5"      5#      