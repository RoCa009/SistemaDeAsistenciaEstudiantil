$(function () {
    Cargar();

    CargarProfesores();
    //CargarGrados();
    //CargarSecciones();
    CargarHorarios();
});

$('#frmMatriculaDeAlumnos').submit(function (event) {
    event.preventDefault();
    Guardar();
});

function Cargar() {
    $.ajax({
        url: "/MatriculaDeAlumno/Obtener",
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var html = '';
            $.each(data, function (key, item) {
                html += "<tr>";
                html += "<td>" + item.Id + "</td>";
                html += "<td>" + item.DUIEncargado + "</td>";
                html += "<td>" + item.NombreEncargado + "</td>";                
                html += "<td>" + item.NombresAlumno + "</td>";
                html += "<td>" + item.ApellidosAlumno + "</td>";
                html += "<td>" + item.Edad + "</td>";
                html += "<td>" + item.Sexo + "</td>";
                html += "<td>" + item.Direccion + "</td>";
                html += "<td>" + item.Telefono + "</td>";
                html += "<td>" + item.Correo + "</td>";
                html += "<td>" + item.IdProfesor + "</td>";
                html += "<td>" + item.IdGrado + "</td>";
                html += "<td>" + item.IdSeccion + "</td>";
                html += "<td>" + item.IdHorario + "</td>";
                html += "<td>" + item.IdAula + "</td>";
                html += "<td>";
                html += "<a href='#' class='btn btn-info' data-toggle='modal' data-target='#miModal' onclick='VerDetalle(" + item.Id + ")'>Detalle</a> | ";
                html += "<a href='#' class='btn btn-danger' onclick='Eliminar(" + item.Id + ")'>Eliminar</a>";
                html += "</td>";
                html += "</tr>";
            });

            $("#matriculadealumnos tbody").html(html);
        },
        error: function (error) {
            alert(error.responseText);
        }
    });
}


function VerDetalle(id) {
    $.ajax({
        url: "/MatriculaDeAlumno/BuscarPorId?pId=" + id,
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $('#Id').val(data.Id);
            $('#DUIEncargado').val(data.DUIEncargado);
            $('#NombreEncargado').val(data.NombreEncargado);
            $('#NombresAlumno').val(data.NombresAlumno);
            $('#ApellidosAlumno').val(data.ApellidosAlumno);
            $('#Edad').val(data.Edad);
            $('#Sexo').val(data.Sexo);
            $('#Direccion').val(data.Direccion);
            $('#Telefono').val(data.Telefono);
            $('#Correo').val(data.Correo);
            $('#IdProfesor').val(data.IdProfesor);
            $('#IdGrado').val(data.IdGrado);
            $('#IdSeccion').val(data.IdSeccion);
            $('#IdHorario').val(data.IdHorario);
            $('#IdAula').val(data.IdAula);

            $('#exampleModalLabel').text("Modificar Matrcula De Alumno");
            $('#btnGuardar').val("Guardar Cambios");
        },
        error: function (error) {
            alert("Parece que hubo un error al hacer la petición");
            alert(error)
        }
    });
}

