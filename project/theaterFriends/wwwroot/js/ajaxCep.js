
$(document).ready(function () {

    $('input[name=Number]').mask('0#####');
    $('input[name=State]').mask('AA');
    $('input[name=Cep]').mask('00000-000');
    $('input[name=Phone]').mask('(00) 0000-0000#');

    const clear_form_cep = () => {
        $('input[name=Address]').value = ("");
        $('input[name=Neighbourhood]').value = ("");
        $('input[name=City]').value = ("");
        $('input[name=State]').value = ("");
    }

    const search_cep = (value) => {
        var cep = value.replace(/\D/g, '');
        let msg = localStorage.getItem('lang') && localStorage.getItem('lang') == 'BR'
            ? 'CEP não encontrado.' : 'Zip Code not found';

        if (cep != "") {
            var rgxCep = /^[0-9]{8}$/;

            if (rgxCep.test(cep)) {
                $('input[name=Address]').val("...");
                $('input[name=Neighbourhood]').val("...");
                $('input[name=City]').val("...");
                $('input[name=State]').val("...");

                var script = document.createElement('script');
                script.src = 'https://viacep.com.br/ws/' + cep + '/json/?callback=write_content';
                document.body.appendChild(script);
            }
            else {
                clear_form_cep();
                alert(msg);
            }
        }
        else {
            clear_form_cep();
            alert(msg);
        }
    };

    $('#search-cep').on('click', function (e) {
        e.preventDefault();
        search_cep($('input[name=Cep]').val());
    })

    $('a.submit-form').on('click', function (e) {
        e.preventDefault();

        $.ajax({
            url: "/Localization/SalvarAjax",
            type: 'post',
            data: {
                Address: $('input[name=Address]').val(),
                Neighbourhood: $('input[name=Neighbourhood]').val(),
                City: $('input[name=City]').val(),
                State: $('input[name=State]').val(),
                Number: $('input[name=Number]').val(),
                Phone: $('input[name=Phone]').val(),
                Operacao: "I",
            },
        })
        .done(function (msg) {
            if (msg == "error") {
                alert("Erro ao cadastrar endereço.");
            } else {
                $('input#Localization_id').val(msg);
                $('form').submit();
            }
            console.log('msgg done', msg);
        })
        .fail(function (jqXHR, textStatus, msg) {
            alert("Erro ao cadastrar endereço.")
            console.log('msgg err', msg);
        });
    })

})
