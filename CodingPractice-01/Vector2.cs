public struct Vector2
{
    public float X;
    public float Y;
    public Vector2(float x, float y)
    {
        X = x;
        Y = y;
    }
    // 복합 대입 연산자 += 구현
    public static Vector2 operator +(Vector2 a, Vector2 b)//
    {
        //a와 b의 각 성분을 더해서 새로운 Vector2를 반환
        return new Vector2(a.X + b.X, a.Y + b.Y);
        //X는 a/b와 Y는 a/b의 각 요소를 더해서 새로운 Vector2를 반환
    }

    public override string ToString()
    {
        return $"({X}, {Y})";

    }
}