sap.ui.define([
	"sap/ui/test/opaQunit",
    "./pages/DetalhesAnime",
	"./pages/Lista"
], (opaTest) => {
	"use strict";

	QUnit.module("Detalhes anime");

    opaTest("Ao clicar em voltar deve navegar para tela anterior", function (Given, When, Then) {
        // Arrangements
        Given.iStartMyApp({
            hash: "anime/1"
        });
        //Actions
        When.onPaginaDetalhesoAnime.aoClicarEmVoltar();
		// Assertions
        Then.onPaginaDetalhesoAnime.deveVoltarParaTelaAnterior();

        // Cleanup
		Then.iTeardownMyApp();
	});
    opaTest("Na tela deve conter as informações corretas do item clicado", function (Given, When, Then) {
        // Arrangements
        Given.iStartMyApp({
            hash: "anime/1"
        });

		// Assertions
        Then.onPaginaDetalhesoAnime.deveTerOIdDoItemSelecionado("1");
		Then.onPaginaDetalhesoAnime.deveTerONomeDoItemSelecionado("One Piece");
        Then.onPaginaDetalhesoAnime.deveTerANotaDoItemSelecionado("10");
        Then.onPaginaDetalhesoAnime.deveTerADataLancamentoDoItemSelecionado("20/10/1999");
        Then.onPaginaDetalhesoAnime.deveTerOStatusDeExibicaoDoItemSelecionado("Em Exibição");
        Then.onPaginaDetalhesoAnime.deveTerASinopseDoItemSelecionado("Bom demais");
        Then.onPaginaDetalhesoAnime.aListaDeveMostrarTodosOsGenerosDoAnime(2);
        // Cleanup
		Then.iTeardownMyApp();
	});
}
);