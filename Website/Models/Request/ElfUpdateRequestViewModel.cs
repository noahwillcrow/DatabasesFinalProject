using DatabaseBridge.Models;

namespace Website.Models.Request
{
    public class ElfUpdateRequestViewModel
    {
        public string name { get; set; }

        public int yearsOnJob { get; set; }

        public int salary { get; set; }

        public int rank { get; set; }

        public void UpdateElfModel(Elf elf)
        {
            this.name = elf.Name;
            this.yearsOnJob = elf.YearsOnJob;
            this.salary = elf.Salary;
            this.rank = elf.Rank;
        }
    }
}