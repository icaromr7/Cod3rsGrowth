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
			var oRouter = this._getRota();
			oRouter.getRoute(NOME_DA_ROTA).attachMatched(this._PegarDadosPorId, this);
		},
        _PegarDadosPorId : function () {
            this._exibirEspera(async () => {               
                var obterParametro = this._getRota().getHashChanger().getHash().split("/");
                this._getGenero(CAMINHO_PARA_API,obterParametro[POSICAO_ID_DO_GENERO]);
			})
			
		},
        _getGenero: async function(url, idGenero){
            var urlFinal = url + idGenero;
            const response = await fetch(urlFinal, {
                method: "GET",
                headers: {
                    "Content-Type": "application/json"
                }
            });
            if (response.ok) {
                const data = await response.json();
                const oModel = new JSONModel(data);
                return this._modeloLista(oModel, NOME_DO_MODELO_DO_DETALHES_DO_GENERO);
            }
        }
	});

});