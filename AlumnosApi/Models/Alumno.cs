﻿namespace AlumnosApi.Models
{
    public class Alumno
    {
        public int Id { get; set; }
        public string ? Nombre { get; set; }
        public int ? Edad { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}