public struct Fraction
{
    public int numerator;
    public int denominator;

    public Fraction(int numerator, int denominator)
    {
        this.numerator = numerator;
        this.denominator = denominator;
    }

    //곱셈 연산자 오버로딩
    public static Fraction operator *(Fraction a, Fraction b)
    {
        //
        return new Fraction(a.numerator * b.numerator, a.denominator * b.denominator);

    }

    //덧셈 연산자 오버로딩
    public static Fraction operator +(Fraction a, Fraction b)
    {
        int num, den;
        num = a.numerator * b.denominator + b.numerator * a.denominator;
        den = a.denominator * b.denominator;
        return new Fraction(num, den);


    }

    public override string ToString()
    {
        return $"{numerator}/{denominator}";
    }
}
