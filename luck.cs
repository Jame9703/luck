//=================================================================================
//========================= 中奖      +     BY 李哲宇 =============================
//=================================================================================
//=================================================================================
//.setup();             初始化，参数：1、2、3等奖个数
//.judge_one();   判断是否中奖 -1：未中奖，1、2、3：1、2、3等奖
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
        int inputnum=0;
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
        public void store_inputnum(int name_to_int)//name_to_int为将100个按钮的Name转换为int
        {
            inputnum=name_to_int;
        }
        public int get_inputnum()
        {
           return inputnum;
        }
        public int judge_one()
        {
            FillLuckyNumbers();
            if (inputnum == 0) { return 3; }
            else
            {
                //TODO:后续将10，40替换为一等奖和二等奖概率
                List<int> FirstPrizeList = LuckyNumbers.Take(10).ToList();//第1-10个
                List<int> SecondPrizeList = LuckyNumbers.Skip(10).Take(30).ToList();//第11-40个
                List<int> ThirdPrizeList = LuckyNumbers.Skip(40).Take(100).ToList();//第41-100个
                if ((Application.Current as App).FirstPrizeCount > 0 && (Application.Current as App).SecondPrizeCount > 0 && (Application.Current as App).ThirdPrizeCount > 0)
                {
                    //for (int i = 0; i < 10; i++)
                    //{
                    //    if (inputnum == LuckyNumbers[i]) return 1;
                    //}
                    //for (int i = 10; i < 40; i++)
                    //{
                    //    if (inputnum == LuckyNumbers[i]) return 2;
                    //}
                    //for (int i = 40; i <= 100; i++)
                    //{
                    //    if (inputnum == LuckyNumbers[i]) return 3;
                    //}

                    ///----------Contains判断集合是否包含元素-------------
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
                else
                {
                    //在此处写FirstPrizeCount，SecondPrizeCount，ThirdPrizeCount=0时执行的操作
                }
            }
            return 3;
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
