namespace ServerlessFunctions
{
    public static class Mappings
    {
        public static ToDoTableEntity ToTableEntity(this ToDo todo)
        {
            return new ToDoTableEntity
            {
                PartitionKey = "TODO",
                RowKey = todo.Id,
                CreatedTime = todo.CreatedTime,
                IsCompleted = todo.IsCompleted,
                TaskDescription = todo.TaskDescription
            };
        }

        public static ToDo ToPocoEntity(this ToDoTableEntity tableEntity)
        {
            return new ToDo
            {
                Id = tableEntity.RowKey,
                CreatedTime = tableEntity.CreatedTime,
                IsCompleted = tableEntity.IsCompleted,
                TaskDescription = tableEntity.TaskDescription
            };
        }
    }
}
