#!/bin/bash

make TestPoint.exe

#SetLocation
mono TestPoint.exe 1 2 3 4 5 6 0 4 5 6
mono TestPoint.exe 1 2 3 4 2 3 0 4 2 3
mono TestPoint.exe 1 2 3 1 2 3 0 1 2 3

#Setters/Getters
mono TestPoint.exe 1 2 3 4 2 3 1 4
mono TestPoint.exe 1 2 3 1 4 3 2 4
mono TestPoint.exe 1 2 3 1 2 4 3 4
mono TestPoint.exe 1 2 3 1 2 3 4 1
mono TestPoint.exe 1 2 3 1 2 3 5 2
mono TestPoint.exe 1 2 3 1 2 3 6 3

#CalculateDistance
mono TestPoint.exe 0 0 0 0 0 0 7 2 0 0 2
mono TestPoint.exe 0 0 0 0 0 0 7 3 4 0 5
mono TestPoint.exe 0 0 0 0 0 0 7 4 4 7 9
mono TestPoint.exe 4 4 7 4 4 7 7 0 0 0 9
mono TestPoint.exe 0 0 0 0 0 0 7 1 1 1 1.723
mono TestPoint.exe 15 18 19 15 18 19 7 15 18 19 0

#Equals
mono TestPoint.exe 1 2 3 1 2 3 8 1 2 3 true
mono TestPoint.exe 1 2 3 1 2 3 8 3 2 1 false