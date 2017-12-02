using DatabaseBridge.Models;

namespace Website.Models.Request
{
    public class ElfUpdateRequestViewModel
    {
        public string Name { get; set; }

        public int YearsOnJob { get; set; }

        public int Salary { get; set; }

        public int Rank { get; set; }

        public void UpdateElfModel(Elf elf)
        {
            elf.Name = this.Name;
            elf.YearsOnJob = this.YearsOnJob;
            elf.Salary = this.Salary;
            elf.Rank = this.Rank;
        }
    }
}