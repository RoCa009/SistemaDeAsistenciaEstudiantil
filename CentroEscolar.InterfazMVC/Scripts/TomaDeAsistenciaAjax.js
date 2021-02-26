$(function () {
    Cargar();
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