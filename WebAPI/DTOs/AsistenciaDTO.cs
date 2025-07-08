namespace WebAPI.DTOs
{
    public class AsistenciaDTO
    {
        public int IdEmpleado { get; set; }
        public DateTime Fecha { get; set; }
        public TimeOnly HoraEntrada { get; set; }
        public TimeOnly HoraSalida { get; set; }
        public bool Justificado { get; set; }
        public int CreadoPor { get; set; }
    }
}
