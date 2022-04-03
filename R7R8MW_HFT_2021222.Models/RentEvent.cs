﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R7R8MW_HFT_2021222.Models
{
    public class RentEvent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RentEventId { get; set; }
        [Required]
        public DateTime RentDate { get; set; }
        [Required]
        public double Duration { get; set; }

        [ForeignKey(nameof(Car))]
        public int? CarId { get; set; }

        public virtual Car Car { get; private set; }
        public RentEvent()
        {

        }
        public RentEvent(string data)
        {
            string[] splitted = data.Split('#');
            RentEventId = int.Parse(splitted[0]);
            RentDate = DateTime.ParseExact(splitted[1], "yyyyMMdd HH:mm", null); //f.e.: 20080916 11:02
            Duration = int.Parse(splitted[2]);
            CarId = int.Parse(splitted[3]);
        }
    }
}