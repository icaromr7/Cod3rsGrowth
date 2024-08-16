sap.ui.define([
	"sap/ui/test/opaQunit",
    "./pages/EditarAnime",
    "./pages/Lista"
], (opaTest,EditarAnime,Lista) => {
	"use strict";

	QUnit.module("Editar anime");

    opaTest("Deve está na tela de editar anime", function (Given, When, Then) {
        Given.iStartMyApp({
            hash: "anime/editar/1"
        });
        
        Then
            .onPaginaEditarAnime
            .aTelaEditarAnimeFoiCarregadaCorretamente();
    });
    opaTest("Na tela deve conter ao id correto do item", function (Given, When, Then) {
        Then
            .onPaginaEditarAnime
            .deveTerOIdDoItemSelecionado("1")
	});
    opaTest("Ao tentar editar um anime invalido deve aparecer uma message box de erro", function (Given, When, Then) {
        When
            .onPaginaEditarAnime
            .aoDigitarNome("Teste")
            .aoDigitarSinopse("Teste")
            .aoDigitarNota(2)
            .aoClicarNaLista()
            .aoPressionarUmItem("Aventura")
            .aoSelecionarData("20/07/2024")
            .aoClicarNoSelectStatus()
            .aoSelecionarStatus("Previsto")
            .aoClicarEmSalvar();    
        Then
            .onPaginaEditarAnime
            .deveAperecerUmaMessageBoxDe("Erro")
            .deveFecharMessageBoxAoApertarEmOk("Fechar");
    });
    opaTest("Ao tentar editar um anime válido deve aparecer uma message box de êxito", function (Given, When, Then) {
        When
            .onPaginaEditarAnime
            .aoDigitarNome("One Piece")
            .aoDigitarSinopse("Bom demais")
            .aoDigitarNota(10)
            .aoClicarNaLista()
            .aoPressionarUmItem("Aventura")
            .aoSelecionarData("20/10/1999")
            .aoClicarNoSelectStatus()
            .aoSelecionarStatus("Em Exibição")
            .aoClicarEmSalvar();
        Then
            .onPaginaEditarAnime
            .deveAperecerUmaMessageBoxDe("Êxito")
            .deveFecharMessageBoxAoApertarEmOk("Voltar a lista de anime");
    });
}
);