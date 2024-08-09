sap.ui.define([
	'sap/ui/test/Opa5',
    'sap/ui/test/matchers/Properties',
    'sap/ui/test/actions/Press'
], function (Opa5, Properties, Press ) {
    "use strict";

    var sNomeDaTela = "genero.DetalhesGenero";
    var sListaId = "listaDeGeneros"
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
                aTelaDetalhesGeneroFoiCarregadaCorretamente: function(){
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
                DeveSairDaTelaDeDetalhes: function(sTitulo){
                    return this.waitFor({
                        controlType: "sap.m.Page",
                        matchers: {
                            PropertyStrictEquals: {
                                name: "tittle",
                                value: sTitulo
                            }
                        },
                        success: () => Opa5.assert.ok(false, "Sucesso ao sair da pagina de detalhes"),
                        errorMessage: "Falha ao ao sair da pagina de detalhes"
                    });
                }
            }
        }
    });
}
);