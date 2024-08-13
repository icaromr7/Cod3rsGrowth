sap.ui.define([
	'sap/ui/test/Opa5',
	'sap/ui/test/actions/Press',
    'sap/ui/test/actions/EnterText',
    'sap/ui/test/matchers/PropertyStrictEquals',
    'sap/ui/test/matchers/Properties',
    'sap/ui/test/matchers/Ancestor'
], function (Opa5, Press, EnterText, PropertyStrictEquals ,Properties ,Ancestor) {
    "use strict";

    var sNomeDaTela = "anime.CadastroAnime";
    Opa5.createPageObjects({
        onPaginaCadastroAnime : {
            actions: {
                aoClicarEmVoltar: function () {
                    return this.waitFor({
                        id: "pagina",
                        viewName: sNomeDaTela,
                        actions: new Press(),
                        errorMessage: "Não foi possível encontrar o botão de voltar na página do objeto"
                    });
                },
                aoDigitarNoInput: function(chavei18n, stext){
                    return this.waitFor({
                        id: chavei18n,
                        viewName: sNomeDaTela,
                        actions: new EnterText({
                            text: stext
                        }),
                        errorMessage: `${chavei18n} não foi encontrado.`
                    });
                },
                aoDigitarNome : function (chavei18n, stext){
                    this.aoDigitarNoInput(chavei18n, stext);
                },
                aoDigitarSinopse : function (chavei18n, stext){
                    this.aoDigitarNoInput(chavei18n, stext);
                },
                aoDigitarNota : function (chavei18n, stext){
                    this.aoDigitarNoInput(chavei18n, stext);
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
                aoPressionarUmItem: function (sNome) {
                    return this.waitFor({
                        controlType: "sap.m.Label",
                        viewName: sNomeDaTela,
                        matchers:  new Properties({
                            text: sNome
                        }),
                        actions: new Press(),
                        errorMessage: "A lista não contém o gênero "
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
                aTelaCadastroAnimeFoiCarregadaCorretamente: function(){
                    return this.waitFor({
                        viewName: sNomeDaTela,
                        success: () => Opa5.assert.ok(true, "Sucesso ao navegar para tela de cadastro"),
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
				},
                DeveSairDaTelaDeCadastro: function(sTitulo){
                    return this.waitFor({
                        controlType: "sap.m.Page",
                        matchers: {
                            PropertyStrictEquals: {
                                name: "tittle",
                                value: sTitulo
                            }
                        },
                        success: () => Opa5.assert.ok(false, "Sucesso ao sair da pagina de cadastro"),
                        errorMessage: "Falha ao ao sair da pagina de cadastro"
                    });
                }
                
            }
        }
    });
}
);