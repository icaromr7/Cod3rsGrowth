sap.ui.define([
	"ui5/anime/app/common/ControleBase",
	'sap/ui/model/json/JSONModel',
	'../model/formatter'
], function (ControleBase, JSONModel, formatter) {
	"use strict";
    const NOME_DO_MODELO_DO_DETALHES_DO_GENERO = "genero";
    const CAMINHO_PARA_API = "/api/genero/";
    const NOME_DA_ROTA = "detalhesGenero";
    const POSICAO_ID_DO_GENERO = 1;
	
	return ControleBase.extend("ui5.anime.app.detalhesGenero.DetalhesGenero", {
        formatter: formatter,

        onInit: function () {
			let oRouter = this._getRota();
			oRouter.getRoute(NOME_DA_ROTA).attachMatched(this._aoCoincidirRota, this);
		},
        _aoCoincidirRota: function(){
            this._exibirEspera(async () => {               
                this._obterEDefinirDados();
			})

        },
        _obterEDefinirDados : async function () {
            var obterParametro = this._getRota().getHashChanger().getHash().split("/");
            this._modeloLista(await this._getPorParametro(CAMINHO_PARA_API,obterParametro[POSICAO_ID_DO_GENERO]),NOME_DO_MODELO_DO_DETALHES_DO_GENERO);
			
		},
	});

});
