//=================================================================================
//========================= 中奖      +     BY 李哲宇 =============================
//=================================================================================
//=================================================================================
//.setup();             初始化，参数：1、2、3等奖个数
//.judge_if_win(num);   判断是否中奖 -1：未中奖，1、2、3：1、2、3等奖
using System;
using System.Collections.Generic;

namespace luck
{
    public class Luck
    {
        private int FirstCnt, SecondCnt, ThirdCnt;
        private List<int> LuckyNumbers = new List<int>();
        private List<int> inputnum = new List<int>();
        private List<int> first_win = new List<int>();
        private List<int> second_win = new List<int>();
        private List<int> third_win = new List<int>();
        private List<int> not_win = new List<int>();
        public Luck(int A = a, int B = b, int C = c)
        {
            FirstCnt = A; SecondCnt = B; ThirdCnt = C;
            FillNum();
        }
        private const int a = 1, b = 1, c = 5;
        public void setup(int A = a, int B = b, int C = c)
        {
            FirstCnt = A; SecondCnt = B; ThirdCnt = C;
            FillNum();
        }
        public void renew(int A = a, int B = b, int C = c)
        {
            inputnum.Clear();
            FirstCnt = A; SecondCnt = B; ThirdCnt = C;
            FillNum();
        }
        public void store_inputnum(string str)
        {
            int tmp = Convert.ToInt16(str);
            bool thesame = false;
            for (int i = 0; i < inputnum.Count; i++)
            {
                if (inputnum[i] == tmp) thesame = true;
            }
            if (thesame == false) inputnum.Add(tmp);
        }
        public string get_inputnum(string sptr = " ") { return L2S(inputnum, sptr); }

        private string L2S(List<int> ints, string sprtr = " ")
        {
            string str = "";
            if (ints.Count == 0) return str;
            for (int i = 0; i < ints.Count - 1; i++)
            {
                str += ints[i].ToString();
                str += sprtr;
            }
            str += ints[ints.Count - 1].ToString();
            return str;
        }
        public int judge_one()
        {
            if (inputnum.Count == 0) { return 3; }
            int num = inputnum[0];
            //if (FirstCnt + SecondCnt + ThirdCnt != LuckyNumbers.Count) return 0;
            for (int i = 0; i < FirstCnt; i++)
            { 
                if (num == LuckyNumbers[i] && FirstCnt >= 0) return 1;
            } 
            for (int i = FirstCnt; i < SecondCnt + FirstCnt; i++)
            {
                if (num == LuckyNumbers[i] && SecondCnt >=0) return 2;
            }

            for (int i = SecondCnt + FirstCnt; i < ThirdCnt + SecondCnt + FirstCnt; i++)
            {
                if (num == LuckyNumbers[i] && ThirdCnt >= 0) return 3; 
            } 
            return -1;
        }
        public int judge_if_win_once(int num)
        {
            if (FirstCnt + SecondCnt + ThirdCnt != LuckyNumbers.Count) return 0;
            for (int i = 0; i < FirstCnt; i++) if (num == LuckyNumbers[i]) return 1;
            for (int i = FirstCnt; i < SecondCnt + FirstCnt; i++)
            {
                if (num == LuckyNumbers[i]) return 2;
            } 
            for (int i = SecondCnt + FirstCnt; i < ThirdCnt + SecondCnt + FirstCnt; i++) if (num == LuckyNumbers[i]) return 3;
            return -1;
        }
        private void FillNum()
        {
            LuckyNumbers.Clear();
            Random random = new Random();
            while (LuckyNumbers.Count < FirstCnt + SecondCnt + ThirdCnt)
            {
                int tmp = random.Next(1, 101);
                LuckyNumbers.Remove(tmp);
                LuckyNumbers.Add(tmp);
            }
        }
    }
}
