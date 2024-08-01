sap.ui.define([
	"sap/ui/test/opaQunit",
	"./pages/Lista"
], (opaTest) => {
	"use strict";

	QUnit.module("Lista de anime");
	
	opaTest("Deve ser capaz de mostrar todos os itens",  function(Given, When, Then) {
		// Arrangements
		Given.iStartMyApp();

		//Actions
		When.onPaginaListaAnime.aoApertarEmMais();

		//Assertions
		Then.onPaginaListaAnime.aListaDeveMostrarTodosAnimes();
	})
	opaTest("Deve ser capaz de pesquisar itens", function(Given, When, Then)  {
		
		//Actions
		When.onPaginaListaAnime.aoPesquisarPorNome("One");

		// Assertions
		Then.onPaginaListaAnime.aListaTemUmAnime();
	});
	opaTest("Deve ser capaz de filtrar itens pela data", function(Given,When, Then) {
		//Arrangements
		When.onPaginaListaAnime.aoPesquisarPorNome("");

		//Actions
		When.onPaginaListaAnime.aoSelecionarData("16/06/2023");

		//Assertions
		Then.onPaginaListaAnime.aListaTemUmAnime();
	});
	opaTest("Deve ser capaz de filtrar itens pelo status", function(Given,When, Then)  {
		//Arrangements
		When.onPaginaListaAnime.aoSelecionarData("");

		//Actions
		When.onPaginaListaAnime.aoClicarNoFiltroStatus();
		When.onPaginaListaAnime.aoSelecionarStatus("Concluído");

		//Assertions
		Then.onPaginaListaAnime.aListaTemDoisAnimes();

	});
	opaTest("Ao clicar no anime deve navegar para tela de detalhes", function (Given, When, Then) {
		//Arrangaments
		When.onPaginaListaAnime.aoClicarNoFiltroStatus();
		When.onPaginaListaAnime.aoSelecionarStatus("Todos");
        //Actions
        When.onPaginaListaAnime.aoClicarEmUmAnime("One Piece");

		// Assertions
		Then.onPaginaDetalhesoAnime.deveNavegarParaTelaDeDetalhes();
		// Cleanup
		Then.iTeardownMyApp();
	});

	opaTest("Ao clicar em cadastrar anime deve navegar para tela de cadastro", function (Given, When, Then) {
		// Arrangements
		Given.iStartMyApp();

        //Actions
        When.onPaginaListaAnime.aoApertarEmAdicionarAnime();

		// Assertions
		Then.onPaginaCadastroAnime.deveNavegarParaTelaDeCadastro();
		// Cleanup
		Then.iTeardownMyApp();
	});
	opaTest("Ao clicar em lista de gêneros deve navegar para tela de lista de gêneros", function (Given, When, Then) {
		// Arrangements
		Given.iStartMyApp();

        //Actions
        When.onPaginaListaAnime.aoApertarEmListaDeGeneros();

		// Assertions
		Then.onPaginaListaGeneros.deveNavegarParaTelaDeListaDeGeneros();

		// Cleanup
		Then.iTeardownMyApp();
	})
});