$(function () {    
    Cargar();
    CargarProfesores();
    CargarSecciones();
    CargarHorarios();
    CargarAulas();
});

$('#frmGrados').submit(function (event) {
    event.preventDefault();
    Guardar();
});

function Cargar() {
    $.ajax({
        url: "/Grado/Obtener",
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var html = '';
            $.each(data, function (key, item) {
                html += "<tr>";
                html += "<td>" + item.Id + "</td>";
                html += "<td>" + item.GradoAsignado + "</td>";
                html += "<td>" + item.IdProfesor + "</td>";
                html += "<td>" + item.IdSeccion + "</td>";
                html += "<td>" + item.IdHorario + "</td>";
                html += "<td>" + item.IdAula + "</td>";
                html += "<td>";
                html += "<a href='#' class='btn btn-info' data-toggle='modal' data-target='#miModal' onclick='VerDetalle(" + item.Id + ")'>Detalle</a> | ";
                html += "<a href='#' class='btn btn-danger' onclick='Eliminar(" + item.Id + ")'>Eliminar</a>";
                html += "</td>";
                html += "</tr>";
            });

            $("#grados tbody").html(html);
        },
        error: function (error) {
            alert(error.responseText);
        }
    });
}

function VerDetalle(Id) {
    $.ajax({
        url: "/Grado/BuscarPorId?pId=" + Id,
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $('#Id').val(data.Id);
            $('#GradoAsignado').val(data.GradoAsignado);
            $('#IdProfesor').val(data.IdProfesor);
            $('#IdSeccion').val(data.IdSeccion);
            $('#IdHorario').val(data.IdHorario);
            $('#IdAula').val(data.IdAula);

            $('#exampleModalLabel').text("Modificar Grado");
            $('#btnGuardar').val("Guardar Cambios");        
        },
        error: function (error) {
            alert("Ocurrió un error al momento de procesar la petición");
            alert(error);
        }
    })
}

function Guardar() {
    if (!($('#GradoAsignado').val() == "" || $('#IdProfesor').val() == "" || $('#IdSeccion').val == "-1" || $('IdHorario').val == "-1"
        || $('IdAula').val == "-1")) {
        var url = '';
        var Aula = {
            Id: $('#Id').val(),
            GradoAsignado: $('#GradoAsignado').val(),
            IdProfesor: $('#IdProfesor').val(),
            IdSeccion: $('#IdSeccion').val(),
            IdHorario: $('#IdHorario').val(),
            IdAula: $('#IdAula').val(),
        }

        if (Aula.Id) {
            url = '/Grado/Modificar';
        } else {
            url = '/Grado/Agregar';
        }

        $.ajax({
            url: url,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(Aula),
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
                alert("Hubo un error en el proceso de registrar");
            }
        });
    }

    else {
        alert("Todos los campos son requeridos");
    }
}

function Limpiar() {
    $('#Id').val("");
    $('#GradoAsignado').val("");
    $('#IdProfesor').val("");
    $('#IdSeccion').val("");
    $('#IdHorario').val("");
    $('#IdAula').val("");

    $('#exampleModalLabel').text("Crear Grado");
    $('#btnGuardar').val("Guardar");
}

function Eliminar(Id) {
    var resp = confirm("¿Desea eliminar este registro? Una vez hecho no se podrá revertir el cambio");
    if (resp) {
        $.ajax({
            url: "/Grado/Eliminar?pId=" + Id,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                alert("Registro Eliminado de forma exitosa");
                Cargar();
            },
            error: function (error) {
                alert("Ocurrió un error al eliminar el registro");
            }
        });
    }
}


// Select's de Combobox

function CargarProfesores() {
    $.ajax({
        url: "/Profesor/Obtener",
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var html = "";
            $.each(data, function (key, item) {
                html += "<option value='" + item.Id + "'>" + item.Nombres + " " + item.Apellidos + "<option>";
            });
            $('#IdProfesor').append(html);
        },
        error: function (error) {
            alert("Error");
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
                html += "<option value='" + item.Id + "'>" + item.SeccionAsignada + "<option>";                
            });
            $('#IdSeccion').append(html)
        },
        error: function (error) {
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
                html += "<option value='" + item.Id + "'>" + item.HorarioDeClase + "<option>";
            });
            $('#IdHorario').append(html)
        },
        error: function (error) {
            alert(error);
        }
    });
}

function CargarAulas() {
    $.ajax({
        url: "/Aula/Obtener",
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var html = "";
            $.each(data, function (key, item) {
                html += "<option value='" + item.Id + "'>" + item.NumeroDeAula + "<option>";
            });
            $('#IdAula').append(html)
        },
        error: function (error) {
            alert(error);
        }
    });
}