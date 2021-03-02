$(function () {
    Cargar();    
});

$('#frmProfesores').submit(function (event) {
    event.preventDefault();
    Guardar();
});

function Cargar() {
    $.ajax({
        url: "/Profesor/Obtener",
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var html = '';
            $.each(data, function (key, item) {
                html += "<tr>";
                html += "<td>" + item.Id + "</td>";
                html += "<td>" + item.DUI + "</td>";
                html += "<td>" + item.Nombres + "</td>";
                html += "<td>" + item.Apellidos + "</td>";
                html += "<td>" + item.Edad + "</td>";
                html += "<td>" + item.Sexo + "</td>";
                html += "<td>" + item.Direccion + "</td>";
                html += "<td>" + item.Telefono + "</td>";
                html += "<td>" + item.Correo + "</td>";
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

function VerDetalle(id) {
    $.ajax({
        url: "/Profesor/BuscarPorId?pId="+id,
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {            
            $('#Id').val(data.Id);
            $('#DUI').val(data.DUI);
            $('#Nombres').val(data.Nombres);
            $('#Apellidos').val(data.Apellidos);            
            $('#Edad').val(data.Edad);            
            $('#Sexo').val(data.Sexo);            
            $('#Direccion').val(data.Direccion);            
            $('#Telefono').val(data.Telefono);            
            $('#Correo').val(data.Correo);     
            
            $('#exampleModalLabel').text("Modificar Profesor");
            $('#btnGuardar').val("Guardar Cambios");            
        },
        error: function (error) {
            alert("Parece que hubo un error al hacer la petición");
            alert(error)
        }
    });
}


function Guardar() {
    if ($('#DUI').val() == "" ||
    $('#Nombres').val() == "" ||
    $('#Apellidos').val() == "" ||
    $('#Edad').val() == "" ||
    $('#Sexo').val() == "" ||
    $('#Direccion').val() == "" ||
    $('#Telefono').val() == "" ||
    $('#Correo').val() == "") {
        alert("Todos los campos son requeridos!");
    } else {        
        var url = ' ';
        var profesor = {
            Id: $('#Id').val(),
            DUI: $('#DUI').val(),
            Nombres: $('#Nombres').val(),
            Apellidos: $('#Apellidos').val(),
            Edad: $('#Edad').val(),
            Sexo: $('#Sexo').val(),
            Direccion: $('#Direccion').val(),
            Telefono: $('#Telefono').val(),
            Correo: $('#Correo').val()
        }

        if (profesor.Id) {
            url = '/Profesor/Modificar';
        } else {
            url = '/Profesor/Agregar';
        }

        $.ajax({
            url: url,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(profesor),
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
    $('#DUI').val("");
    $('#Nombres').val("");
    $('#Apellidos').val("");
    $('#Edad').val("");
    $('#Sexo').val("");
    $('#Direccion').val("");
    $('#Telefono').val("");
    $('#Correo').val("");
    $('#exampleModalLabel').text("Crear Profesor");
    $('#btnGuardar').val("Guardar");
}

function Eliminar(id) {
    var resp = confirm("¿Estas seguro que quieres eliminar este registro?");
    if (resp) {
        $.ajax({
            url: "/Profesor/Eliminar?pId="+id,
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


