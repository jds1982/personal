   M S B A M L   `   `   `  ����  BDI_Pre-Process    BDI_Pre_Process.XML_Form   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � 
ResizeMode$  NoResize=�5   	    � Title$ XML_Form��5   	   $	��450��6    � SizeToContent$ Height=�5   	   $	��441��6    .��5      � .+�5   
   �� $
��Left=�6   $��	11,10,0,0q�6/   $
��Wrap=�6B   $��Appeal Code��6V   $	��Top=�6i   �� 5	   
   -   5         ��Name$ tb_XMLAppealCode��5	      $
��Left=�6,   $��23��6G   $��	10,31,0,0q�6S    �� TextWrapping$
 Wrap=�6f   $�� ��6z   $	��Top=�6�   $	��120��6�   �� 5
   
   $
��Left=�6   $��
146,10,0,0q�6/   $
��Wrap=�6C   $��Appeal Description��6W   $	��Top=�6q   �� 5   
   -   5        $ tb_XMLAppealDescription��5      $
��Left=�63   $��23��6N   $��
146,31,0,0q�6Z   $
 Wrap=�6n   $�� ��6�   $	��Top=�6�   $	��150��6�   �� 5   
   $��301,10,90,0q�6   $
��Wrap=�6)   $��	Mail Date��6=   $	��Top=�6N   �� 5   
   -   5        $ tb_MailDate��5      $��23��6'   $��301,31,21,0q�63   $
 Wrap=�6H   $�� ��6\   $	��Top=�6d   �� 5   
   $
��Left=�6   $��	10,73,0,0q�6/   $
��Wrap=�6B   $��Package Cost��6V   $	��Top=�6j   �� 5   
   $
��Left=�6   $��
109,73,0,0q�6/   $
��Wrap=�6C   $��Postage Cost��6W   $	��Top=�6k   �� 5   
   -   5        $ tb_XMLPackCost��5      $
��Left=�6*   $��23��6E   $��	10,94,0,0q�6Q   $
 Wrap=�6d   $�� ��6x   $	��Top=�6�   $��71��6�   �� 5   
   -   5        $ tb_XMLPostCost��5      $
��Left=�6*   $��23��6E   $��
109,94,0,0q�6Q   $
 Wrap=�6e   $�� ��6y   $	��Top=�6�   $��71��6�   �� 5   
   -   5         ��Name$ 
cb_Cleanse��5      $��Cleanse��6'   $
��Left=�69   $��
206,73,0,0q�6T   $	��Top=�6h   �� 5   
   -   5        $ 
cb_Stylist��5      $��Stylist��6'   $
��Left=�69   $��
285,73,0,0q�6T   $	��Top=�6h   �� 5   
   -   5        $ 	cb_Dedupe��5      $��Dedupe��6&   $
��Left=�67   $��
362,73,0,0q�6R   $	��Top=�6f   �� 5   
   $
��Left=�6   $��
10,142,0,0q�6/   $
��Wrap=�6C   $��	Data File��6W   $	��Top=�6h   �� 5   
   -	   5        $ tb_DataFile��5      $��23��6'   $��10,158,10,0q�63   $
 Wrap=�6H   $�� ��6\   $	��Top=�6d   �� 5   
   $
��Left=�6   $��
10,186,0,0q�6/   $
��Wrap=�6C   $��Activity File��6W   $	��Top=�6l   �� 5   
   -
   5        $ 
tb_ActFile��5      $
��Left=�6&   $��23��6A   $��
10,202,0,0q�6M   $
 Wrap=�6a   $�� ��6u   $	��Top=�6}   $	��422��6�   �� 5   
   $
��Left=�6   $��
10,230,0,0q�6/   $
��Wrap=�6C   $��Suppression File��6W   $	��Top=�6o   �� 5   
   -   5        $ 
tb_SupFile��5      $��23��6&   $��10,246,10,0q�62   $
 Wrap=�6G   $�� ��6[   $	��Top=�6c   �� 5   
   $
��Left=�6   $��
10,273,0,0q�6/   $
��Wrap=�6C   $��Eligible File��6W   $	��Top=�6l   �� 5   
   -   5        $ 	tb_ElFile��5      $��23��6%   $��10,289,10,0q�61   $
 Wrap=�6F   $�� ��6Z   $	��Top=�6b   �� 5   
   $
��Left=�6   $��
11,331,0,0q�6/   $
��Wrap=�6C   $��Segments��6W   $	��Top=�6g   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dg_Segments��5      $��11,352,9,31q�6(    J� RenderTransformOrigin$ -0.083,2.308&�6=      AutoGenerateColumns .  	   CanUserAddRows	 . 
   Columns
 5!      0  *System.Windows.Controls.DataGridTextColumn  5"      ,  &System.Windows.Controls.DataGridColumn   Header$ FileName��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 6a   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *
FileName+ �� Mode$ TwoWay=�6a     5#      $ SegmentCode��6%   $ 85 6Z    6:   �� *SegmentCode+6Z     5$      $ SegmentName��6%   $	 125 6Z    6:   �� *SegmentName+6Z     5%      $ Priority��6%   $ 50 6T    67   �� *
Priority+6T   5'      �� 5*   
   -   5         ��Name$ 
btn_Cancel��5*      $��Cancel��6%   $��Right=�66   $��0,0,10,0q�6R   $��75��6d   $��22��6�   $��Bottom=�6�   �� 5+   
   -   5        $ btn_Continue��5+      $��Continue��6'   $��Right=�6:   $��	0,0,109,0q�6V   $��75��6i   $��22��6�   $��Bottom=�6�   ��5,   
   �� 5-       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5.      �  � Color$ CornflowerBlue��6    � Offset$ 0Q�67   � 5/      $ AntiqueWhite��6   $ 1Q�64   50      52      53      