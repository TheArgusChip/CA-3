public static class Converter
{
    public static string ToDecimal(string binary)
    {
        int result = 0;
        for (int i = 0; i < binary.Length; i++)
        {
            result += Convert.ToInt32(binary[i].ToString()) * (int)Math.Pow(2, i);
        }

        return result.ToString();
    }

    public static void ToEqualLength(ref string firstNumber, ref string secondNumber)
    {
        int difference = Math.Abs(firstNumber.Length - secondNumber.Length);
        if (firstNumber.Length >= secondNumber.Length)
        {
            for (int i = 0; i < difference; i++)
            {
                secondNumber += "0";
            }
        }
        else
        {
            for (int i = 0; i < difference; i++)
            {
                firstNumber += "0";
            }
        }
    }

    public static string ToBinary(int source)
    {
        if (source < 2)
        {
            return (source % 2).ToString();
        }

        return (source % 2).ToString() + ToBinary(source / 2);
    }

    public static string ToEightBitBinary(this string source)
    {
        source = ToBinary(Convert.ToInt32(source));
        for (int i = source.Length; i < 8; i++)
        {
            source += "0";
        }

        return source;
    }
}