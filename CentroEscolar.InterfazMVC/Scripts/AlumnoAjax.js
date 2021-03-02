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
                html += "<td>" + item.NombresAlumno + "</td>";
                html += "<td>" + item.ApellidosAlumno + "</td>";
                html += "<td>" + item.Edad + "</td>";
                html += "<td>" + item.Sexo + "</td>";
                html += "<td>" + item.Direccion + "</td>";
                html += "<td>" + item.Telefono + "</td>";
                html += "<td>" + item.Correo + "</td>";
                html += "<td>";
                html += "<button type='button' class='btn btn-secondary disabled'>Editar</button>";
                html += "<button type='button' class='btn btn-secondary disabled'>Eliminar</button>";
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

