// See https://aka.ms/new-console-template for more information

using Gestion_Empleados.Models;
using Gestion_Empleados.Operaciones;
using Gestion_Empleados.Operations;

TipoEmpleadoDAO opTipoEmpleado = new TipoEmpleadoDAO();

//opTipoEmpleado.insertar("Administrador");

//opTipoEmpleado.actualizar(7, "Logistica");

opTipoEmpleado.eliminar(7);

var tipoempleados = opTipoEmpleado.seleccionarTodos();

foreach (var tipoempleado in tipoempleados)
{
    Console.WriteLine(tipoempleado.NombreTipo);
}


Console.WriteLine("********************************************");

var TipoEmpleadoSeleccionado = opTipoEmpleado.seleccionarTipoEmpleado(3);

if (TipoEmpleadoSeleccionado != null)
{
    Console.WriteLine("El puesto con el id = 3 es:" + TipoEmpleadoSeleccionado.NombreTipo);
}
else
{
    Console.WriteLine("No existe");
}

Console.WriteLine("********************************************");

var empletipo = opTipoEmpleado.seleccionarEmpleadosTipo();

foreach (EmpleadoTipo empleadoTipo in empletipo)
{
    Console.WriteLine(empleadoTipo.NombreEmpleado + " => " + empleadoTipo.NombreTipo);
}

Console.WriteLine("********************************************");

static void MostrarTurnos(TurnoDAO dao)
{
    List<Turno> turnos = dao.seleccionarTodos();

    Console.WriteLine("=== Lista de Turnos ===");
    foreach (var turno in turnos)
    {
        Console.WriteLine($"Nombre: {turno.Nombre}, Entrada: {turno.HoraEntrada}, Salida: {turno.HoraSalida}");
    }

    Console.WriteLine("Presione una tecla para continuar...");
    Console.ReadKey();
}
