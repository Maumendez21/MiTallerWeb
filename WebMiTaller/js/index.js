function msgbox(ti, msg, tipo, url) {
    Swal.fire({
        title: ti,
        text: msg,
        icon: tipo,
        confirmButtonText: 'Aceptar'
    }).then(function(){
        //Redirigir a la ruta del parametro url
        window.location.href = url;
});
}