function Guardar() {
    if ($('#DUIEncargado').val() == "" ||
    $('#NombreEncargado').val() == "" ||
    $('#NombresAlumno').val() == "" ||
    $('#ApellidosAlumno').val() == "" ||
    $('#Edad').val() == "" ||
    $('#Sexo').val() == -1 ||
    $('#Direccion').val() == "" ||
    $('#Telefono').val() == "" ||
    $('#Correo').val() == "" ||
    $('#IdProfesor').val() == "" ||
    $('#IdGrado').val() == "" ||
    $('#IdSeccion').val() == "" ||
    $('#IdHorario').val() == "" ||
    $('#IdAula').val() == ""){
        alert("Todos los campos son requeridos!");    
    } else {
        var url = ' ';
        var matriculadealumno = {              
            Id: $('#Id').val(),
            DUIEncargado: $('#DUIEncargado').val(),
            NombreEncargado: $('#NombreEncargado').val(),
            NombresAlumno: $('#NombresAlumno').val(),
            ApellidosAlumno: $('#ApellidosAlumno').val(),
            Edad: $('#Edad').val(),
            Sexo: $('#Sexo').val(),
            Direccion: $('#Direccion').val(),
            Telefono: $('#Telefono').val(),
            Correo: $('#Correo').val(),
            IdProfesor: $('#IdProfesor').val(),
            IdGrado: $('#IdGrado').val(),
            IdSeccion: $('#IdSeccion').val(),
            IdHorario: $('#IdHorario').val(),
            IdAula: $('#IdAula').val()
        }

        if (matriculadealumno.Id) {
            url = '/MatriculaDeAlumno/Modificar';
        } else {
            url = '/MatriculaDeAlumno/Agregar';
        }

        $.ajax({
            url: url,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(matriculadealumno),
            success: function (data) {
                if ($('#btnGuardar').val() == "Guardar Cambios") {
                    alert("Se guardaron los cambios");
                } else if ($('#btnGuardar').val() == "Guardar") {
                    alert("Registro guardado con éxito");
                }
                $('#miModal').modal('hide');
                Cargar();
                Limpiar();
                AsistenciaActiva();
            },
            error: function (error) {
                alert("No se pudo guardar el registro");
            }
        });
    }
}

function Limpiar() {
    $('#Id').val("");
    $('#DUIEncargado').val("");
    $('#NombreEncargado').val("");
    $('#NombresAlumno').val("");
    $('#ApellidosAlumno').val("");
    $('#Edad').val("");
    $('#Sexo').val("");
    $('#Direccion').val("");
    $('#Telefono').val("");
    $('#Correo').val("");
    $('#IdProfesor').val("");
    $('#IdGrado').val("");
    $('#IdSeccion').val("");
    $('#IdHorario').val("");
    $('#IdAula').val("");

    $('#exampleModalLabel').text("Crear Matricula De Alumno");
    $('#btnGuardar').val("Guardar");

    AsistenciaActiva();
}


function Eliminar(id) {
    var resp = confirm("¿Estas seguro que quieres eliminar este registro?");
    if (resp) {
        $.ajax({
            url: "/MatriculaDeAlumno/Eliminar?pId=" + id,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                alert("Registro eliminado con éxito");
                Cargar();
                Limpiar();
            },
            error: function (error) {
                alert("No se pudo eliminar el registro");
            }
        });

    }
}


// Traer Listados de Select's

function CargarProfesores() {
    $.ajax({
        url: "/Profesor/Obtener",
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var html = "";
            $.each(data, function (key, item) {
                html += "<option value='" + item.Id + "'>" + item.Nombres + " " + item.Apellidos  + "</option>";
            });
            $('#IdProfesor').append(html);
        },
        error: function (error) {
            alert("Error al mostrar datos");
        }
    });
}

function CargarGrados() {    
        $.ajax({
            url: "/Grado/Obtener",
            type: "GET",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                var html = "";
                $.each(data, function (key, item) {
                    html += "<option value='" + item.Id + "'>" + item.Id + "</option>";
                });
                $('#IdGrado').append(html);
            },
            error: function (error) {
                alert("Error al mostrar datos");
                alert(error);
            }
        });
}


function CargarSecciones() {
    $.ajax({
        url: "/Seccion/Obtener",
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var html = "";
            $.each(data, function (key, item) {
                html += "<option value='" + item.Id + "'>" + item.SeccionAsignada + "</option>";
            });
            $('#IdSeccion').append(html);
        },
        error: function (error) {
            alert("Error al mostrar datos");
            alert(error);
        }
    });
}

function CargarHorarios() {
    $.ajax({
        url: "/Horario/Obtener",
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var html = "";
            $.each(data, function (key, item) {
                html += "<option value='" + item.Id + "'>" + item.HorarioDeClase + "</option>";
            });
            $('#IdHorario').append(html);
        },
        error: function (error) {
            alert("Error al mostrar datos");
            alert(error);
        }
    });
}