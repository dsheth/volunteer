//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace volunteer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Talent
    {
        public Talent()
        {
            this.FamilyTalents = new HashSet<FamilyTalent>();
            this.TaskTalents = new HashSet<TaskTalent>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<FamilyTalent> FamilyTalents { get; set; }
        public virtual ICollection<TaskTalent> TaskTalents { get; set; }
    }
}
