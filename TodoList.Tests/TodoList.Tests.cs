using TodoListModelClassLibrary;

namespace TodoList.Tests
{
    [TestClass]
    public class TodoListTests
    {
        ToDoItem? todoTask;

        [TestInitialize]
        public void TestInitialize()
        {
            //arrange test
            todoTask = new ToDoItem();
        }

        [TestMethod]
        public void TodoItem_Initialization_Success()
        {   
            // Assert
            Assert.IsNotNull(todoTask);
        }

        [TestMethod]
        public void TodoItem_SetDateDue_Success()
        {
            // Act
            var dueDate = DateTime.Now.AddDays(7);
            // Arrange
            todoTask.DueDate = dueDate;
            // Assert
            Assert.AreEqual(dueDate, todoTask.DueDate);
        }

        [TestMethod]
        public void TodoItem_MarkTaskAsCompleted_Success()
        {
            // Arrange
            var expectedCompletedDate = DateTime.Now;
            // Act
            todoTask.CompletedDate = expectedCompletedDate;
            // Assert
            Assert.AreEqual(expectedCompletedDate, todoTask.CompletedDate);
        }

        [TestMethod]
        public void TodoItem_SetDescription_Success()
        {
            var description = "Description";

            todoTask.Description = description;

            Assert.AreEqual(description, todoTask.Description);
        }
    }
}