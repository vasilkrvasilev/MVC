//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MovieApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Movy
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public int Year { get; set; }
        public string MaleRoleName { get; set; }
        public string FemaleRoleName { get; set; }
        public int MaleRoleAge { get; set; }
        public int FemaleRoleAge { get; set; }
        public string Studio { get; set; }
        public string StudioAddress { get; set; }
    }
}
