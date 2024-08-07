sap.ui.define([
	"ui5/anime/app/common/ControleBase",
	'sap/m/MessageBox',
	"ui5/anime/app/common/HttpRequest"
], function (ControleBase, MessageBox, HttpRequest) {

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
	const POST = 'POST';
	return ControleBase.extend("ui5.anime.app.cadastroGenero.CadastroGenero", {

		onInit: async function () {
			const oRota = this.getOwnerComponent().getRouter();
			oRota.getRoute(ROTA_ADICIONAR_GENERO).attachMatched(this._aoCoincidirRota, this);
		},

		_aoCoincidirRota: function(){
            this._exibirEspera(async () => {
                this._limparCampos();
            })
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
					await HttpRequest._request(CAMINHO_PARA_API_ADICIONAR_GENERO, POST, genero);
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

		_limparCampos: function () {
			this.byId(ID_INPUT_NOME).setValue("");
			this.byId(ID_INPUT_NOME).setValueState(VALUE_STATE_NONE);
		},
	});
});