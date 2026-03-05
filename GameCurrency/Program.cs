using System;

// README.md를 읽고 코드를 작성하세요.
//1G = 100S
 
GameCurrency wallet1 = new GameCurrency(3, 50);
GameCurrency wallet2 = new GameCurrency(1, 80);

Console.WriteLine($"지갑1: {wallet1}");
Console.WriteLine($"지갑2: {wallet2}");

GameCurrency sum = wallet1 + wallet2;
Console.WriteLine($"합계: {sum}");

GameCurrency diff = wallet2 - wallet1;
Console.WriteLine($"차액: {diff}");

Console.WriteLine($"지갑1 == 지갑2: {wallet1 == wallet2}");
Console.WriteLine($"지갑1 != 지갑2: {wallet1 != wallet2}");
Console.WriteLine($"지갑1 > 지갑2: {wallet1 > wallet2}");
Console.WriteLine($"지갑1 < 지갑2: {wallet1 < wallet2}");

GameCurrency wallet3 = new GameCurrency(0, 250);
Console.WriteLine($"250S 정규화: {wallet3}");
Console.WriteLine($"지갑1 총 Silver: {wallet1.GetTotalSilver()}");
struct GameCurrency
{
    public int Gold;
    public int Silver;

    public GameCurrency(int gold, int silver)
    {
        Gold = gold;
        Silver = silver;
        Normalize();
    }

    private void Normalize()// Silver이 100 이상인 경우 Gold로 변환
    {
        if (Silver >= 100)
        {
            Gold = Gold + Silver / 100;
            Silver %= 100;
        }
    }

    public static GameCurrency operator +(GameCurrency a, GameCurrency b)
    {
        return new GameCurrency(
            a.Gold + b.Gold, 
            a.Silver + b.Silver);
    }

    //뺄셈 연산자 오버로딩 - a에서 b를 뺀 결과를 반환
    public static GameCurrency operator -(GameCurrency a, GameCurrency b)
    {
        //(결과가 음수가 되면 0G 0S로 처리

        int diff1 = a.Gold - b.Gold;
        int diff2 = a.Silver - b.Silver; 
        int totalDiff = diff1 * 100 + diff2; // 전체 차이를 Silver 단위로 계산

        if (totalDiff <= 0)
        {
            return new GameCurrency(0, 0);
        }
        else
        {
            return new GameCurrency(
                a.Gold - b.Gold,
                a.Silver - b.Silver);

        }
    }
        

    //동일 비교 연산자 오버로딩
    public static bool operator ==(GameCurrency a, GameCurrency b)
    {
         return
            a.Gold == b.Gold
            &&
            a.Silver == b.Silver;
    }

    public static bool operator !=(GameCurrency a, GameCurrency b)
    {
        return !(a == b);
    }

    //`<`, `>` : 크기 비교
    public static bool operator <(GameCurrency a, GameCurrency b)
    {
        return a.Gold < b.Gold;
    }

    public static bool operator >(GameCurrency a, GameCurrency b)
    {
        return a.Gold > b.Gold;
    }

    public int GetTotalSilver()
    {
        return Gold * 100 + Silver;
    }
    public override string ToString()
    {
        return $"{Gold}G, {Silver}S";
    }


}