﻿namespace FilmChallengeApp;

public class Film : FilmBase
{
    private readonly List<int> _grades = new();

    public Film(string title, int year) : base(title, year)
    {
    }

    public override void AddGrade(int grade)
    {
        if (grade >= 1 && grade <= 100)
        {
            _grades.Add(grade);
        }
        else
        {
            throw new ArgumentException($"Invalid value: '{grade}'! Correct value range is from 1 to 100.");
        }
    }

    public Statistics GetStatistics()
    {
        return base.GetStatistics(_grades);
    }
}
