namespace Assignment1 {
    internal class Program {
        static void Main(string[] args) {

            ////LAB 1

            //1. 변수 선언
            String temp = "";
            int jaCnt = 0;
            int moCnt = 0;
            Boolean checkMo;

            while (true) {

                //2. 문자 입력
                Console.Write("영문자를 입력하시오: ");
                temp = Console.ReadLine();

                //3. 참/거짓 판독
                checkMo = temp.Equals("a") || temp.Equals("e") || temp.Equals("i") || temp.Equals("o") || temp.Equals("u") || temp.Equals("A") || temp.Equals("E") || temp.Equals("O") || temp.Equals("U") || temp.Equals("I");


                if (temp == "#") {
                    //4. #인경우 반복문 빠져나옴
                    break;
                } else if (checkMo) {
                    //5. 모음인 경우 모음 카운트를 +1 시키고 temp를 초기화 한다.
                    moCnt += 1;
                    temp = "";
                } else {
                    //6. 자음인 경우 자음 카운트를 +1 시키고 temp를 초기화 한다.
                    jaCnt += 1;
                    temp = "";
                }


            }

            //7. 모음과 자음의 수를 출력한다. 
            Console.WriteLine("모음: {0}", moCnt);
            Console.WriteLine("자음: {0}", jaCnt);




            //LAB2
            //1. 변수를 선언한다.
            Random rndNum = new Random();
            int start = 0;
            int end = 100;
            int middle = 0;
            int targetNum = 0;
            int scoreNum = default;

            //2. 사용자 input 받는다. 
            Console.Write("숫자를 맞훠보자..");
            int.TryParse(Console.ReadLine(), out scoreNum);





            for (int index = 0; ; index++) {

                //3. 50, 25, 12, 6, 3, 1 간격으로 컴퓨터가 추측할수 있게 한다.
                middle = (start + end) / 2;
                if (index == 6 && middle == 99) {
                    Console.WriteLine("정답입니다.", 100);
                    break;
                }
                targetNum = middle;



                //4. 내가 설정한 숫자와 컴퓨터가 설정한 숫자 조건을 비교하고 range를 정해준다.
                if (targetNum < scoreNum) {
                    start = middle;
                    Console.WriteLine("{0}보다 정한 숫자 {1} (이)가 더 큽니다.", targetNum, scoreNum);
                } else if (targetNum > scoreNum) {
                    end = middle;
                    Console.WriteLine("{0}보다 정한 숫자 {1} (이)가 더 작습니다.", targetNum, scoreNum);
                } else {
                    Console.WriteLine("{0} 정답입니다.", targetNum);
                    break;
                }

            }

            //LAB 3
            //1. 변수 선언한다.
            int num1, num2;
            num1 = rndNum.Next(-1, 100);
            num2 = rndNum.Next(-1, 100);
            double answer2 = 0;
            double myAnswer2 = 0;

            //2. 사용자 input 입력 받는다.
            Console.Write("곱셈? 덧셈? 뺄셈? 나눗셈? ");
            String whatFom = Console.ReadLine();



            while (true) {

                //3. 사용자에게 곱셈, 나눗셈, 덧셈, 뺄셈을 입력받고 해당식을 실행한다.
                if (whatFom == "곱셈") {
                    answer2 = num1 * num2;
                    Console.Write("곱셈 해보자: {0} * {1} = ", num1, num2);
                    double.TryParse(Console.ReadLine(), out myAnswer2);
                    if (myAnswer2 == answer2) {
                        Console.WriteLine("정답입니다.");
                        break;
                    } else {
                        Console.WriteLine("오답입니다. 정답은 {0}입니다.", answer2);
                        continue;
                    }

                } else if (whatFom == "덧셈") {

                    answer2 = num1 + num2;
                    Console.Write("덧셈 해보자: {0} + {1} = ", num1, num2);
                    double.TryParse(Console.ReadLine(), out myAnswer2);
                    if (myAnswer2 == answer2) {
                        Console.WriteLine("정답입니다.");
                        break;
                    } else {
                        Console.WriteLine("오답입니다. 정답은 {0}입니다.", answer2);
                        continue;
                    }

                } else if (whatFom == "나눗셈") {



                    Console.Write("나눗셈 해보자(둘째 자리 까지): {0} / {1} = ", num1, num2);

                    //4. 나눗셈 예외 처리
                    answer2 = (double)num1 / (double)num2;
                    answer2 = Math.Round(answer2, 2);

                    double.TryParse(Console.ReadLine(), out myAnswer2);

                    if (myAnswer2 == answer2) {
                        Console.WriteLine("정답입니다.");
                        break;
                    } else {
                        Console.WriteLine("오답입니다. 정답은 {0}입니다.", answer2);
                        continue;
                    }
                } else {

                    answer2 = num1 - num2;
                    Console.Write("뺄셈 해보자: {0} - {1} = ", num1, num2);
                    double.TryParse(Console.ReadLine(), out myAnswer2);
                    if (myAnswer2 == answer2) {
                        Console.WriteLine("정답입니다.");
                        break;
                    } else {
                        Console.WriteLine("오답입니다. 정답은 {0}입니다.", answer2);
                        continue;
                    }

                }
            }

        }
    }
}