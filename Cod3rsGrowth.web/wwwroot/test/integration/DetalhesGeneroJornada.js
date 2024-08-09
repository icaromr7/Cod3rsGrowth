sap.ui.define([
	"sap/ui/test/opaQunit",
    "./pages/DetalhesGenero",
	"./pages/ListaGeneros",
	"./pages/Lista"
], (opaTest) => {
	"use strict";

	QUnit.module("Detalhes gênero");
	opaTest("Ao clicar em voltar deve navegar para tela anterior", function (Given, When, Then) {
		// Arrangements
		Given.iStartMyApp({
			hash: "genero/2"
		});
        //Actions
        When.onPaginaDetalhesGenero.aoClicarEmVoltar();
		// Assertions
        Then.onPaginaDetalhesGenero.deveVoltarParaTelaAnterior();
        // Cleanup
		Then.iTeardownMyApp();
	});
    opaTest("Na tela deve conter as informações corretas do item clicado", function (Given, When, Then) {
		// Arrangements
		Given.iStartMyApp({
			hash: "genero/2"
		});

		// Assertions
        Then.onPaginaDetalhesGenero.deveTerOIdDoItemSelecionado("2");
		Then.onPaginaDetalhesGenero.deveTerONomeDoItemSelecionado("Aventura");
        
	});
}
);