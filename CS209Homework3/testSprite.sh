#!/bin/bash

make

#HorizontalRotate
mono TestSprite.exe 20 50 0 25 0 100 100 20 50 0 20 0 100 100 0 -5
mono TestSprite.exe 20 50 0 25 0 100 100 20 50 0 350 0 100 100 0 -35
mono TestSprite.exe 20 50 0 300 0 100 100 20 50 0 40 0 100 100 0 100

#VerticalRotate
mono TestSprite.exe 20 50 0 0 25 100 100 20 50 0 0 20 100 100 1 -5
mono TestSprite.exe 20 50 0 0 25 100 100 20 50 0 0 350 100 100 1 -35
mono TestSprite.exe 20 50 0 0 300 100 100 20 50 0 0 40 100 100 1 100

#Move
mono TestSprite.exe 20 50 0 180 0 100 100 -3 50 0 180 0 100 100 2 23
mono TestSprite.exe 20 50 0 90 0 100 100 20 73 0 90 0 100 100 2 23
mono TestSprite.exe 0 0 0 225 0 100 100 -3 -999 -999 225 0 100 100 2 1414

#DrinkSmallShieldPot
mono TestSprite.exe 20 50 0 180 0 100 10 20 50 0 180 0 100 35 3 1
mono TestSprite.exe 20 50 0 180 0 100 30 20 50 0 180 0 100 50 3 1
mono TestSprite.exe 20 50 0 180 0 100 60 20 50 0 180 0 100 60 3 0

#DrinkLargeShieldPot
mono TestSprite.exe 20 50 0 180 0 100 30 20 50 0 180 0 100 80 4 1
mono TestSprite.exe 20 50 0 180 0 100 70 20 50 0 180 0 100 100 4 1
mono TestSprite.exe 20 50 0 180 0 100 100 20 50 0 180 0 100 100 4 0

#ApplyBandage
mono TestSprite.exe 20 50 0 180 0 33 30 20 50 0 180 0 48 30 5 1
mono TestSprite.exe 20 50 0 180 0 70 30 20 50 0 180 0 75 30 5 1
mono TestSprite.exe 20 50 0 180 0 80 30 20 50 0 180 0 80 30 5 0

#UseMedKit
mono TestSprite.exe 20 50 0 180 0 33 30 20 50 0 180 0 100 30 6 1
mono TestSprite.exe 20 50 0 180 0 100 30 20 50 0 180 0 100 30 6 0
mono TestSprite.exe 20 50 0 180 0 30 30 20 50 0 180 0 100 30 6 1

#WeaponDamage
mono TestSprite.exe 20 50 0 180 0 33 30 20 50 0 180 0 23 0 7 40 1
mono TestSprite.exe 20 50 0 180 0 33 50 20 50 0 180 0 33 10 7 40 1
mono TestSprite.exe 20 50 0 180 0 50 0 20 50 0 180 0 10 0 7 40 1
mono TestSprite.exe 20 50 0 180 0 100 50 20 50 0 180 0 0 0 7 200 0

#Revive
mono TestSprite.exe 20 50 0 180 0 0 0 20 50 0 180 0 30 0 8 1
mono TestSprite.exe 20 50 0 180 0 56 0 20 50 0 180 0 56 0 8 0
mono TestSprite.exe 20 50 0 180 0 30 0 20 50 0 180 0 30 0 8 0

#Reboot
mono TestSprite.exe 20 50 0 180 0 0 0 20 50 0 180 0 100 0 9 1
mono TestSprite.exe 20 50 0 180 0 75 0 20 50 0 180 0 75 0 9 0
mono TestSprite.exe 20 50 0 180 0 100 0 20 50 0 180 0 100 0 9 0
