//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LaSalleWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Nota
    {
        public int Id { get; set; }
        public decimal Acumulado { get; set; }
        public decimal Examen { get; set; }
        public int AlumnoId { get; set; }
        public int AsignaturaId { get; set; }
    
        public virtual Alumno Alumno { get; set; }
        public virtual Asignatura Asignatura { get; set; }
    }
}