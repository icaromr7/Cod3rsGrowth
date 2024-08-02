sap.ui.define([
	"ui5/anime/app/common/ControleBase",
	'sap/ui/model/json/JSONModel',
    "ui5/anime/app/common/HttpRequest",
	'../model/formatter'
], function (ControleBase, JSONModel, HttpRequest, formatter) {
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
			let oRouter = this._getRota();
			oRouter.getRoute(NOME_DA_ROTA).attachMatched(this._aoCoincidirRota, this);
		},
        _aoCoincidirRota: function(){
            this._exibirEspera(async () => {
                this._obterEDefinirDados();
            })
        },
        
        _obterEDefinirDados : async function () {
            let obterParametro = this._getRota().getHashChanger().getHash().split("/");
            this._modeloLista(await HttpRequest._request(CAMINHO_PARA_API + obterParametro[POSICAO_ID_DO_ANIME]),NOME_DO_MODELO_DO_DETALHES_DO_ANIME);
            this._modeloLista(await HttpRequest._request(CAMINHO_PARA_API_GENEROS_DO_ANIME+ obterParametro[POSICAO_ID_DO_ANIME]),NOME_DO_MODELO_GENEROS_DO_ANIME);
		},

	});

});
