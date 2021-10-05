#!/bin/bash

mono TestLab1.exe 0 5 6.3 c howdy
mono TestLab1.exe 0 7 6.2 z fjlaidsufe
mono TestLab1.exe 0 25 16.7 A California
mono TestLab1.exe 1 0 0
mono TestLab1.exe 1 1 5
mono TestLab1.exe 1 2 10
mono TestLab1.exe 1 12 60
mono TestLab1.exe 2 1 1
mono TestLab1.exe 2 2 2
mono TestLab1.exe 2 3 6
mono TestLab1.exe 2 5 120
mono TestLab1.exe 3 3 6 9
mono TestLab1.exe 3 0 0 0
mono TestLab1.exe 3 5 9 14
mono TestLab1.exe 3 115 99 214
mono TestLab1.exe 4 0 0
mono TestLab1.exe 4 2 14
mono TestLab1.exe 4 -3 -21
mono TestLab1.exe 4 613566757 4294967299
echo "Expected failure on last test due to integer overflow."
