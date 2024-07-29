sap.ui.define([
	"sap/ui/test/opaQunit",
    "./pages/CadastroAnime",
	"./pages/Lista"
], (opaTest) => {
	"use strict";

	QUnit.module("Cadastro anime");

    opaTest("Ao clicar em cadastrar anime deve navegar para tela de cadastro", function (Given, When, Then) {
		// Arrangements
		Given.iStartMyApp();

        //Actions
        When.onPaginaListaAnime.aoApertarEmAdicionarAnime();

		// Assertions
		Then.onPaginaCadastroAnime.deveNavegarParaTelaDeCadastro();
	});
    opaTest("Ao tentar cadastrar um anime invalido deve aparecer uma message box de erro", function(Given, When, Then){

		//Actions
        When.onPaginaCadastroAnime.aoDigitarNome("Teste");
        When.onPaginaCadastroAnime.aoDigitarSinopse("Teste");
        When.onPaginaCadastroAnime.aoDigitarNota(2);
        When.onPaginaCadastroAnime.aoClicarNaLista();
        When.onPaginaCadastroAnime.aoPressionarUmItem();
        When.onPaginaCadastroAnime.aoSelecionarData("20/07/2024");
        When.onPaginaCadastroAnime.aoClicarNoSelectStatus();
        When.onPaginaCadastroAnime.aoSelecionarStatus();
        When.onPaginaCadastroAnime.aoClicarEmSalvar();

		// Assertions
		Then.onPaginaCadastroAnime.deveAperecerUmaMessageBoxDe("Erro");
		// Assertions
		Then.onPaginaCadastroAnime.deveFecharMessageBoxAoApertarEmOk("Fechar");
	});
    opaTest("Ao tentar cadastrar um anime válido deve aparecer uma message box de êxito", function(Given, When, Then){

		//Actions
        When.onPaginaCadastroAnime.aoDigitarNome("Teste");
        When.onPaginaCadastroAnime.aoDigitarSinopse("Teste");
        When.onPaginaCadastroAnime.aoDigitarNota(2);
        When.onPaginaCadastroAnime.aoSelecionarData("20/11/2024");
        When.onPaginaCadastroAnime.aoClicarNoSelectStatus();
        When.onPaginaCadastroAnime.aoSelecionarStatus();
        When.onPaginaCadastroAnime.aoClicarEmSalvar();

		// Assertions
		Then.onPaginaCadastroAnime.deveAperecerUmaMessageBoxDe("Êxito");
		Then.onPaginaCadastroAnime.deveFecharMessageBoxAoApertarEmOk("Voltar a lista de anime");
	});
}
);