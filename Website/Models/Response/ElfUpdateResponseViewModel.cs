using DatabaseBridge.Models;

namespace Website.Models.Response
{
    public class ElfUpdateResponseViewModel
    {
        public string name { get; set; }

        public int yearsOnJob { get; set; }

        public int salary { get; set; }

        public int rank { get; set; }

        public bool updateSuccess { get; set; }

        public ElfUpdateResponseViewModel(Elf elf)
        {
            this.name = elf.Name;
            this.yearsOnJob = elf.YearsOnJob;
            this.salary = elf.Salary;
            this.rank = elf.Rank;
        }       
    }
}