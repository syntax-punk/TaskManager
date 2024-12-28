namespace TaskManager.Models;

public class RequestTaskItem
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime DueDate { get; set; }
}