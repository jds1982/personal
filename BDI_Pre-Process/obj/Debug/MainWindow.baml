   M S B A M L   `   `   `  ����  BDI_Pre-Process     BDI_Pre_Process.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � 
ResizeMode$  NoResize=�5   	    � Title$ BDI_Pre_Process��5   	   $	��265��6!   $	��250��6.   .��5      � $��0,0,0,0q�6   .+�5	   
   � -   5        $��progress��5	      $
��Left=�6    $��Bottom=�6;   $	��245��6V   $��20��6b   $��Bottom=�6n   .��5
      � .+�5      � -   5        $��progressbar��5      $	��245��61   $��20��6=    � Minimum$ 0Q�6I    � Maximum$	 100Q�6U   
���  �� � IsIndeterminate . 6u   �� 5      -   5         ��Name$ progresstext��5      $	��245��62   $��20��6>   $�� ��6J   $��Center=�6R   $��Center=�6o    J� RenderTransformOrigin$ 
0.44,-1.65&�6�   5      5      �� 5   
   -   5         ��Name$ btn_Continue��5      $��Continue��6'   $
��Left=�6:   $��
15,200,0,0q�6U   $	��Top=�6i   $��75��6�   $��5��6�   �� 5   
   -   5         ��Name$ cb_JobNumber��5      $
��Left=�6)   $��
100,14,0,0q�6D   $	��Top=�6X   $	��120��6p   	 J� 	AllowDrop	 . 
 � ToolTip$
 
Job Number��6�   $��1��6�   �� 5   
   -   5        $��lbl_JobNumber��5      $��
Job Number��6%   $
��Left=�6:   $��	15,10,0,0q�6U   $	��Top=�6h   �� 5   
   -   5         ��Name$ tb_AppealCode��5      $
��Left=�6)   $��23��6D   $��	15,56,0,0q�6P    �� TextWrapping$
 Wrap=�6c   $��Appeal Code��6w   $	��Top=�6�   $	��205��6�   $��2��6�   6�   �� 5   
   -   5        $ tb_AppealDescription��5      $
��Left=�60   $��23��6K   $��	15,99,0,0q�6W   $
 Wrap=�6j   $��Appeal Description��6~   $	��Top=�6�   $	��205��6�   $��3��6�   6�   (  "System.Windows.Controls.DatePicker  5   
   -	   5          Name$ dp_MailDate��5         SelectedDateFormat$ Short=�6*   $
��Left=�6E   $��
94,155,0,0q�6`   $	��Top=�6t   $��4��6�   $	��126��6�   �� 5   
   -
   5        $��lbl_MailDate��5      $��	Mail Date��6$   $
��Left=�68   $��
15,153,0,0q�6S   $	��Top=�6g   �� 5   
   -   5        $ btn_Quit��5      $
��Quit��6$   $
��Left=�63   $��145,200,0,0q�6N   $	��Top=�6c   $��75��6{   $��6��6�   ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ CornflowerBlue��6    � Offset$ 0Q�67   � 5      $ AntiqueWhite��6   $ 1Q�64   5      5"      5%      