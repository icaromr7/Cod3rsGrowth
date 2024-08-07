sap.ui.define([
	"sap/ui/test/opaQunit",
    "./pages/CadastroAnime",
	"./pages/Lista"
], (opaTest) => {
	"use strict";

	QUnit.module("Cadastro anime");

    opaTest("Ao tentar cadastrar um anime invalido deve aparecer uma message box de erro", function(Given, When, Then){
        //Arrangements
        Given.iStartMyApp({
            hash: "cadastro"
        });

		//Actions
        When.onPaginaCadastroAnime.aoDigitarNome("Teste");
        When.onPaginaCadastroAnime.aoDigitarSinopse("Teste");
        When.onPaginaCadastroAnime.aoDigitarNota(2);
        When.onPaginaCadastroAnime.aoClicarNaLista();
        When.onPaginaCadastroAnime.aoPressionarUmItem("Aventura");
        When.onPaginaCadastroAnime.aoSelecionarData("20/07/2024");
        When.onPaginaCadastroAnime.aoClicarNoSelectStatus();
        When.onPaginaCadastroAnime.aoSelecionarStatus("Previsto");
        When.onPaginaCadastroAnime.aoClicarEmSalvar();

		// Assertions
		Then.onPaginaCadastroAnime.deveAperecerUmaMessageBoxDe("Erro");
		Then.onPaginaCadastroAnime.deveFecharMessageBoxAoApertarEmOk("Fechar");
	});
    opaTest("Ao tentar cadastrar um anime válido deve aparecer uma message box de êxito", function(Given, When, Then){

		//Actions
        When.onPaginaCadastroAnime.aoDigitarNome("Teste");
        When.onPaginaCadastroAnime.aoDigitarSinopse("Teste");
        When.onPaginaCadastroAnime.aoDigitarNota(2);
        When.onPaginaCadastroAnime.aoClicarNaLista();
        When.onPaginaCadastroAnime.aoPressionarUmItem("Drama");
        When.onPaginaCadastroAnime.aoSelecionarData("20/11/2024");
        When.onPaginaCadastroAnime.aoClicarNoSelectStatus();
        When.onPaginaCadastroAnime.aoSelecionarStatus("Previsto");
        When.onPaginaCadastroAnime.aoClicarEmSalvar();

		// Assertions
		Then.onPaginaCadastroAnime.deveAperecerUmaMessageBoxDe("Êxito");
		Then.onPaginaCadastroAnime.deveFecharMessageBoxAoApertarEmOk("Voltar a lista de anime");

        // Cleanup
		Then.iTeardownMyApp();

	});
    opaTest("Ao clicar em voltar deve navegar para tela anterior", function (Given, When, Then) {
        //Arrangements
        Given.iStartMyApp({
            hash: "cadastro"
        });
        //Actions
        When.onPaginaCadastroAnime.aoClicarEmVoltar();
		// Assertions
        Then.onPaginaCadastroAnime.deveVoltarParaTelaAnterior();

        // Cleanup
		Then.iTeardownMyApp();
        
	});
}
);