namespace CarStatusAPI.ApiModels
{
    public class ToDoDto
    {
        public required string Task { get; set; }

        public required bool Done { get; set; } = false;

    }
}
