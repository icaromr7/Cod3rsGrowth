sap.ui.define([
	"ui5/anime/app/common/ControleBase",
	'sap/ui/model/json/JSONModel',
	'../model/formatter',
    "ui5/anime/app/common/HttpRequest",
    'sap/m/MessageBox'
], function (ControleBase, JSONModel, formatter, HttpRequest, MessageBox) {
	"use strict";
    const NOME_DO_MODELO_DO_DETALHES_DO_GENERO = "genero";
    const CAMINHO_PARA_API = "/api/genero/";
    const NOME_DA_ROTA_DETALHES = "detalhesGenero";
    const NOME_DA_ROTA_EDITAR = "editarGenero"
    const CAMINHO_PARA_API_DELETAR_GENERO ="/api/genero/deletar/"
    const POSICAO_ID_DO_GENERO = 1;
    const ROTA_PARA_LISTA_GENERO = "listaGenero"
    const INPUT_ID = 'inputId';
    const MSG_EXCLUIR = "msgExcluir";
    const MSG_SUCESSO_AO_EXCLUIR = "msgSucessoAoExcluir"
    const DELETE = "DELETE"
	let obterParametro = ""
    let i18n = ''
	return ControleBase.extend("ui5.anime.app.genero.DetalhesGenero", {
        formatter: formatter,

        onInit: function () {
			let oRouter = this._getRota();
			oRouter.getRoute(NOME_DA_ROTA_DETALHES).attachMatched(this._aoCoincidirRota, this);
		},
        _aoCoincidirRota: function(){
            this._exibirEspera(async () => {               
                this._obterEDefinirDados();
                i18n = this.getView().getModel("i18n").getResourceBundle(); 
			})

        },
        _obterEDefinirDados : async function () {
            obterParametro = this._getRota().getHashChanger().getHash().split("/");
            this._modelo(await HttpRequest._request(CAMINHO_PARA_API + obterParametro[POSICAO_ID_DO_GENERO]),NOME_DO_MODELO_DO_DETALHES_DO_GENERO);
		},
        aoClicarEmEditar: function(){
            this._exibirEspera(async () =>{
                const aRota = this.getOwnerComponent().getRouter();
				aRota.navTo(NOME_DA_ROTA_EDITAR,{
                    id: this.byId(INPUT_ID).getValue()
                });
            })
        },
        aoClicarEmRemover: function(){
            this._exibirEspera(async () => {
                const aRota = this.getOwnerComponent().getRouter(); 
                MessageBox.confirm(i18n.getText(MSG_EXCLUIR),{
                    actions: [MessageBox.Action.YES, MessageBox.Action.NO],
                    dependentOn: this.getView(),
                    onClose: async function(sAcao){
                        if(sAcao == MessageBox.Action.YES)
                        {
                            await HttpRequest._request(CAMINHO_PARA_API_DELETAR_GENERO + obterParametro[POSICAO_ID_DO_GENERO],DELETE);
                            MessageBox.success(i18n.getText(MSG_SUCESSO_AO_EXCLUIR), {
                                onClose: () => {
                                    aRota.navTo(ROTA_PARA_LISTA_GENERO);
                                }
                            });
                        }
                    },
                })
            });
        }
	});

});
