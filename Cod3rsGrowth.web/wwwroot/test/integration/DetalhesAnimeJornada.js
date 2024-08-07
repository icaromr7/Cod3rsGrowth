sap.ui.define([
	"sap/ui/test/opaQunit",
    "./pages/DetalhesAnime",
	"./pages/Lista"
], (opaTest) => {
	"use strict";

	QUnit.module("Detalhes anime");

    opaTest("Na tela deve conter as informações corretas do item clicado", function (Given, When, Then) {
        // Arrangements
        Given.iStartMyApp({
            hash: "anime/7"
        });

		// Assertions
        Then.onPaginaDetalhesoAnime.deveTerOIdDoItemSelecionado("7");
		Then.onPaginaDetalhesoAnime.deveTerONomeDoItemSelecionado("One Piece");
        Then.onPaginaDetalhesoAnime.deveTerANotaDoItemSelecionado("10");
        Then.onPaginaDetalhesoAnime.deveTerADataLancamentoDoItemSelecionado("20/10/1999");
        Then.onPaginaDetalhesoAnime.deveTerOStatusDeExibicaoDoItemSelecionado("Em Exibição");
        Then.onPaginaDetalhesoAnime.deveTerASinopseDoItemSelecionado("Bom demais");
        Then.onPaginaDetalhesoAnime.aListaDeveMostrarTodosOsGenerosDoAnime(2);
	});
    opaTest("Ao clicar em voltar deve navegar para tela anterior", function (Given, When, Then) {
        
        //Actions
        When.onPaginaDetalhesoAnime.aoClicarEmVoltar();
		// Assertions
        Then.onPaginaDetalhesoAnime.deveVoltarParaTelaAnterior();

        // Cleanup
		Then.iTeardownMyApp();
        
	});  
}
);