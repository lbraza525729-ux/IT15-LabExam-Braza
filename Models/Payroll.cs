namespace IT15_LabExam_Braza.Models
{
    public class Payroll
    {
        public int PayrollID { get; set; }

        public int EmployeeID { get; set; }
        public Employee? Employee { get; set; }

        public DateTime Date { get; set; }

        public int DaysWorked { get; set; }
        public decimal Deduction { get; set; }

        public decimal GrossPay { get; set; }
        public decimal NetPay { get; set; }
    }
}