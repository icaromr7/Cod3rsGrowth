sap.ui.define([
	"ui5/anime/app/common/ControleBase",
	'sap/ui/model/json/JSONModel',
	'../model/formatter',
	'sap/m/MessageBox'
], function (ControleBase, JSONModel, formatter, MessageBox) {
	"use strict";
	let _filtroNome = "";
	let _filtro = {};

	const PARAMETRO_FILTRO_POR_NOME = "generos?nome";
	const CAMINHO_PARA_API = "/api/genero?";
	const NOME_DA_ROTA = "listaGenero";
	const ROTA_ADICIONAR_GENERO = "cadastroGenero"
	const ID_CAMPO_DE_BUSCA = "CampoDeBusca";
	const NOME_DO_MODELO_DA_LISTA_DE_GENEROS = "generos";
	const ROTA_DETALHES_GENERO = "detalhesGenero"

	return ControleBase.extend("ui5.anime.app.listaGeneros.ListaGeneros", {
		formatter: formatter,

		onInit: function () {
			const aRota = this._getRota();
			aRota.getRoute(NOME_DA_ROTA).attachPatternMatched(this._preencherLista, this);
		},

		_filtrarPorRota: function () {
			const aRota = this.getOwnerComponent().getRouter();
			const oHash = aRota.getHashChanger().getHash();
			_filtro = new URLSearchParams(oHash);
			_filtroNome = _filtro.get(PARAMETRO_FILTRO_POR_NOME) ? _filtro.get(PARAMETRO_FILTRO_POR_NOME) : "" ;
            this.byId(ID_CAMPO_DE_BUSCA).setValue(_filtroNome);
		},

		aoFiltrarGenero: function (oEvent) {
			this._exibirEspera(async () => {
				let sNome = oEvent.getSource().getValue();
				_filtroNome = sNome;
				this._adicionarParametrosNaRota();
			});
		},

		_get: async function (url) {
				let urlFinal = url + "nome=" + _filtroNome;
				const response = await fetch(urlFinal, {
					method: "GET",
					headers: {
						"Content-Type": "application/json"
					}
				});
				if (response.ok) {
					const data = await response.json();
					const oModel = new JSONModel(data);
					return this._modeloLista(oModel, NOME_DO_MODELO_DA_LISTA_DE_GENEROS);
				}
		},

		_preencherLista: async function () {
			this._filtrarPorRota();
			this._get(CAMINHO_PARA_API);
		},

		_adicionarParametrosNaRota: function () {
			const aRota = this.getOwnerComponent().getRouter();
			let query = {};
			if (_filtroNome) {
				query.nome = _filtroNome;
			}
			aRota.navTo(NOME_DA_ROTA, { "?query": query });
		},
		aoClicarAdicionarGenero: function(){
			const aRota = this.getOwnerComponent().getRouter();
			aRota.navTo(ROTA_ADICIONAR_GENERO);
		},
		aoClicarNoGenero: function(oEvent){
			this._exibirEspera(async () => {
				let _idGenero = oEvent.getSource().getBindingContext(NOME_DO_MODELO_DA_LISTA_DE_GENEROS).getProperty("id");
				this._getRota().navTo(ROTA_DETALHES_GENERO,{
					id : _idGenero
				});
			})
		}
	});

});
