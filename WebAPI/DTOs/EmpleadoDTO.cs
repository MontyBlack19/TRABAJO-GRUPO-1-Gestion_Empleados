namespace WebAPI.DTOs
{
    public class EmpleadoDTO
    {
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int IdTipo { get; set; }
        public int IdDepartamento { get; set; }
        public int IdTurno { get; set; }
        public int IdSucursal { get; set; }
        public bool Activo { get; set; }
    }
}
