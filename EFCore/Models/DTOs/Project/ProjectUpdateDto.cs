namespace EFCore.Models.DTOs.Project
{
    public class ProjectUpdateDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
    }
}