   M S B A M L   `   `   `  ����B  >WPFmvvm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WPFmvvmWPFmvvm  5   	       WPFmvvm.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WPFmvvm     5   	     � Title$  
MainWindow��5   	   $��441.2��6   $
��1198��6+   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��* �6   �� 5      $
��0.5* �6   �� 5      $
��0.5* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ TaskListGrid��5      $��0��6)      SelectionMode$ Single=�6l   $��0��6�      AutoGenerateColumns .     
IsReadOnly . $
��Left=�6�   $��	10,10,0,0q�6�   $	��Top=�6  $	��186��6'  $	��478��64   �� SelectedItem 69   �� *SelectedTaskListViewModel+��6�   �� *
Tasklist+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$
	 Name��6?   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 6M   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Name+6M     5      $	 Create Date��6E   $
 * 6Z    6%   �� *
CreateDate+6Z     5      $	 Due date��6A   $
 * 6S    6%   �� *	DueDate+6S   5      �� 5   
   $��1��6   $��0��6%    � DataContext 62   �� *
Tasklist+.+�5      �� $��Selected task list��6   �� 5      $
��Name��6   �� 5      ��6   �� *Name+ �� UpdateSourceTrigger$ PropertyChanged=�5        5    
   -   5        $ TaskGrid��5       $��0��6%   $��1��65    .   . $
��Left=�6�   $��	10,10,0,0q�6  $	��Top=�6  $	��186��6.  $	��478��6;  ��6C   ��  �� ElementName$ TaskListGrid�� �� Path$ SelectedItem.TaskListID� 6�   �� *SelectedTask+ 5!        5"      $
	 Name��6>   $
 * 6L    6%   �� *Name+6L   5%      �� 5&   
   $��2��6   $��0��6%   $	��206��62   $��0.4,0,0,0.4q�6?   $��Bottom=�6T   .+�5'      �� $��Add task list��6   �� 5(      $
��Name��6   �� 5)      ��6   �� *NewTaskListName+(  "System.Windows.Controls.DatePicker  5*         SelectedDate 6   �� *
NewDueDate+�� 5+      ��6   �� *AddTaskListCommand+.��6<   Add new task list6O   �� 5,      $��Delete selected task list��6   �� 5-      ��6   �� *DeleteTaskListCommand+��5.      �� *SelectedTaskListViewModel+.��6L   Delete Selected Task list6g   5/      �� 51   
   $��2��6   $��1��6%   .+�52      �� $#��Add task to current task list��6   �� 53      ��6   �� *NewTaskName+�� 54      $��Status��6   �� 55      -   5         ��Name$ CBStatus��55      $��	0,0,0.4,0q�6)   .@�56      �� $
��Open��6   �� 57      $��Closed��6   58      �� 59      ��6   �� *
AddCommand+.��64   Add69   �� 5:      ��6   �� *DeleteTaskCommand+��5;      �� *SelectedTaskViewModel+.��6H   Delete Selected Task6^   5=      5@      5A      