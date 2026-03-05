using System;

public struct Money
{
    public decimal Amount; // 금액
    public string Currency; // 통화 단위

    // 생성자
    public Money(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    // == 연산자 오버로딩
    public static bool operator ==(Money a , Money b)//같을떄
    {
        // 통화 단위와 금액이 모두 같을 때 동일하다고 판단
        return a.Currency == b.Currency && a.Amount == b.Amount;
    }

    // != 연산자 오버로딩
    public static bool operator !=(Money a, Money b)//다를 때
    {
        // == 연산자의 결과를 반대로 반환
        return !(a == b);
    }
    public static bool operator <(Money a, Money b)//a가 더 작을때
    {   // 통화 단위가 다르면 비교할 수 없으므로 예외를 던짐
        if (a.Currency != b.Currency)
        {
            throw new InvalidOperationException("통화가 다릅니다.");
        }
        return a.Amount < b.Amount;
    }

    public static bool operator >(Money a, Money b)//a가 더 클때
    {   //위와 동일 연산자 기호만 다름
        if (a.Currency != b.Currency)
        {
            throw new InvalidOperationException("통화가 다릅니다.");
        }
        return a.Amount > b.Amount;
    }
    // Equals 메서드 오버라이딩 (== 연산자와 일관성 유지)
    public override bool Equals(object obj)//Money타입 체크
    {
        // obj가 Money 타입인지 확인 후, == 연산자를 사용하여 비교
        if (obj is Money money)
        {
            return this == money; // == 연산자 재사용
        }
        return false;
    }
    //
    public override int GetHashCode()
    {
        return HashCode.Combine(Amount, Currency);
    }
}