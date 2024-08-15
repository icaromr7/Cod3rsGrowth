sap.ui.define([
	"ui5/anime/app/common/ControleBase",
	'sap/m/MessageBox',
	"ui5/anime/app/common/HttpRequest"
], function (ControleBase, MessageBox, HttpRequest) {

	const ROTA_PARA_LISTA_GENERO = "listaGenero";
	const ROTA_ADICIONAR_GENERO = "cadastroGenero";
	const ROTA_EDITAR_GENERO ="editarGenero"
	const NOME_MODELO_GENERO = "genero"
	const ID_INPUT_NOME = "inputNome";
	const POSICAO_INICIAL_DA_LISTA = 0;
	const VALUE_STATE_ERROR = "Error";
	const VALUE_STATE_NONE = "None";
	const VALUE_STATE_NOME_OBRIGATORIO = "ValueStateNomeObrigatorio";
	const MENSAGEM_SUCESSO_CADASTRO = "mensagemSucessoCadastrarGenero";
	const MENSAGEM_SUCESSO_EDITAR = "mensagemSucessoEditarGenero";
	const CAMINHO_PARA_API_ADICIONAR_GENERO = "/api/genero/adicionar";
	const CAMINHO_PARA_API_EDITAR_GENERO = "/api/genero/atualizar";
	const CAMINHO_PARA_API_GENERO = '/api/genero/'
	const OPCAO_VOLTAR_PARA_LISTA_DE_GENEROS = "voltarAListaGenero";
    const POSICAO_PRIMEIRA_LETRA = 0;
    const POSICAO_SEGUNDA_LETRA = 1;
	const POST = 'POST';
	const PUT = 'PUT';
	const POSICAO_CADASTRO_OU_EDITAR = 1;
	const POSICAO_ID_DO_GENERO = 2;
	const LABEL_ID = 'labelId';
	const INPUT_ID = 'inputId';
	const HASH_EDITAR = 'editar';
	const ID_PAGINA = "pagina";
	const TITULO_CADASTRO = "TituloPaginaCadastroGenero"
	const TITULO_EDITAR = "TituloPaginaEditarGenero"
	let parametros = ''
	let i18n ='';

	return ControleBase.extend("ui5.anime.app.genero.CadastroEditarGenero", {

		onInit: async function () {
			const oRota = this.getOwnerComponent().getRouter();
			oRota.getRoute(ROTA_ADICIONAR_GENERO).attachMatched(this._aoCoincidirRota, this);
			oRota.getRoute(ROTA_EDITAR_GENERO).attachMatched(this._aoCoincidirRota, this);
		},

		_aoCoincidirRota: function(){
            this._exibirEspera(async () => {
                this._limparCampos();
				i18n = this.getView().getModel("i18n").getResourceBundle();
				parametros = this._getRota().getHashChanger().getHash().split('/');
				if (parametros[POSICAO_CADASTRO_OU_EDITAR] == HASH_EDITAR) {
					this.byId(ID_PAGINA).setTitle(i18n.getText(TITULO_EDITAR));
					this.byId(LABEL_ID).setVisible(true);
					this.byId(INPUT_ID).setVisible(true);
					this._definirDados();
				}
				else{
					this.byId(ID_PAGINA).setTitle(i18n.getText(TITULO_CADASTRO));
					this.byId(LABEL_ID).setVisible(false);
					this.byId(INPUT_ID).setVisible(false);
				}
            })
        },
		_definirDados: async function () {
			this._modelo(await HttpRequest._request(CAMINHO_PARA_API_GENERO + parametros[POSICAO_ID_DO_GENERO]), NOME_MODELO_GENERO)
		},

		_VerificarCampos: function () {
			let verificacao = true;
			const _nome = this.byId(ID_INPUT_NOME);
			if (_nome.getValue() == "") {
				_nome.setValueState(VALUE_STATE_ERROR);
				_nome.setValueStateText(i18n.getText(VALUE_STATE_NOME_OBRIGATORIO));
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
					if (parametros[POSICAO_CADASTRO_OU_EDITAR] == HASH_EDITAR) {
						await HttpRequest._request(CAMINHO_PARA_API_EDITAR_GENERO, PUT, genero);
						this._sucessoNaRequisicao(i18n.getText(MENSAGEM_SUCESSO_EDITAR));
					}
					else{
						await HttpRequest._request(CAMINHO_PARA_API_ADICIONAR_GENERO, POST, genero);
						this._sucessoNaRequisicao(i18n.getText(MENSAGEM_SUCESSO_CADASTRO));
					}
				}
			})
			
		},

		aoDigitarNoInput: function (oEvent) {
			this._exibirEspera(async () => {
				oEvent.getSource().setValueState(VALUE_STATE_NONE);
			})
			
		},

		_sucessoNaRequisicao: function (msgSucesso) {
			MessageBox.success(msgSucesso, {
				actions: [i18n.getText(OPCAO_VOLTAR_PARA_LISTA_DE_GENEROS)],
				onClose: (sAcao) => {
					if (sAcao === i18n.getText(OPCAO_VOLTAR_PARA_LISTA_DE_GENEROS)) {
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