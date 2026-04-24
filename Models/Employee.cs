namespace IT15_LabExam_Braza.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;

        public decimal DailyRate { get; set; }

        public List<Payroll>? Payrolls { get; set; }
    }
}