namespace FilmChallengeApp;

public class Statistics
{
    public Statistics()
    {
        Min = 100;
        Max = 0;
        Sum = 0;
        Count = 0;
    }

    public int Min { get; private set; }
    public int Max { get; private set; }
    public int Sum { get; private set; }
    public int Count { get; private set; }

    public float Average
    {
        get
        {
            return Sum / Count;
        }
    }

    public char AverageLetter
    {
        get
        {
            switch (Average)
            {
                case var average when average > 80:
                    return 'A';
                case var average when average > 60:
                    return 'B';
                case var average when average > 40:
                    return 'C';
                case var average when average > 20:
                    return 'D';
                default:
                    return 'E';
            }
        }
    }

    public void AddGrade(int grade)
    {
        Min = Math.Min(Min, grade);
        Max = Math.Max(Max, grade);
        Sum += grade;
        Count++;
    }
}
