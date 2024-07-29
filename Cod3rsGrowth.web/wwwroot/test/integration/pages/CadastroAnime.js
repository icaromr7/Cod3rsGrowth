sap.ui.define([
	'sap/ui/test/Opa5',
	'sap/ui/test/actions/Press',
    'sap/ui/test/actions/EnterText',
    'sap/ui/test/matchers/PropertyStrictEquals',
    'sap/ui/test/matchers/Properties',
    'sap/ui/test/matchers/Ancestor'
], function (Opa5, Press, EnterText, PropertyStrictEquals ,Properties ,Ancestor) {
    "use strict";

    var sNomeDaTela = "cadastroAnime.CadastroAnime";
    Opa5.createPageObjects({
        onPaginaCadastroAnime : {
            actions: {

                aoDigitarNome : function (sNomeDigitado){
                    return this.waitFor({
                        id: "inputNome",
                        viewName: sNomeDaTela,
                        actions: new EnterText({
                            text: sNomeDigitado
                        }),
                        errorMessage: "inputNome não foi encontrado."
                    });
                },
                aoDigitarSinopse : function (sSinopseDigitada){
                    return this.waitFor({
                        id: "inputSinopse",
                        viewName: sNomeDaTela,
                        actions: new EnterText({
                            text: sSinopseDigitada
                        }),
                        errorMessage: "inputSinopse não foi encontrado."
                    });
                },
                aoDigitarNota : function (sNotaDigitada){
                    return this.waitFor({
                        id: "inputNota",
                        viewName: sNomeDaTela,
                        actions: new EnterText({
                            text: sNotaDigitada
                        }),
                        errorMessage: "inputNota não foi encontrado."
                    });
                },
                aoClicarNaLista: function(){
                    return this.waitFor({
                        id: "listaDeGeneros",
                        viewName: sNomeDaTela,
                        actions: new Press(),
                        errorMessage: "Não foi encontrada a lista"
                    })
                }
                ,
                aoPressionarUmItem: function () {
                    return this.waitFor({ 
                        controlType: "sap.m.CustomListItem",
                        viewName: sNomeDaTela,
                        matchers: 
                            new PropertyStrictEquals ({
                                name: "id",
                                value: "__item2-__component1---cadastroAnime--listaDeGeneros-5"})
                        ,                        
                        actions: new Press(),
                        errorMessage: "Nenhum item da lista com o nome foi encontrado."
                    });
                },
                aoSelecionarData: function(sDataDigitada){
                    return this.waitFor({
                        id: "inputDataLancamento",
                        viewName: sNomeDaTela,
                        actions: new EnterText({
                            text: sDataDigitada,
                            pressEnterKey: true
                        }),
                        errorMessage: "inputDataLancamento não foi encontrado"
                    });
                },
                aoClicarNoSelectStatus: function(){
                    return this.waitFor({
                        id: "inputStatus",
                        viewName: sNomeDaTela,
                        actions: new Press(),
                        errorMessage: "inputStatus não foi encontrado"
                    })
                },
                aoSelecionarStatus: function(){
                    return this.waitFor({
                        controlType: "sap.ui.core.Item",
                        matchers: 
                            new PropertyStrictEquals ({
                                name: "id",
                                value: "__item3-__component1---cadastroAnime--inputStatus-1"})
                        ,
                        actions: new Press(),
                        errorMessage: "status não foi encontrado"
                    })
                },
                aoClicarEmSalvar: function(){
                    return this.waitFor({
                        id: "btnSalvar",
                        viewName: sNomeDaTela,
                        actions: new Press(),
                        errorMessage: "Botão de salvar não foi encontrado"
                    })
                }
            },
            assertions:{
                deveNavegarParaTelaDeCadastro: function(){
                    return this.waitFor({
                        viewName: sNomeDaTela,
                        success: function () {
                            Opa5.assert.ok(true, "Sucesso ao navegar para tela de cadastro");
                        },
                        errorMessage: "Falha ao navegar a pagina de cadastro"
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