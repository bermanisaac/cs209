#!/bin/bash

make clean
make TestSprite.exe

#AddItem
echo "    Testing AddItem"
mono TestSprite.exe 1 2 3 45 90 50 100 testItems.txt 1 2 3 45 90 50 100 testOut1.txt 0 LargeShield
mono TestSprite.exe 1 2 3 45 90 50 100 testItems.txt 1 2 3 45 90 50 100 testOut2.txt 0 Bandages
mono TestSprite.exe 1 2 3 45 90 50 100 testItems.txt 1 2 3 45 90 50 100 testOut3.txt 0 Imposters

#HasItem
echo "    Testing HasItem"
mono TestSprite.exe 1 2 3 45 90 50 100 testItems.txt 1 2 3 45 90 50 100 testItems.txt 1 LargeShield true
mono TestSprite.exe 1 2 3 45 90 50 100 testItems.txt 1 2 3 45 90 50 100 testItems.txt 1 Bandages true
mono TestSprite.exe 1 2 3 45 90 50 100 testItems.txt 1 2 3 45 90 50 100 testItems.txt 1 Imposters false

#PutItemInQuickSlot
echo "    Testing PutItemInQuickSlot"
mono TestSprite.exe 1 2 3 45 90 50 100 testItems.txt 1 2 3 45 90 50 100 testOut4.txt 2 LargeShield 3
mono TestSprite.exe 1 2 3 45 90 50 100 testItems.txt 1 2 3 45 90 50 100 testOut5.txt 2 SmallShield 5
mono TestSprite.exe 1 2 3 45 90 50 100 testItems.txt 1 2 3 45 90 50 100 testOut6.txt 2 LargeShield 1

#GetItemInQuickSlot
echo "    Testing GetItemInQuickSlot"
mono TestSprite.exe 1 2 3 45 90 50 100 testItems.txt 1 2 3 45 90 50 100 testItems.txt 3 1 GoldScopedAR
mono TestSprite.exe 1 2 3 45 90 50 100 testItems.txt 1 2 3 45 90 50 100 testItems.txt 3 5 Bandages
mono TestSprite.exe 1 2 3 45 90 50 100 testItems.txt 1 2 3 45 90 50 100 testItems.txt 3 3 null

#PrintInventory
echo "    Testing PrintInventory"
mono TestSprite.exe 1 2 3 45 90 50 100 testOut1.txt 1 2 3 45 90 50 100 testOut1.txt 4 testOut7.txt
mono TestSprite.exe 1 2 3 45 90 50 100 testOut2.txt 1 2 3 45 90 50 100 testOut2.txt 4 testOut8.txt
mono TestSprite.exe 1 2 3 45 90 50 100 testOut3.txt 1 2 3 45 90 50 100 testOut3.txt 4 testOut9.txt

#PrintQuickSlots
echo "    Testing PrintQuickSlots"
mono TestSprite.exe 1 2 3 45 90 50 100 testOut4.txt 1 2 3 45 90 50 100 testOut4.txt 5 testOut10.txt
mono TestSprite.exe 1 2 3 45 90 50 100 testOut5.txt 1 2 3 45 90 50 100 testOut5.txt 5 testOut11.txt
mono TestSprite.exe 1 2 3 45 90 50 100 testOut6.txt 1 2 3 45 90 50 100 testOut6.txt 5 testOut12.txt
