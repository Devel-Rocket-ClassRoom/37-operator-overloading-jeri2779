using System;

public struct Vector3
{
    //3개의 축 필드
    public float X;
    public float Y; 
    public float Z;

    //생성자
    public Vector3(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    //벡터의 덧셈
    public static Vector3 operator +(Vector3 a, Vector3 b)
    {
        //XYZ에 a+b를 해주어야 한다
        return new Vector3
            (
                a.X + b.X,
                a.Y + b.Y,
                a.Z + b.Z
            );
    }

    //벡터의 뺄셈
    public static Vector3 operator -(Vector3 a, Vector3 b)
    {
        //XYZ에 a-b를 해주어야 한다
        return new Vector3
            (
                a.X - b.X,
                a.Y - b.Y,
                a.Z - b.Z
            );
    }

    //벡터의 스칼라 곱
    //스칼라 곱이란? 
    //벡터에 숫자를 곱하는 것. 예를 들어, (1,2,3) * 2 => (2,4,6)
    public static Vector3 operator *(Vector3 v, float scalar)
    {
        return new Vector3
            (
                v.X * scalar,
                v.Y * scalar,
                v.Z * scalar
            );
    }
    //벡터의 스칼라 곱 (반대 순서)
    public static Vector3 operator *(float scalar, Vector3 v)
    {
        return v * scalar;
    }

    //단항 음수 연산자
    public static Vector3 operator -(Vector3 v)
    {
        return new Vector3
        (
            -v.X,
            -v.Y,
            -v.Z
        );
    }

    //equal비교 연산자
    public static bool operator == (Vector3 a, Vector3 b)
    {
        return
            a.X == b.X
            &&
            a.Y == b.Y
            &&
            a.Z == b.Z;
    }
    //not equal 비교 연산자
    public static bool operator != (Vector3 a, Vector3 b)
    {
        return !(a == b);
    }

    public override string ToString()
    {
        return $"({X}, {Y}, {Z})";
    }

    public override bool Equals(object obj)
    {
        throw new NotImplementedException();
    }

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }
}