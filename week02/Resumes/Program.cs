using System;

class Program
{
    static void Main(string[] args)
    {
        Resume myResume = new Resume();
        myResume._name = "John Doe";

        Job job1 = new Job();
        job1._company = "Tech Corp";
        job1._jobTitle = "Software Engineer";
        job1._startYear = 2018;
        job1._endYear = 2022;

        Job job2 = new Job();
        job2._company = "Web Solutions";
        job2._jobTitle = "Web Developer";
        job2._startYear = 2022;
        job2._endYear = 2023;

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}