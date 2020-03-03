namespace BowlingKata
{
    public class Game
    {
        private int _totalScore;
        private readonly int[] _rolls = new int[21];
        private int _currentRoll;
        public void Roll(int pins)
        {
            _rolls[_currentRoll++] = pins;
        }

        public int TotalScore
        {
            get
            {
                var rollIndex = 0;
                for (var frame = 0; frame < 10; frame++)
                {
                    if (IsSpare(rollIndex))
                    {
                        _totalScore = _totalScore + 10 + SpareBonus(rollIndex);
                        rollIndex = rollIndex + 2;
                    }
                    else if (IsStrike(rollIndex))
                    {
                        _totalScore = _totalScore + 10 + StrikeBonus(rollIndex);
                        rollIndex++;
                    }
                    else
                    {
                        _totalScore += SumOfBallsInFrame(rollIndex);
                        rollIndex = rollIndex + 2;
                    }
                }

                return _totalScore;
            }
        }

        private bool IsSpare(int rollIndex)
        {
            return (_rolls[rollIndex] + _rolls[rollIndex + 1] == 10);
        }

        private int SumOfBallsInFrame(int rollIndex)
        {
            return _rolls[rollIndex] + _rolls[rollIndex + 1];
        }

        private int SpareBonus(int rollIndex)
        {
            return _rolls[rollIndex + 2];
        }

        private int StrikeBonus(int rollIndex)
        {
            return _rolls[rollIndex + 1] + _rolls[rollIndex + 2];
        }

        private bool IsStrike(int rollIndex)
        {
            return _rolls[rollIndex] == 10;
        }
    }
}