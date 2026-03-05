using System;
using System.Numerics;

// README.md를 읽고 코드를 작성하세요.
GameTime t1 = new GameTime(1, 30, 45);
GameTime t2 = new GameTime(0, 45, 30);

Console.WriteLine($"시간1: {t1}");
Console.WriteLine($"시간2: {t2}");

GameTime sum = t1 + t2;
Console.WriteLine($"합계: {sum}");

GameTime diff = t2 - t1;
Console.WriteLine($"차이: {diff}");

Console.WriteLine($"시간1 == 시간2: {t1 == t2}");
Console.WriteLine($"시간1 != 시간2: {t1 != t2}");
Console.WriteLine($"시간1 > 시간2: {t1 > t2}");
Console.WriteLine($"시간1 < 시간2: {t1 < t2}");

GameTime t3 = t2 * 3;
Console.WriteLine($"시간2 x 3: {t3}");

GameTime t4 = new GameTime(0, 0, 3700);
Console.WriteLine($"3700초 정규화: {t4}");
Console.WriteLine($"시간1 총 초: {t1.GetTotalSeconds()}");
public struct GameTime
{
    public int Hours;
    public int Minutes;
    public int Seconds;

    public GameTime(int hours, int minutes, int seconds)
    {
        Hours = hours;
        Minutes = minutes;
        Seconds = seconds;
        Normalize();
    }

    private void Normalize()
    {
        if (Seconds >= 60)
        {
            Minutes += Seconds / 60;
            Seconds %= 60;
        }
        if (Minutes >= 60)
        {
            Hours += Minutes / 60;
            Minutes %= 60;
        }
    }
    //+ 연산자 오버로딩 - a와 b의 시간을 더한 결과를 반환
    public static GameTime operator +(GameTime a, GameTime b)
    {
        return new GameTime(
            a.Hours + b.Hours,
            a.Minutes + b.Minutes,
            a.Seconds + b.Seconds);
    }

    //-연산자 오버로딩 - a에서 b를 뺀 결과를 반환
    //(결과가 음수가 되면 0시간 0분 0초로 처리)
    public static GameTime operator -(GameTime a, GameTime b)
    {

        int diffHours = a.Hours - b.Hours;
        int diffMinutes = a.Minutes - b.Minutes;
        int diffSeconds = a.Seconds - b.Seconds;
        int totalDiff = diffHours * 3600 + diffMinutes * 60 + diffSeconds; // 전체 차이를 초 단위로 계산

        if (totalDiff <= 0)
        {
            return new GameTime(0, 0, 0);
        }
        else
        {
            return new GameTime(
                a.Hours - b.Hours,
                a.Minutes - b.Minutes,
                a.Seconds - b.Seconds);
        }

    }

    //동일 비교
    public static bool operator ==(GameTime a, GameTime b)
    {
        return
            a.Hours == b.Hours &&
            a.Minutes == b.Minutes &&
            a.Seconds == b.Seconds;
    }
    //동일 비교의 반대 
    public static bool operator !=(GameTime a, GameTime b)
    {
        return !(a == b);
    }

    public static bool operator <(GameTime a, GameTime b)
    {
        
        return 
            a.Hours * 3600 + 
            a.Minutes * 60 + 
            a.Seconds < 
            b.Hours * 3600 + 
            b.Minutes * 60 + 
            b.Seconds;
    }

    public static bool operator >(GameTime a, GameTime b)
    {
        return
            a.Hours * 3600 +
            a.Minutes * 60 +
            a.Seconds >
            b.Hours * 3600 +
            b.Minutes * 60 +
            b.Seconds;
    }

     
    public static GameTime operator *(GameTime a, int multiplier)
    {
        return new GameTime(
            a.Hours * multiplier,
            a.Minutes * multiplier,
            a.Seconds * multiplier);
    }
     
    public int GetTotalSeconds()
    {
        return Hours * 3600 + Minutes * 60 + Seconds;
    }


    public override string ToString()
    {
        return $"{Hours}h {Minutes}m {Seconds}s";
    }
    public override bool Equals(object obj)
    {
        if (obj is GameTime other)
        {
            return this == other;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Hours, Minutes, Seconds);
    }
}