   M S B A M L   `   `   `  ����J  FCapybaraClicker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:CapybaraClickerCapybaraClicker  5   	        CapybaraClicker.SoundPanel   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:CapybaraClicker     5   	   -   5          � Title$  
SoundPanel��5   	   $	��450��6   $	��800��6)   $	��400��5	   	   $	��400��6    � AllowsTransparency .  � WindowStyle$
 None=�5
   #    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ MyStyles.xaml?�6%   %    5      ��5      �� 5   
    �� ResourceKey$ WindowBlackTransparent��6   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5       $��* �6   �� 5!      $��* �6   �� 5"      $��* �6   �� 5#      $��* �6   .+�5%   
   �� $��1��6   $��2��6!   $��2��61    "  RectangleColorStyleTransparent#��[  5&      �� 5'   
   -   5        	 ��Name$	 sliderMusic��5)      $��1��5'      $��2��6   $��2��6.     ColoredSliderStyle#��[ 5(      
 � Maximum$	
 100Q�5)   &   64   �� 5*   
   $��2��6   $��2��6!   $��2��61   #��[  5+      �� 5,   
   -   5        $	 sliderSounds��5.      $��2��5,      $��2��6   $��2��6.   #��[ 5-      $	
 100Q�5.   '   65   �� 5/   
   $��Images\Musical Note.png��6   $
��Auto��61   $
��Auto��6>   $��1��50      $��1��6   $��10q�6-   �� 51   
   $��Images\Speaker.png��6   $
��Auto��6,   $
��Auto��69   $��2��52      $��1��6   $��10q�6-   �� 53   
   -   5        $��Images\Close.png��53      $
��Auto��6*   $
��Auto��67   $��0��54      $��4��6   6-   55      56      