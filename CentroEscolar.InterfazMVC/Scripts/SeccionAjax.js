$(function () {
    Cargar();
});

$('#frmSeccion').submit(function (event) {
    event.preventDefault();
    Guardar();
});

function Cargar() {
    $.ajax({
        url: "/Seccion/Obtener",
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var html = '';
            $.each(data, function (key, item) {
                html += "<tr>";
                html += "<td>" + item.Id + "</td>";
                html += "<td>" + item.SeccionAsignada + "</td>";
                html += "<td>";
                html += "<a href='#' class='btn btn-info' data-toggle='modal' data-target='#miModal' onclick='VerDetalle(" + item.Id + ")'>Detalle</a> | ";
                html += "<a href='#' class='btn btn-danger' onclick='Eliminar(" + item.Id + ")'>Eliminar</a>";
                html += "</td>";
                html += "</tr>";
            });

            $("#seccion tbody").html(html);
        },
        error: function (error) {
            alert(error.responseText);
        }
    });
}

function VerDetalle(Id) {
    $.ajax({
        url: "/Seccion/BuscarPorId?pId=" + Id,
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $('#Id').val(data.Id);
            $('#SeccionAsignada').val(data.SeccionAsignada);

            $('#exampleModalLabel').text("Modificar Sección");
            $('#btnGuardar').val("Guardar Cambios");          
        },
        error: function (error) {
            alert("Ocurrió un error al momento de procesar la petición");
            alert(error);
        }
    })
}


function Guardar() {
    if (!($('#SeccionAsignada').val() == "")) {
        var url = '';
        var Seccion = {
            Id: $('#Id').val(),
            SeccionAsignada: $('#SeccionAsignada').val()
        }

        if (Seccion.Id) {
            url = '/Seccion/Modificar';
        } else {
            url = '/Seccion/Agregar';
        }

        $.ajax({
            url: url,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(Seccion),
            success: function (data) {
                if ($('#btnGuardar').val() == "Guardar Cambios") {
                    alert("Se guardaron los cambios");
                } else if ($('#btnGuardar').val() == "Guardar") {
                    alert("Registro guardado con éxito");
                }                    
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

function Limpiar() {
    $('#Id').val("");
    $('#SeccionAsignada').val("");

    $('#exampleModalLabel').text("Crear Sección");
    $('#btnGuardar').val("Guardar");
}

function Eliminar(Id) {
    var resp = confirm("¿Desea eliminar este registro? Una vez hecho no se podrá revertir el cambio");
    if (resp) {
        $.ajax({
            url: "/Seccion/Eliminar?pId=" + Id,
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