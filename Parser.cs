namespace DeleteConsole
{
    internal class Parser
    {
        private string _info;
        private string[] _numbers;
        public Parser(string info)
        {
            _info = info;
            _numbers = GetOperation(info);
        }

        private string[] GetOperation(string info)
        {
            return info.Split(new string[] { "and", "or", "xor", "->" }, StringSplitOptions.None);
        }

        public string Rule
        {
            get
            {

                foreach (var number in _numbers)
                {
                    _info = _info.Replace(number, String.Empty);
                }

                return new OperationFactory().Get(_info).ToString().ToEightBitBinary();
            }
        }

        public int[] FirstLine
        {
            get
            {
                var firstBinary = Converter.ToBinary(Convert.ToInt32(_numbers[0]));
                var secondBinary = Converter.ToBinary(Convert.ToInt32(_numbers[1]));

                Converter.ToEqualLength(ref firstBinary, ref secondBinary);
                return GetShuffle(firstBinary, secondBinary);
            }
        }

        private int[] GetShuffle(string firstBinary, string secondBinary)
        {
            int[] result = new int[firstBinary.Length * 2];

            for (int i = 0; i < result.Length; i+=2)
            {
                result[i] = Convert.ToInt32(firstBinary[i / 2].ToString());
            }

            int o = 0;
            for (int i = 1; i < result.Length; i+=2)
            {
                result[i] = Convert.ToInt32(secondBinary[o++].ToString());
            }

            return result;
        }
    }
}
