using System;

namespace Application_Software_Practice
{
    class Practice
    {
        static void Main(string[] args)
        {
            Practice p = new Practice();
            //p.example1();
            //p.example2();
            //p.example3();
            //p.example4();
            //p.example5();
            //p.example6();
            p.example7();

        }

        #region class
        class Student
        {
            private int mINumber;
            private int mIScore;
            public Student(int iNumber, int iScore)
            {
                mINumber = iNumber;
                mIScore = iScore;
            }
            public int getNumber() { return mINumber; }
            public int getScore() { return mIScore; }
        }
        #endregion
        #region method
        void example7()
        {
            const int NUM_STUDENTS = 5;
            Array arrStudents = Array.CreateInstance(typeof(Student), NUM_STUDENTS);
            int iScoreSum = 0;
            double dScoreMean = 0.0;
            Console.WriteLine("<< {0} 명의 학생의 점수를 입력하세요.", NUM_STUDENTS);
            for(int i = 0; i < NUM_STUDENTS; i++)
            {
                int iNumber = i + 1;
                string strScore = Console.ReadLine();
                int iScore = Convert.ToInt32(strScore);
                Student student = new Student(iNumber, iScore);
                arrStudents.SetValue(student, i);

            }
            for(int i = 0; i < arrStudents.Length; i++)
            {
                int iNumber = ((Student)arrStudents.GetValue(i)).getNumber();
                int iScore = ((Student)arrStudents.GetValue(i)).getScore();
                String strGrade = "F";
                if (iScore >= 90) { strGrade = "A"; }
                else if (iScore >= 80) { strGrade = "B"; }
                else if (iScore >= 70) { strGrade = "C"; }
                else if (iScore >= 60) { strGrade = "D"; }
                Console.WriteLine(">> {0}번 학생의 점수 : {1}. 등급 {2}", iNumber, iScore, strGrade);
                iScoreSum += iScore;
            }
            dScoreMean = (double)iScoreSum / NUM_STUDENTS;
            Console.WriteLine("평균점수: {0}", dScoreMean);
        }
        void example6()
        {
            String strName;
            Console.Write("<< 이름을 입력하세요: ");    strName = Console.ReadLine();
            Console.WriteLine(">> {0} 님, 안녕하세요!", strName);
        }
        void example5()
        {
            int iNum1 = 3;
            int iNum2 = 3;
            Console.WriteLine("전위연산자");
            Console.WriteLine("iNum1 = {0}, iNum2 = {1}", iNum1, iNum2);
            Console.WriteLine("++iNum1 = {0}, --iNum2 = {1}", ++iNum1, --iNum2);
            Console.WriteLine("iNum1 = {0}, iNum2 = {1}", iNum1, iNum2);


            iNum1 = iNum2 = 3;
            Console.WriteLine("전위연산자");
            Console.WriteLine("iNum1 = {0}, iNum2 = {1}", iNum1, iNum2);
            Console.WriteLine("iNum1++ = {0}, iNum2-- = {1}", iNum1++, iNum2--);
            Console.WriteLine("iNum1 = {0}, iNum2 = {1}", iNum1, iNum2);

        }
        void example4()
        {
            int iNum1 = 2;
            int iNum2 = 7;
            Console.WriteLine("iNum1 = {0}, iNum2 = {1}",iNum1,iNum2);
            Console.WriteLine("iNum1 + iNum2 = {0}",iNum1+iNum2);
            Console.WriteLine("iNum1 - iNum2 = {0}",iNum1-iNum2);
            Console.WriteLine("iNum1 / iNum2 = {0}",iNum1/iNum2);
            Console.WriteLine("iNum1 * iNum2 = {0}",iNum1*iNum2);
            Console.WriteLine("iNum1 % iNum2 = {0}",iNum1%iNum2);
        }
        void example3()
        {
            int iAge = 22;
            String strText1 = "안녕하세요";
            String strText2 = "제 나이는";
            String strText3 = "세 입니다.";
            Console.WriteLine("{0} {1} {2} {3}",strText1
                                               ,strText2
                                               ,iAge
                                               ,strText3);

        }
        void example2()
        {
            String strText1 = " Hello ";
            String strText2 = " C# ";
            String strText3 = " World ";
            String strText4 = strText1 + strText2 + strText3;

            Console.WriteLine("전체 문자열: {0}", strText4);
            Console.WriteLine("전체 문자열의 길이: {0}", strText4.Length);//non function
            Console.WriteLine("문자열 시작과 끝의 공백 제거: {0}", strText4.Trim());
            String tmp = strText4.Trim();
            Console.WriteLine("문자열 시작과 끝의 공백 제거길이: {0}", tmp.Length);
            Console.WriteLine("C# 제거: {0}", strText4.Remove(8,2));
            Console.WriteLine("Hello를 안녕으로 변경: {0}", strText4.Replace("Hello","안녕"));
            Console.WriteLine("모두 대문자로 변경: {0}", strText4.ToUpper());
            Console.WriteLine("모두 소문자로 변경: {0}", strText4.ToLower());
        }
        void example1()
        {
            char chVar1 = 'A';
            char chVar2 = '\x0041';
            char chVar3 = (char)65;
            char chVar4 = '\u0041';

            Console.WriteLine("문자표현: {0}", chVar1);
            Console.WriteLine("16진수 표현: {0}", chVar2);
            Console.WriteLine("ASCII 표현: {0}", chVar3);
            Console.WriteLine("Unicode 표현: {0}", chVar4);
        }

        #endregion

    }
}
