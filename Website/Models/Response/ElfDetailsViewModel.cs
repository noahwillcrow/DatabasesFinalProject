﻿using DatabaseBridge.Models;
using System.Collections.Generic;

namespace Website.Models.Response
{
    public class ElfDetailsViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int YearsOnJob { get; set; }

        public int Salary { get; set; }

        public int Rank { get; set; }

        public IEnumerable<Reindeer> Reindeer { get; set; }

        public IEnumerable<Present> Presents { get; set; }

        public ElfDetailsViewModel(Elf elf, IEnumerable<Reindeer> reindeer, IEnumerable<Present> presents)
        {
            this.ID = elf.ID;
            this.Name = elf.Name;
            this.YearsOnJob = elf.YearsOnJob;
            this.Salary = elf.Salary;
            this.Rank = elf.Rank;
            this.Reindeer = reindeer;
            this.Presents = presents;
        }
    }
}