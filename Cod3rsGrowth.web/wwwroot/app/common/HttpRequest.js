sap.ui.define([
    'sap/m/MessageBox'
], function (MessageBox) {
	"use strict";
    return{
        _request : async function(url, method = 'GET', data = null){
            const options = {
                method,
                headers: {
                    'Content-Type': 'application/json'
                }
            }
            if(data){
                options.body = JSON.stringify(data);
            }
            return  fetch(url, options)               
                .then(response => {
                    if (!response.ok) {
                        return Promise.reject(response);
                    };
                    return response;
                })
                .then(response=> {
                    return response.json().catch(() => response.headers.get('Content-Type'));
                })
        },

        _falhaNaRequicao: function (data) {
			let detalhesDoErro = data.errors;
			let arrayErrors = Object.keys(detalhesDoErro);
			arrayErrors = arrayErrors.map(x => detalhesDoErro[x]);
			detalhesDoErro = '\n';
			for (var i = POSICAO_INICIAL_DA_LISTA; i < arrayErrors.length; i++) {
				for (var j = POSICAO_INICIAL_DA_LISTA; j < arrayErrors[i].length; j++)
					detalhesDoErro += arrayErrors[i][j] + '\n';
			};
			const mensagemErro = `
				Título: ${data.title}
				Status: ${data.status}
				Detalhes: ${data.detail}
				Erros: ${detalhesDoErro}
			`;

			MessageBox.error(`${FALHA_NA_REQUISIÇÃO}\n${mensagemErro}`);
		}
    }
});