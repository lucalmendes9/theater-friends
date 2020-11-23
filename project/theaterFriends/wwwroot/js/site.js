function apagar(id,controller) {
    if (confirm('Deseja apagar este registro?'))
        location.href = '/'+ controller +'/Delete?id=' + id;
}

