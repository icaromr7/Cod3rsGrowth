sap.ui.define([
	"sap/ui/test/opaQunit",
    "./pages/DetalhesGenero",
	"./pages/ListaGeneros",
	"./pages/Lista"
], (opaTest) => {
	"use strict";

	QUnit.module("Detalhes gênero");
	opaTest("Deve está na tela de detalhes gênero", function (Given, When, Then) {
        Given.iStartMyApp({
			hash: "genero/2"
		});

        Then
            .onPaginaDetalhesGenero
            .aTelaDetalhesGeneroFoiCarregadaCorretamente();
    });
    opaTest("Na tela deve conter as informações corretas do item clicado", function (Given, When, Then) {
		
        Then
			.onPaginaDetalhesGenero
			.deveTerOIdDoItemSelecionado("2")
			.deveTerONomeDoItemSelecionado("Aventura");
        
	});
	opaTest("Ao clicar em voltar deve navegar para tela anterior", function (Given, When, Then) {
        When
            .onPaginaDetalhesGenero
            .aoClicarEmVoltar();
        Then
            .onPaginaDetalhesGenero
            .DeveSairDaTelaDeDetalhes("Detalhes do Gênero");
        
        Then
            .iTeardownMyApp();
    });
}
);