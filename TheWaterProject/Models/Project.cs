namespace TheWaterProject.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProgramName { get; set; }
        public string ProjectType { get; set; }
        public string ProjectImpact { get; set; }
        public DateTime ProjectInstallation {  get; set; }
        public string ProjectPhase { get; set; }
    }
}
