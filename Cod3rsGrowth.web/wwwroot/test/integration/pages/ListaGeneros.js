sap.ui.define([
	'sap/ui/test/Opa5',
	'sap/ui/test/matchers/Properties',
	'sap/ui/test/actions/Press',
    'sap/ui/test/actions/EnterText',
    'sap/ui/test/matchers/AggregationLengthEquals',
    'sap/ui/test/matchers/Ancestor',
    'sap/ui/test/matchers/PropertyStrictEquals'
], function (Opa5, Properties, Press, EnterText, AggregationLengthEquals,Ancestor,PropertyStrictEquals) {
	"use strict";
    
		var sNomeDaTela = "listaGeneros.ListaGeneros";
        var sNomeDaTelaDetalhe = "detalhesGenero.DetalhesGenero";
        var sListaId = "listaDeGeneros"
        
        const sUrlLista = Opa5.getWindow().location.href;
        Opa5.createPageObjects({
                onPaginaListaGeneros: {
                    actions:{
                        aoClicarEmVoltar: function () {
                            return this.waitFor({
                                id: "pagina",
                                viewName: sNomeDaTela,
                                actions: new Press(),
                                errorMessage: "Não foi possível encontrar o botão de voltar na página do objeto"
                            });
                        },
                        aoApertarEmMais(){
                            return this.waitFor({
                                id: sListaId,
                                viewName: sNomeDaTela,
                                actions: new Press(),
                                errorMessage: "Lista não tem o botão mais."
                            })
                        },
                        aoPesquisarPorNome : function (sTextoPesquisado){
                            return this.waitFor({
                                id: "CampoDeBusca",
                                viewName: sNomeDaTela,
                                actions: new EnterText({
                                    text: sTextoPesquisado
                                }),
                                errorMessage: "CampoDeBusca não foi encontrado."
                            });
                        },
                        
                        aoApertarEmAdicionarGênero: function(){
                            return this.waitFor({
                                id: "btnAdicionar",
                                viewName: sNomeDaTela,
                                actions: new Press(),
                                errorMessage: "Não foi possível pressionar o botão de adicionar."
                            });
                        },                      
                        aoClicarEmUmGenero: function(sNome){
                            return this.waitFor({
                                controlType: "sap.m.Label",
                                viewName: sNomeDaTela,
                                matchers:  new Properties({
                                    text: sNome
                                }),
                                actions: new Press(),
                                errorMessage: "A lista não contém o gênero " + sNome
                            });
                        }
                    },
                    assertions:{
                        deveNavegarParaTelaDeDetalhesDeGeneros: function(){
                            return this.waitFor({
                                viewName: sNomeDaTelaDetalhe,
                                success: function () {
                                    Opa5.assert.ok(true, "Sucesso ao navegar para tela de lista de gêneros");
                                },
                                errorMessage: "Falha ao navegar a pagina de lista de gêneros"
                            });
                        },
                        aListaTemUmGenero :  function(){
                            return this.waitFor({
                                id: sListaId,
                                viewName: sNomeDaTela,
                                matchers: new AggregationLengthEquals({
                                    name: "items",
                                    length: 1
                                }),
                                success: function () {
                                    Opa5.assert.ok(true, "A lista contém uma entrada correspondente");
                                },
                                errorMessage: "A lista não contém um anime."
                            });
                        },
                        aListaTemDoisAnimes: function(){
                            return this.waitFor({
                                id: sListaId,
                                viewName: sNomeDaTela,
                                matchers: new AggregationLengthEquals({
                                    name: "items",
                                    length: 2
                                }),
                                success: function () {
                                    Opa5.assert.ok(true, "A lista contém uma entrada correspondente");
                                },
                                errorMessage: "A lista não contém dois gêneros."
                            });
                        },
                        aListaDeveMostrarMaisGeneros(){
                            return this.waitFor({
                                id: sListaId,
                                viewName: sNomeDaTela,
                                matchers: new AggregationLengthEquals({
                                    name: "items",
                                    length: 20
                                }),
                                success: function(){
                                    Opa5.assert.ok(true, "A lista contém 20 gêneros");
                                },
                                errorMessage: "A lista não contém todos os items"
                            })
                        },
                        deveVoltarParaTelaAnterior: function(){
                            const sUrlAtual = Opa5.getWindow().location.href;
                            return this.waitFor({
                                success: function() {
                                    if (sUrlLista !== sUrlAtual) {
                                        Opa5.assert.ok(true, "Falha ao navegar para página anterior.");
                                    }
                                },
                                errorMessage: "Falha ao navegar para página anterior."
                            });
                        }
                    }
                }
        });
	});