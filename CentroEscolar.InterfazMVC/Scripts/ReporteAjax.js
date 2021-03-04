$(function () {    
    
    CargarAlumnos();
});

function ActivarReporteAlumno(id) {
    if ($("#IdAlumno").val() == 1) {
        CargarDatosAlumno(id);
        CargarFechasAlumno();
    } else {
        if (id == 0) {
            LimpiarDatosAlumno();
            LimpiarFechasAlumno();
        } else {
            CargarDatosAlumno(id);
            LimpiarFechasAlumno();
        }
    }
}


function CargarDatosAlumno(id) {    
    $.ajax({
        url: "/MatriculaDeAlumno/BuscarPorId?pId="+id,
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {

            $('#NombresApellidos').text(data.NombresAlumno + " " + data.ApellidosAlumno);
            $('#Edad').text(data.Edad);
            $('#Sexo').text(data.Sexo);
            $('#Direccion').text(data.Direccion);
            $('#Telefono').text(data.Telefono);
            $('#Correo').text(data.Correo);
        },
        error: function (error) {
            alert("Parece que hubo un error al hacer la petición");
            alert(error)
        }
    });

}

function CargarFechasAlumno() {
    var id = 1;
    $.ajax({
        url: "/TomaDeAsistencia/Obtener",
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {                 
            var html = "";
            $.each(data, function (key, item) {
                html += "<tr>";                                            
                html += "<td>" + item.Fecha + "</td>"; 
                html += "<td style='color: #0094B3'>" + item.Asistencia + "</td>"; 
                html += "<td>" + item.LlegoTarde + "</td>";
                html += "<td>" + item.JustificacionLlegadaTarde + "</td>"; 
                html += "</tr>";
            });
            $("#fechasalumno tbody").html(html);
        },
        error: function (error) {
            alert("Parece que hubo un error al hacer la petición LOL");
            alert(error)
        }
    });

}







function LimpiarFechasAlumno() {
    $("#fechasalumno tbody").html("");
}
function LimpiarDatosAlumno() {
    $('#NombresApellidos').text("");
    $('#Edad').text("");
    $('#Sexo').text("");
    $('#Direccion').text("");
    $('#Telefono').text("");
    $('#Correo').text("");
}

// Traer Listados de Select's


function CargarAlumnos() {
    $.ajax({
        url: "/MatriculaDeAlumno/Obtener",
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var html = "";
            $.each(data, function (key, item) {
                html += "<option value='" + item.Id + "'>" + item.NombresAlumno + " " + item.ApellidosAlumno + "</option>";
            });
            $('#IdAlumno').append(html);
        },
        error: function (error) {
            alert("Error al mostrar datos");
        }
    });

}

