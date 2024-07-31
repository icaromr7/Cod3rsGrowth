sap.ui.define([
	"sap/ui/test/opaQunit",
    "./pages/DetalhesGenero",
	"./pages/ListaGeneros"
], (opaTest) => {
	"use strict";

	QUnit.module("Detalhes gênero");

    opaTest("Ao clicar no gênero deve navegar para tela de detalhes", function (Given, When, Then) {
		// Arrangements
		Given.iStartMyApp();

        //Actions
		When.onPaginaListaAnime.aoApertarEmListaDeGeneros();
        When.onPaginaListaGeneros.aoClicarEmUmGenero("Aventura");

		// Assertions
		Then.onPaginaDetalhesGenero.deveNavegarParaTelaDeDetalhes();
	});
    opaTest("Na tela deve conter as informações corretas do item clicado", function (Given, When, Then) {

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