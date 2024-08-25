//=================================================================================
//========================= 中奖      +     BY 李哲宇 =============================
//=================================================================================
//=================================================================================
//.setup();             初始化，参数：1、2、3等奖个数
//.judge_if_win(num);   判断是否中奖 -1：未中奖，1、2、3：1、2、3等奖
//.get_all_cnt();       返回总剩余奖数
//.get_first_cnt();     返回剩余一等奖奖数
//.get_second_cnt();    返回剩余二等奖奖数
//.get_third_cnt();     返回剩余三等奖奖数
//Award.get_first();    返回剩余一等奖号码 <list>
//Award.get_second();   返回剩余二等奖号码 <list>
//Award.get_third();    返回剩余三等奖号码 <list>
//Award.get_first_str();返回剩余一等奖号码 <string>  参数为号码之间的分隔符 <string> ，选填
//Award.get_second_str();返回剩余二等奖号码 <string> 参数为号码之间的分隔符 <string> ，选填
//Award.get_third_str();返回剩余三等奖号码 <string>  参数为号码之间的分隔符 <string> ，选填
//Award.get_all_str();  返回总奖号码 <string>        参数为号码之间的分隔符 <string> ，选填
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luck
{
    public class Luck
    {
        public Luck(int A = a, int B = b, int C = c)
        {
            SetCntr(A, B, C);
            FillNum();
        }
        private const int a = 1, b = 1, c = 5;
        public void setup(int A = a, int B = b, int C = c)
        {
            SetCntr(A, B, C);
            FillNum();
        }
        public void renew(int A = a, int B = b, int C = c)
        {
            inputnum.Clear();
            SetCntr(A, B, C);
            FillNum();
        }

        private List<int> inputnum = new List<int>();
        private List<int> first_win = new List<int>();
        private List<int> second_win = new List<int>();
        private List<int> third_win = new List<int>();
        private List<int> not_win = new List<int>();
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
        public string get_first_win(string sptr = " ") { return L2S(first_win, sptr); }
        public string get_second_win(string sptr = " ") { return L2S(second_win, sptr); }
        public string get_third_win(string sptr = " ") { return L2S(third_win, sptr); }
        public int judge_one()
        {
            if (inputnum.Count == 0) { return 3; }
            int num = inputnum[0];
            if (FirstCnt + SecondCnt + ThirdCnt != LuckyNumbers.Count) return 0;
            for (int i = 0; i < FirstCnt; i++) if (num == LuckyNumbers[i]) return 1;
            for (int i = FirstCnt; i < SecondCnt + FirstCnt; i++) if (num == LuckyNumbers[i]) return 2;

            for (int i = SecondCnt + FirstCnt; i < ThirdCnt + SecondCnt + FirstCnt; i++) if (num == LuckyNumbers[i]) return 3;
            return -1;
        }
        public void judge_if_win()
        {

            for (int i = 0; i < inputnum.Count; i++)
            {
                first_win.Clear();
                second_win.Clear();
                third_win.Clear();
                not_win.Clear();
                int rt = judge_if_win_once(inputnum[i]);
                switch (rt)
                {
                    case 1:
                        //一等奖
                        first_win.Add(inputnum[i]);
                        break;
                    case 2:
                        //二等奖
                        second_win.Add(inputnum[i]);
                        break;
                    case 3:
                        //三等奖
                        third_win.Add(inputnum[i]);
                        break;
                    case -1:
                        //没中奖
                        not_win.Add(inputnum[i]);
                        break;
                    default:
                        throw new Exception("ERROR_AWARD_NOT_EQUEL");
                }
            }
            inputnum.Clear();
        }
        public int judge_if_win_once(int num)
        {
            if (FirstCnt + SecondCnt + ThirdCnt != LuckyNumbers.Count) return 0;
            for (int i = 0; i < FirstCnt; i++) if (num == LuckyNumbers[i]) return 1;
            for (int i = FirstCnt; i < SecondCnt + FirstCnt; i++) if (num == LuckyNumbers[i]) return 2;
            for (int i = SecondCnt + FirstCnt; i < ThirdCnt + SecondCnt + FirstCnt; i++) if (num == LuckyNumbers[i]) return 3;
            return -1;
        }
        public int get_first_cnt() { return FirstCnt; }
        public List<int> get_first() { return LuckyNumbers.GetRange(0, FirstCnt - 1); }
        public string get_first_str(string sprtr = " ")
        {
            string str = "";
            for (int i = 0; i < FirstCnt; i++)
            {
                str += LuckyNumbers[i].ToString();
                str += sprtr;
            }
            return str;
        }
        public int get_second_cnt() { return SecondCnt; }
        public List<int> get_second() { return LuckyNumbers.GetRange(FirstCnt, FirstCnt + SecondCnt - 1); }
        public string get_second_str(string sprtr = " ")
        {
            string str = "";
            for (int i = FirstCnt; i < SecondCnt + FirstCnt; i++)
            {
                str += LuckyNumbers[i].ToString();
                str += sprtr;
            }
            return str;
        }
        public int get_third_cnt() { return ThirdCnt; }
        public List<int> get_third() { return LuckyNumbers.GetRange(FirstCnt + SecondCnt, FirstCnt + SecondCnt + ThirdCnt - 1); }
        public string get_third_str(string sprtr = " ")
        {
            string str = "";
            for (int i = SecondCnt + FirstCnt; i < ThirdCnt + SecondCnt + FirstCnt; i++)
            {
                str += LuckyNumbers[i].ToString();
                str += sprtr;
            }
            return str;
        }
        public int get_all_cnt() { return ThirdCnt + SecondCnt + FirstCnt; }
        public string get_all_str(string sprtr = " ")
        {
            string str = "";
            for (int i = 0; i < ThirdCnt + SecondCnt + FirstCnt; i++)
            {
                str += LuckyNumbers[i].ToString();
                str += sprtr;
            }
            return str;
        }
        public List<int> get_luckynumders() { return LuckyNumbers; }

        private List<int> LuckyNumbers = new List<int>();

        private int FirstCnt, SecondCnt, ThirdCnt;
        private void SetCntr(int A, int B, int C)
        {
            FirstCnt = A; SecondCnt = B; ThirdCnt = C;
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
