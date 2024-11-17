/// <summary>
///=================================luck.cs BY 李哲宇 ==============================
///=================================================================================
///=================================================================================
///.Setup();   初始化，参数:1、2、3等奖个数
///.ChangePrizeProbability();  修改概率，参数:1、2、3等奖概率
///.JudgePrize();   判断是否中奖 0:未选择幸运数字 -1:所有奖项已被抽完，1、2、3:1、2、3等奖
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;

namespace luck
{
    public static class Luck
    {
        private static List<int> LuckyNumbers = new List<int>();
        public static int SelectedNumber = 0;
        public static int FirstPrizeCount;//默认为10
        public static int SecondPrizeCount;//默认为90
        public static int ThirdPrizeCount;//默认为400
        public static int FirstPrizeProbability;//默认为10%
        public static int SecondPrizeProbability;//默认为30%
        public static int ThirdPrizeProbability;//默认为60%
        public static void Setup(int A, int B, int C)//TODO:在设置页面调用
        {
            FirstPrizeCount = A; SecondPrizeCount = B; ThirdPrizeCount = C;
        }
        public static void SetPrizeProbability(int A, int B,int C)//TODO:在设置页面调用
        {
            FirstPrizeProbability = A; SecondPrizeProbability = B; ThirdPrizeProbability = C;
        }
        public static void Renew(int A, int B, int C)
        {
            SelectedNumber=0;
            FirstPrizeCount = A; SecondPrizeCount = B; ThirdPrizeCount = C;
            FillLuckyNumbers();
        }
        public static int JudgePrize()
        {
            FillLuckyNumbers();
            if (SelectedNumber == 0) { return 0; }
            else
            {
                if (FirstPrizeCount <= 0)
                {
                    FirstPrizeProbability = 0;
                }
                if (SecondPrizeCount <= 0)
                {
                    SecondPrizeProbability = 0;
                }
                if (ThirdPrizeCount <= 0)
                {
                    ThirdPrizeProbability = 0;
                }
                //重新计算概率
                //设为double避免答案为0
                double TotalPrizeProbability = FirstPrizeProbability + SecondPrizeProbability + ThirdPrizeProbability;
                if(TotalPrizeProbability != 0)
                {
                    FirstPrizeProbability = (int)(FirstPrizeProbability / TotalPrizeProbability * 100);
                    SecondPrizeProbability = (int)(SecondPrizeProbability / TotalPrizeProbability * 100);
                    ThirdPrizeProbability = 100 - FirstPrizeProbability - SecondPrizeProbability;
                    List<int> FirstPrizeList = LuckyNumbers.Take(FirstPrizeProbability).ToList();//默认第1-10个
                    List<int> SecondPrizeList = LuckyNumbers.Skip(FirstPrizeProbability).Take(SecondPrizeProbability).ToList();//默认第11-40个
                    List<int> ThirdPrizeList = LuckyNumbers.Skip(FirstPrizeProbability + SecondPrizeProbability).Take(ThirdPrizeProbability).ToList();//默认第41-100个
                    ///----------Contains判断集合是否包含元素-------------///
                    if (FirstPrizeList.Contains(SelectedNumber))
                    {
                        return 1;
                    }
                    else if (SecondPrizeList.Contains(SelectedNumber))
                    {
                        return 2;
                    }
                    else if (ThirdPrizeList.Contains(SelectedNumber))
                    {
                        return 3;
                    }
                }
                return -1;//TODO:所有奖已抽完
            }
        }
        private static void FillLuckyNumbers()
        {
            LuckyNumbers.Clear();
            LuckyNumbers = Enumerable.Range(1, 100).ToList();
            Random random = new Random();
            LuckyNumbers = LuckyNumbers.OrderBy(x => random.Next()).ToList();
        }
    }
}
