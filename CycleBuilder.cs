namespace DeleteConsole
{
    internal class CycleBuilder
    {
        private List<int[]> _cycles =  new List<int[]>();
        private int _t = 1;
        private string _rule;
        private int _length;

        public CycleBuilder(Parser settings)
        {
            _cycles.Add(settings.FirstLine);
            _rule = settings.Rule;
            _length = _cycles.First().Length;
        }

        public void Work()
        {
            Build();
            Show();
        }

        private void Show()
        {
            foreach (var cycle in _cycles)
            {
                foreach (var element in cycle)
                {
                    Console.Write(element);
                }

                Console.WriteLine();
            }
        }

        private void Build()
        {
            for (int i = 1; i < _t + 1; i++)
            {
                _cycles.Add(GetNewLine(i - 1));
            }
        }

        private int[] GetNewLine(int previousLineIndex)
        {
            var result = new int[_length];
            FillCalculatedValue(ref result, _length - 1, previousLineIndex);
            return result;
        }

        private void FillCalculatedValue(ref int[] result, int length, int previousLineIndex)
        {
            for (int i = 1; i < length; i++)
            {
                result[i] = Calculate(previousLineIndex, i);
            }
        }

        private int Calculate(int lineIndex, int i)
        {
            int multiplier = 4;
            int ruleIndex = 0;
            for (int t = i - 1; t < i + 2; t++)
            {
                ruleIndex += _cycles[lineIndex][t] * multiplier;
                multiplier /= 2;
            }

            return Convert.ToInt32(_rule[ruleIndex].ToString());
        }
    }
}
