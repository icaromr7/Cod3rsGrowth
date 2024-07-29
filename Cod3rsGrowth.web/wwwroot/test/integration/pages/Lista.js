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
                        aoSelecionarStatus: function(){
                            return this.waitFor({
                                controlType: "sap.ui.core.Item",
                                matchers: 
                                    new PropertyStrictEquals ({
                                        name: "id",
                                        value: "__item0-__component0---lista--selectStatus-2"})
                                ,
                                actions: new Press(),
                                errorMessage: "selectStatus não foi encontrado"
                            })
                        },
                        aoApertarEmAdicionarAnime: function(){
                            return this.waitFor({
                                id: "btnAdicionar",
                                viewName: sNomeDaTela,
                                actions: new Press(),
                                errorMessage: "Não foi possível pressionar o botão de adicionar."
                            });
                        }
                    },
                    assertions:{
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
                                errorMessage: "A lista não contém um snimr."
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
                                errorMessage: "A lista não contém dois snimes."
                            });
                        },
                        aListaDeveMostrarTodosAnimes(){
                            return this.waitFor({
                                id: sListaId,
                                viewName: sNomeDaTela,
                                matchers: new AggregationLengthEquals({
                                    name: "items",
                                    length: 11
                                }),
                                success: function(){
                                    Opa5.assert.ok(true, "A lista contém 11 animes");
                                },
                                errorMessage: "A lista não contém todos os items"
                            })
                        }
                    }
                }
        });
	});