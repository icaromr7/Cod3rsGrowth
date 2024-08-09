sap.ui.define([
	"sap/ui/test/opaQunit",
    "./pages/DetalhesAnime",
	"./pages/Lista"
], (opaTest,DetalhesAnime, Lista) => {
	"use strict";

	QUnit.module("Detalhes anime");

    opaTest("Deve está na tela de detalhes anime", function (Given, When, Then) {
        Given.iStartMyApp({
            hash: "anime/1"
        });
        
        Then
            .onPaginaDetalhesoAnime
            .aTelaDetalhesAnimeFoiCarregadaCorretamente();
    });

    opaTest("Na tela deve conter as informações corretas do item clicado", function (Given, When, Then) {
        Then
            .onPaginaDetalhesoAnime
            .deveTerOIdDoItemSelecionado("1")
            .deveTerONomeDoItemSelecionado("One Piece")
            .deveTerANotaDoItemSelecionado("10")
            .deveTerADataLancamentoDoItemSelecionado("20/10/1999")
            .deveTerOStatusDeExibicaoDoItemSelecionado("Em Exibição")
            .deveTerASinopseDoItemSelecionado("Bom demais")
            .aListaDeveMostrarTodosOsGenerosDoAnime(2)
		
        Then
            .iTeardownMyApp();
	});
    opaTest("Ao clicar em voltar deve navegar para tela anterior", function (Given, When, Then) {
        When
            .onPaginaDetalhesoAnime
            .aoClicarEmVoltar();
        Then
            .onPaginaDetalhesoAnime
            .DeveSairDaTelaDeDetalhes("Detalhes do Anime");
        
        Then
            .iTeardownMyApp();
    });
}
);