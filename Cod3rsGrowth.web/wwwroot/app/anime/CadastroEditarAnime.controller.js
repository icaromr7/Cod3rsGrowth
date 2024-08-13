sap.ui.define([
	"ui5/anime/app/common/ControleBase",
	'sap/m/MessageBox',
	"ui5/anime/app/common/HttpRequest"
], function (ControleBase, MessageBox, HttpRequest) {

	const ROTA_PARA_LISTA = "lista";
	const ROTA_ADICIONAR_ANIME = "cadastroAnime";
	const ROTA_EDITAR_ANIME = "editarAnime"
	const NOME_DO_MODELO_LISTA_DE_GENEROS = "generos";
	const NOME_DO_MODELO_DA_LISTA_DE_STATUS = "status";
	const CAMINHO_PARA_API_GENEROS = "/api/genero";
	const ID_DA_LISTA_DE_GENEROS = "listaDeGeneros";
	const ID_INPUT_NOME = "inputNome";
	const ID_INPUT_SINOPSE = "inputSinopse";
	const ID_INPUT_NOTA = "inputNota";
	const ID_INPUT_DATA_LANCAMENTO = "inputDataLancamento";
	const ID_INPUT_STATUS = "inputStatus";
	const KEY_EM_EXIBICAO = "1";
	const VALOR_INICIAL_DA_NOTA = 1;
	const POSICAO_INICIAL_DA_LISTA = 0;
	const POSICAO_DO_ID = 1;
	const VALUE_STATE_ERROR = "Error";
	const VALUE_STATE_NONE = "None";
	const VALUE_STATE_NOME_OBRIGATORIO = "o campo nome é obrigatório";
	const VALUE_STATE_SINOPSE_OBRIGATORIA = "o campo sinopse é obrigatório";
	const VALUE_STATE_DATA_OBRIGATORIO = "o campo data lançamento é obrigatório";
	const MESSAGEM_PRECISA_SELECIONAR_GENERO = "Precisa selecionar ao menos 1 gênero";
	const CAMINHO_PARA_API_STATUS = "/api/anime/status";
	const MESSAGEM_SUCESSO_CADASTRO = "Sucesso ao cadastrar o anime!";
	const CAMINHO_PARA_API_ADICIONAR_ANIME = "/api/anime/adicionar";
	const CAMINHO_PARA_API_ANIME = "/api/anime/"
	const OPCAO_VOLTAR_PARA_LISTA_DE_ANIME = "Voltar a lista de anime";
	const POST = 'POST';
	const PUT = 'PUT';
	const POSICAO_CADASTRO_OU_EDITAR = 1;
	const POSICAO_ID_DO_ANIME = 2;
	const LABEL_ID = 'labelId'
	const INPUT_ID = 'inputId'

	return ControleBase.extend("ui5.anime.app.anime.CadastroEditarAnime", {
		onInit: function () {
			const oRota = this.getOwnerComponent().getRouter();
			oRota.getRoute(ROTA_ADICIONAR_ANIME).attachMatched(this._aoCoincidirRota, this);
			oRota.getRoute(ROTA_EDITAR_ANIME).attachMatched(this._aoCoincidirRota, this);
		},
		_aoCoincidirRota: function () {
			this._exibirEspera(async () => {
				this._limparCampos();
				let obterParametro = this._getRota().getHashChanger().getHash().split('/');
				this._modelo(await HttpRequest._request(CAMINHO_PARA_API_GENEROS), NOME_DO_MODELO_LISTA_DE_GENEROS);
				this._modelo(await HttpRequest._request(CAMINHO_PARA_API_STATUS), NOME_DO_MODELO_DA_LISTA_DE_STATUS);
				if (obterParametro[POSICAO_CADASTRO_OU_EDITAR] == 'editar') {
					this.byId(LABEL_ID).setVisible(true);
					this.byId(INPUT_ID).setVisible(true);
					this._definirDados(obterParametro);
				}
			})
		},
		_definirDados: async function (obterParametro) {
			var anime = await HttpRequest._request(CAMINHO_PARA_API_ANIME + obterParametro[POSICAO_ID_DO_ANIME]);
			this.byId(INPUT_ID).setValue(anime.id);
			this.byId(ID_INPUT_NOME).setValue(anime.nome);
			this.byId(ID_INPUT_SINOPSE).setValue(anime.sinopse);
			this.byId(ID_INPUT_NOTA).setValue(anime.nota);
			this.byId(ID_INPUT_DATA_LANCAMENTO).setValue(anime.dataLancamento);
			console.log(anime)
			var items = this.byId(ID_DA_LISTA_DE_GENEROS).getItems();
			for (var i = POSICAO_INICIAL_DA_LISTA; i < items.length; i++) {
				for (var j = POSICAO_INICIAL_DA_LISTA; j < anime.idGeneros.length; j++) {
					if (parseInt(items[i].mAggregations.content[POSICAO_DO_ID].mProperties.text) == anime.idGeneros[j]) {
						this.byId(ID_DA_LISTA_DE_GENEROS).setSelectedItem(items[i], true);
					}
				}
			}
		},
		_VerificarCampos: function () {
			var verificacao = true;
			const _nome = this.byId(ID_INPUT_NOME);
			if (_nome.getValue() == "") {
				_nome.setValueState(VALUE_STATE_ERROR);
				_nome.setValueStateText(VALUE_STATE_NOME_OBRIGATORIO);
			}
			const _sinopse = this.byId(ID_INPUT_SINOPSE);
			if (_sinopse.getValue() == "") {
				_sinopse.setValueState(VALUE_STATE_ERROR);
				_sinopse.setValueStateText(VALUE_STATE_SINOPSE_OBRIGATORIA);
			}
			const _nota = this.byId(ID_INPUT_NOTA);
			if (_nota.getValueState() == VALUE_STATE_ERROR) verificacao = false;

			const _generos = this.byId(ID_DA_LISTA_DE_GENEROS);
			if (_generos.getSelectedItems().length == 0) {
				MessageBox.show(MESSAGEM_PRECISA_SELECIONAR_GENERO);
				verificacao = false
			}
			const _dataLancamento = this.byId(ID_INPUT_DATA_LANCAMENTO);
			if (_dataLancamento.getValue() == "") {
				_dataLancamento.setValueState(VALUE_STATE_ERROR);
				_dataLancamento.setValueStateText(VALUE_STATE_DATA_OBRIGATORIO);
			}

			return verificacao;
		},

		aoClicarEmSalvar: function () {
			this._exibirEspera(async () => {
				if (this._VerificarCampos()) {
					let anime = {
						nome: this.byId(ID_INPUT_NOME).getValue(),
						sinopse: this.byId(ID_INPUT_SINOPSE).getValue(),
						dataLancamento: this.byId(ID_INPUT_DATA_LANCAMENTO).getValue(),
						nota: this.byId(ID_INPUT_NOTA).getValue(),
						statusDeExibicao: parseInt(this.byId(ID_INPUT_STATUS).getSelectedItem().getKey()),
						idGeneros: this._preencherAListaDeGenerosSelecionados()
					}
					await HttpRequest._request(CAMINHO_PARA_API_ADICIONAR_ANIME, POST, anime);
					this._sucessoNoPost();
				}
			})

		},

		aoDigitarNoInput: function (oEvent) {
			this._exibirEspera(async () => {
				oEvent.getSource().setValueState(VALUE_STATE_NONE);
			})

		},

		_sucessoNoPost: function () {
			MessageBox.success(MESSAGEM_SUCESSO_CADASTRO, {
				actions: [OPCAO_VOLTAR_PARA_LISTA_DE_ANIME],
				onClose: (sAcao) => {
					if (sAcao === OPCAO_VOLTAR_PARA_LISTA_DE_ANIME) {
						this._limparCampos();
						const aRota = this.getOwnerComponent().getRouter();
						aRota.navTo(ROTA_PARA_LISTA);
					}
				}
			});
		},

		_limparCampos: async function () {
			this.byId(ID_INPUT_NOME).setValue("");
			this.byId(ID_INPUT_NOME).setValueState(VALUE_STATE_NONE)
			this.byId(ID_INPUT_SINOPSE).setValue("");
			this.byId(ID_INPUT_SINOPSE).setValueState(VALUE_STATE_NONE)
			this.byId(ID_INPUT_DATA_LANCAMENTO).setValue("");
			this.byId(ID_INPUT_DATA_LANCAMENTO).setValueState(VALUE_STATE_NONE)
			this.byId(ID_INPUT_NOTA).setValue(VALOR_INICIAL_DA_NOTA);
			this.byId(ID_INPUT_NOTA).setValueState(VALUE_STATE_NONE)
			this.byId(ID_INPUT_STATUS).setSelectedKey(KEY_EM_EXIBICAO);
			var items = this.byId(ID_DA_LISTA_DE_GENEROS).getSelectedItems();
			for (var i = POSICAO_INICIAL_DA_LISTA; i < items.length; i++) {
				this.byId(ID_DA_LISTA_DE_GENEROS).setSelectedItem(items[i], false);
			}
		},

		_preencherAListaDeGenerosSelecionados: function () {
			var items = this.byId(ID_DA_LISTA_DE_GENEROS).getSelectedItems();
			var listaIdGeneros = [];
			for (var i = POSICAO_INICIAL_DA_LISTA; i < items.length; i++) {
				var idGenero = parseInt(items[i].mAggregations.content[POSICAO_DO_ID].mProperties.text)
				listaIdGeneros.push(idGenero);
			}
			return listaIdGeneros;
		}
	});
});