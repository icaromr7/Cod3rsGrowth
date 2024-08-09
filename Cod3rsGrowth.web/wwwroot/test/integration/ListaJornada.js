sap.ui.define([
	"sap/ui/test/opaQunit",
	"./pages/Lista"
], (opaTest) => {
	"use strict";

	QUnit.module("Lista de anime");
	opaTest("Deve está na tela lista de anime", function (Given, When, Then) {
        Given.iStartMyApp();
        
        Then
            .onPaginaListaGeneros
            .aTelaListaDeGenerosFoiCarregadaCorretamente();
    });
	opaTest("Deve ser capaz de mostrar todos os itens",  function(Given, When, Then) {
		When
			.onPaginaListaAnime
			.aoApertarEmMais();
		Then
			.onPaginaListaAnime
			.aListaDeveMostrarTodosAnimes();
	})
	opaTest("Deve ser capaz de pesquisar itens", function(Given, When, Then)  {
		When
			.onPaginaListaAnime
			.aoPesquisarPorNome("One");
		Then
			.onPaginaListaAnime
			.aListaTemUmAnime();
	});
	opaTest("Deve ser capaz de filtrar itens pela data", function(Given,When, Then) {
		When
			.onPaginaListaAnime
			.aoPesquisarPorNome("")
			.aoSelecionarData("16/06/2023");
		Then
			.onPaginaListaAnime
			.aListaTemUmAnime();
	});
	opaTest("Deve ser capaz de filtrar itens pelo status", function(Given,When, Then)  {
		When
			.onPaginaListaAnime
			.aoSelecionarData("")
			.aoClicarNoFiltroStatus()
			.aoSelecionarStatus("Concluído");
		Then
			.onPaginaListaAnime
			.aListaTemDoisAnimes();
	});
	opaTest("Ao clicar no anime deve navegar para tela de detalhes", function (Given, When, Then) {
		When
			.onPaginaListaAnime
			.aoClicarNoFiltroStatus()
			.aoSelecionarStatus("Todos")
			.aoClicarEmUmAnime("One Piece");
		Then
			.onPaginaDetalhesoAnime
			.deveTerADataLancamentoDoItemSelecionado();
		When
			.onPaginaDetalhesoAnime
			.aoClicarEmVoltar();
	});
	opaTest("Ao clicar em cadastrar anime deve navegar para tela de cadastro", function (Given, When, Then) {
        When
			.onPaginaListaAnime
			.aoApertarEmAdicionarAnime();
		Then
			.onPaginaCadastroAnime
			.aTelaCadastroAnimeFoiCarregadaCorretamente();
		When
			.onPaginaCadastroAnime
			.aoClicarEmVoltar();
	});
	opaTest("Ao clicar em lista de gêneros deve navegar para tela de lista de gêneros", function (Given, When, Then) {
		When
			.onPaginaListaAnime
			.aoApertarEmListaDeGeneros();
		Then
			.onPaginaListaGeneros
			.aTelaListaDeGenerosFoiCarregadaCorretamente();
		When
			.onPaginaListaGeneros
			.aoClicarEmVoltar();

		Then.iTeardownMyApp();
	})
});