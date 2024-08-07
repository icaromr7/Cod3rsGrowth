sap.ui.define([
	"ui5/anime/app/common/ControleBase",
	'sap/ui/model/json/JSONModel',
	'../model/formatter',
	'sap/m/MessageBox',
	"ui5/anime/app/common/HttpRequest"
], function (ControleBase, JSONModel, formatter, MessageBox, HttpRequest) {
	"use strict";
	let _filtroNome = "";
	let _filtroData = null;
	let _filtroStatus = null;
	let _filtro = {};

	const PARAMETRO_FILTRO_POR_NOME = "nome";
	const PARAMETRO_FILTRO_POR_DATA = "datalancamento";
	const PARAMETRO_FILTRO_POR_STATUS = "statusexibicao";
	const CAMINHO_PARA_API = "/api/anime?";
	const CAMINHO_PARA_API_STATUS = "/api/anime/status"
	const NOME_DA_ROTA = "lista";
	const ID_CAMPO_DE_BUSCA = "CampoDeBusca";
	const ID_CAMPO_DE_STATUS = "selectStatus";
	const ID_CAMPO_DE_DATA = "dpDataLancamento"
	const PARAMETRO_VALUE = "value"
	const PARAMETRO_SELECTED_ITEM = "selectedItem"
	const NOME_DO_MODELO_DA_LISTA_DE_ANIME = "animes";
	const NOME_DO_MODELO_DA_LISTA_DE_STATUS = "status"
	const ID_DA_LISTA_DE_ANIMES = "listaDeAnimes";
	const INDEX_STATUS_TODOS = 0;
	const ROTA_PARA_CADASTRO_ANIME = "cadastroAnime"
	const ROTA_PARA_DETALHES_ANIME = "detalhesAnime";
	const ROTA_PARA_LISTA_GENEROS = "listaGenero"
	const ID = "id"

	return ControleBase.extend("ui5.anime.app.lista.Lista", {
		formatter: formatter,

		onInit: async function () {
			const aRota = this._getRota();
			aRota.getRoute(NOME_DA_ROTA).attachPatternMatched(this._aoCoincidirRota, this);
			
		},

		_aoCoincidirRota: async function(){
			this._exibirEspera(async () => {
				await this._obterEPreencherSelectStatus();
				this._filtrarPorRota();
				this._modelo(await HttpRequest._request(CAMINHO_PARA_API+_filtro),NOME_DO_MODELO_DA_LISTA_DE_ANIME);
			});
		},

		_filtrarPorRota: function () {
			const aRota = this.getOwnerComponent().getRouter();
			const oHash = aRota.getHashChanger().getHash();
			_filtro = new URLSearchParams(oHash);
			_filtroNome = _filtro.get(PARAMETRO_FILTRO_POR_NOME);
			_filtroData = _filtro.get(PARAMETRO_FILTRO_POR_DATA);
			_filtroStatus = _filtro.get(PARAMETRO_FILTRO_POR_STATUS);
			const CampoDeBusca = this.byId(ID_CAMPO_DE_BUSCA).setValue(_filtroNome);
			this._adicionarParametrosNaRota();
		},

		aoFiltrarAnime: async function (oEvent) {
			this._exibirEspera(() => {
				let sNome = oEvent.getSource().getValue();
				_filtroNome = sNome;
				this._adicionarParametrosNaRota();
			});
		},

		aoSelecionarData: async function (oEvent) {
			this._exibirEspera(() => {
				_filtroData = oEvent.getParameter(PARAMETRO_VALUE);
				this._adicionarParametrosNaRota();
			});
		},

		aoSelecionarStatus: async function (oEvent) {
			this._exibirEspera(() => {
				_filtroStatus = oEvent.getParameter(PARAMETRO_SELECTED_ITEM).getKey();
				this._adicionarParametrosNaRota();
			});

		},
		_obterEPreencherSelectStatus: async function () {
				let data = await HttpRequest._request(CAMINHO_PARA_API_STATUS);
				var todos =
				{
					id: 0,
					descricao: "Todos"
				}
				data.push(todos);
				this._modelo(await data, NOME_DO_MODELO_DA_LISTA_DE_STATUS);
		},

		_limparCampos: function(){
			this.byId(ID_CAMPO_DE_BUSCA).setValue(undefined);
			this.byId(ID_CAMPO_DE_STATUS).setSelectedKey(INDEX_STATUS_TODOS);
			this.byId(ID_CAMPO_DE_DATA).setValue(undefined);
		},

		_adicionarParametrosNaRota: function () {
			const aRota = this.getOwnerComponent().getRouter();
			let query = {};
			if (_filtroNome) {
				query.nome = _filtroNome;
			}
			if (_filtroData !== null && _filtroData != "") {
				query.datalancamento = _filtroData;
			}
			if (_filtroStatus !== null && _filtroStatus != INDEX_STATUS_TODOS) {
				query.statusexibicao = _filtroStatus;
			}
			aRota.navTo(NOME_DA_ROTA, { "?query": query });
		},

		aoClicarEmAdicionarAnime: function () {
			this._exibirEspera(async () => {
				const aRota = this.getOwnerComponent().getRouter();
				aRota.navTo(ROTA_PARA_CADASTRO_ANIME);
			})
			
		},

		aoClicarNoAnime: function(oEvent){
			this._exibirEspera(async () => {
				let _idAnime = oEvent.getSource().getBindingContext(NOME_DO_MODELO_DA_LISTA_DE_ANIME).getProperty(ID);
				this._getRota().navTo(ROTA_PARA_DETALHES_ANIME,{
					id : _idAnime
				});
			})
		},
		aoClicarEmListaDeGeneros: function(oEvent){
			this._exibirEspera(async () => {
				this._getRota().navTo(ROTA_PARA_LISTA_GENEROS);
			})
		}
	});

});
