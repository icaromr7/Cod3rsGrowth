sap.ui.define([
	'sap/ui/test/Opa5',
	'sap/ui/test/matchers/Properties',
	'sap/ui/test/actions/Press',
    'sap/ui/test/actions/EnterText',
    'sap/ui/test/matchers/AggregationLengthEquals',
    'sap/ui/test/matchers/Ancestor',
    'sap/ui/test/matchers/PropertyStrictEquals'
], function (Opa5, Properties, Press,EnterText, AggregationLengthEquals,Ancestor,PropertyStrictEquals) {
	"use strict";
    
		var sNomeDaTela = "lista.Lista";
        var sListaId = "listaDeAnimes"
        Opa5.createPageObjects({
                onPaginaListaAnime: {
                    actions:{
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
                        aoSelecionarData: function(sDataPesquisada){
                            return this.waitFor({
                                id: "dpDataLancamento",
                                viewName: sNomeDaTela,
                                actions: new EnterText({
                                    text: sDataPesquisada,
                                    pressEnterKey: true
                                }),
                                errorMessage: "dpdataLancamento não foi encontrado"
                            });
                        },
                        aoClicarNoFiltroStatus: function(){
                            return this.waitFor({
                                id: "selectStatus",
                                viewName: sNomeDaTela,
                                actions: new Press(),
                                errorMessage: "selectStatus não foi encontrado"
                            })
                        },
                        aoSelecionarStatus: function(sStatus){
                            return this.waitFor({
                                controlType: "sap.ui.core.Item",
                                matchers: 
                                    new PropertyStrictEquals ({
                                        name: "text",
                                        value: sStatus})
                                ,
                                actions: new Press(),
                                errorMessage: "Status não foi encontrado"
                            })
                        },
                        aoApertarEmAdicionarAnime: function(){
                            return this.waitFor({
                                id: "btnAdicionar",
                                viewName: sNomeDaTela,
                                actions: new Press(),
                                errorMessage: "Não foi possível pressionar o botão de adicionar."
                            });
                        },
                        aoApertarEmListaDeGeneros: function(){
                            return this.waitFor({
                                id: "btnListaDeGeneros",
                                viewName: sNomeDaTela,
                                actions: new Press(),
                                errorMessage: "Não foi possível pressionar o botão lista de gêneros"
                            });
                        },
                        aoClicarEmUmAnime: function(sNome){
                            return this.waitFor({
                                controlType: "sap.m.Label",
                                viewName: sNomeDaTela,
                                matchers:  new Properties({
                                    text: sNome
                                }),
                                actions: new Press(),
                                errorMessage: "A lista não contém o anime " + sNome
                            });
                        }
                    },
                    assertions:{
                        deveNavegarParaTelaDeLista: function(){
                            return this.waitFor({
                                viewName: sNomeDaTela,
                                success: function () {
                                    Opa5.assert.ok(true, "Sucesso ao navegar para tela de lista");
                                },
                                errorMessage: "Falha ao navegar a pagina de lista"
                            });
                        },
                        aListaTemUmAnime :  function(){
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
                                errorMessage: "A lista não contém dois animes."
                            });
                        },
                        aListaDeveMostrarTodosAnimes(){
                            return this.waitFor({
                                id: sListaId,
                                viewName: sNomeDaTela,
                                matchers: new AggregationLengthEquals({
                                    name: "items",
                                    length: 15
                                }),
                                success: function(){
                                    Opa5.assert.ok(true, "A lista contém mais de 10 animes");
                                },
                                errorMessage: "A lista não contém todos os items"
                            })
                        }
                    }
                }
        });
	});