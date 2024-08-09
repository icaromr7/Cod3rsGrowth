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
    const sUrlCadastro = Opa5.getWindow().location.href;
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
				},
                deveVoltarParaTelaAnterior: function(){
                    const sUrlAtual = Opa5.getWindow().location.href;
                    return this.waitFor({
                        success: function() {
                            if (sUrlCadastro !== sUrlAtual) {
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