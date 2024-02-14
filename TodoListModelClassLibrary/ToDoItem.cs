namespace TodoListModelClassLibrary;

public class ToDoItem
    {
        public int Id { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string? Description { get; set; }

        public ToDoItem()
        {
            // Set DueDate to be 7 Days from now if it's  null
            if (DueDate == default)
            {
                DueDate = DateTime.Now.AddDays(7);
            }
        }
    }
