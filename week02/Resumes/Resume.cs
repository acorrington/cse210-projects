
public class Resume
{
    public string _name;
    public List<Job> _jobs;


    public Resume()
    {
        _name = string.Empty;
        _jobs = new List<Job>();
    }

    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");
        foreach (var job in _jobs)
        {
            job.Display();
        }
    }
}