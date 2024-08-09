sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/core/routing/History",
    "sap/m/MessageBox",
    "sap/ui/model/json/JSONModel"
], function (Controller, History, MessageBox, JSONModel) {
    "use strict";

    const ROTA_PARA_LISTA = "lista";
    const POSICAO_INICIAL_DA_LISTA = 0;
    const FALHA_NA_REQUISIÇÃO = "Ocorreu um ou mais erros na requisição";
    var sResponsivePaddingClasses = "sapUiResponsivePadding--header sapUiResponsivePadding--content sapUiResponsivePadding--footer";

    return Controller.extend("ui5.codersgrowth.app.common.ControleBase", {

        _exibirEspera: async function (funcao) {
            let aPagina = this.getView();
            aPagina.setBusy(true);
            return Promise.resolve(funcao()).catch(erro => {
                if (erro.body && erro.body.getReader) {
                    const reader = erro.body.getReader();
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
                            enqueueValues();
                        }
                    })
                    return new Response(a).json().then((erro) => {
                        let detalhesDoErro = '';
                        let mensagemErro = ``;
                        if (erro.errors) {
                            let arrayErrors = Object.keys(erro.errors);
                            arrayErrors = arrayErrors.map(x => erro.errors[x]);
                            detalhesDoErro = `<p><strong>Erros:</strong></p>
                            <ul>`;
                            for (var i = POSICAO_INICIAL_DA_LISTA; i < arrayErrors.length; i++) {
                                for (var j = POSICAO_INICIAL_DA_LISTA; j < arrayErrors[i].length; j++)
                                    detalhesDoErro += "<li>" + arrayErrors[i][j] + "</li>" + '\n';
                            };
                            detalhesDoErro+="</ul>"
                            mensagemErro = `
                            ${erro.title}
                            `;
                        } else {
                            mensagemErro = `${erro.Title}`
                            detalhesDoErro = `<p><strong>System Exception:</strong></p>
                            <ul>
                            ${erro.Detail}
                            </ul>`;
                        }
                        MessageBox.error(`${mensagemErro}`, {
                            title: "Erro",
                            id: "messageBox",
                            details: detalhesDoErro,
                            contentWidth: "auto",
                            styleClass: sResponsivePaddingClasses,
                            dependentOn: this.getView()
                        });
                    })
                }
                else {
                    return MessageBox.error(FALHA_NA_REQUISIÇÃO + erro.message, {
                        details: erro.stack,
                        contentWidth: "25%",
                    });
                }
            })
                .finally(() => {
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

                
                this._getRota().navTo(ROTA_PARA_LISTA, {}, true);
                
            })

        },
        _modelo: function (oData, oNomeModelo) {
            const oModel = new JSONModel(oData);
            this.getView().setModel(oModel, oNomeModelo);
        },

    });

}
);