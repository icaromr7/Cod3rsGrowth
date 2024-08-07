sap.ui.define([
	'sap/ui/test/Opa5',
    'sap/ui/test/matchers/Properties',
    'sap/ui/test/actions/Press'
], function (Opa5, Properties, Press ) {
    "use strict";

    var sNomeDaTela = "detalhesGenero.DetalhesGenero";
    var sListaId = "listaDeGeneros"
    const sUrlDetalhes = Opa5.getWindow().location.href;
    Opa5.createPageObjects({
        onPaginaDetalhesGenero : {
            actions: {
                aoClicarEmVoltar: function () {
                    return this.waitFor({
                        id: "pagina",
                        viewName: sNomeDaTela,
                        actions: new Press(),
                        errorMessage: "Não foi possível encontrar o botão de voltar na página do objeto"
                    });
                }
            },
            assertions:{
                deveNavegarParaTelaDeDetalhes: function(){
                    return this.waitFor({
                        viewName: sNomeDaTela,
                        success: function () {
                            Opa5.assert.ok(true, "Sucesso ao navegar para tela de detalhes");
                        },
                        errorMessage: "Falha ao navegar a pagina de detalhes"
                    });
                },
                deveTerOIdDoItemSelecionado: function(sId){
                    return this.waitFor({
                        success: function () {
                            return this.waitFor({
                                id: "inputId",
                                viewName: sNomeDaTela,
                                matchers: new Properties({
                                    value: sId
                                }),
                                success: function (oPage) {
                                    Opa5.assert.ok(true, "Sucesso ao carregar o id");
                                },
                                errorMessage: "O id " + sId + " não está sendo mostrado"
                            });
                        }
                    });
                },

                deveTerONomeDoItemSelecionado: function(sNome){
                    return this.waitFor({
                        success: function () {
                            return this.waitFor({
                                id: "inputNome",
                                viewName: sNomeDaTela,
                                matchers: new Properties({
                                    value: sNome
                                }),
                                success: function (oPage) {
                                    Opa5.assert.ok(true, "Sucesso ao carregar o nome");
                                },
                                errorMessage: "O nome " + sNome + " não está sendo mostrado"
                            });
                        }
                    });
                },
                deveVoltarParaTelaAnterior: function(){
                    const sUrlAtual = Opa5.getWindow().location.href;
                    return this.waitFor({
                        success: function() {
                            if (sUrlDetalhes !== sUrlAtual) {
                                Opa5.assert.ok(true, "Falha ao navegar para página anterior.");
                            }
                        },
                        errorMessage: "Falha ao navegar para página anterior."
                    });
                }
            }
        }
    });
}
);