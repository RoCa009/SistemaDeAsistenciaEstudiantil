$(function () {
    Cargar();

    CargarProfesores();
    CargarAlumnos();
    //CargarGrados();
    //CargarSecciones();
});

$('#frmTomaDeAsistencia').submit(function (event) {
    event.preventDefault();
    Guardar();
});

function Cargar() {
    $.ajax({
        url: "/TomaDeAsistencia/Obtener",
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var html = '';
            $.each(data, function (key, item) {
                html += "<tr>";
                html += "<td>" + item.Id + "</td>";
                html += "<td>" + item.Fecha + "</td>";
                html += "<td>" + item.IdProfesor + "</td>";
                html += "<td>" + item.IdAlumno + "</td>";
                html += "<td>" + item.IdGrado + "</td>";
                html += "<td>" + item.IdSeccion + "</td>";
                html += "<td>" + item.Asistencia + "</td>";
                html += "<td>" + item.LlegoTarde + "</td>";
                html += "<td>" + item.JustificacionLlegadaTarde + "</td>";
                html += "<td>";
                html += "<a href='#' class='btn btn-info' data-toggle='modal' data-target='#miModal' onclick='VerDetalle(" + item.Id + ")'>Detalle</a> | ";
                html += "<a href='#' class='btn btn-danger' onclick='Eliminar(" + item.Id + ")'>Eliminar</a>";
                html += "</td>";
                html += "</tr>";
            });

            $("#tomadeasistencias tbody").html(html);
        },
        error: function (error) {
            alert(error.responseText);
        }
    });
}

function VerDetalle(id) {
    $.ajax({
        url: "/TomaDeAsistencia/BuscarPorId?pId=" + id,
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $('#Id').val(data.Id);
            $('#Fecha').val(data.Fecha);
            $('#IdProfesor').val(data.IdProfesor);
            $('#IdAlumno').val(data.IdAlumno);
            $('#IdGrado').val(data.IdGrado);
            $('#IdSeccion').val(data.IdSeccion);
            $('#Asistencia').val(data.Asistencia);
            $('#LlegoTarde').val(data.LlegoTarde);
            $('#JustificacionLlegadaTarde').val(data.JustificacionLlegadaTarde);

            $('#exampleModalLabel').text("Modificar Toma De Asistencia");
            $('#btnGuardar').val("Guardar Cambios");
            AsistenciaActiva();
        },
        error: function (error) {
            alert("Parece que hubo un error al hacer la petición");
            alert(error)
        }
    });
}

function Guardar() {
    if ($('#Fecha').val() == "" ||
        $('#IdProfesor').val() == "" ||
        $('#IdAlumno').val() == "" ||
        $('#IdGrado').val() == "" ||
        $('#IdSeccion').val() == "" ||
        $('#Asistencia').val() == "" ||
        $('#LlegoTarde').val() == "") {
        alert("Todos los campos son requeridos!");
    } else {
        var url = ' ';
        var tomadeasistencia = {
            Id: $('#Id').val(),
            Fecha: $('#Fecha').val(),            
            IdProfesor: $('#IdProfesor').val(),
            IdAlumno: $('#IdAlumno').val(),
            IdGrado: $('#IdGrado').val(),
            IdSeccion: $('#IdSeccion').val(),
            Asistencia: $('#Asistencia').val(),
            LlegoTarde: $('#LlegoTarde').val(),
            JustificacionLlegadaTarde: $('#JustificacionLlegadaTarde').val()
        }

        if (tomadeasistencia.Id) {
            url = '/TomaDeAsistencia/Modificar';
        } else {
            url = '/TomaDeAsistencia/Agregar';
        }

        $.ajax({
            url: url,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(tomadeasistencia),
            success: function (data) {
                if ($('#btnGuardar').val() == "Guardar Cambios") {
                    alert("Se guardaron los cambios");
                } else if ($('#btnGuardar').val() == "Guardar") {
                    alert("Registro guardado con éxito");
                }
                $('#miModal').modal('hide');
                Cargar();
                Limpiar();
            },
            error: function (error) {
                alert("No se pudo guardar el registro");
            }
        });
    }
}

function Limpiar() {
    $('#Id').val("");
    $('#Fecha').val("");
    $('#IdAlumno').val("");
    $('#IdProfesor').val("");
    $('#IdGrado').val("");
    $('#IdSeccion').val("");
    $('#Asistencia').val(""),
    $('#LlegoTarde').val(""),
    $('#JustificacionLlegadaTarde').val("")

    $('#exampleModalLabel').text("Crear Matricula De Alumno");
    $('#btnGuardar').val("Guardar");
}

function AsistenciaActiva() {
    if ($("#Asistencia").val() == "Si") {
        $("#LlegoTarde").val("No");
        document.getElementById("JustificacionLlegadaTarde").disabled = true;

    } else if ($("#Asistencia").val() == "No") {
        $("#LlegoTarde").val("No");
        document.getElementById("JustificacionLlegadaTarde").disabled = true;
    } else if ($("#Asistencia").val() == "Si, con llegada tarde") {
        $("#LlegoTarde").val("Si");
        document.getElementById("JustificacionLlegadaTarde").disabled = false;
    } else {
        $("#LlegoTarde").val("");
    }
}


function Eliminar(id) {
    var resp = confirm("¿Estas seguro que quieres eliminar este registro?");
    if (resp) {
        $.ajax({
            url: "/TomaDeAsistencia/Eliminar?pId=" + id,
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
                html += "<option value='" + item.Id + "'>" + item.Nombres + " " + item.Apellidos + "</option>";
            });
            $('#IdProfesor').append(html);
        },
        error: function (error) {
            alert("Error al mostrar datos");
        }
    });
}

function CargarAlumnos() {
    $.ajax({
        url: "/MatriculaDeAlumno/Obtener",
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var html = "";
            $.each(data, function (key, item) {
                html += "<option value='" + item.Id + "'>" + item.NombresAlumno + " " + item.ApellidosAlumno + "</option>";
            });
            $('#IdAlumno').append(html);
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