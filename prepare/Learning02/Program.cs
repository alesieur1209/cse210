using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Krabby Patty Maker";
        job1._company = "The Krusty Krab";
        job1._startYear = 2000;
        job1._endYear = 2005;

        Job job2 = new Job();
        job2._jobTitle = "Manager";
        job2._company = "The Krusty Krab 2";
        job2._startYear = 2005;
        job2._endYear = 2010;

        Resume myResume = new Resume();
        myResume._name = "Spongebob Squarepants";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}