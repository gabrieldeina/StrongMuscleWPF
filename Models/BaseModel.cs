using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StrongMuscle.Models {
    class BaseModel {
        public BaseModel() => CriadoEm = DateTime.Now;
        [Key]
        public int Id { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}