public struct Celsius
{
    public double Degrees;
    public Celsius(double degrees)
    {
        Degrees = degrees;
    }
    //celsius에서 fahrenheit로 명시적 변환 연산자
    public static explicit operator Fahrenheit(Celsius c)
    {
        return new Fahrenheit(c.Degrees * 9 / 5 + 32);
    }

    //fahrenheit에서 celsius로 명시적 변환 연산자
    public static explicit operator Celsius(Fahrenheit f)
    {
        return new Celsius((f.Degrees - 32) * 5 / 9);
    }
    public override string ToString()
    {
        return $"{Degrees} °C";
    }   
}
