sap.ui.define([
	"sap/ui/test/opaQunit",
    "./pages/CadastroGenero",
	"./pages/ListaGeneros",
	"./pages/Lista"
], (opaTest) => {
	"use strict";

	QUnit.module("Cadastro gênero");

    
    opaTest("Ao tentar cadastrar um gêneroinvalido deve aparecer uma message box de erro", function(Given, When, Then){
		// Arrangements
		Given.iStartMyApp({
			hash: "genero/cadastro"
		});

		//Actions
        When.onPaginaCadastroGenero.aoDigitarNome("Drama");
		When.onPaginaCadastroGenero.aoClicarEmSalvar();
        
		// Assertions
		Then.onPaginaCadastroGenero.deveAperecerUmaMessageBoxDe("Erro");
		Then.onPaginaCadastroGenero.deveFecharMessageBoxAoApertarEmOk("Fechar");
	});
    opaTest("Ao tentar cadastrar um gênero válido deve aparecer uma message box de êxito", function(Given, When, Then){

		//Actions
        When.onPaginaCadastroGenero.aoDigitarNome("Ninja");
		When.onPaginaCadastroGenero.aoClicarEmSalvar();

		// Assertions
		Then.onPaginaCadastroGenero.deveAperecerUmaMessageBoxDe("Êxito");
		Then.onPaginaCadastroGenero.deveFecharMessageBoxAoApertarEmOk("Voltar a lista de gêneros");

        // Cleanup
		Then.iTeardownMyApp();
	});
	opaTest("Ao clicar em voltar deve navegar para tela anterior", function (Given, When, Then) {
        //Arrangements
        Given.iStartMyApp({
            hash: "genero/cadastro"
        });
        //Actions
        When.onPaginaCadastroGenero.aoClicarEmVoltar();
		// Assertions
        Then.onPaginaCadastroGenero.deveVoltarParaTelaAnterior();

        // Cleanup
		Then.iTeardownMyApp();
        
	});
}
);