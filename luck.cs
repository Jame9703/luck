/// <summary>
///=================================luck.cs BY 李哲宇 ==============================
///=================================================================================
///=================================================================================
///.setup();   初始化，参数:1、2、3等奖个数,暂时用不上
///.judge_one();   判断是否中奖 0:未选择幸运数字 -1:所有奖项已被抽完，1、2、3:1、2、3等奖
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;

namespace luck
{
    public class Luck
    {
        //此处定义会出现灾难性故障
        //int FirstPrizeCount = (Application.Current as App).FirstPrizeCount,
        //    SecondPrizeCount = (Application.Current as App).SecondPrizeCount,
        //    ThirdPrizeCount = (Application.Current as App).ThirdPrizeCount;
        private List<int> LuckyNumbers = new List<int>();
        int inputnum = 0;
        //public Luck(int A = a, int B = b, int C = c)
        //{
        //    FirstCnt = A; SecondCnt = B; ThirdCnt = C;
        //    FillNum();
        //}
        //public void setup(int A, int B, int C)
        //{
        //    FirstPrizeCount = A; SecondPrizeCount = B; ThirdPrizeCount = C;
        //    FillLuckyNumbers();
        //}
        public void renew(int A, int B, int C)
        {
            inputnum=0;
            (Application.Current as App).FirstPrizeCount = A; (Application.Current as App).SecondPrizeCount = B; (Application.Current as App).ThirdPrizeCount = C;
            FillLuckyNumbers();
        }
        public void store_inputnum(int name_to_int)//name_to_int为将100个按钮的Name转换为int的值
        {
            inputnum=name_to_int;
        }
        public int get_inputnum()
        {
           return inputnum;
        }
        public int judge_one()
        {
            int FirstPrizeProbability = 10;//10%
            int SecondPrizeProbability = 30;//30%
            int ThirdPrizeProbability = 60;//60%
            FillLuckyNumbers();
            if (inputnum == 0) { return 0; }
            else
            {
                if ((Application.Current as App).FirstPrizeCount <= 0)
                {
                    FirstPrizeProbability = 0;
                }
                if ((Application.Current as App).SecondPrizeCount <= 0)
                {
                    SecondPrizeProbability = 0;
                }
                if ((Application.Current as App).ThirdPrizeCount <= 0)
                {
                    ThirdPrizeProbability = 0;
                }
                //重新计算概率(似乎仍需优化，如将强制转为int改为四舍五入)
                //将TotalPrizeProbability设为double类型避免整数除法结果为0
                double TotalPrizeProbability = FirstPrizeProbability + SecondPrizeProbability + ThirdPrizeProbability;
                FirstPrizeProbability = (int)(FirstPrizeProbability / TotalPrizeProbability * 100);
                SecondPrizeProbability = (int)(SecondPrizeProbability / TotalPrizeProbability * 100);
                ThirdPrizeProbability = (int)(ThirdPrizeProbability / TotalPrizeProbability * 100);
                List<int> FirstPrizeList = LuckyNumbers.Take(FirstPrizeProbability).ToList();//默认第1-10个
                List<int> SecondPrizeList = LuckyNumbers.Skip(FirstPrizeProbability).Take(SecondPrizeProbability).ToList();//默认第11-40个
                List<int> ThirdPrizeList = LuckyNumbers.Skip(FirstPrizeProbability+SecondPrizeProbability).Take(ThirdPrizeProbability).ToList();//默认第41-100个
                ///----------Contains判断集合是否包含元素-------------///
                if (FirstPrizeList.Contains(inputnum))
                {
                    return 1;
                }
                else if (SecondPrizeList.Contains(inputnum))
                {
                    return 2;
                }
                else if (ThirdPrizeList.Contains(inputnum))
                {
                    return 3;
                }
            }
            return -1;//TODO:所有奖已抽完
        }
        private void FillLuckyNumbers()
        {
            LuckyNumbers.Clear();
            LuckyNumbers = Enumerable.Range(1, 100).ToList();
            Random random = new Random();
            LuckyNumbers = LuckyNumbers.OrderBy(x => random.Next()).ToList();
            //while (LuckyNumbers.Count < FirstCnt + SecondCnt + ThirdCnt)
            //{
            //    int tmp = random.Next(1, 101);
            //    LuckyNumbers.Remove(tmp);
            //    LuckyNumbers.Add(tmp);
            //}
        }
    }
}
