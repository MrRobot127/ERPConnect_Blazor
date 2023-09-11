﻿namespace ERPConnect.Models
{
    public class CompanyGroup
    {
        public int Id { get; set; }
        public string? GroupName { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}