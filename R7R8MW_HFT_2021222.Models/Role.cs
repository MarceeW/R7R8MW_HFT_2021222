﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace R7R8MW_HFT_2021222.Models
{
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleId { get; set; }

        public int Priority { get; set; }
        public string RoleName { get; set; }

        public int MovieId { get; set; }
        public int ActorId { get; set; }
        public virtual Actor Actor { get; private set; }
        [JsonIgnore]
        public virtual Movie Movie { get; private set; }
        public Role()
        {
        }

        public Role(string seed)
        {
            string[] split = seed.Split('#');
            RoleId = int.Parse(split[0]);
            MovieId = int.Parse(split[1]);
            ActorId = int.Parse(split[2]);
            Priority = int.Parse(split[3]);
            RoleName = split[4];
        }
        public override bool Equals(object obj)
        {
            if(obj is Role)
            {
                Role other = obj as Role;
                return RoleId == other.RoleId && RoleName == other.RoleName;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
