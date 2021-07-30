function msgbox(ti, msg, tipo) {
    Swal.fire({
        title: ti,
        text: msg,
        icon: tipo,
        confirmButtonText: 'Aceptar'
    })
}