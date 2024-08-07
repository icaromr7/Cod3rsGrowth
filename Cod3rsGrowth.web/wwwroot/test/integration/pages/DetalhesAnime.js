sap.ui.define([
	'sap/ui/test/Opa5',
    'sap/ui/test/matchers/Properties',
    'sap/ui/test/matchers/AggregationLengthEquals',
    'sap/ui/test/actions/Press'
], function (Opa5, Properties, AggregationLengthEquals, Press ) {
    "use strict";

    var sNomeDaTela = "detalhesAnime.DetalhesAnime";
    var sListaId = "listaDeGeneros"
    const sUrlDetalhes = Opa5.getWindow().location.href;
    Opa5.createPageObjects({
        onPaginaDetalhesoAnime : {
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
                deveTerANotaDoItemSelecionado: function(sNota){
                    return this.waitFor({
                        success: function () {
                            return this.waitFor({
                                id: "inputNota",
                                viewName: sNomeDaTela,
                                matchers: new Properties({
                                    value: sNota
                                }),
                                success: function (oPage) {
                                    Opa5.assert.ok(true, "Sucesso ao carregar a nota");
                                },
                                errorMessage: "A nota " + sNota + " não está sendo mostrada"
                            });
                        }
                    });
                },
                deveTerADataLancamentoDoItemSelecionado: function(sDataLancamento){
                    return this.waitFor({
                        success: function () {
                            return this.waitFor({
                                id: "inputDataLancamento",
                                viewName: sNomeDaTela,
                                matchers: new Properties({
                                    value: sDataLancamento
                                }),
                                success: function (oPage) {
                                    Opa5.assert.ok(true, "Sucesso ao carregar a data lançamento");
                                },
                                errorMessage: "A data lançamento " + sDataLancamento + " não está sendo mostrada"
                            });
                        }
                    });
                },
                deveTerOStatusDeExibicaoDoItemSelecionado: function(sStatusExibicao){
                    return this.waitFor({
                        success: function () {
                            return this.waitFor({
                                id: "inputStatusExibicao",
                                viewName: sNomeDaTela,
                                matchers: new Properties({
                                    value: sStatusExibicao
                                }),
                                success: function (oPage) {
                                    Opa5.assert.ok(true, "Sucesso ao carregar o status de exibição");
                                },
                                errorMessage: "O status de exibição " + sStatusExibicao + " não está sendo mostrada"
                            });
                        }
                    });
                },
                deveTerASinopseDoItemSelecionado: function(sSinopse){
                    return this.waitFor({
                        success: function () {
                            return this.waitFor({
                                id: "inputSinopse",
                                viewName: sNomeDaTela,
                                matchers: new Properties({
                                    value: sSinopse
                                }),
                                success: function (oPage) {
                                    Opa5.assert.ok(true, "Sucesso ao carregar o status de exibição");
                                },
                                errorMessage: "A sinopse " + sSinopse + " não está sendo mostrada"
                            });
                        }
                    });
                },
                aListaDeveMostrarTodosOsGenerosDoAnime(sQuantidadeDeGeneros){
                    return this.waitFor({
                        id: sListaId,
                        viewName: sNomeDaTela,
                        matchers: new AggregationLengthEquals({
                            name: "items",
                            length: sQuantidadeDeGeneros
                        }),
                        success: function(){
                            Opa5.assert.ok(true, "A lista contém " + sQuantidadeDeGeneros + " gêneros");
                        },
                        errorMessage: "A lista não contém todos os gêneros"
                    })
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