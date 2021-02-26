$(function () {
    Cargar();
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
                html += "<td>" + item.DuiEncargado + "</td>";
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