$(function () {
    Cargar();
    CargarProfesor();
    CargarSeccion();
    CargarHorarios();
    CargarAulas();
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

            $("#profesores tbody").html(html);
        },
        error: function (error) {
            alert(error.responseText);
        }
    });
}

function CargarProfesor() {
    $.ajax({
        url: "/Profesor/Obtener",
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var html = "";
            $.each(data, function (key, item) {
                html += "<option value='" + item.Id + "'>" + item.Nombres + "<option>";
            });
            $('#IdProfesor').append(html)
        },
        error: function (error) {
            alert(error.responseText);
        }
    });
}

function CargarSeccion() {
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
            alert(error.responseText);
        }
    });
}

function CargarHorarios() {
    $.ajax({
        url: "/Horarios/Obtener",
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
            alert(error.responseText);
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
            $('#btnAgregar').val("Agregar");
        },
        error: function (error) {
            alert("Ocurrió un error al momento de procesar la petición");
            alert(error);
        }
    })
}

function Guardar() {
    if (!($('#NumeroDeAula').val() == "")) {
        var url = '';
        var Aula = {
            Id: $('#Id').val(),
            GradoAsignado: $('#GradoAsignado').val(),
            IdProfesor: $('#IdProfesor').val(),
            IdSeccion: $('#IdSeccion').val(),
            IdHorario: $('#IdHorario').val(),
            IdAula: $('#IdAula').val()
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
                alert("Registro guardado con éxito");
                $('#miModal').modal('hide');
                Cargar();
                limpiar();
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

function limpiar() {
    $('#Id').val("");
    $('#NumeroDeAula').val("");
    $('btnAgregar').val("Guardar");
}