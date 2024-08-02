sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/core/routing/History",
    "sap/m/MessageBox",
    "sap/ui/model/json/JSONModel"
], function (Controller, History,MessageBox, JSONModel) {
    "use strict";

    const MESSAGEM_DE_ERRO = "Ocorreu um erro: ";
    const ROTA_PARA_LISTA = "lista";
    const POSICAO_INICIAL_DA_LISTA = 0;
    const FALHA_NA_REQUISIÇÃO = "Ocorreu um ou mais erros na requisição";

    return Controller.extend("ui5.codersgrowth.app.common.ControleBase", {

        _exibirEspera: function (funcao) {
            let aPagina = this.getView();
            aPagina.setBusy(true);

            return Promise.resolve(funcao()).catch(x => {
                const reader = x.body.getReader()
                let a = new ReadableStream({
                    start(controller) {
                        function enqueueValues() {
                            reader.read()
                            .then(({ done, value }) => {
                                if (done) {
                                    controller.close()
                                    return
                                }
                                controller.enqueue(value)
                                enqueueValues();
                            })
                        }
                        enqueueValues()
                    }})
                    return new Response(a).json().then((erro)=>{
                        let detalhesDoErro = erro.errors;
                        let arrayErrors = Object.keys(detalhesDoErro);
                        arrayErrors = arrayErrors.map(x => detalhesDoErro[x]);
                        detalhesDoErro = '\n';
                        for (var i = POSICAO_INICIAL_DA_LISTA; i < arrayErrors.length; i++) {
                            for (var j = POSICAO_INICIAL_DA_LISTA; j < arrayErrors[i].length; j++)
                                detalhesDoErro += arrayErrors[i][j] + '\n';
                        };
                        const mensagemErro = `
                            Título: ${erro.title}
                            Status: ${erro.status}
                            Detalhes: ${erro.detail}
                            Erros: ${detalhesDoErro}
                        `;

                        MessageBox.error(`${FALHA_NA_REQUISIÇÃO}\n${mensagemErro}`);
                    })
            })
            .finally(()=>{
                aPagina.setBusy(false);
            });
        },

        _getRota: function () {
            return this.getOwnerComponent().getRouter();
        },

        aoClicarEmVoltar: function () {
            this._exibirEspera(async () => {
                var oHistory, sPreviousHash;

                oHistory = History.getInstance();
                sPreviousHash = oHistory.getPreviousHash();

                if (sPreviousHash !== undefined) {
                    window.history.go(-1);
                } else {
                    this._getRota().navTo(ROTA_PARA_LISTA, {}, true);
                }
			})
            
        },
        _modeloLista: async function (oData, oNomeModelo) {
            const oModel = new JSONModel(oData);
            this.getView().setModel(oModel, oNomeModelo);
        },
        
    });

}
);