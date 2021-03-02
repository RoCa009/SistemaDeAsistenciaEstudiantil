﻿$(function () {
    Cargar();    
});

$('#frmHorarios').submit(function (event) {
    event.preventDefault();
    Guardar();
});


function Cargar() {
    $.ajax({
        url: "/Horario/Obtener",
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var html = '';
            $.each(data, function (key, item) {
                html += "<tr>";
                html += "<td>" + item.Id + "</td>";
                html += "<td>" + item.HorarioDeClase + "</td>";
                html += "<td>" + item.HoraEntrada + "</td>";
                html += "<td>" + item.HoraSalida + "</td>";
                html += "<td>";
                html += "<a href='#' class='btn btn-info' data-toggle='modal' data-target='#miModal' onclick='VerDetalle(" + item.Id + ")'>Detalle</a> | ";
                html += "<a href='#' class='btn btn-danger' onclick='Eliminar(" + item.Id + ")'>Eliminar</a>";
                html += "</td>";
                html += "</tr>";
            });

            $("#horarios tbody").html(html);            
        },
        error: function (error) {
            alert(error.responseText);
        }
    });
}


function VerDetalle(id) {
    $.ajax({
        url: "/Horario/BuscarPorId?pId="+id,
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {            
            $('#Id').val(data.Id);
            $('#HorarioDeClase').val(data.HorarioDeClase);
            $('#HoraEntrada').val(data.HoraEntrada);
            $('#HoraSalida').val(data.HoraSalida);            
            $('#exampleModalLabel').text("Modificar Horario");
            $('#btnGuardar').val("Guardar Cambios");            
        },
        error: function (error) {
            alert("Parece que hubo un error al hacer la petición");
            alert(error)
        }
    });
}


function Guardar() {
    if ($('#HorarioDeClase').val() == "" || $('#HoraEntrada').val() == "" || $('#HoraSalida').val() == "") {
        alert("Todos los campos son requeridos!");
    } else {        
        var url = ' ';
        var horario = {
            Id: $('#Id').val(),
            HorarioDeClase: $('#HorarioDeClase').val(),
            HoraEntrada: $('#HoraEntrada').val(),
            HoraSalida: $('#HoraSalida').val(),
        }

        if (horario.Id) {
            url = '/Horario/Modificar';
        } else {
            url = '/Horario/Agregar';
        }

        $.ajax({
            url: url,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify(horario),
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
    $('#HorarioDeClase').val("");
    $('#HoraEntrada').val("");
    $('#HoraSalida').val("");
    $('#exampleModalLabel').text("Crear Horario");
    $('#btnGuardar').val("Guardar");
}

function Eliminar(id) {
    var resp = confirm("¿Estas seguro que quieres eliminar este registro?");
    if (resp) {
        $.ajax({
            url: "/Horario/Eliminar?pId="+id,
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