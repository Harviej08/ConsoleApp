﻿using System;
using System.Runtime.ConstrainedExecution;

class Dice
{
    static void Main(string[] args)
    {
        Random roll = new Random();
        RollUntillSix(roll);
        OverHundred(roll);
        ExactHundred(roll);
        NumberRun(roll);
    }

    static void RollUntillSix(Random roll)
    {
        int num = 0;
        bool check = false;

        while(check == false)
        {
            int rollDie = roll.Next(1, 7);
            num++;

            if (rollDie == 6)
                check = true;
        } 
        Console.WriteLine($"You took {num} roll(s) to get a 6");
    }

    static void OverHundred(Random roll)
    {
        bool check = false;
        int num = 0;
        int rolled = 0;

        while (check == false)
        {
            rolled = rolled + roll.Next(1, 7);
            num++;
            if (rolled > 100)
            {
                check = true;
                Console.WriteLine($"you took {num} roll(s) to get over 100");
            }
        }
    }

    static void ExactHundred(Random roll)
    {
        bool check = false;
        int game = 1;
        int rolled = 0;

        while(check == false)
        {
            rolled = rolled + roll.Next(1, 7);
            if (rolled == 100)
            {
                check= true;
                Console.WriteLine($"you took {game} game(s) to get exacty 100");
            }
            else if (rolled > 100)
            {
                game++;
                rolled = 0;
            }
        }
    }

    static void NumberRun(Random roll)
    {
        int num = 0;
        bool sequence = false;
        int finalRow = 1;
        int row = 0;
        Dictionary<int,int> numDict = new Dictionary<int, int>();
        for (int i = 1;i <= 7; i++)
        {
            numDict.Add(i, 0);
        }

        for (int i = 0; i < 100000; i++)
        {
            int prevRoll = num;
            num = roll.Next(1, 7);

            if (prevRoll == num)
            {
                if (sequence == false)
                {
                    row = 2;
                    sequence = true;
                }
                else
                {
                    num++;
                }
            }
            else if (sequence == true)
            {
                if (row > finalRow)
                {
                    finalRow = row;
                }
                sequence = false;
            }
            numDict[num]++;
        }
        for (int i = 1;i < 7; i++)
        {
            Console.WriteLine($"{i} showed up {numDict[i]} times");
        }
    }
}