

/* $(function () {
    Cargar();
});
*/

function Cargar() {
    $.ajax({
        url: "/Administrador/Obtener",
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var html = '';
            $.each(data, function (key, item) {
                html += "<tr>";
                html += "<td>" + item.Id + "</td>";
                html += "<td>" + item.Nombre + "</td>";
                html += "<td>" + item.Correo + "</td>";
                html += "<td>" + item.Contrasena + "</td>";
                html += "<td>";
                html += "<a href='#' class='btn btn-info' data-toggle='modal' data-target='#miModal' onclick='VerDetalle(" + item.Id + ")'>Detalle</a> | ";
                html += "<a href='#' class='btn btn-danger' onclick='Eliminar(" + item.Id + ")'>Eliminar</a>";
                html += "</td>";
                html += "</tr>";
            });

            $("#administradores tbody").html(html);
        },
        error: function (error) {
            alert(error.responseText);
        }
    });
}