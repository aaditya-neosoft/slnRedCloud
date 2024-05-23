﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCloud.Domain.Entities
{
    public class OrganizationAdmin
    {
        [Key] 
        public int OrgID { get; set; }
        public string OrgName { get; set; }

        public string OrgAdminName { get; set; }

        public string OrgAdminEmail { get; set; }

        public string? OrgAdminPassword { get; set; }

        public string OrgAdminMobNo { get; set; }

        public string AddressLineOne { get; set; }

        public string AddressLineTwo { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public int ZipCode { get; set; }

        public string OrgURL { get; set; }

        public bool IsActive { get; set; } = true;


        public virtual ICollection<ResellerAdmin> ResellerAdmins { get; set; } = new List<ResellerAdmin>();

    }
}
