sap.ui.define([
	'sap/ui/test/Opa5',
    'sap/ui/test/matchers/Properties',
    'sap/ui/test/matchers/AggregationLengthEquals',
    'sap/ui/test/actions/Press',
    'sap/ui/test/matchers/Ancestor'
], function (Opa5, Properties, AggregationLengthEquals, Press,Ancestor ) {
    "use strict";

    var sNomeDaTela = "anime.DetalhesAnime";
    var sListaId = "listaDeGeneros"
    Opa5.createPageObjects({
        onPaginaDetalhesDoAnime : {
            actions: {
                aoClicarEmVoltar: function () {
                    return this.waitFor({
                        id: "pagina",
                        viewName: sNomeDaTela,
                        actions: new Press(),
                        errorMessage: "Não foi possível encontrar o botão de voltar na página do objeto"
                    });
                },
                aoClicarEmEditar: function(){
                    return this.waitFor({
                        id: "btnEditar",
                        viewName: sNomeDaTela,
                        actions: new Press(),
                        errorMessage: "Não foi possível pressionar o botão de editar."
                    })
                },
                aoClicarEmRemover: function(){
                    return this.waitFor({
                        id: "btnRemover",
                        viewName: sNomeDaTela,
                        actions: new Press(),
                        errorMessage: "Não foi possível pressionar o botão de remover."
                    })
                }
            },
            assertions:{
                aTelaDetalhesAnimeFoiCarregadaCorretamente: function(){
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
                },
                deveAperecerUmaMessageBoxDe: function(sTitulo){
					return this.waitFor({
						controlType: "sap.m.Dialog",
						matchers: new Properties({ title: sTitulo}),
						success: function () {
							Opa5.assert.ok("A MessageBox apareceu");
						},
						errorMessage: "A MessageBox não apareceu"
					});
				},
                deveFecharMessageBoxAoApertarEmOk: function(sTextoBotao){
					return this.waitFor({
						controlType: "sap.m.Button",
						matchers: [
							new Properties({ text: sTextoBotao }),
							new Ancestor(Opa5.getContext().dialog, false) 
						],
						actions: new Press(),
						success: function () {
							Opa5.assert.ok(true, "Sucesso ao clicar no botao Ok");
						},
						errorMessage: "Falhar ao clicar no botao Ok"
                    });
				}
            }
        }
    });
}
);