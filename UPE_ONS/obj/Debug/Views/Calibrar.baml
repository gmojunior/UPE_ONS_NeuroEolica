   M S B A M L   `   `   `  ����  UPE_ONS    UPE_ONS.Views.Calibrar   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      X TXceed.Wpf.Toolkit, Version=2.1.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5      $��Center=�5      .��5	      %  Xceed.Wpf.Toolkit.BusyIndicator  -   5        $��BusyIndicatorCarregando��5	   C       BusyContent$  Carregando...��6      IsBusy . .��5
   
   �  � RowDefinitions 5      �� 5      $��75 �6    �� 5      $��* �6    .+�5      �� -   5        $��	txtTitulo��5   /   $��Center=�5      $��Center=�65   $
��Wrap=�6P   $��Calibrar Rede Neural��6d   $��30(�5      $��0��6"   $��2��6@   � 5      -   5        $��gridContent��5       $��1��6   .+�5      �� -   5        $��feedbackMessage��5      $��Center=�5      $
��Wrap=�69   $.��(Parques Eólicos calibrados com sucesso!��5      $
��Bold"�6G   $��0 10 0 0q�5      
��� � �$	��Top=�6=   $y�Hidden=�5   /   �� 5      -   5        $��lstViewParquesEolicos��5   X   $��Center=�5      $��1��68   $	��Top=�5      $	��250��6+   $	��350��68   $��
0 75 375 0q�6D    � DataContext 5   E   �� *ListatParquesEolicos+ �� View 5      �� 5      .P�5      �� $��Parques Eólicos��6-    �� DisplayMemberBinding 6F   �� *Nome+�� 5      $��Última Calibração��6-    �� Width$	 150��6I    6U   �� *Calibracao.Data+ �� StringFormat$ {0:dd/MM/yyyy HH:mm}��5       5"      �� 5$      -   5        $'��!lstViewParquesEolicosSelecionados��5%   D   $��Center=�5$      $	��Top=�68   $	��250��6P   $	��350��6]   $��1��5%      $��1��6#   $��
375 75 0 0q�60    5$   i   �� *!ListaParquesEolicosSelecionados+ 5&      �� 5'      .P�5(      �� $#��Parques Eólicos Selecionados��6-    6T   �� *Nome+5)      5+      � 5-      $��1��6   $��50��6$   $	��Top=�60   $��	0 335 0 0q�6H   .+�5.      �� -   5        $��<��5.      $��Center=�6,   $��0 0 65 0q�6I   $	��Top=�6[   $��35��6s   6~   �� 5/      -   5        $��<<��5/      $��Center=�60   $��	0 0 175 0q�6M   $	��Top=�6`   $��35��6x   6�   �� 51      -	   5        $��>��51      $��Center=�6,   $��65 0 0 0q�6I   $	��Top=�6[   $��35��6s   6~   �� 52      -
   5        $��>>��52      $��Center=�60   $��	175 0 0 0q�6M   $	��Top=�6a   $��35��6y   6�   53      (  "System.Windows.Controls.DatePicker  55      -   5        $��datePickerDataInicial��56   9   $��Center=�55      $��
0 40 555 0q�6:   $��1��6N   $	��Top=�56      $	��170��6-    � 	Resources 57      :  4System.Windows.Controls.Primitives.DatePickerTextBox	 �� 
TargetType
 �� Property �� Value��%\   '        �� 58      "	  6    .�59      �� 
 � ��$ Data Inicial��65   5:      5;      5<        5=      -   5        $��datePickerDataFinal��5>      $��Center=�5=      $��
0 40 200 0q�6:   $��1��6N   $	��Top=�6[   $	��170��6s    5?      ��%Z   '        �� 5@      "	  6    .�5A      �� 
 � ��$ 
Data Final��65   5B      5C      5D      �� 5F      -   5        $��cmbBoxIntervalo��5G   ?   $��Center=�5F      $��
130 40 0 0q�68   $��1��6L   $	��Top=�5G      $	��100��63   .@�5H      �� 
 � Tag$ 30min��6#    �� 
IsSelected . .��6A   
30 minutos6M   �� 5I      $ 10min��6#   .��6/   
10 minutos6;   5J      �� 5L      -   5        $��
cmbBoxTipo��5M   ?   $��Center=�5L      $��
490 40 0 0q�68   $��1��6L   $	��Top=�5M      $	��235��63   .@�5N      ��  . $ PP��65   .��6>   Potência Potência6Q   �� 5O      $ VP��6#   .��6,   Vento Potência6<   5P      �� 5R       �� Orientation$ 
Horizontal=�6   $��Center=�66   $	��Top=�6S   $��620 375 0 0q�6k   .+�5S      �� -   5        $��35��5S      $��10q�6P   $	��100��6\   ��5T      �� 5U      $
��Wrap=�6(    �� TextAlignment$ Center=�6<    J� RenderTransformOrigin$ 
0.51,0.525&�6S    �� Padding$ 	10 0 10 0q�6v   
Calibrar5W      5Y      5Z      5[      � 5\      -   5        $��gridPaternProgressBar��5\      $y�	Collapsed=�60   $��1��6G   
������� J� Opacity$	 0.5Q�5]      � 5^      -   5        $��GridProgressBar��5^   ,   $	��250��6   $	��110��6   $y�	Collapsed=�6C   $��1��6Z   ��5_      �� 5`       �� 
StartPoint$ 0.5,0&�6*    �� EndPoint$ 0.5,1&�6=   .��5a      �  � Color$ White��6'    � Offset$ 0Q�65   � 5b      $ 	LightGray��6'   $ 1Q�69   5c      .+�5e      �� 
�������$��1q�6,    �� CornerRadius$ 2��6@   ._�5f      �� $��4q�6!   .+�5g      �� $��Aguarde, processando...��6$   $
��Bold"�6C   $��Center=�5h   $   $��0 5 0 0q�6A   �� 5i      $.��(Esse processo pode levar alguns minutos.��6$   $��Center=�5j   $   $��0 5 0 0q�6A   �� 5k      $��4q�6%   .+�5l      �� -   5        $��txtProgressValue��5l   (   $��5q�6@   $��Center=�6K   � 5m      -   5        $��
processBar��5m   A   $��15��6*   $��5q�66    � Value$ 1Q�6S   5n      5o      5p      5q      � 5r      -   5        $��gridMessage��5r      $y�Hidden=�6&   $��1��6:   
�������.+�5s      �� -   5        $��
txtMessage��5t      $��Center=�5s      $
��Wrap=�69   $��Center=�6M   5t      5u      5v      5w      5x      