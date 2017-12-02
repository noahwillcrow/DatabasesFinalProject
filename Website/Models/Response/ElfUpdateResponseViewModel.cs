using DatabaseBridge.Models;

namespace Website.Models.Response
{
    public class ElfUpdateResponseViewModel
    {
        public string Name { get; set; }

        public int YearsOnJob { get; set; }

        public int Salary { get; set; }

        public int Rank { get; set; }

        public bool UpdateSuccess { get; set; }

        public ElfUpdateResponseViewModel() { }

        public ElfUpdateResponseViewModel(Elf elf)
        {
            this.Name = elf.Name;
            this.YearsOnJob = elf.YearsOnJob;
            this.Salary = elf.Salary;
            this.Rank = elf.Rank;
        }       
    }
}