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
    using System.Collections.ObjectModel;
    
    public partial class Family
    {
        public Family()
        {
            this.FamilyTalents = new ObservableCollection<FamilyTalent>();
            this.Persons = new ObservableCollection<Person>();
            this.Works = new ObservableCollection<Work>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int HoursRequired { get; set; }
        public string MaritalStatus { get; set; }
        public string Note { get; set; }
        public string AdminNote { get; set; }
    
        public virtual ObservableCollection<FamilyTalent> FamilyTalents { get; set; }
        public virtual ObservableCollection<Person> Persons { get; set; }
        public virtual ObservableCollection<Work> Works { get; set; }
    }
}
