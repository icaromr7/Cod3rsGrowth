sap.ui.define([
	"ui5/anime/app/common/ControleBase",
	'sap/m/MessageBox',
], function (ControleBase, MessageBox) {

	const ROTA_PARA_LISTA_GENERO = "listaGenero";
	const ROTA_ADICIONAR_GENERO = "cadastroGenero";
	const ID_INPUT_NOME = "inputNome";
	const POSICAO_INICIAL_DA_LISTA = 0;
	const FALHA_NA_REQUISIÇÃO = "Ocorreu um ou mais erros na requisição";
	const VALUE_STATE_ERROR = "Error";
	const VALUE_STATE_NONE = "None";
	const VALUE_STATE_NOME_OBRIGATORIO = "o campo nome é obrigatório";
	const MESSAGEM_SUCESSO_CADASTRO = "Sucesso ao cadastrar o gênero!";
	const CAMINHO_PARA_API_ADICIONAR_GENERO = "/api/genero/adicionar";
	const OPCAO_VOLTAR_PARA_LISTA_DE_GENEROS = "Voltar a lista de gêneros";
    const POSICAO_PRIMEIRA_LETRA = 0;
    const POSICAO_SEGUNDA_LETRA = 1;
	return ControleBase.extend("ui5.anime.app.cadastroGenero.CadastroGenero", {

		onInit: async function () {
			const oRota = this.getOwnerComponent().getRouter();
			oRota.getRoute(ROTA_ADICIONAR_GENERO);
		},

		_VerificarCampos: function () {
			let verificacao = true;
			const _nome = this.byId(ID_INPUT_NOME);
			if (_nome.getValue() == "") {
				_nome.setValueState(VALUE_STATE_ERROR);
				_nome.setValueStateText(VALUE_STATE_NOME_OBRIGATORIO);
			}
			return verificacao;
		},

		aoClicarEmSalvar: function () {
			this._exibirEspera(async () => {
				if (this._VerificarCampos()) {
                    let _generoNome = this.byId(ID_INPUT_NOME).getValue().split();
                    let _nome = "";
                    for (let i =POSICAO_INICIAL_DA_LISTA; i<_generoNome.length; i++){
                        _nome+= _generoNome[i].substring(POSICAO_PRIMEIRA_LETRA,POSICAO_SEGUNDA_LETRA).toUpperCase() + _generoNome[i].substring(POSICAO_SEGUNDA_LETRA).toLowerCase() + " ";
                    }
					let genero = {
						nome: _nome.trim()
					}
					this._postGenero(CAMINHO_PARA_API_ADICIONAR_GENERO, genero);
				}
			})
			
		},

		aoDigitarNoInput: function (oEvent) {
			this._exibirEspera(async () => {
				oEvent.getSource().setValueState(VALUE_STATE_NONE);
			})
			
		},

		_postGenero: async function (url, genero) {
				const response = await fetch(url, {
					method: "POST",
					headers: {
						"Content-Type": "application/json"
					},
					body: JSON.stringify(genero)
				});
				const data = await response.json();

				if (response.ok) {
					this._sucessoNoPost();
				}
				else {
					this._falhaNaRequicaoPost(data);
				}
		},

		_sucessoNoPost: function () {
			MessageBox.success(MESSAGEM_SUCESSO_CADASTRO, {
				actions: [OPCAO_VOLTAR_PARA_LISTA_DE_GENEROS],
				onClose: (sAcao) => {
					if (sAcao === OPCAO_VOLTAR_PARA_LISTA_DE_GENEROS) {
						this._limparCampos();
						const aRota = this.getOwnerComponent().getRouter();
						aRota.navTo(ROTA_PARA_LISTA_GENERO);
					}
				}
			});
		},

		_falhaNaRequicaoPost: function (data) {
			let detalhesDoErro = data.errors;
			let arrayErrors = Object.keys(detalhesDoErro);
			arrayErrors = arrayErrors.map(x => detalhesDoErro[x]);
			detalhesDoErro = '\n';
			for (let i = POSICAO_INICIAL_DA_LISTA; i < arrayErrors.length; i++) {
				for (let j = POSICAO_INICIAL_DA_LISTA; j < arrayErrors[i].length; j++)
					detalhesDoErro += arrayErrors[i][j] + '\n';
			};
			const mensagemErro = `
				Título: ${data.title}
				Status: ${data.status}
				Detalhes: ${data.detail}
				Erros: ${detalhesDoErro}
			`;

			MessageBox.error(`${FALHA_NA_REQUISIÇÃO}\n${mensagemErro}`);
		},

		_limparCampos: function () {
			this.byId(ID_INPUT_NOME).setValue(undefined);
		},
	});
});