namespace DeleteConsole
{
    internal class OperationFactory
    {
        public int Get(string input)
        {
            switch (input)
            {
                case "and":
                    return 192;
                case "or":
                    return 252;
                case "xor":
                    return 60;
                case "->":
                    return 207;
                default:
                    throw new Exception("неправильно");
            }
        }
    }
}
