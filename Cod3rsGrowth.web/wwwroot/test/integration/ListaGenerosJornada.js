sap.ui.define([
	"sap/ui/test/opaQunit",
	"./pages/Lista",
	"./pages/ListaGeneros"
], (opaTest) => {
	"use strict";

	QUnit.module("Lista de gêneros");

    opaTest("Ao clicar em lista de gêneros deve navegar para tela de lista de gêneros", function (Given, When, Then) {
		// Arrangements
		Given.iStartMyApp();

        //Actions
        When.onPaginaListaAnime.aoApertarEmListaDeGeneros();

		// Assertions
		Then.onPaginaListaGeneros.deveNavegarParaTelaDeListaDeGeneros();
	})
	
	opaTest("Deve ser capaz de mostrar todos os itens",  function(Given, When, Then) {
		//Actions
		When.onPaginaListaGeneros.aoApertarEmMais();

		//Assertions
		Then.onPaginaListaGeneros.aListaDeveMostrarMaisGeneros();
	})
	opaTest("Deve ser capaz de pesquisar itens", function(Given, When, Then)  {
		
		//Actions
		When.onPaginaListaGeneros.aoPesquisarPorNome("Av");

		// Assertions
		Then.onPaginaListaGeneros.aListaTemUmGenero();

		// Cleanup
		Then.iTeardownMyApp();
	});
	
	
});