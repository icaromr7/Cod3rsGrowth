sap.ui.define([
	"ui5/anime/app/common/ControleBase",
	'sap/ui/model/json/JSONModel',
	'../model/formatter'
], function (ControleBase, JSONModel, formatter) {
	"use strict";
    const NOME_DO_MODELO_DO_DETALHES_DO_ANIME = "anime";
    const NOME_DO_MODELO_GENEROS_DO_ANIME = "generos"
    const CAMINHO_PARA_API = "/api/anime/";
    const CAMINHO_PARA_API_GENEROS_DO_ANIME = "/api/genero/animeGenero/"
    const NOME_DA_ROTA = "detalhesAnime";
    const POSICAO_ID_DO_ANIME = 1;
	
	return ControleBase.extend("ui5.anime.app.detalhesAnime.DetalhesAnime", {
        formatter: formatter,

        onInit: function () {
			var oRouter = this._getRota();
			oRouter.getRoute(NOME_DA_ROTA).attachMatched(this._PegarDadosPorId, this);
		},
        _PegarDadosPorId : function () {
            this._exibirEspera(async () => {               
                var obterParametro = this._getRota().getHashChanger().getHash().split("/");
                this._getAnime(CAMINHO_PARA_API,obterParametro[POSICAO_ID_DO_ANIME]);
                this._getGeneros(CAMINHO_PARA_API_GENEROS_DO_ANIME,obterParametro[POSICAO_ID_DO_ANIME]);
			})
			
		},
        _getAnime: async function(url, idAnime){
            var urlFinal = url + idAnime;
            const response = await fetch(urlFinal, {
                method: "GET",
                headers: {
                    "Content-Type": "application/json"
                }
            });
            if (response.ok) {
                const data = await response.json();
                const oModel = new JSONModel(data);
                return this._modeloLista(oModel, NOME_DO_MODELO_DO_DETALHES_DO_ANIME);
            }
        },
        _getGeneros: async function(url, idAnime){
            var urlFinal = url + idAnime;
            const response = await fetch(urlFinal, {
                method: "GET",
                headers: {
                    "Content-Type": "application/json"
                }
            });
            if (response.ok) {
                const data = await response.json();
                const oModel = new JSONModel(data);
                return this._modeloLista(oModel, NOME_DO_MODELO_GENEROS_DO_ANIME);
            }
        }

	});

});
