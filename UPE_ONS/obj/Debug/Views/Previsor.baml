   M S B A M L   `   `   `  ����  UPE_ONS    UPE_ONS.Views.Previsor   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      X TXceed.Wpf.Toolkit, Version=2.1.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5      .��5	      %  Xceed.Wpf.Toolkit.BusyIndicator  -   5        $��BusyIndicatorCarregando��5	   C       BusyContent$  Carregando...��6      IsBusy . .��5
   
   �  � RowDefinitions 5      �� 5      $��75 �6    �� 5      $��* �6    .+�5      �� -   5        $��	txtTitulo��5   3   $��Center=�5      $��Center=�65   $
��Wrap=�6P   $��	Previsão��6d   $��30(�5      $��0��6&   $��2��6D   � 5      -   5        $��gridContent��5       $��1��6   $��
-10,0,10,0q�63   .+�5      �� -   5        $��feedbackMessage��5      $��Center=�5      $
��Wrap=�69   $'��!Previsão concluída com sucesso!��5      $
��Bold"�6?   $��0 10 0 0q�5      
��� � �$	��Top=�6=   $y�Hidden=�5   /   �� 5      -   5        $��
cmbBoxTipo��5   ?   $��Center=�5      $��
0 40 485 0q�68   $��1��6L   $	��Top=�5      $	��235��63   .@�5      ��  �� 
IsSelected . 
 � Tag$ PP��65   .��6>   Potência Potência6Q   �� 5      $ TR��6#   .��6,   
Tempo Real68   5      �� 5       -   5        $��lstViewParquesEolicos��5!   \   $��Center=�5       $��1��68   $	��Top=�5!      $	��250��6/   $	��350��6<   $��
0 75 375 0q�6H    � DataContext 5    E   �� *ListatParquesEolicos+ �� View 5"      �� 5#      .P�5$      �� $!��Parques Eólicos Calibrados��6-    �� DisplayMemberBinding 6Q   �� *Nome+5%      5'      �� 5)      -   5        $'��!lstViewParquesEolicosSelecionados��5*   H   $��Center=�5)      $	��Top=�68   $	��250��6P   $	��350��6]   $��1��5*      $��1��6'   $��
375 75 0 0q�64    5)   i   �� *!ListaParquesEolicosSelecionados+ 5+      �� 5,      .P�5-      �� $#��Parques Eólicos Selecionados��6-    6T   �� *Nome+5.      50      � 52      $��1��6   $��50��6$   $	��Top=�60   $��	0 335 0 0q�6H   .+�53      �� -   5        $��<��53      $��Center=�6,   $��0 0 65 0q�6I   $	��Top=�6[   $��35��6s   6~   �� 54      -	   5        $��<<��54      $��Center=�60   $��	0 0 175 0q�6M   $	��Top=�6`   $��35��6x   6�   �� 56      -
   5        $��>��56      $��Center=�6,   $��65 0 0 0q�6I   $	��Top=�6[   $��35��6s   6~   �� 57      -   5        $��>>��57      $��Center=�60   $��	175 0 0 0q�6M   $	��Top=�6a   $��35��6y   6�   58      �� 5:       �� Orientation$ 
Horizontal=�6   $��Center=�66   $	��Top=�6S   $��578,377,102,0q�6k   .+�5;      �� -   5        $��35��5;      $��10q�6K   $	��100��6W   ��5<      �� 5=      $
��Wrap=�6(   	 �� TextAlignment$	 Center=�6<   
 J� RenderTransformOrigin$
 
0.51,0.525&�6S    �� Padding$ 	10 0 10 0q�6v   Prever5?      5A      5B      �� 5D      $ 
Horizontal=�6   $��Center=�66   $	��Top=�6S   $��300,377,102,0q�6k   .+�5E      �� -   5        $
��btn1��5E   a   $��35��6   $��10q�6I   $	��100��6U   ��5F      �� 5G      $
��Wrap=�6(   $	 Center=�6<   $
 
0.51,0.525&�6S   $ 	10 0 10 0q�6v   Exibir gráficos5I      5K      5L      � 5N      -   5        $��gridPaternProgressBar��5N      $y�	Collapsed=�64   $��1��6K   
������� J� Opacity$	 0.5Q�5O      � 5P      -   5        $��GridProgressBar��5P   0   $	��350��6   $	��110��6#   $y�	Collapsed=�6G   $��1��6^   ��5Q      �� 5R       �� 
StartPoint$ 0.5,0&�6.    �� EndPoint$ 0.5,1&�6A   .��5S      �  � Color$ White��6+    � Offset$ 0Q�69   � 5T      $ 	LightGray��6+   $ 1Q�6=   5U      .+�5W      �� 
�������$��1q�60    �� CornerRadius$ 2��6D   ._�5X      �� $��4q�6%   .+�5Y      �� $��Aguarde, processando...��6(   $
��Bold"�6G   $��Center=�5Z   (   $��0 5 0 0q�6E   �� 5[      $.��(Esse processo pode levar alguns minutos.��6(   $��Center=�5\   (   $��0 5 0 0q�6E   �� 5]      $��4q�6)   .+�5^   "   �� -   5        $��txtProgressValue��5^   ,   $��5q�6D   $��Center=�6O   � 5_   "   -   5        $��
processBar��5_   E   $��15��6.   $��5q�6:    � Value$ 1Q�6W   5`      5a      5b      5c      � 5d      -   5        $��gridMessage��5d      $y�Hidden=�6*   $��1��6>   
�������.+�5e      �� -   5        $��
txtMessage��5f      $��Center=�5e       $
��Wrap=�6=   $��Center=�6Q   5f      5g      5h      5i      5j      5k      