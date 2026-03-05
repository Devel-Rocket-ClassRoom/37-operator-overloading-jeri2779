struct Counter
    {
    public int Value;
        public Counter(int value)
        {
            Value = value;
        }


    public static Counter operator ++(Counter c)
    {
        return new Counter(++c.Value);

    }

    public static Counter operator -(Counter c)
    {
        return new Counter(-c.Value);
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}
