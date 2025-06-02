// See https://aka.ms/new-console-template for more information

using Gestion_Empleados.Models;
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


//*************************************************************************************************************

DepartamentoDAO departamentodao = new DepartamentoDAO();

//*****************************************************************************
Console.WriteLine("*****************************************************************************");
var depas = departamentodao.listar(); //Como es una lista hay que recorrerlo

foreach (var listardep in depas)
{
    Console.WriteLine(listardep.IdDepartamento + " " + listardep.Nombre);
}
//*****************************************************************************
Console.WriteLine("*****************************************************************************");
var ldepasid = departamentodao.listarId(2);

if (ldepasid != null)
{
    Console.WriteLine("Departamento con el ID " + ldepasid.IdDepartamento + " es: " + ldepasid.Nombre);
}
else
{
    Console.WriteLine("No existe el departamento ingresado.");
}
//*****************************************************************************
Console.WriteLine("*****************************************************************************");
var depaEmpleado = departamentodao.selecDepEmpleado();

foreach (DepartamentoEmpleado lstDepEmpleado in depaEmpleado)
{
    Console.WriteLine(lstDepEmpleado.nombreEmpleado +
                      " " +
                      lstDepEmpleado.apellidoEmpleado +
                      " -----> " +
                      lstDepEmpleado.tipoEmpleado +
                      " -----> " +
                      lstDepEmpleado.nombreDepartamento);

    Console.WriteLine();
}

//departamentodao.insertar("Administrativo");
//departamentodao.actualizar(3,"Operario");
//departamentodao.eliminar(4);