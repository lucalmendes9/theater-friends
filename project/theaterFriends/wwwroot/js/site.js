function apagar(id,controller) {
    if (confirm('Deseja apagar este registro?'))
        location.href = '/'+ controller +'/Delete?id=' + id;
}

function exibirImagem() {
    var oFReader = new FileReader();
    oFReader.readAsDataURL(document.getElementById("Imagem").files[0]);
    oFReader.onload = function (oFREvent) {
        document.getElementById("imgPreview").src = oFREvent.target.result;
    };
}