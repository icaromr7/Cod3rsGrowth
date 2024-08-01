sap.ui.define([
	"sap/ui/test/opaQunit",
    "./pages/DetalhesGenero",
	"./pages/ListaGeneros"
], (opaTest) => {
	"use strict";

	QUnit.module("Detalhes gênero");

    opaTest("Na tela deve conter as informações corretas do item clicado", function (Given, When, Then) {
		// Arrangements
		Given.iStartMyApp({
			hash: "genero/33"
		});

		// Assertions
        Then.onPaginaDetalhesGenero.deveTerOIdDoItemSelecionado("33");
		Then.onPaginaDetalhesGenero.deveTerONomeDoItemSelecionado("Aventura");
        
	});
    opaTest("Ao clicar em voltar deve navegar para tela de lista", function (Given, When, Then) {

        //Actions
        When.onPaginaDetalhesGenero.aoClicarEmVoltar();
		// Assertions
        Then.onPaginaListaGeneros.deveNavegarParaTelaDeListaDeGeneros();

		// Cleanup
		Then.iTeardownMyApp();
        
	});   
}
);