

$(function () {
    Cargar();
});

$('#frmAula').submit(function (event) {
    event.preventDefault();
    Guardar();
});

function Cargar() {
    $.ajax({
        url: "/Aula/Obtener",
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var html = '';
            $.each(data, function (key, item) {
                html += "<tr>";
                html += "<td>" + item.Id + "</td>";
                html += "<td>" + item.NumeroDeAula + "</td>";
                html += "<td>";
                html += "<a href='#' class='btn btn-info' data-toggle='modal' data-target='#miModal' onclick='VerDetalle(" + item.Id + ")'>Detalle</a> | ";
                html += "<a href='#' class='btn btn-danger' onclick='Eliminar(" + item.Id + ")'>Eliminar</a>";
                html += "</td>";
                html += "</tr>";
            });

            $("#aula tbody").html(html);
        },
        error: function (error) {
            alert(error.responseText);
        }
    });
}


function VerDetalle(Id) {
    $.ajax({
        url: "/Aula/BuscarPorId?pId=" + Id,
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $('#Id').val(data.Id);
            $('#NumeroDeAula').val(data.NumeroDeAula);
            $('btnAgregar').val("Agregar");
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
            NumeroDeAula: $('#NumeroDeAula').val()
        }

        if (Aula.Id) {
            url = '/Aula/Modificar';
        } else {
            url = '/Aula/Agregar';
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

function Eliminar(Id) {
    var resp = confirm("¿Desea eliminar este registro? Una vez hecho no se podrá revertir el cambio");
    if (resp) {
        $.ajax({
            url: "/Aula/Eliminar?pId=" + Id,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                alert("Registro Elimnado de forma exitosa");
                Cargar();
            },
            error: function (error) {
                alert("Ocurrió un error al eliminar el registro");
            }
        });
    }
}