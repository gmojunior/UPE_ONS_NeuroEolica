   M S B A M L   `   `   `  ����  UPE_ONS    UPE_ONS.ImportacaoPrevEOL   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   X TXceed.Wpf.Toolkit, Version=2.1.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   .��5      �   � RowDefinitions  5	   
   �� 5
      $��75 �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��Center=�6!   $��Center=�6>   $��Importar arquivos PrevEOL��5      $
��Wrap=�65   $��30(�6I   � 5   
   -   5        $��gridContent��5      $��1��6   .+�5      �� -   5        $��feedbackMessage��5      $��Center=�5      $
��Wrap=�65   $&�� Arquivos importados com sucesso!��5      $
��Bold"�6@   $��0 30 0 0q�5      
��� � �$	��Top=�6=   $y�Hidden=�5   /   &   System.Windows.Controls.DataGrid  5      -   5        $$��dataGridImportacaoPrevEOLFiles��5   >   $��Center=�5      $	��Top=�64      AutoGenerateColumns .  $��0 50 0 0q�5      $	��500��6%   $	��250��61      RowHeaderWidth$ 0Q�6d      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Arquivo��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6N      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� 6X   5      �� 5      -   5        $��Importar��5      $��Center=�6(   $	��Top=�5       $��25��6)   $	��100��65   $��1��6A   $��400 325 0 0q�6u   5!      � 5#   
   -   5        $��gridPaternProgressBar��5#      $y�	Collapsed=�6,   $��1��6C   
������� J� Opacity$	 0.5Q�5$      � 5%   
   -   5        $��GridProgressBar��5%   '   $	��200��6   $��90��6   $y�	Collapsed=�5&      $��1��6*   ��5'      �� 5(      	 �� 
StartPoint$	 0.5,0&�6&   
 �� EndPoint$
 0.5,1&�69   .��5)      �  � Color$ White��6#    � Offset$ 0Q�61   � 5*      $ 	LightGray��6#   $ 1Q�65   5+      .+�5-      �� 
�������$��1q�6(    �� CornerRadius$ 2��6<   ._�5.      �� $��4q�6   .+�5/      �� $��Aguarde, processando...��6    $
��Bold"�6?   $��Center=�50   $   $��0 5 0 0q�6A   �� 51      $��4q�6!   .+�52      �� -   5        $��txtProgressValue��52   $   $��5 5 0 0q�6<   � 53      -   5        $��
processBar��53   U    � IsIndeterminate . $��15��6>   $��5q�6J   6U   54      55      56      57      � 59   
   -	   5        $��gridMessage��59      $y�Hidden=�6"   $��1��66   
�������.+�5:      �� -
   5        $��
txtMessage��5;      $��Center=�5:      $
��Wrap=�65   $��Center=�6I   5;      5<      5=      5>      