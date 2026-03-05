using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

// README.md를 읽고 아래에 코드를 작성하세요.
Console.WriteLine("코드를 작성하세요.");
{
    Console.WriteLine("## 1. 단항 연산자");


    Counter c = new Counter(5);
    Console.WriteLine(-c);
    c++;
    Console.WriteLine(c);

    Console.WriteLine();
}

Console.WriteLine();
Console.WriteLine("## 2. 이항 연산자");

Fraction f1 = new Fraction(1, 2);
Fraction f2 = new Fraction(1, 3);
Console.WriteLine(f1 + f2);
Console.WriteLine(f1 * f2);


Console.WriteLine();
Console.WriteLine("## 3. 비교 연산자");

Money m1 = new Money(1000, "KRW");//currency가 !=이면 비교 불가.
Money m2 = new Money(2000, "KRW");
//m1과 m2는 통화 단위가 같으므로 비교 가능
Console.WriteLine(m1 == m2); // false
Console.WriteLine(m1 < m2); // true


Console.WriteLine();
Console.WriteLine("## 4. 복합 대입 연산자");

Vector2 v = new Vector2(1, 2);
v += new Vector2(3, 4);
Console.WriteLine(v);

Console.WriteLine();
Console.WriteLine("## 5. 암시적 변환");

Celsius temp = 36.5; // double에서 Celsius로 암시적 변환
double value = temp; // Celsius에서 double로 암시적 변환
Console.WriteLine(value);

public struct Celsius
{
    public double Degrees;
    public Celsius(double degrees)
    {
        Degrees = degrees;
    }

    //celsius => double implicit 변환
    public static implicit operator double(Celsius c)
    {
        return c.Degrees;
    }

    //double => celsius implicit 변환
    public static implicit operator Celsius(double d)
    {
        return new Celsius(d);
    }
}