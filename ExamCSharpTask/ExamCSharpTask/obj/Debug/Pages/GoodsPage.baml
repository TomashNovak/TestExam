   M S B A M L   `   `   `  ����I  EExamCSharpTask, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:ExamCSharpTask.PagesExamCSharpTask.Pages  5      $    ExamCSharpTask.Pages.GoodsPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:ExamCSharpTask.Pages     5      -   5          N� Title$  	GoodsPage��5	      .��5      �  � RowDefinitions 5   
   �� 5      �� 5      $��60 �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 
Goods_Grid��5   A      AutoGenerateColumns .     
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Название��6>      Width5  /System.Windows.Controls.DataGridLengthConverter$ 1* 6P   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Name+	   ElementStyle	 5      �� 5      
 �� 
TargetType"
 ��6    .�5      ��  �� Property � �� �� Value$
 Wrap=�6=   6L   5      5        5      $ Цена��6?   $ 80 6M    6%   �� *Price+6M     5      $ Категория��6B   $
 0.5* 6U    6%   �� *
Category+	 5      �� 5      "
 ��6    .�5      ��  � ��$
 Wrap=�6=   6L   5      5       4  .System.Windows.Controls.DataGridTemplateColumn  5!      $	 220 6)      CellTemplate 5"      �� 5#      .R�5$      ��  ��Name$ Update_button��6%   -   5        $ ��Редактировать��5$   <   6T   5%      5'      5)      � 5*   
   $��1��6    � ColumnDefinitions 5+      �� 5,      �� 5-      .+�5/      �� -   5        $��Добавить��5/      $��2��6(   65   �� 50      -   5        $��Удалиить��50      $��2��6(   $��3��65   6E   51      52      53      