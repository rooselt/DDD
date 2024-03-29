﻿using Sisacon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sisacon.UI.ViewModels
{
    public class CostCategoryViewModel : BaseViewModel
    {
        [Required]
        [MaxLength(50)]
        public string Description { get; set; }
        public int IdUser { get; set; }
        [Required]
        public virtual User User { get; set; }
    }
}