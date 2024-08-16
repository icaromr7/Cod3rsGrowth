sap.ui.define([
	'sap/ui/test/Opa5',
	'sap/ui/test/actions/Press',
    'sap/ui/test/actions/EnterText',
    'sap/ui/test/matchers/Properties',
    'sap/ui/test/matchers/Ancestor'
], function (Opa5, Press, EnterText,Properties ,Ancestor) {
    "use strict";

    var sNomeDaTela = "genero.CadastroEditarGenero";
    Opa5.createPageObjects({
        onPaginaEditarGenero : {
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
                aTelaEditarGeneroFoiCarregadaCorretamente: function(){
                    return this.waitFor({
                        viewName: sNomeDaTela,
                        success: function () {
                            Opa5.assert.ok(true, "Sucesso ao navegar para tela de edição");
                        },
                        errorMessage: "Falha ao navegar a pagina de edição"
                    });
                },deveTerOIdDoItemSelecionado: function(sId){
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
                DeveSairDaTelaDeEdicao: function(sTitulo){
                    return this.waitFor({
                        controlType: "sap.m.Page",
                        matchers: {
                            PropertyStrictEquals: {
                                name: "tittle",
                                value: sTitulo
                            }
                        },
                        success: () => Opa5.assert.ok(false, "Sucesso ao sair da pagina de edição"),
                        errorMessage: "Falha ao ao sair da pagina de edição"
                    });
                }
            }
        }
    });
}
);