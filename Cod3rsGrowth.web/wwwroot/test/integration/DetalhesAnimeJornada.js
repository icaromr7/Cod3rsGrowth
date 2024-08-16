sap.ui.define([
	"sap/ui/test/opaQunit",
    "./pages/DetalhesAnime",
    "./pages/Lista",
    "./pages/EditarAnime"
], (opaTest,DetalhesAnime,Lista, EditarAnime) => {
	"use strict";

	QUnit.module("Detalhes anime");

    opaTest("Deve está na tela de detalhes anime", function (Given, When, Then) {
        Given.iStartMyApp({
            hash: "anime/12"
        });
        
        Then
            .onPaginaDetalhesDoAnime
            .aTelaDetalhesAnimeFoiCarregadaCorretamente();
    });

    opaTest("Na tela deve conter as informações corretas do item", function (Given, When, Then) {
        Then
            .onPaginaDetalhesDoAnime
            .deveTerOIdDoItemSelecionado("12")
            .deveTerONomeDoItemSelecionado("Teste")
            .deveTerANotaDoItemSelecionado("2")
            .deveTerADataLancamentoDoItemSelecionado("20/11/2024")
            .deveTerOStatusDeExibicaoDoItemSelecionado("Previsto")
            .deveTerASinopseDoItemSelecionado("Teste")
            .aListaDeveMostrarTodosOsGenerosDoAnime(2)
	});
    opaTest("Ao clicar em editar deve navegar para tela de edição", function (Given, When, Then) {
        When
            .onPaginaDetalhesDoAnime
            .aoClicarEmEditar();
        Then
            .onPaginaEditarAnime
            .aTelaEditarAnimeFoiCarregadaCorretamente();
        Then
            .iTeardownMyApp();
    });
    opaTest("Ao clicar em voltar deve navegar para tela anterior", function (Given, When, Then) {
        Given.iStartMyApp({
            hash: "anime/12"
        });
        When
            .onPaginaDetalhesDoAnime
            .aoClicarEmVoltar();
        Then
            .onPaginaListaAnime
            .aTelaListaDeAnimesFoiCarregadaCorretamente();
        Then
            .iTeardownMyApp();
    });
    opaTest("Ao clicar em não deve fechar a mensagem box", function (Given, When, Then) {
        Given.iStartMyApp({
            hash: "anime/12"
        });
        When
            .onPaginaDetalhesDoAnime
            .aoClicarEmRemover();
        Then
            .onPaginaDetalhesDoAnime
            .deveAperecerUmaMessageBoxDe("Confirmação")
            .deveFecharMessageBoxAoApertarEmOk("Não");
    });
    opaTest("Ao clicar em sim deve fechar a mensagem box", function (Given, When, Then) {       
        When
            .onPaginaDetalhesDoAnime
            .aoClicarEmRemover();
        Then
            .onPaginaDetalhesDoAnime
            .deveAperecerUmaMessageBoxDe("Confirmação")
            .deveFecharMessageBoxAoApertarEmOk("Sim");
        Then
            .iTeardownMyApp();
    });
}
);