sap.ui.define([
	"sap/ui/test/opaQunit",
	"./pages/Lista"
], (opaTest) => {
	"use strict";

	QUnit.module("Navigation");
	
	opaTest("Deve ser capaz de mostrar todos os itens", (Given, When, Then) => {
		// Arrangements
		Given.iStartMyUIComponent({
			componentConfig: {
				name: "ui5.anime"
			}
		});

		//Actions
		When.onPaginaListaAnime.aoApertarEmMais();

		//Assertions
		Then.onPaginaListaAnime.aListaDeveMostrarTodosAnimes();
	})
	opaTest("Deve ser capaz de pesquisar itens", (Given, When, Then) => {
		
		//Actions
		When.onPaginaListaAnime.aoPesquisarPorNome("One");

		// Assertions
		Then.onPaginaListaAnime.aListaTemUmAnime();
	});
	opaTest("Deve ser capaz de filtrar itens pela data", (Given,When, Then) =>{
		//Arrangements
		When.onPaginaListaAnime.aoPesquisarPorNome("");

		//Actions
		When.onPaginaListaAnime.aoSelecionarData("16/06/2023");

		//Assertions
		Then.onPaginaListaAnime.aListaTemUmAnime();
	});
	opaTest("Deve ser capaz de filtrar itens pelo status", (Given,When, Then) => {
		//Arrangements
		When.onPaginaListaAnime.aoSelecionarData("");

		//Actions
		When.onPaginaListaAnime.aoClicarNoFiltroStatus();
		When.onPaginaListaAnime.aoSelecionarStatus();

		//Assertions
		Then.onPaginaListaAnime.aListaTemDoisAnimes();

		// Cleanup
		Then.iTeardownMyApp();
	});
	
});