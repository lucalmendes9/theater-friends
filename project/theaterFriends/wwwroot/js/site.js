﻿function apagar(id, controller) {
    swal({
        title: "Você realmente deseja Excluir?",
        text: "Esse registro sera apagado do sistema!",
        type: "warning",
        showCancelButton: true,
        confirmButtonClass: "btn-danger",
        confirmButtonText: "Sim",
        cancelButtonText: "Não",
        closeOnConfirm: false
    },
        function () {
            location.href = '/' + controller + '/Delete?id=' + id;
        });
}

